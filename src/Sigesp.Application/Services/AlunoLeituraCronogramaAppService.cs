using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using AutoMapper;
using Sigesp.Domain.Interfaces;
using Sigesp.Domain.Models;
using Sigesp.Application.Interfaces;
using Sigesp.Application.ViewModels;
using Sigesp.Application.Extensions;
using Sigesp.Infra.Data.Extensions;

namespace Sigesp.Application.Services
{
    public class AlunoLeituraCronogramaAppService : IAlunoLeituraCronogramaAppService
    {
        private readonly ValidationResult _validationResult;
        private readonly IAlunoLeituraCronogramaRepository _alunoLeituraCronogramaRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ITenantRepository _tenantRepository;

        public AlunoLeituraCronogramaAppService(ValidationResult validationResult,
                                                IAlunoLeituraCronogramaRepository alunoLeituraCronogramaRepository,
                                                IUnitOfWork unitOfWork, IMapper mapper,
                                                ITenantRepository tenantRepository)
        {
            _validationResult = validationResult;
            _alunoLeituraCronogramaRepository = alunoLeituraCronogramaRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _tenantRepository = tenantRepository;
        }

        #region Multitenants Methods
        public async Task<IEnumerable<AlunoLeituraCronogramaViewModel>> GetAllForSelect2Async()
        {
            IEnumerable<AlunoLeituraCronograma> result = new List<AlunoLeituraCronograma>();
            var tenantId = StringHelpers.ExtractTenantId(await _tenantRepository.GetTenantIdAsync());
            try
            {
                result = await _alunoLeituraCronogramaRepository
                                    .GetAllForSelect2Async((Guid) tenantId);
            }   
            catch { throw new Exception("Problemas ao obter uma UNIDADE PRISIONAL para o usuário logado. <br><br>Faça login novamente, caso o problema persista, informe a equipe técnica do sistema."); }
            IEnumerable<AlunoLeituraCronogramaViewModel> resultMapped = new List<AlunoLeituraCronogramaViewModel>();
            try
            {
                resultMapped = _mapper
                                    .Map<IEnumerable<AlunoLeituraCronogramaViewModel>>(result);
            }   
            catch { throw; }
            return resultMapped;
        }
        public async Task<ValidationResult> AddAsync(AlunoLeituraCronogramaViewModel alunoLeituraCronogramaViewModel)
        {
            try
            {
                #region Validações campo obrigatório
                if (alunoLeituraCronogramaViewModel.AnoReferencia.Length < 10
                    || alunoLeituraCronogramaViewModel.AnoReferencia.Length > 10)
                {
                    _validationResult.AddErrorMessage("Requerido 4 números para o ano referência.");
                    return _validationResult;
                }

                if (alunoLeituraCronogramaViewModel.PeriodoInicio.IsNullOrEmpty()
                    || alunoLeituraCronogramaViewModel.PeriodoInicio == "0001-01-01")
                {
                    _validationResult.AddErrorMessage("Período início requerido.");
                    return _validationResult;
                }

                if (alunoLeituraCronogramaViewModel.PeriodoFim.IsNullOrEmpty()
                    || alunoLeituraCronogramaViewModel.PeriodoFim == "0001-01-01")
                {
                    _validationResult.AddErrorMessage("Período fim requerido.");
                    return _validationResult;
                }

                if (alunoLeituraCronogramaViewModel.PeriodoReferencia.IsNullOrEmpty())
                {
                    _validationResult.AddErrorMessage("Período referência requerido.");
                    return _validationResult;
                }
                #endregion Validações campo obrigatório

                #region Validações - Não permitir ano diferente período início e fim e ano referência
                if (alunoLeituraCronogramaViewModel.AnoReferencia.Substring(0, 4)
                        != alunoLeituraCronogramaViewModel.PeriodoInicio.Substring(0, 4) ||
                    alunoLeituraCronogramaViewModel.AnoReferencia.Substring(0, 4)                   
                        != alunoLeituraCronogramaViewModel.PeriodoFim.Substring(0, 4) ||
                    alunoLeituraCronogramaViewModel.PeriodoInicio.Substring(0, 4)
                        != alunoLeituraCronogramaViewModel.PeriodoFim.Substring(0, 4))
                {
                    _validationResult.AddErrorMessage("Os anos dos PERÍODOS INÍCIO, FIM e ANO REFERÊNCIA não podem ser diferentes.");
                    return _validationResult;
                }
                #endregion Validações - Não permitir ano diferente periodo inicio e fim e ano referência

                #region Validação - Não permitir dias referência menor que 21
                if (!alunoLeituraCronogramaViewModel.DiasPeriodo.IsNullOrEmpty() &&
                    Convert.ToInt32(alunoLeituraCronogramaViewModel.DiasPeriodo) < 21)
                {
                    _validationResult.AddErrorMessage("Não é permitido período de leitura menor que 21 dias.");
                    return _validationResult;
                }
                #endregion Validação - Não permitir dias referência menor que 21

                #region Resolve Tenant
                var tenantId = StringHelpers.ExtractTenantId(await _tenantRepository.GetTenantIdAsync());
                #endregion

                #region Validação - Não permitir 2 cronogramas períodos identicos
                bool alreadyIdenticalPeriodo;
                try
                {
                    alreadyIdenticalPeriodo = await _alunoLeituraCronogramaRepository
                                                                .AlreadyIdenticalPeriodoAsync((Guid) tenantId, 
                                                                                              Convert.ToDateTime(alunoLeituraCronogramaViewModel.PeriodoInicio),    
                                                                                              Convert.ToDateTime(alunoLeituraCronogramaViewModel.PeriodoFim));                    
                }
                catch { throw; }
                
                if (alreadyIdenticalPeriodo)
                {
                    _validationResult.AddErrorMessage("Já existe um cronograma com o mesmo período início e fim informados.");
                    return _validationResult;
                }                   
                #endregion Validação - Não permitir 2 cronogramas períodos identicos

                #region Validação - Não permitir mais que 2 cronogramas mesmo mês e ano
                bool alreadyMoreTwoPeriodosInicioSameMesAno;
                try
                {
                    alreadyMoreTwoPeriodosInicioSameMesAno = await _alunoLeituraCronogramaRepository
                                                                         .AlreadyMoreTwoPeriodosInicioSameMesAnoAsync((Guid) tenantId,
                                                                                                                      Convert.ToDateTime(alunoLeituraCronogramaViewModel.PeriodoInicio));
                }
                catch { throw; }
                if (alreadyMoreTwoPeriodosInicioSameMesAno)
                {
                    _validationResult.AddErrorMessage("Já existem dois períodos início mesmo mês e ano.");
                    return _validationResult;
                }
                #endregion Validação - Não permitir mais que 2 cronogramas mesmo mês e ano

                #region Validação - Não permitir dois períodos referencia no mesmo ano
                bool alreadyMoreOnePeriodoReferenciaSameAno;
                try
                {
                    alreadyMoreOnePeriodoReferenciaSameAno = await _alunoLeituraCronogramaRepository
                                                                        .AlreadyMoreOnePeriodoReferenciaSameAnoAsync
                                                                        ((Guid) tenantId, Convert.ToDateTime(alunoLeituraCronogramaViewModel.PeriodoInicio), 
                                                                        Convert.ToInt32(alunoLeituraCronogramaViewModel.PeriodoReferencia));
                }
                catch { throw; }
                if (alreadyMoreOnePeriodoReferenciaSameAno)
                {
                    _validationResult.AddErrorMessage("Já existe um PERÍODO REFERÊNCIA para o ano do PERÍODO INÍCIO informado.");
                    return _validationResult;
                }
                #endregion Validação - Não permitir dpos períodos referencia no mesmo ano

                #region Mapeamento e persistência de dados
                var alunoLeituraCronogramaMapped = _mapper
                                                        .Map<AlunoLeituraCronograma>(alunoLeituraCronogramaViewModel);
                try
                {
                    alunoLeituraCronogramaMapped.TenantId = (Guid)tenantId;    
                }
                catch { throw; }
                _alunoLeituraCronogramaRepository.Add(alunoLeituraCronogramaMapped);
                #endregion Mapeamento e persistência de dados

                #region UnitOfwork - Commit
                _unitOfWork.Commit();
                #endregion

                return _validationResult;
            }
            catch { throw; }
        }
        public async Task<ValidationResult> UpdateAsync(AlunoLeituraCronogramaViewModel alunoLeituraCronogramaViewModel)
        {
            try
            {
                #region Validações campo obrigatório e existência de um registro ativo com o id informado
                if (alunoLeituraCronogramaViewModel.Id == Guid.Empty)
                {
                    _validationResult.AddErrorMessage("Id Requerido.");
                    return _validationResult;
                }

                var alcDB = _alunoLeituraCronogramaRepository
                                        .GetById((Guid) alunoLeituraCronogramaViewModel.Id);
                if (alcDB == null)
                {
                    _validationResult.AddErrorMessage("Nenhum registro encontrado para edição com o Id informado.");
                    return _validationResult;
                }

                if (alunoLeituraCronogramaViewModel.AnoReferencia.Length < 10
                    || alunoLeituraCronogramaViewModel.AnoReferencia.Length > 10)
                {
                    _validationResult.AddErrorMessage("Requerido 4 números para o ano referência.");
                    return _validationResult;
                }

                if (alunoLeituraCronogramaViewModel.PeriodoInicio.IsNullOrEmpty()
                    || alunoLeituraCronogramaViewModel.PeriodoInicio == "0001-01-01")
                {
                    _validationResult.AddErrorMessage("Período início requerido.");
                    return _validationResult;
                }

                if (alunoLeituraCronogramaViewModel.PeriodoFim.IsNullOrEmpty()
                    || alunoLeituraCronogramaViewModel.PeriodoFim == "0001-01-01")
                {
                    _validationResult.AddErrorMessage("Período fim requerido.");
                    return _validationResult;
                }

                if (alunoLeituraCronogramaViewModel.PeriodoReferencia.IsNullOrEmpty())
                {
                    _validationResult.AddErrorMessage("Período referência requerido.");
                    return _validationResult;
                }
                #endregion Validações campo obrigatório e existência de um registro ativo com o id informado

                #region Validações - Não permitir ano diferente período início e fim e ano referência
                if (alunoLeituraCronogramaViewModel.AnoReferencia.Substring(0, 4)
                        != alunoLeituraCronogramaViewModel.PeriodoInicio.Substring(0, 4) ||
                    alunoLeituraCronogramaViewModel.AnoReferencia.Substring(0, 4)                   
                        != alunoLeituraCronogramaViewModel.PeriodoFim.Substring(0, 4) ||
                    alunoLeituraCronogramaViewModel.PeriodoInicio.Substring(0, 4)
                        != alunoLeituraCronogramaViewModel.PeriodoFim.Substring(0, 4))
                {
                    _validationResult.AddErrorMessage("Os anos dos PERÍODOS INÍCIO, FIM e ANO REFERÊNCIA não podem ser diferentes.");
                    return _validationResult;
                }
                #endregion Validações - Não permitir ano diferente período início e fim e ano referência

                #region Validação - Não permitir dias referência menor que 21
                if (!alunoLeituraCronogramaViewModel.DiasPeriodo.IsNullOrEmpty() &&
                    Convert.ToInt32(alunoLeituraCronogramaViewModel.DiasPeriodo) < 21)
                {
                    _validationResult.AddErrorMessage("Não é permitido período de leitura menor que 21 dias.");
                    return _validationResult;
                }
                #endregion Validação - Não permitir dias referência menor que 21
                
                #region Resolve Tenancy
                var tenantId = StringHelpers.ExtractTenantId(await _tenantRepository.GetTenantIdAsync());
                #endregion

                #region Validação - Não permitir 2 cronogramas períodos identicos
                bool alreadyIdenticalPeriodo;
                try
                {
                    alreadyIdenticalPeriodo = await _alunoLeituraCronogramaRepository
                                                    .AlreadyIdenticalPeriodoAsync((Guid) tenantId, 
                                                            Convert.ToDateTime(alunoLeituraCronogramaViewModel.PeriodoInicio),
                                                            Convert.ToDateTime(alunoLeituraCronogramaViewModel.PeriodoFim));
                }
                catch { throw; }
                if (alreadyIdenticalPeriodo)
                {
                    _validationResult.AddErrorMessage("Já existe um cronograma com o mesmo período início e fim informados.");
                    return _validationResult;
                }                   
                #endregion Validação - Não permitir 2 cronogramas períodos identicos

                #region Validação - Não permitir mais que 2 cronogramas mesmo mês e ano
                bool alreadyMoreTwoPeriodosInicioSameMesAno;
                try
                {
                    alreadyMoreTwoPeriodosInicioSameMesAno = await _alunoLeituraCronogramaRepository
                                                                                .AlreadyMoreTwoPeriodosInicioSameMesAnoAsync((Guid) tenantId, 
                                                                                                                        Convert.ToDateTime(alunoLeituraCronogramaViewModel.PeriodoInicio));
                }
                catch { throw; }
                if (alreadyMoreTwoPeriodosInicioSameMesAno)
                {
                    _validationResult.AddErrorMessage("Já existem dois períodos início mesmo mês e ano.");
                    return _validationResult;
                }
                #endregion Validação - Não permitir mais que 2 cronogramas mesmo mês e ano

                #region Validação - Não permitir dpos períodos referencia no mesmo ano
                bool alreadyMoreOnePeriodoReferenciaSameAnoById;
                try
                {
                    alreadyMoreOnePeriodoReferenciaSameAnoById = await _alunoLeituraCronogramaRepository
                                                                            .AlreadyMoreOnePeriodoReferenciaSameAnoByIdAsync
                                                                                ((Guid) tenantId,
                                                                                (Guid) alunoLeituraCronogramaViewModel.Id,
                                                                                Convert.ToDateTime(alunoLeituraCronogramaViewModel.PeriodoInicio), 
                                                                                Convert.ToInt32(alunoLeituraCronogramaViewModel.PeriodoReferencia));
                }
                catch { throw; }
                if (alreadyMoreOnePeriodoReferenciaSameAnoById)
                {
                    _validationResult.AddErrorMessage("Já existe um PERÍODO REFERÊNCIA para o ano do PERÍODO INÍCIO informado.");
                    return _validationResult;
                }
                #endregion Validação - Não permitir dpos períodos referencia no mesmo ano

                #region Mapeamento e persistência de dados
                var alunoLeituraCronogramaMapped = new AlunoLeituraCronograma();
                try
                {
                    alunoLeituraCronogramaMapped = _mapper
                                                        .Map<AlunoLeituraCronogramaViewModel,
                                                             AlunoLeituraCronograma>(alunoLeituraCronogramaViewModel, alcDB);
                }
                catch { throw; }
                _alunoLeituraCronogramaRepository.Update(alunoLeituraCronogramaMapped);
                #endregion Mapeamento e persistência de dados

                #region UnitOfwork - Commit
                _unitOfWork.Commit();
                #endregion

                return _validationResult;
            }
            catch { throw; }
        }
        #endregion

        #region Methods is not multitenants
        #endregion

        #region Multitenancy outstanding methods
        public IEnumerable<AlunoLeituraCronogramaViewModel> GetAll()
        {
            var alunosLeiturasCronogramas = _mapper.Map<IEnumerable<AlunoLeituraCronogramaViewModel>>(
                                                _alunoLeituraCronogramaRepository.GetAll());
            return alunosLeiturasCronogramas;
        }
        public async Task<AlunoLeituraCronogramaViewModel> GetByIdAsync(string id)
        {
            try
            {
                if (id.IsNullOrEmpty())
                    throw new Exception("Id requerido");

                var alunoLeituraCronograma = await _alunoLeituraCronogramaRepository
                                                        .GetByIdAsync(Guid.Parse(id));
                var alunoLeituraCronogramaMapped = _mapper
                                                    .Map<AlunoLeituraCronogramaViewModel>(alunoLeituraCronograma);
            
                return alunoLeituraCronogramaMapped;    
            }
            catch { throw; }
        }
        public AlunoLeituraCronogramaViewModel GetByIdIncludes(string id)
        {
            try
            {
                if (id.IsNullOrEmpty())
                    throw new Exception("Id requerido");

                var alunoLeituraCronograma = _alunoLeituraCronogramaRepository.GetByIdIncludes(Guid.Parse(id));
                var alunoLeituraCronogramaMapped = _mapper
                                                    .Map<AlunoLeituraCronogramaViewModel>(alunoLeituraCronograma);
            
                return alunoLeituraCronogramaMapped;    
            }
            catch { throw; }
        }
        public async Task<IEnumerable<AlunoLeituraCronogramaViewModel>> GetAllAsync()
        {
            try
            {
                var alunoLeiturasCronogramas = await _alunoLeituraCronogramaRepository
                                                        .GetAllAsync();
                var alunoLeiturasCronogramasMapped = _mapper
                                                        .Map<IEnumerable<AlunoLeituraCronogramaViewModel>>(alunoLeiturasCronogramas);
            
                return alunoLeiturasCronogramasMapped;    
            }
            catch { throw; }
        }
        public async Task<IEnumerable<AlunoLeituraCronogramaViewModel>> GetAllAsyncIncludes()
        {
            try
            {
                var alunoLeiturasCronogramas  = await _alunoLeituraCronogramaRepository.GetAllAsync();
                var alunoLeiturasCronogramasMapped = _mapper
                                                     .Map<IEnumerable<AlunoLeituraCronogramaViewModel>>(alunoLeiturasCronogramas);

                return alunoLeiturasCronogramasMapped;    
            }
            catch { throw; }
        }
        public async Task<IEnumerable<AlunoLeituraCronogramaViewModel>> GetAllWithIncludeAsync()
        {
            var tenantId = StringHelpers.ExtractTenantId(await _tenantRepository.GetTenantIdAsync());
            IEnumerable<AlunoLeituraCronograma> alunoLeiturasCronogramas = new List<AlunoLeituraCronograma>();
            try
            {
                alunoLeiturasCronogramas = await _alunoLeituraCronogramaRepository
                                                    .GetAllWithIncludesAsync((Guid) tenantId);
                

                
            }
            catch { throw; }
            
            IEnumerable<AlunoLeituraCronogramaViewModel> alunoLeiturasCronogramasMapped = new List<AlunoLeituraCronogramaViewModel>();
            try
            {
                alunoLeiturasCronogramasMapped = _mapper
                                                        .Map<IEnumerable<AlunoLeituraCronogramaViewModel>>(alunoLeiturasCronogramas);
            }
            catch { throw; }
            return alunoLeiturasCronogramasMapped;
        }
        public ValidationResult Remove(Guid id)
        {
            try
            {
                _alunoLeituraCronogramaRepository.Remove(id);
                _unitOfWork.Commit();

                return _validationResult;
            }
            catch { throw; }
        }
        public async Task<Int64> GetTotalAtivosAsync()
        {
            var tenantId = StringHelpers.ExtractTenantId(await _tenantRepository.GetTenantIdAsync());
            Int64 ativos;
            try
            {
                ativos = await _alunoLeituraCronogramaRepository.GetTotalAtivosAsync((Guid) tenantId);
            }
            catch { throw; }
            return ativos;
        }
        public async Task<Int64> GetTotalInativosAsync()
        {
            Int64 inativos;
            var tenantId = StringHelpers.ExtractTenantId(await _tenantRepository.GetTenantIdAsync());
            try
            {
                inativos = await _alunoLeituraCronogramaRepository.GetTotalInativosAsync((Guid) tenantId);
            }
            catch { throw; }
            return inativos;
        }
        public async Task<Int64> GetTotalWithIgnoreQueryFilterAsync()
        {
            Int64 total;
            var tenantId = StringHelpers.ExtractTenantId(await _tenantRepository.GetTenantIdAsync());
            try
            {
                total = await _alunoLeituraCronogramaRepository.GetTotalWithIgnoreQueryFilterAsync((Guid) tenantId);
            }
            catch  { throw; }
            return total;
        }
        #endregion

        public void Dispose()
        {
            _alunoLeituraCronogramaRepository.Dispose();
        }
    }
}   