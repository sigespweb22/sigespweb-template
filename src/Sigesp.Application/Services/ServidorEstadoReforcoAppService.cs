using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using AutoMapper;
using Sigesp.Domain.Interfaces;
using Sigesp.Domain.Models;
using Sigesp.Application.Interfaces;
using Sigesp.Application.ViewModels;
using Sigesp.Domain.Enums;
using Sigesp.Infra.Data.Extensions;
using System.Globalization;
using Sigesp.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.SignalR;
using System.Dynamic;
using Sigesp.Application.Helpers;

namespace Sigesp.Application.Services
{
    public class ServidorEstadoReforcoAppService : IServidorEstadoReforcoAppService
    {
        private readonly ValidationResult _validationResult;
        private readonly SigespDbContext _context;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ITenantRepository _tenantRepository;
        private readonly IServidorEstadoReforcoRepository _serRepository;
        private readonly IServidorEstadoRepository _seRepository;
        private readonly IServidorEstadoReforcoRegraRepository _serrRepository;

        public ServidorEstadoReforcoAppService(ValidationResult validationResult,
                                               IUnitOfWork unitOfWork, 
                                               IMapper mapper,
                                               ITenantRepository tenantRepository,
                                               IServidorEstadoReforcoRepository serRepository,
                                               IServidorEstadoRepository seRepository,
                                               IServidorEstadoReforcoRegraRepository serrRepository,
                                               SigespDbContext context)
        {
            _validationResult = validationResult;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _tenantRepository = tenantRepository;
            _serRepository = serRepository;
            _seRepository = seRepository;
            _serrRepository = serrRepository;
            _context = context;
        }

        #region Private methods
        private async Task<int> CommandCreateAsync(ServidorEstadoReforcoViewModel serVM, ServidorEstado seDM)
        {
            #region Date to Markup resolve
            DateTime markupDateTimePrevInicio;
            DateTime markupDateTimePrevFim;
            DateTime.TryParse(serVM.DataPrevistaInicio, out markupDateTimePrevInicio);
            DateTime.TryParse(serVM.DataPrevistaFim, out markupDateTimePrevFim);

            if (seDM.IsExpediente)
            {
                markupDateTimePrevInicio = new DateTime(markupDateTimePrevInicio.Year, markupDateTimePrevInicio.Month, markupDateTimePrevInicio.Day, 18,00,00, 000000);
                markupDateTimePrevFim = new DateTime(markupDateTimePrevInicio.Year, markupDateTimePrevInicio.Month, markupDateTimePrevInicio.Day, 07,59,59, 000000).AddDays(1);
            } 
            else 
            {
                markupDateTimePrevInicio = new DateTime(markupDateTimePrevInicio.Year, markupDateTimePrevInicio.Month, markupDateTimePrevInicio.Day, 08, 00, 00, 000000);
                markupDateTimePrevFim = new DateTime(markupDateTimePrevInicio.Year, markupDateTimePrevInicio.Month, markupDateTimePrevInicio.Day, 17,59,59, 000000);
            }
            #endregion

            #region Mapper
            var mapped = new ServidorEstadoReforco();
            try
            {
                mapped = _mapper.Map<ServidorEstadoReforco>(serVM);
                mapped.ServidorEstadoId = seDM.Id;
                mapped.ReforcoSituacao = ReforcoSituacaoEnum.AGENDADO;
                CultureInfo ptBR = new CultureInfo("pt-BR");
                mapped.DiaSemana = ptBR.DateTimeFormat.GetDayName(mapped.DataPrevistaInicio.DayOfWeek).ToUpper();
                mapped.MesExtenso = ptBR.DateTimeFormat.GetMonthName(mapped.DataPrevistaInicio.Month).ToUpper();
                mapped.MesNumeral = mapped.DataPrevistaInicio.Month;
                mapped.DataPrevistaInicio = markupDateTimePrevInicio;
                mapped.DataPrevistaFim = markupDateTimePrevFim;
                mapped.IsExpediente = seDM.IsExpediente;
            }
            catch (Exception ex) { throw ex; }
            #endregion

            #region Persistence and commit
            try
            {
                await _serRepository.AddAsync(mapped);
            }
            catch (Exception ex) { throw ex; }
            
            int result;
            /// commit
            try
            {
                result = await _unitOfWork.CommitAsync();
            }
            catch (Exception ex) { throw ex; }
            #endregion
            return result;
        }
        
        private bool IsDateAvailable(ServidorEstadoReforcoRegra servidorEstadoReforcoRegra,
                                           IEnumerable<ServidorEstadoReforco> reforcosOfMonth,
                                           DateTime MarkupDate,
                                           bool isExpediente, Guid seId)
        {
            // ** first
            //    check to limite de vagas existente para a data do reforço que deseja marcar
            bool alreadyDate;
            try
            {
                alreadyDate = servidorEstadoReforcoRegra.VagasPorDia.Any(x => x.Dia == MarkupDate.Day.ToString());
            }
            catch { throw;}
            if (!alreadyDate) return false;

            // ** second
            //    check to already reforço to same day to same servidor
            bool alreadySameDay;
            try
            {
                alreadySameDay = reforcosOfMonth.Any(x => x.DataPrevistaInicio.Date.Day == MarkupDate.Day && x.ServidorEstado.Id == seId);
            }
            catch { throw;}
            if (alreadySameDay) return false;
            
            // ** third
            // ** obtenho total de vagas para o dia que está recebendo nova marcação de reforço
            //    de acordo com a condição do servidor
            // ** sendo expediente, obtém o total de vagas noturnas para o dia 
            // ** caso contrário, obtém o total de vagas diurnas para o dia 

            var totalVagasDia = new ServidorEstadoReforcoRegraVagaDia();
            switch (isExpediente)
            {
                case true:
                    totalVagasDia = servidorEstadoReforcoRegra.VagasPorDia.FirstOrDefault(x => x.Dia == MarkupDate.Day.ToString() && x.Turno == TurnoEnum.NOTURNO);
                    break;
                case false:
                    totalVagasDia = servidorEstadoReforcoRegra.VagasPorDia.FirstOrDefault(x => x.Dia == MarkupDate.Day.ToString() && x.Turno == TurnoEnum.DIURNO);
                    break;
            }

            // ** verifica se o total das vagas do dia estão disponíveis
            //    ou seja, ainda não possuem reforços agendados
            if (totalVagasDia == null) return false;

            int totalReforcosJaMarcadosParaData;
            totalReforcosJaMarcadosParaData = totalVagasDia.TotalVagas - reforcosOfMonth.Where(x => x.DataPrevistaInicio.Date == MarkupDate.Date && x.IsExpediente == isExpediente).Count();
            if (totalReforcosJaMarcadosParaData >= 1) return true;
            return false;
        }
        #endregion

        #region Methods multitenancies
        public async Task<int> CreateAsync(ServidorEstadoReforcoViewModel servidorEstadoReforcoViewModel)
        {
            #region Variables
            int monthToMarkupInt = DateTime.Now.AddMonths(1).Month;
            String monthToMarkupString = Enum.GetName(typeof(MonthOfYearEnum), monthToMarkupInt);
            MonthOfYearEnum monthToMarkupEnum = Enum.Parse<MonthOfYearEnum>(monthToMarkupString);
            
            int currentYear = DateTime.Now.Year;
            int today = DateTime.Now.Day;
            DateTime markupDateTime = Convert.ToDateTime(servidorEstadoReforcoViewModel.DataPrevistaInicio);
            #endregion

            #region Required and generals validations
            try
            {
                if (string.IsNullOrEmpty(servidorEstadoReforcoViewModel.DataPrevistaInicio))
                    throw new ArgumentException("Data prevista início requerida.");
            
                if (string.IsNullOrEmpty(servidorEstadoReforcoViewModel.UserId))
                    throw new ArgumentException("Usuário requerido."+"\nSaia e entre no sistema novamente, persistindo o problema informe a equipe técnica do sistema.");
                
                /// check if date month is current year
                if (markupDateTime.Year != currentYear)
                    throw new Exception("Não é permitido marcar reforço para ANO diferente do atual.");

                /// check if date month is diff of markup month
                if (markupDateTime.Month != monthToMarkupInt)
                    throw new Exception("Não é possível marcar reforço para MÊS diferente do MÊS seguinte ao atual.");
            }
            catch (Exception ex) { throw ex;}
            #endregion

            #region Tenancy resolve
            Guid tenantId;
            try
            {
                var getTenantId = await _tenantRepository.GetTenantIdAsync();
                tenantId = (Guid)StringHelpers.ExtractTenantId(getTenantId);
            }
            catch (Exception ex) { throw ex; }
            #endregion

            #region Servidor resolve
            
            var se = new ServidorEstado();
            try
            {
                se = await _context
                            .ServidoresEstado
                            .Include(x => x.ServidoresEstadoReforcos)
                            .FirstOrDefaultAsync(x => x.UserId == servidorEstadoReforcoViewModel.UserId);
            }
            catch (Exception ex) { throw ex; }
            if (se == null) throw new Exception("Problemas ao obter os dados do SERVIDOR para marcação do reforço."+"\nTente novamente, persistindo o erro informe a equipe técnica do sistema.");
            #endregion

            #region Regras resolve
            var reforcoRegras = new ServidorEstadoReforcoRegra();
            try
            {
                reforcoRegras = await _context
                                        .ServidorEstadoReforcoRegras
                                        .Include(x => x.VagasPorDia)
                                        .FirstOrDefaultAsync(x => x.MesRegra == monthToMarkupEnum &&
                                                             x.TenantId == tenantId);
            }
            catch (Exception ex) { throw ex; }
            if (reforcoRegras == null) throw new Exception("Problemas ao obter a regra de marcação de reforço para o mês."+"\nTente novamente, persistindo o erro informe a equipe técnica do sistema.");
            #endregion

            #region Reforços schedules to markut month resolve
            IEnumerable<ServidorEstadoReforco> reforcosOfMonth = new List<ServidorEstadoReforco>();
            try
            {
                reforcosOfMonth = await _context
                                            .ServidoresEstadoReforcos
                                            .Include(x => x.ServidorEstado)
                                            .Where(x => x.MesNumeral == monthToMarkupInt)
                                            .ToListAsync();
            }
            catch { throw; }
            #endregion

            #region Total reforços servidor resolve
            int totalReforcosServidorInMonth;
            totalReforcosServidorInMonth = se.ServidoresEstadoReforcos.Count(x => x.MesNumeral == monthToMarkupInt);
            #endregion

            #region Generals validations and markup ou flux out
            // *** init out flux
            
            // ** first
            // check to 5 reforços já marcados
            if (reforcosOfMonth.Where(x => x.ServidorEstadoId == se.Id).Count() >= 5)
                throw new Exception("Você já atingiu o limite de 5 reforços para o mês corrente."+"\nExclua um reforço já agendado ainda não realizado, ou aguarde abertura de nova janela de marcação para o próximo mês.");

            // ** second
            // check to servidor com licença prêmio ou férias agendadas para o mês do reforço
            if (se.DataInicioGozo != null &&
                se.DataInicioGozo != new DateTime(0001,01,01,00,00,00) &&
                se.DataFimGozo != null &&
                se.DataFimGozo != new DateTime(0001,01,01,00,00,00) &&
                se.DataInicioGozo.Month == monthToMarkupInt && 
                se.DataInicioGozo.Year == currentYear)
            {
                // check to 4 reforços marcados
                if (totalReforcosServidorInMonth == 4)
                {
                    // check to 3ª janela de marcação de reforço open
                    if (DateTime.Now < reforcoRegras.DataTerceiraJanela) throw new Exception("Você já marcou 4 reforços permitidos para sua condição (Licença prêmio ou Férias para o mês de marcação), fora das janelas de marcação. Portanto, para agendar seu último reforço, aguarda a abertura da terceira janela que ocorrerá em " + reforcoRegras.DataTerceiraJanela.ToString("dd/MM/yyyy"));
                    return await CommandCreateAsync(servidorEstadoReforcoViewModel, se);                    
                }
                else
                {
                    try
                    {
                        if(IsDateAvailable(reforcoRegras, reforcosOfMonth, markupDateTime, se.IsExpediente, se.Id)) return await CommandCreateAsync(servidorEstadoReforcoViewModel, se);
                        throw new Exception("Data para marcação de reforço indisponível. Você já possui reforço marcado para este dia? Pode ser isso! Ou o limite de vagas para o dia foi atingido, bem como também pode não ter sido disponibilizada vagas para o dia. Consulte o gestor dos reforços para mais detalhes.");
                    }
                    catch { throw; }
                }
            }

            // ** third
            // check to prioridade de marcação
            if (se.HasPrioridadeMarcacaoReforco)
            {
                // check to 3 reforços marcados
                if (totalReforcosServidorInMonth == 3)
                {
                    // check to 3ª janela de marcação de reforço open
                    if (DateTime.Now < reforcoRegras.DataTerceiraJanela) throw new Exception("Você já marcou 3 reforços permitidos para sua condição (Tem prioridade de marcação), fora das janelas de marcação. Portanto, para agendar seu último reforço, aguarda a abertura da terceira janela que ocorrerá em " + reforcoRegras.DataTerceiraJanela.ToString("dd/MM/yyyy"));
                    return await CommandCreateAsync(servidorEstadoReforcoViewModel, se);                    
                }
                else
                {
                    try
                    {
                        if(IsDateAvailable(reforcoRegras, reforcosOfMonth, markupDateTime, se.IsExpediente, se.Id)) return await CommandCreateAsync(servidorEstadoReforcoViewModel, se);
                        throw new Exception("Data para marcação de reforço indisponível. Você já possui reforço marcado para este dia? Pode ser isso! Ou o limite de vagas para o dia foi atingido, bem como também pode não ter sido disponibilizada vagas para o dia. Consulte o gestor dos reforços para mais detalhes.");
                    }
                    catch { throw; }
                }
            }

            // ** fourth
            // flux to sem prioridade de marcação
            int firstWindowMarkup;
            int secondWindowMarkup;
            int thirdWindowMarkup;

            firstWindowMarkup = reforcoRegras.DataPrimeiraJanela.Day;
            secondWindowMarkup = reforcoRegras.DataSegundaJanela.Day;
            thirdWindowMarkup = reforcoRegras.DataTerceiraJanela.Day;

            if (today < firstWindowMarkup && today < firstWindowMarkup && today < firstWindowMarkup)
                throw new Exception("Você não está autorizado a agendar reforço fora das janelas de marcação."+"\nAguarde a abertura da 1ª janela de agendamento de reforço que será aberta a partir das ZERO HORA do dia "+firstWindowMarkup+" do mês de marcação.");

            if (today >= firstWindowMarkup && today < secondWindowMarkup)
            {
                if (totalReforcosServidorInMonth == 2) throw new Exception("Seu limite (2) de agendamento de reforço na 1ª janela foi atingido."+"\nAguarde a abertura da 2ª janela que ocorrerá em "+secondWindowMarkup+", para o agendamento de mais 2 reforços para o mês.");
            } else if (today >= secondWindowMarkup && today < thirdWindowMarkup)
            {
                if (totalReforcosServidorInMonth == 4) throw new Exception("Seu limite (4) de agendamento de reforço na 1ª e 2ª janelas foi atingido."+"\nAguarde a abertura da 3ª janela que ocorrerá em "+thirdWindowMarkup+", para o agendamento do seu último reforço para este mês.");
            } else if (today >= thirdWindowMarkup)
            {
                if (totalReforcosServidorInMonth == 5) throw new Exception("Você já atingiu o limite de 5 reforços para o mês corrente."+"\nExclua um reforço já agendado ainda não realizado, ou aguarde abertura de nova janela de marcação para o próximo mês.");
            }

            return await CommandCreateAsync(servidorEstadoReforcoViewModel, se);
            #endregion
        }
        #endregion

        #region Methods that are not tenants
        public async Task<List<ServidorEstadoReforcoViewModel>> DeleteOnDemandAsync(string userId, string deleteType)
        {
            #region Generals validations
            if (string.IsNullOrEmpty(userId))
                throw new ArgumentException("Id usuário requerido. Tente novamente, persistindo o problema informe a equipe técnica do sistema.");
             
            if (string.IsNullOrEmpty(deleteType))
                throw new ArgumentException("Tipo delete requerido para este padrão de exclusão de reforço.");
            
            if (deleteType != "all" &&  deleteType != "last")
                throw new Exception("Tipo delete fornecido está fora do padrão aceito. Tente novamente, persistindo o problema informe a equipe técnica do sistema;");
            #endregion 
            
            #region Servidor estado resolve
            Guid servidorEstadoId;
            try
            {
                servidorEstadoId =  _context
                                        .ServidoresEstado
                                        .FirstOrDefault(x => x.UserId == userId).Id;
            }
            catch { throw; }

            if (servidorEstadoId == Guid.Empty)
                throw new Exception("Servidor estado não encontrado com o id do usuário fornecido. \nTente novamente, persistindo o problema informe a equipe técnica do sistema.");
            #endregion

            #region Check and to delete
            var currentMonth = DateTime.Now.AddMonths(1).Month;
            IEnumerable<ServidorEstadoReforco> reforcosOfMonth = new List<ServidorEstadoReforco>();
            
            // get all data
            try
            {
                reforcosOfMonth = await _context
                                             .ServidoresEstadoReforcos
                                             .Where(x => x.ServidorEstadoId == servidorEstadoId &&
                                                    x.MesNumeral == currentMonth)
                                             .OrderByDescending(x => x.CreatedAt)
                                             .ToListAsync();
            }
            catch { throw; }

            if (reforcosOfMonth == null || reforcosOfMonth.Count() == 0)
                throw new Exception("Nenhum reforço encontrado para o mês de marcação do reforço para efetuar a exclusão.");

            var result = new List<ServidorEstadoReforcoViewModel>();
            if (deleteType == "last")
            {
                var reforcoToDelete = reforcosOfMonth.First();
                _context
                    .ServidoresEstadoReforcos
                    .Remove(reforcoToDelete);

                var map = _mapper.Map<ServidorEstadoReforcoViewModel>(reforcoToDelete);
                result.Add(map);
            } else if (deleteType == "all")
            {
                _context
                    .ServidoresEstadoReforcos
                    .RemoveRange(reforcosOfMonth);

                result = _mapper.Map<IEnumerable<ServidorEstadoReforcoViewModel>>(reforcosOfMonth).ToList();
            } else
            {
                throw new Exception("Tipo delete fornecido está fora do padrão aceito. Tente novamente, persistindo o problema informe a equipe técnica do sistema;");
            }
            #endregion

            try
            {
                _unitOfWork.CommitWithoutSoftDeletion();    
            }
            catch { throw; }
            return result.ToList();
        }
        #endregion

        public void Dispose()
        {
            _serRepository.Dispose();
        }
    }
}