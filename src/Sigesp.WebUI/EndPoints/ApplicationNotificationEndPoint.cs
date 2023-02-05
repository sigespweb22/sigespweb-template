using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sigesp.Application.ViewModels;
using Sigesp.WebUI.Controllers;
using Microsoft.AspNetCore.Authorization;
using AutoMapper;
using Sigesp.Infra.Data.Context;
using Sigesp.Domain.Interfaces;
using Sigesp.Domain.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Sigesp.Domain.Enums;
using Sigesp.Infra.Data.Extensions;

namespace Sigesp.WebUI.EndPoints
{
    [Authorize(Roles = "Master, Notification_Novo,"+
                       "Notification_Edicao, Notification_Delete,"+
                       "Notification_Lista")]
    [ApiController]
    [Route("api/notifications")]
    public class ApplicationNotificationEndPoint : ApiController
    {
        private readonly SigespDbContext _context;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITenantRepository _tenantRepository;

        public ApplicationNotificationEndPoint(SigespDbContext context,
                                               IMapper mapper, IUnitOfWork unitOfWork,
                                               ITenantRepository tenantRepository)
        {
            _context = context;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _tenantRepository = tenantRepository;
        }

        #region Methods CRUD
        [Authorize(Roles = "Master, Notification_Novo")]
        [Route("novo")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> NovoAsync([FromBody]ApplicationNotificationViewModel anVM)
        {
            #region Map
            var notification = new ApplicationNotification();
            try
            {
                notification = _mapper.Map<ApplicationNotification>(anVM);
            }
            catch (Exception ex) { AddError(ex.Message); return CustomResponse(500); }
            #endregion

            #region Persitence
            var commandSend  = await _context.ApplicationNotifications.AddAsync(notification);
            _unitOfWork.Commit();
            #endregion

            return StatusCode(201);
        }

        [Authorize(Roles = "Master, Notification_Edicao")]
        [Route("edicao")]
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> EdicaoAsync([FromBody]ApplicationNotificationViewModel anVM)
        {
            #region Map
            var notification = new ApplicationNotification();
            try
            {
                notification = _mapper.Map<ApplicationNotification>(anVM);
            }
            catch (Exception ex) { AddError(ex.Message); return CustomResponse(500); }
            #endregion

            #region Persitence
            _context.ApplicationNotifications.Update(notification);
            await _unitOfWork.CommitAsync();
            #endregion

            return StatusCode(204);
        }

        [Authorize(Roles = "Master, Notification_Delete")]
        [Route("delete/{id}")]
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteAsync([FromRoute]string id)
        {
            #region Validation required
            if (string.IsNullOrEmpty(id)) return StatusCode(400, "Id requerido.");
            #endregion

            #region User resolve
            String userId;
            try
            {
                if (HttpContext.User == null) throw new Exception("Problemas ao obter usuário logado. Saia e entre no sistema novamente, persistindo o problema informe a equipe técnica.");
                userId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            }
            catch (Exception ex) { AddError(ex.Message); return StatusCode(500); }
            if (string.IsNullOrEmpty(userId)) throw new Exception("Usuário não encontrado.");
            #endregion

            #region Get data
            var an = new ApplicationNotification();
            try
            {
                an = await _context
                                .ApplicationNotifications
                                .FirstOrDefaultAsync(x => x.Id == Guid.Parse(id));
            }
            catch (Exception ex) { AddError(ex.Message); return StatusCode(500); }
            if (an == null) return StatusCode(404, "Não encontrado.");
            #endregion

            #region Owner validation
            if (string.IsNullOrEmpty(an.UserId) || an.UserId != userId) return StatusCode(400, "Você só pode marcar como lida as suas notificações. <br>Notificações globais são disponíveis a todos os usuários do sistema por um tempo determinado.");
            #endregion

            #region Persistance
            _context.ApplicationNotifications.Remove(an);
            _unitOfWork.Commit();
            #endregion

            return StatusCode(204);
        }

        [Authorize(Roles = "Master, Notification_Lista")]
        [Route("lista")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Lista()
        {
            #region User resolve
            String userId;
            try
            {
                if (HttpContext.User == null) throw new Exception("Problemas ao obter usuário logado. Saia e entre no sistema novamente, persistindo o problema informe a equipe técnica.");
                userId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            }
            catch (Exception ex) { AddError(ex.Message); return StatusCode(500); }
            if (string.IsNullOrEmpty(userId)) throw new Exception("Usuário não encontrado.");
            #endregion

            #region Tenant resolve
            Guid tenantId;
            try
            {
                tenantId = (Guid) StringHelpers.ExtractTenantId(await _tenantRepository.GetTenantIdAsync());
            }
            catch (Exception ex) { return StatusCode(404, ex.Message); }
            if (tenantId == Guid.Empty) throw new Exception("Problemas ao obter a UNIDADE do usuário logado. Tente novamente, persistindo o problema informe a equipe técnica do sistema.");
            #endregion

            #region Get data
            IEnumerable<ApplicationNotification> anList = new List<ApplicationNotification>();
            try
            {
                anList = await _context
                                    .ApplicationNotifications
                                    .Where(x => (x.UserId == userId || x.UserId == null) &&
                                           x.IsRead == false &&
                                           x.TenantId == tenantId &&
                                           x.Scope != NotificationScopeTypeEnum.NONE &&
                                           x.IsDeleted == false)
                                    .OrderByDescending(x => x.CreatedAt)
                                    .ToListAsync();
            }
            catch (Exception ex) { AddError(ex.Message); return StatusCode(500); }
            #endregion

            #region Map
            var anVM = new List<ApplicationNotificationViewModel>();
            try
            {
                anVM = _mapper.Map<IEnumerable<ApplicationNotificationViewModel>>(anList).ToList();
            }
            catch (Exception ex) { AddError(ex.Message); return StatusCode(500); }
            #endregion

            return CustomResponse(anVM);
        }
        #endregion

        [Authorize(Roles = "Master, Notification_Ler")]
        [Route("read/{id}")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ReadAsync([FromRoute]string id)
        {
            #region Validation required
            if (string.IsNullOrEmpty(id)) return StatusCode(400, "Id requerido.");
            #endregion

            #region Get data
            var an = new ApplicationNotification();
            try
            {
                an = await _context
                                .ApplicationNotifications
                                .FirstOrDefaultAsync(x => x.Id == Guid.Parse(id));
            }
            catch (Exception ex) { AddError(ex.Message); return StatusCode(500); }
            if (an == null) return StatusCode(404, "Não encontrado.");
            #endregion

            #region User resolve
            String userId;
            try
            {
                if (HttpContext.User == null) throw new Exception("Problemas ao obter usuário logado. Saia e entre no sistema novamente, persistindo o problema informe a equipe técnica.");
                userId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            }
            catch (Exception ex) { AddError(ex.Message); return StatusCode(500); }
            if (string.IsNullOrEmpty(userId)) throw new Exception("Usuário não encontrado.");
            #endregion

            #region Owner validation
            if (string.IsNullOrEmpty(an.UserId) || an.UserId != userId) return StatusCode(400, "Você só pode marcar como lida as suas notificações. <br>Notificações globais são disponíveis a todos os usuários do sistema por um tempo determinado.");
            #endregion

            #region Update data
            if (an.IsRead)
            {
                an.IsRead = false;
            }
            else
            {
                an.IsRead = true;
            }
            _context.ApplicationNotifications.Update(an);
            _unitOfWork.Commit();
            #endregion

            return StatusCode(200, an.IsRead);
        }
    }
}