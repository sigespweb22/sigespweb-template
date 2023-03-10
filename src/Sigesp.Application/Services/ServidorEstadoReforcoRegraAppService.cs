using System;
using System.Threading.Tasks;
using AutoMapper;
using Sigesp.Domain.Interfaces;
using Sigesp.Domain.Models;
using Sigesp.Application.Interfaces;
using Sigesp.Application.ViewModels;
using Sigesp.Infra.Data.Extensions;
using Sigesp.Domain.Models.DataTable;
using System.Collections.Generic;
using Sigesp.Domain.Enums;
using Sigesp.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Sigesp.Application.Services
{
    public class ServidorEstadoReforcoRegraAppService : IServidorEstadoReforcoRegraAppService
    {
        private readonly SigespDbContext _context;
        private readonly ValidationResult _validationResult;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ITenantRepository _tenantRepository;
        private readonly IServidorEstadoReforcoRegraRepository _serrRepository;
        private readonly IServidorEstadoReforcoRepository _serRepository;

        public ServidorEstadoReforcoRegraAppService(SigespDbContext context,
                                                    ValidationResult validationResult,
                                                    IUnitOfWork unitOfWork, 
                                                    IMapper mapper,
                                                    ITenantRepository tenantRepository,
                                                    IServidorEstadoReforcoRegraRepository serrRepository,
                                                    IServidorEstadoReforcoRepository serRepository)
        {
            _context = context;
            _validationResult = validationResult;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _tenantRepository = tenantRepository;
            _serrRepository = serrRepository;
            _serRepository = serRepository;
        }

        #region Methods multitenancies
        public async Task<int> CreateAsync(ServidorEstadoReforcoRegraViewModel 
                                           servidorEstadoReforcoRegraViewModel)
        {
            /// data terceira janela nunca dever ser maior que 31
            #region Required validations
            try
            {
                if (string.IsNullOrEmpty(servidorEstadoReforcoRegraViewModel.MesRegra))
                    throw new ArgumentException("M??s regra requerido.");

                if (string.IsNullOrEmpty(servidorEstadoReforcoRegraViewModel.DataPrimeiraJanela))
                    throw new ArgumentException("Data primeira janela requerida.");
                
                if (string.IsNullOrEmpty(servidorEstadoReforcoRegraViewModel.DataSegundaJanela))
                    throw new ArgumentException("Data segunda janela requerida.");
                
                if (string.IsNullOrEmpty(servidorEstadoReforcoRegraViewModel.DataTerceiraJanela))
                    throw new ArgumentException("Data terceira janela requerida.");
            }
            catch (Exception ex) { throw ex;}
            #endregion

            #region Mappers micellaneous
            int monthNumber;
            int lastDayInCurrentMonth;
            DateTime dia1;
            DateTime dia2;
            DateTime dia3;
            DateTime dataPPM;
            try
            {
                monthNumber = (int)Enum.Parse<MonthOfYearEnum>(servidorEstadoReforcoRegraViewModel.MesRegra);
                lastDayInCurrentMonth = DateTime.DaysInMonth(DateTime.Now.Year, monthNumber);
                dia1 = Convert.ToDateTime(servidorEstadoReforcoRegraViewModel.DataPrimeiraJanela);
                dia2 = Convert.ToDateTime(servidorEstadoReforcoRegraViewModel.DataSegundaJanela);
                dia3 = Convert.ToDateTime(servidorEstadoReforcoRegraViewModel.DataTerceiraJanela);
                dataPPM = !string.IsNullOrEmpty(servidorEstadoReforcoRegraViewModel.DataPrimeiroPlantao) ? Convert.ToDateTime(servidorEstadoReforcoRegraViewModel.DataPrimeiroPlantao) : DateTime.Now;
            }
            catch (Exception ex) { throw ex; }
            #endregion

            #region Generals validations
            try
            {
                if (dia1.Date <= DateTime.Now.Date ||
                    dia2.Date <= DateTime.Now.Date ||
                    dia3.Date <= DateTime.Now.Date)
                    throw new ArgumentException("Nenhuma das datas pode ser menor ou igual ao dia de hoje.");
            }
            catch (Exception ex) { throw ex;}

            try
            {
                if (dia1 >= dia2 || dia1 >= dia3)
                    throw new ArgumentException("Data primeira janela n??o pode ser maior ou igual a segunda tampouco maior ou igual a terceira janela.");
                
                if (dia2 <= dia1 || dia2 >= dia3)
                    throw new ArgumentException("Data segunda janela n??o pode ser menor ou igual a primeira tampouco maior ou igual a terceira janela.");
                
                if (dia3 <= dia2 || dia3 <= dia1)
                    throw new ArgumentException("Data terceira janela n??o pode ser menor ou igual a segunda tampouco menor ou igual a primeira janela.");
            }
            catch (Exception ex) { throw ex;}
            
            /// check terceira janela - cannot greater be two days before last day in month
            if ((lastDayInCurrentMonth - dia3.Day) < 2)
                throw new Exception("Data terceira janela n??o pode ser menor que 2 dias antes do ??ltimo dia do m??s corrente."+"\nPois, o per??odo m??ximo de abertura desta janela s??o 48 horas.");
            
            /// check month between dates the windows
            if (dia1.Month != dia2.Month ||
                dia1.Month != dia3.Month ||
                dia2.Month != dia3.Month)
                throw new Exception("As datas de PRIMEIRA, SEGUNDA E TERCEIRA janela devem ser do mesmo m??s.");
            
            /// check year between dates the windows
            if (dia1.Year != dia2.Year ||
                dia1.Year != dia3.Year ||
                dia2.Year != dia3.Year)
                throw new Exception("As datas de PRIMEIRA, SEGUNDA E TERCEIRA janela devem ser do mesmo ano.");
            
            /// check to month of first wizard as being month prev
            if ((monthNumber - 1) != dia1.Month)
                throw new Exception("M??s primeira janela deve ser m??s anterior ao m??s da regra.");
            
            /// check to month of first wizard as being month prev
            if ((monthNumber - 1) != dia2.Month)
                throw new Exception("M??s segunda janela deve ser m??s anterior ao m??s da regra.");
            
            /// check to month of first wizard as being month prev
            if ((monthNumber - 1) != dia3.Month)
                throw new Exception("M??s terceira janela deve ser m??s anterior ao m??s da regra.");
            
            /// check year prev in current
            if (dia1.Year < DateTime.Now.Year)
                throw new Exception("N??o ?? permitido criar regra para um ano anterior ao corrente.");

            /// check month of first plant??o diff of the month rule
            if (dataPPM != DateTime.Now && dataPPM.Month != monthNumber)
                throw new Exception("O m??s do primeiro plant??o n??o pode ser diferente do m??s escolhido para vig??ncia da regra no campo M??s Regra.");
            
            /// check year of first plant??o diff of the year first date duty
            if (dataPPM != DateTime.Now && dataPPM.Year != dia1.Year)
                throw new Exception("O ano do primeiro plant??o n??o pode ser diferente do ano escolhido para vig??ncia da regra no campo M??s Regra.");
            #endregion

            #region Tenancy resolve
            Guid tenantId;
            try
            {
                tenantId = (Guid)StringHelpers.ExtractTenantId(await _tenantRepository.GetTenantIdAsync());
            }
            catch (Exception ex) { throw ex; }
            #endregion

            #region Check already active rule same month and year
            bool alreadyRuleActiveSameMonthYear;
            try
            {
                alreadyRuleActiveSameMonthYear = await _serrRepository.AlreadyRuleSameMonthYear(tenantId, dia1, Guid.Empty);
                if (alreadyRuleActiveSameMonthYear)
                    throw new Exception("J?? existe um conjunto de regras para marca????o de refor??o ativo para sua unidade com o mesmo m??s e ano informados na Data primeira janela.");
            }
            catch (Exception ex) { throw ex; }
            #endregion

            #region Mapper to add or edit
            /// get rule
            var mapped = new ServidorEstadoReforcoRegra();
            try
            {
                mapped = _mapper.Map<ServidorEstadoReforcoRegra>(servidorEstadoReforcoRegraViewModel);
                mapped.TenantId = tenantId;
            }
            catch (Exception ex) { throw ex; }
            await _serrRepository.AddAsync(mapped);
            #endregion

            #region Commit
            int result;
            /// commit
            try
            {
                result = await _unitOfWork.CommitAsync();
            }
            catch (Exception ex) { throw ex; }
            #endregion
            
            /// return 
            return result;
        }
        public async Task<int> UpdateAsync(ServidorEstadoReforcoRegraViewModel 
                                           servidorEstadoReforcoRegraViewModel)
        {
            /// data terceira janela nunca dever ser maior que 31
            #region Required validations
            try
            {
                if (servidorEstadoReforcoRegraViewModel.Id == Guid.Empty)
                    throw new ArgumentException("Id requerido.");

                if (string.IsNullOrEmpty(servidorEstadoReforcoRegraViewModel.MesRegra))
                    throw new ArgumentException("M??s regra requerido.");

                if (string.IsNullOrEmpty(servidorEstadoReforcoRegraViewModel.DataPrimeiraJanela))
                    throw new ArgumentException("Data primeira janela requerida.");
                
                if (string.IsNullOrEmpty(servidorEstadoReforcoRegraViewModel.DataSegundaJanela))
                    throw new ArgumentException("Data segunda janela requerida.");
                
                if (string.IsNullOrEmpty(servidorEstadoReforcoRegraViewModel.DataTerceiraJanela))
                    throw new ArgumentException("Data terceira janela requerida.");
            }
            catch (Exception ex) { throw ex;}
            #endregion

            #region Mappers micellaneous
            int monthNumber;
            int lastDayInCurrentMonth;
            DateTime dia1;
            DateTime dia2;
            DateTime dia3;
            DateTime dataPPM;
            try
            {
                monthNumber = (int)Enum.Parse<MonthOfYearEnum>(servidorEstadoReforcoRegraViewModel.MesRegra);
                lastDayInCurrentMonth = DateTime.DaysInMonth(DateTime.Now.Year, monthNumber);
                dia1 = Convert.ToDateTime(servidorEstadoReforcoRegraViewModel.DataPrimeiraJanela);
                dia2 = Convert.ToDateTime(servidorEstadoReforcoRegraViewModel.DataSegundaJanela);
                dia3 = Convert.ToDateTime(servidorEstadoReforcoRegraViewModel.DataTerceiraJanela);
                dataPPM = !string.IsNullOrEmpty(servidorEstadoReforcoRegraViewModel.DataPrimeiroPlantao) ? Convert.ToDateTime(servidorEstadoReforcoRegraViewModel.DataPrimeiroPlantao) : DateTime.Now;
            }
            catch (Exception ex) { throw ex; }
            #endregion

            #region Generals validations
            try
            {
                if (dia1.Date <= DateTime.Now.Date ||
                    dia2.Date <= DateTime.Now.Date ||
                    dia3.Date <= DateTime.Now.Date)
                    throw new ArgumentException("Nenhuma das datas pode ser menor ou igual ao dia de hoje.");
            }
            catch (Exception ex) { throw ex;}

            try
            {
                if (dia1 >= dia2 || dia1 >= dia3)
                    throw new ArgumentException("Data primeira janela n??o pode ser maior ou igual a segunda tampouco maior ou igual a terceira janela.");
                
                if (dia2 <= dia1 || dia2 >= dia3)
                    throw new ArgumentException("Data segunda janela n??o pode ser menor ou igual a primeira tampouco maior ou igual a terceira janela.");
                
                if (dia3 <= dia2 || dia3 <= dia1)
                    throw new ArgumentException("Data terceira janela n??o pode ser menor ou igual a segunda tampouco menor ou igual a primeira janela.");
            }
            catch (Exception ex) { throw ex;}
            
            /// check terceira janela - cannot greater be two days before last day in month
            if ((lastDayInCurrentMonth - dia3.Day) < 2)
                throw new Exception("Data terceira janela n??o pode ser menor que 2 dias antes do ??ltimo dia do m??s corrente."+"\nPois, o per??odo m??ximo de abertura desta janela s??o 48 horas.");
            
            /// check month between dates the windows
            if (dia1.Month != dia2.Month ||
                dia1.Month != dia3.Month ||
                dia2.Month != dia3.Month)
                throw new Exception("As datas de PRIMEIRA, SEGUNDA E TERCEIRA janela devem ser do mesmo m??s.");
            
            /// check year between dates the windows
            if (dia1.Year != dia2.Year ||
                dia1.Year != dia3.Year ||
                dia2.Year != dia3.Year)
                throw new Exception("As datas de PRIMEIRA, SEGUNDA E TERCEIRA janela devem ser do mesmo ano.");
            
            /// check month prev in current
            if (monthNumber < DateTime.Now.Month)
                throw new Exception("N??o ?? permitido criar regra para um m??s anterior ao corrente.");
            
            /// check year prev in current
            if (dia1.Year < DateTime.Now.Year)
                throw new Exception("N??o ?? permitido criar regra para um ano anterior ao corrente.");

            //// check to month of first wizard as being month prev
            if ((monthNumber - dia1.Month) != 1)
                throw new Exception("M??s primeira janela deve ser m??s anterior ao m??s da regra.");
            
            /// check to month of first wizard as being month prev
            if ((monthNumber - dia2.Month) != 1)
                throw new Exception("M??s segunda janela deve ser m??s anterior ao m??s da regra.");
            
            /// check to month of first wizard as being month prev
            if ((monthNumber - dia3.Month) != 1)
                throw new Exception("M??s terceira janela deve ser m??s anterior ao m??s da regra.");
            
            /// check month of first plant??o diff of the month rule
            if (dataPPM != DateTime.Now && dataPPM.Month != monthNumber)
                throw new Exception("O m??s do primeiro plant??o n??o pode ser diferente do m??s escolhido para vig??ncia da regra no campo M??s Regra.");
            
            /// check year of first plant??o diff of the year first date duty
            if (dataPPM != DateTime.Now && dataPPM.Year != dia1.Year)
                throw new Exception("O ano do primeiro plant??o n??o pode ser diferente do ano escolhido para vig??ncia da regra no campo M??s Regra.");
            #endregion

            #region Tenancy resolve
            Guid tenantId;
            try
            {
                tenantId = (Guid)StringHelpers.ExtractTenantId(await _tenantRepository.GetTenantIdAsync());
            }
            catch (Exception ex) { throw ex; }
            #endregion

            #region Check already active rule same month and year
            bool alreadyRuleActiveSameMonthYear;
            try
            {
                alreadyRuleActiveSameMonthYear = await _serrRepository.AlreadyRuleSameMonthYear(tenantId, dia1, servidorEstadoReforcoRegraViewModel.Id);
                if (alreadyRuleActiveSameMonthYear)
                    throw new Exception("J?? existe um conjunto de regras para marca????o de refor??o ativo para sua unidade com o mesmo m??s e ano informados na Data primeira janela.");
            }
            catch (Exception ex) { throw ex; }
            #endregion

            #region Get data and Map to update
            /// get data
            var getRule = new ServidorEstadoReforcoRegra();
            try
            {
                getRule = await _context
                                    .ServidorEstadoReforcoRegras
                                    .Include(x =>  x.VagasPorDia)
                                    .FirstOrDefaultAsync(x => x.Id == ((Guid) servidorEstadoReforcoRegraViewModel.Id));
            }
            catch { throw; }
            if (getRule == null)
                throw new Exception("Regra n??o encontrada com o id informado para atualizar. Tente novamente, persistindo o erro informe a equipe t??cnica do sistema.");

            // ** remove vagas dia
            foreach (var item in getRule.VagasPorDia)
            {
                _context
                    .ServidorEstadoReforcoRegraVagasDia
                    .Remove(item);
                
            }

            getRule.VagasPorDia.Clear();

            var ruleMapped = new ServidorEstadoReforcoRegra();
            try
            {
                ruleMapped = _mapper.Map<ServidorEstadoReforcoRegraViewModel, ServidorEstadoReforcoRegra>(servidorEstadoReforcoRegraViewModel, getRule);
                ruleMapped.TenantId = tenantId;
            }
            catch (Exception ex) { throw ex; }
            _serrRepository.Update(ruleMapped);
            #endregion

            #region Commit
            /// commit
            try
            {
                _unitOfWork.CommitWithoutSoftDeletion();
                _unitOfWork.Commit();
            }
            catch { throw; }
            #endregion
            
            /// return 
            return 1;
        }
        public async Task<DataTableServerSideResult<ServidorEstadoReforcoRegraViewModel>> GetWithDataTableResultAsync(DataTableServerSideRequest request)
        {
            #region Tenancy resolve
            Guid tenantId;
            try
            {
                tenantId = (Guid) StringHelpers.ExtractTenantId(await _tenantRepository.GetTenantIdAsync());
                request.TenantId = (Guid) tenantId;
            }
            catch (Exception ex) { throw ex; }
            #endregion
            
            #region Param resolve
            // // Resolve param to search m??s regra
            // var mesRegraSearchableCol = request.Columns.Where(x => x.Name == "MesRegra").Select(x => x.Searchable).FirstOrDefault();
            // if (mesRegraSearchableCol)
            // {
            //     int monthInt = (int)Enum.Parse<MonthOfYearEnum>(request.Search.Value);
            //     if (monthInt != 0)
            //         request.Search.Value = monthInt;
            // }    
            #endregion

            #region Get data
            var serr = new DataTableServerSideResult<ServidorEstadoReforcoRegra>();
            try
            {
                serr = await _serrRepository
                                    .GetWithDataTableResultAsync(request);
            }
            catch (Exception ex) { throw ex; }
            #endregion
            
            #region Map
            var result = new DataTableServerSideResult<ServidorEstadoReforcoRegraViewModel>();
            IList<ServidorEstadoReforcoRegraViewModel> serrMapped = new List<ServidorEstadoReforcoRegraViewModel>();
            try
            {
                serrMapped = _mapper.Map<IList<ServidorEstadoReforcoRegraViewModel>>(serr.Data);
            }
            catch (Exception ex) { throw ex; }

            result.Data = serrMapped;
            result.Draw = serr.Draw;
            result._iRecordsDisplay = serr._iRecordsDisplay;
            result._iRecordsTotal = serr._iRecordsTotal;
            #endregion

            return result;
        }
        #endregion

        #region Methods that are not tenants
        public async Task<int> DeleteAsync(Guid id)
        {
            #region Required validations
            if (id == Guid.Empty) throw new ArgumentException("Id requerido.");
            #endregion

            #region Tenancy resolve
            Guid tenantId;
            try
            {
                tenantId = (Guid)StringHelpers.ExtractTenantId(await _tenantRepository.GetTenantIdAsync());
            }
            catch { throw; }
            
            if (tenantId == Guid.Empty)
                throw new Exception("Problemas ao obter a unidade. Tente novamente, persistindo o problema informa a equipe t??cnica do sistema.");
            #endregion

            #region Validations generals
            // get data
            var ruleDB = new ServidorEstadoReforcoRegra();
            try
            {
                ruleDB = await _serrRepository.GetByIdAsync(id);
            }   
            catch { throw; }
            
            if (ruleDB == null)
                throw new Exception("Regra n??o encontrada com o id informado para exclus??o.");
            
            // check if rule already used
            bool alreadyMarked;
            try
            {
                alreadyMarked = await _serRepository.AlreadyRuleSameMonthYear(ruleDB.Tenant.Id, Convert.ToInt32(ruleDB.MesRegra), ruleDB.DataPrimeiraJanela.Year);
                if (alreadyMarked)
                {
                    throw new Exception("N??o ?? poss??vel excluir uma regra de refor??o j?? utilizada para marca????o de refor??o.");
                }
            }
            catch { throw; }
            #endregion

            #region Delete and Commit
            try
            {
                _serrRepository.Remove(id);
            }
            catch { throw; }
            #endregion

            return await _unitOfWork.CommitAsync();
        }
        #endregion 
        
        public void Dispose()
        {
            _serrRepository.Dispose();
        }
    }
}