using System;
using System.Threading.Tasks;
using System.Linq;
using System.Security.Claims;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Sigesp.Application.Interfaces;
using Sigesp.Application.ViewModels;
using Sigesp.WebUI.Controllers;
using Sigesp.Infra.Data.Context;
using Sigesp.Domain.Models;
using Sigesp.Domain.Interfaces;
using Sigesp.Domain.Enums;
using Sigesp.Application.ViewModels.Requests;
using Sigesp.Domain.Models.DataTable;
using Sigesp.Infra.Data.Extensions.DataTable;
using Sigesp.WebUI.Helpers;
using Sigesp.Domain.Hubs;
using Microsoft.AspNetCore.SignalR;

namespace Sigesp.WebUI.EndPoints
{
    [ApiController]
    [Route("api/servidores-estado-reforcos")]
    public class ServidorEstadoReforcoEndPoint : ApiController
    {
        private readonly SigespDbContext _context;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IServidorEstadoReforcoAppService _serManager;
        private readonly ITenantRepository _tenantRepository;
        private readonly IHubContext<NotificationHub> _canalDeNotificacao;

        public ServidorEstadoReforcoEndPoint(SigespDbContext context,
                                             IUnitOfWork unitOfWork,
                                             IMapper mapper,
                                             IServidorEstadoReforcoAppService serManager,
                                             ITenantRepository tenantRepository,
                                             IHubContext<NotificationHub> canalDeNotificacao)
        {
            _context = context;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _serManager = serManager;
            _tenantRepository = tenantRepository;
            _canalDeNotificacao = canalDeNotificacao;
        }

        [Authorize(Roles = "Master, Servidor-Estado-Reforco_List")]
        [Route("list-with-unavailable-dates/{month}")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ListWithUnavailableDatesAsync([FromRoute] string month)
        {
            #region Required validations
            if (string.IsNullOrEmpty(month)) return StatusCode(400, "M??s requerido.");
            #endregion

            #region User resolve
            String userId;
            try
            {
                if (HttpContext.User == null) throw new Exception("Problemas ao obter usu??rio logado."+"\nSaia e entre no sistema novamente, persistindo o problema informe a equipe t??cnica.");
                userId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            }
            catch (Exception ex) { return StatusCode(404, ex.Message); }
            if (string.IsNullOrEmpty(userId)) throw new Exception("Usu??rio n??o encontrado.");
            #endregion

            #region Servidor Estado resolve
            var se = new ServidorEstado();
            try
            {
                se = await _context
                             .ServidoresEstado
                                .Include(x => x.Tenant)
                                .Where(x => x.UserId == userId)
                                .FirstOrDefaultAsync();
            }
            catch (Exception ex) { return StatusCode(404, ex.Message); }
            if (se == null) throw new Exception("Servidor Estado n??o encontrado com o ID usu??rio fornecido.");
            #endregion

            #region Month and Year resolve
            var reforcosMonth = (int) Enum.Parse<MonthOfYearEnum>(month);
            var reforcosMonthEnum = Enum.Parse<MonthOfYearEnum>(month);
            #endregion

            #region Get all refor??os
            IEnumerable<ServidorEstadoReforco> pureResult = new List<ServidorEstadoReforco>();
            try
            {
                pureResult = await _context
                                    .ServidoresEstadoReforcos
                                    .Include(x => x.ServidorEstado)
                                    .Where(x => x.ServidorEstado.Tenant.Id == se.Tenant.Id &&
                                           x.MesNumeral == (int) reforcosMonth &&
                                           x.IsExpediente == se.IsExpediente)
                                    .ToListAsync();
            }
            catch (Exception ex) { return StatusCode(400, ex.Message); }
            #endregion

            #region Map
            // filter data to meus refor??os
            IEnumerable<ServidorEstadoReforco> meusReforcos = new List<ServidorEstadoReforco>();
            try
            {
                meusReforcos = pureResult
                                    .Where(x => x.ServidorEstado.Id == se.Id)
                                    .ToList();
            }
            catch (Exception ex) { return StatusCode(400, ex.Message); }

            #region Refor??o rules resolve
            var reforcoRules = new ServidorEstadoReforcoRegra();
            
            try
            {
                reforcoRules = await _context
                                        .ServidorEstadoReforcoRegras
                                        .Include(x => x.VagasPorDia)
                                        .Where(x => x.MesRegra == reforcosMonthEnum)
                                        .FirstOrDefaultAsync();
            }
            catch (Exception ex) { return StatusCode(404, ex.Message); }
            if (se == null) throw new Exception("Servidor Estado n??o encontrado com o ID usu??rio fornecido.");
            #endregion

            // filter data is not meus refor??os
            var datasIndisponiveis = new List<DateTime>();
            int daysOfMonthReforco = DateTime.DaysInMonth(DateTime.Now.AddMonths(1).Year, reforcosMonth);
            try
            {
                for (var i = 1; daysOfMonthReforco >= i; i++)
                {
                    int reforcosDia = pureResult.Where(x => x.DataPrevistaInicio.Day == i && x.ServidorEstado.Id != se.Id).Count();
                    var regrasDia = se.IsExpediente ? reforcoRules.VagasPorDia.FirstOrDefault(x => x.Dia == i.ToString() && x.Turno == TurnoEnum.NOTURNO) : reforcoRules.VagasPorDia.FirstOrDefault(x => x.Dia == i.ToString() && x.Turno == TurnoEnum.DIURNO);
                    
                    var isDisponivel = ServidorEstadoReforcoHelpers.IsDisponivelDia(reforcosDia, regrasDia);
                    if (!isDisponivel)
                    {
                        var dataIndisponivel = new DateTime(DateTime.Now.AddMonths(1).Year, reforcosMonth, i);
                        datasIndisponiveis.Add(dataIndisponivel);
                    }
                }
            }
            catch (Exception ex) { return StatusCode(400, ex.Message); }

            var result = new ServidorEstadoReforcoEventoViewModel();
            result.Eventos = new List<EventFullCalendar>();
            try
            {
                // map meus refor??os
                foreach (var item in meusReforcos)
                {
                    var tmp = new EventFullCalendar()
                    {
                        AllDay = true,
                        Title = "MR",
                        Start = item.DataPrevistaInicio.ToString("yyyy-MM-dd"),
                        End = item.DataPrevistaInicio.ToString("yyyy-MM-dd"),
                        Description = "Meu refor??o do m??s",
                        ClassName = "bg-info border-info"
                    };
                    result.Eventos.Add(tmp);
                }

                // map unavailables dates
                foreach (var item in datasIndisponiveis)
                {
                    //check to unavailable
                    var tmp = new EventFullCalendar()
                    {
                        AllDay = true,
                        Title = "IND",
                        Start = item.ToString("yyyy-MM-dd"),
                        End = item.ToString("yyyy-MM-dd"),
                        Description = "Data indispon??vel",
                        ClassName = "bg-danger border-danger"
                    };
                    result.Eventos.Add(tmp);
                }
            }
            catch (Exception ex) { return StatusCode(400, ex.Message); }
            #endregion

            return Ok(result);
        }

        [Authorize(Roles = "Master, Servidor-Estado-Reforco_List")]
        [Route("list-me")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ListMeAsync([FromForm] DataTableServerSideRequest request)
        {
            #region User resolve
            String userId;
            try
            {
                if (HttpContext.User == null) throw new Exception("Problemas ao obter usu??rio logado."+"\nSaia e entre no sistema novamente, persistindo o problema informe a equipe t??cnica.");
                userId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            }
            catch (Exception ex) { return StatusCode(404, ex.Message); }
            if (string.IsNullOrEmpty(userId)) throw new Exception("Usu??rio n??o encontrado.");
            #endregion

            #region Servidor Estado resolve
            var se = new ServidorEstado();
            try
            {
                se = await _context
                             .ServidoresEstado
                                .Include(x => x.Tenant)
                                .Where(x => x.UserId == userId)
                                .FirstOrDefaultAsync();
            }
            catch (Exception ex) { return StatusCode(404, ex.Message); }
            if (se == null) throw new Exception("Servidor Estado n??o encontrado com o ID usu??rio fornecido.");
            #endregion

            #region Get data
            var reforcosMe = new DataTableServerSideResult<ServidorEstadoReforco>();
            try
            {
                reforcosMe = await _context
                                    .ServidoresEstadoReforcos
                                    .Where(x => x.ServidorEstadoId == se.Id)
                                    .GetDatatableResultAsync(request);  
            }
            catch (Exception ex) { return StatusCode(400, ex.Message); }
            #endregion

            #region Map
            IEnumerable<ServidorEstadoReforcoViewModel> reforcosMeMapped = new List<ServidorEstadoReforcoViewModel>();
            try
            {
                reforcosMeMapped = _mapper.Map<IEnumerable<ServidorEstadoReforcoViewModel>>(reforcosMe.Data);
            }
            catch (Exception ex) { return StatusCode(400, ex.Message); }
            
            var data = new {
                data = reforcosMeMapped
            };
        
            return Ok(new {
                Data = data,
                Draw = reforcosMe.Draw,
                RecordsFiltered  = reforcosMe._iRecordsDisplay,
                RecordsTotal = reforcosMe._iRecordsTotal,
                Success = true
            });
            #endregion
        }

        [Authorize(Roles = "Master, Servidor-Estado-Reforco_Create")]
        [Route("create")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> CreateAsync([FromBody] ServidorEstadoReforcoViewModel
                                                                servidorEstadoReforcoViewModel)
        {
            #region User resolve
            String userId;
            try
            {
                if (HttpContext.User == null) throw new Exception("Problemas ao obter usu??rio logado. Saia e entre no sistema novamente, persistindo o problema informe a equipe t??cnica.");
                userId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

                if (string.IsNullOrEmpty(userId)) throw new Exception("Usu??rio n??o encontrado.");
            }
            catch (Exception ex) { return StatusCode(404, ex.Message); }
            #endregion

            #region Map logged in user
            try
            {
                servidorEstadoReforcoViewModel.UserId = userId;
            }
            catch (Exception ex) { return StatusCode(500, ex.Message); }
            #endregion

            int result;
            try
            {
                result = await _serManager.CreateAsync(servidorEstadoReforcoViewModel);
            }
            catch (Exception ex) { return StatusCode(400, ex.Message); }
            return Ok(result);
        }

        [Authorize(Roles = "Master, Servidor-Estado-Reforco_Delete")]
        [Route("delete")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteAsync([FromBody] string deleteType)
        {
            #region Required validations
            if (string.IsNullOrEmpty(deleteType))
                throw new ArgumentException("O tipo de delete ?? requerido.");
            #endregion

            #region User resolve
            String userId;
            try
            {
                if (HttpContext.User == null) throw new Exception("Problemas ao obter usu??rio logado. Saia e entre no sistema novamente, persistindo o problema informe a equipe t??cnica.");
                userId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

                if (string.IsNullOrEmpty(userId)) throw new Exception("Usu??rio n??o encontrado.");
            }
            catch (Exception ex) { return StatusCode(404, ex.Message); }
            #endregion

            #region Tenant resolve
            Guid tenantId;
            try
            {
                tenantId = (Guid) StringHelpers.ExtractTenantId(await _tenantRepository.GetTenantIdAsync());
            }
            catch (Exception ex) { return StatusCode(404, ex.Message); }
            if (tenantId == Guid.Empty) throw new Exception("Problemas ao obter a UNIDADE do usu??rio logado. Tente novamente, persistindo o problema informe a equipe t??cnica do sistema.");
            #endregion

            #region CommandSend
            var result = new List<ServidorEstadoReforcoViewModel>();
            try
            {
                result = await _serManager.DeleteOnDemandAsync(userId, deleteType);
            }
            catch (Exception ex) { return StatusCode(500, ex.Message); }
            #endregion

            if (result.Count() == 0) return StatusCode(500, "Problemas ao tentar excluir o (s) refor??o (s). Tente novamente, persistindo o problema informe a equipe t??cnica do sistema.");
            
            #region Notification resolve
            var notification = new ApplicationNotification();
            foreach (var reforco in result)
            {
                notification.Id = Guid.NewGuid();
                // create object notification
                notification.Scope = NotificationScopeTypeEnum.APPLICATION;
                notification.MessageTitle = "Meu Refor??o";
                var turno = reforco.IsExpediente ? "NOTURNO" : "DIURNO";
                notification.MessageBody = $"Disponibilizada nova vaga de REFOR??O {turno} para {reforco.DataPrincipalPlantao}";
                notification.MessageDate = DateTime.Now;
                notification.MessageLabel = "+VAGAS";
                notification.MessageLabelColor = "success";
                notification.TenantId = tenantId;

                //  map notification
                var notificationVM = new ApplicationNotificationViewModel();
                try
                {
                    notificationVM = _mapper.Map<ApplicationNotificationViewModel>(notification);
                }
                catch (Exception ex) { return StatusCode(500, ex.Message); }

                try
                {
                    await _canalDeNotificacao.Clients.All.SendAsync("MeuReforcoChannel", notificationVM).ConfigureAwait(false);
                    _context.ApplicationNotifications.Add(notification);
                    _unitOfWork.Commit();
                }
                catch (Exception ex) { return StatusCode(500, ex.Message); }
            }
            #endregion

            return Ok(result);
        }

        [Authorize(Roles = "Master, Servidor-Estado-Reforco_Delete")]
        [Route("delete-by-data")]
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteByDateAsync([FromBody] GenericRequestViewModel genericRequestViewModel)
        {
            #region Required validations
            if (string.IsNullOrEmpty(genericRequestViewModel.Date))
                return StatusCode(400, "A data ?? requerida.");
            #endregion

            #region User resolve
            String userId;
            try
            {
                if (HttpContext.User == null) throw new Exception("Problemas ao obter usu??rio logado. Saia e entre no sistema novamente, persistindo o problema informe a equipe t??cnica.");
                userId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            }
            catch (Exception ex) { return StatusCode(404, ex.Message); }
            if (string.IsNullOrEmpty(userId)) return StatusCode(404, "Usu??rio n??o encontrado.");
            #endregion

            #region Servidor resolve
            var servidorEstado = new ServidorEstado();
            try
            {
                servidorEstado = await _context
                                            .ServidoresEstado
                                            .Include(x => x.ApplicationUser)
                                            .Where(x => x.UserId == userId)
                                            .FirstOrDefaultAsync();
            }
            catch (Exception ex) { return StatusCode(404, ex.Message); }
            if (servidorEstado == null) return StatusCode(404, "Servidor do estado n??o encontrado.");
            #endregion

            #region Date resolve to search refor??o
            DateTime dateOfReforcoToDelete;
            try
            {
                DateTime.TryParse(genericRequestViewModel.Date, out dateOfReforcoToDelete);
            }
            catch (Exception ex) { return StatusCode(404, ex.Message); }
            if (dateOfReforcoToDelete == new DateTime(01,01,0001,00,00,00))
                return StatusCode(400, "Problemas ao converter a data informada do refor??o. Tente novamente, persistindo o problema informe a equipe t??cnica do sistema.");
            #endregion

            #region Data resolve
            var reforco = new ServidorEstadoReforco();
            try
            {
                reforco = await _context
                                    .ServidoresEstadoReforcos
                                    .FirstOrDefaultAsync(x => x.DataPrevistaInicio.Date.Equals(dateOfReforcoToDelete) &&
                                                         x.ServidorEstadoId == servidorEstado.Id);
            }
            catch (Exception ex) { return StatusCode(404, ex.Message); }
            if (reforco == null) return StatusCode(404, "Nenhum refor??o encontrado com a data informada para exclus??o. \nTente outra data.");
            #endregion

            #region Delete
            try
            {
                _context
                    .ServidoresEstadoReforcos
                    .Remove(reforco);
            }
            catch (Exception ex) { return StatusCode(500, ex.Message); }
            #endregion

            #region Tenant resolve
            Guid tenantId;
            try
            {
                tenantId = (Guid) StringHelpers.ExtractTenantId(await _tenantRepository.GetTenantIdAsync());
            }
            catch (Exception ex) { return StatusCode(404, ex.Message); }
            if (tenantId == Guid.Empty) throw new Exception("Problemas ao obter a UNIDADE do usu??rio logado. Tente novamente, persistindo o problema informe a equipe t??cnica do sistema.");
            #endregion

            #region Notification resolve
            var notification = new ApplicationNotification();
            // create object notification
            notification.Scope = NotificationScopeTypeEnum.APPLICATION;
            notification.MessageTitle = "Meu Refor??o";
            var turno = reforco.IsExpediente ? "NOTURNO" : "DIURNO";
            notification.MessageBody = $"Disponibilizada nova vaga de REFOR??O {turno} para {reforco.DataPrevistaInicio.ToString("dd/MM/yyyy")}";
            notification.MessageDate = DateTime.Now;
            notification.MessageLabel = "+VAGAS";
            notification.MessageLabelColor = "success";
            notification.TenantId = tenantId;

            //  map notification
            var notificationVM = new ApplicationNotificationViewModel();
            try
            {
                notificationVM = _mapper.Map<ApplicationNotificationViewModel>(notification);
            }
            catch (Exception ex) { return StatusCode(500, ex.Message); }

            try
            {
                await _canalDeNotificacao.Clients.All.SendAsync("MeuReforcoChannel", notificationVM).ConfigureAwait(false);
                await _context.ApplicationNotifications.AddAsync(notification);
            }
            catch (Exception ex) { return StatusCode(500, ex.Message); }
            #endregion

            #region Commit
            _unitOfWork.Commit();
            #endregion
            
            return StatusCode(204);
        }
    }
}