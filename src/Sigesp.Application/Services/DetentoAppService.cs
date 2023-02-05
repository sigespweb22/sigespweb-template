using System.Linq;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using AutoMapper;
using Sigesp.Domain.Interfaces;
using Sigesp.Domain.Models;
using Sigesp.Application.Interfaces;
using Sigesp.Application.ViewModels;
using Sigesp.Application.Extensions;
using Sigesp.Application.ViewModels.Selects;
using Sigesp.Domain.Enums;
using Sigesp.Application.ViewModels.Reports;
using Sigesp.Domain.Models.DataTable;
using Sigesp.Infra.Data.Extensions;
using Sigesp.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Sigesp.Application.Services
{
    public class DetentoAppService : IDetentoAppService
    {
        private readonly ValidationResult _validationResult;
        private readonly IDetentoRepository _detentoRepository;
        private readonly IListaAmarelaRepository _listaAmarelaRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ITenantRepository _tenantRepository;
        private readonly SigespDbContext _context;

        public DetentoAppService(ValidationResult validationResult,
                                IDetentoRepository detentoRepository,
                                IListaAmarelaRepository listaAmarelaRepository,
                                IUnitOfWork unitOfWork, IMapper mapper,
                                ITenantRepository tenantRepository,
                                SigespDbContext context)
        {
            _validationResult = validationResult;
            _detentoRepository = detentoRepository;
            _listaAmarelaRepository = listaAmarelaRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _tenantRepository = tenantRepository;
            _context = context;
        }
        public async Task<IEnumerable<DetentoViewModel>> GetAIFullAsync()
        {
            try
            {
                var dtAIFull = await _detentoRepository
                                        .GetAIFullAsync();
                IEnumerable<DetentoViewModel> dtsMapped = new List<DetentoViewModel>();
                if (dtAIFull != null)
                {
                    dtsMapped = _mapper
                                    .Map<IEnumerable<DetentoViewModel>>(dtAIFull);
                }
                return dtsMapped;
            }
            catch { throw; }
        }
        public async Task<DetentoViewModel> GetByNomeAsync(string nome)
        {
            var detento = await _detentoRepository.GetByNomeAsync(nome);
            var detentoMapped = new DetentoViewModel();

            if (detento != null)
                detentoMapped = _mapper.Map<DetentoViewModel>(detento);

            return detentoMapped;
        }
        public DetentoViewModel GetByNome(string nome)
        {
            var detento = _detentoRepository.GetByNome(nome);
            var detentoMapped = new DetentoViewModel();

            if (detento != null)
                detentoMapped = _mapper.Map<DetentoViewModel>(detento);

            return detentoMapped;
        }
        public async Task<IEnumerable<DetentoViewModel>> GetAllByNomeAsync(string nome)
        {
            var detentos = await _detentoRepository.GetAllByNomeAsync(nome);
            var detentosMapped = new List<DetentoViewModel>();

            if (detentos.Count() > 0)
                detentosMapped = _mapper.Map<IEnumerable<DetentoViewModel>>(detentos).ToList();

            return detentosMapped;
        }
        public async Task<DetentoForNovoViewModel> GetDetentoDataByIdAsync(string id)
        {
            var detento = await _detentoRepository.GetByIdAsync(Guid.Parse(id));
            var detentoMap = _mapper.Map<DetentoForNovoViewModel>(detento);
            return detentoMap;
        }
        public string GetDetentoRegimeByNome(string nome)
        {
            var detentoRegime = _detentoRepository.GetRegimeByNomeAsync(nome);
            return detentoRegime.ToString();
        }
        public async Task<string> GetIpenByNomeAsync(string nome)
        {
            try
            {
                Int64 detentoIpen = 0;
                detentoIpen = await _detentoRepository
                                        .GetIpenByNomeAsync(nome);
                
                return detentoIpen.ToString();
            }
            catch { throw; }
        }
        public async Task<DetentoViewModel> GetIpenAndGaleriaByNomeAsync(string detentoNome)
        {
            var detentoIpenAndGaleria = await _detentoRepository
                                                .GetIpenAndGaleriaByNomeAsync(detentoNome);

            var detentoIpenAndGaleriaMapped = _mapper.Map<DetentoViewModel>(detentoIpenAndGaleria);
            return detentoIpenAndGaleriaMapped;
        }
        public DetentoViewModel GetIpenAndRegimeByColaboradorId(string colaboradorId)
        {
            try
            {
                if (string.IsNullOrEmpty(colaboradorId))
                    throw new ArgumentException("Id do colaborador requerido");

                var detentoIpenAndRegime = _detentoRepository
                                                        .GetIpenAndRegimeByColaboradorId(colaboradorId);

                var detentoIpenAndRegimeMapped = _mapper.Map<DetentoViewModel>(detentoIpenAndRegime);
                return detentoIpenAndRegimeMapped;    
            }
            catch { throw; }
        }
        public async Task<DetentoViewModel> GetIpenAndRegimeByNomeAsync(string detentoNome)
        {
            var detentoIpenAndRegime = await _detentoRepository
                                                .GetIpenAndRegimeByNomeAsync(detentoNome);
            
            var detentoIpenAndRegimeMapped = _mapper.Map<DetentoViewModel>(detentoIpenAndRegime);
            return detentoIpenAndRegimeMapped;
        }
        public async Task<string> GetIpenByIdAsync(string id)
        {
            try
            {
                if (string.IsNullOrEmpty(id))
                    throw new ArgumentException("Id requerido");

                var detentoIpen = await _detentoRepository
                                            .GetIpenByIdAsync(id);
                return detentoIpen.ToString();
            }
            catch { throw; }
        }
        public async Task<Generic2Select2ViewModel> GetByIpenOrNomeAsync(string property,
                                                                         string arg)
        {
            try
            {
                if (string.IsNullOrEmpty(property) ||
                    string.IsNullOrEmpty(arg))
                    throw new ArgumentException("Parâmetros requeridos");

                var detentoIdAndNome = await _detentoRepository
                                                .GetIdAndNomeByIpenOrNomeAsync(property, arg);
                var detentoSelect2Result = new Generic2Select2ViewModel()
                {
                    Id = detentoIdAndNome.Id.ToString(),
                    Nome = detentoIdAndNome.Nome
                };  

                return detentoSelect2Result;    
            }
            catch { throw; }
        }
        public async Task<IEnumerable<DetentoViewModel>> GetAllOnlyIsDeletedTrueAsync()
        {
            var detentos = _mapper.Map<IEnumerable<DetentoViewModel>>(
                                     await _detentoRepository.GetAllOnlyIsDeletedTrueAsync());
            return detentos;
        }
        public async Task<IEnumerable<DetentoViewModel>> GetAllAsync()
        {
            try
            {
                var detentos = _mapper.Map<IEnumerable<DetentoViewModel>>(
                                     await _detentoRepository.GetAllAsync());
                return detentos;    
            }
            catch { throw; }
        }
        public IEnumerable<DetentoViewModel> GetAll()
        {
            try
            {
                var detentos = _detentoRepository
                                    .GetAll();
                var detentosMapped = new List<DetentoViewModel>();

                if (detentos != null && detentos.Count() > 0)
                {
                    detentosMapped = _mapper
                                        .Map<IEnumerable<DetentoViewModel>>(detentos).ToList();
                }
                return detentosMapped; 
            }
            catch { throw; }
        }
        public async Task<IEnumerable<DetentoViewModel>> GetAllWithInactiveAsync()
        {
            var detentos = _mapper.Map<IEnumerable<DetentoViewModel>>(
                                    await _detentoRepository.GetAllWithInactiveAsync());
            return detentos;
        }
        public async Task<ValidationResult> AddAsync(DetentoViewModel detentoViewModel)
        {               
            try
            {
                #region Validações de requerimento
                if (detentoViewModel.Ipen == null)
                {
                    _validationResult.AddErrorMessage("Ipen requerido!");
                    return _validationResult;
                }
                #endregion Validações de requerimento

                #region Resolve tenancy
                var tenantId = StringHelpers.ExtractTenantId(await _tenantRepository.GetTenantIdAsync());
                if (tenantId == null || tenantId == Guid.Empty)
                {
                    _validationResult.AddErrorMessage("Problemas ao obter os dados da UNIDADE PRISIONAL para finalizar o cadastrado. <br><br>Tente novamente, caso o problema persista informe o suporte técnico do sistema.");
                    return _validationResult;
                }
                #endregion

                #region Validações de duplicidade - Check only in my tenancy
                var alreadyAtivo = _detentoRepository
                                            .IsAlreadyByIpen(Convert.ToInt32(detentoViewModel.Ipen), (Guid) tenantId);
                if (alreadyAtivo)
                {
                    _validationResult.AddErrorMessage("Detento já cadastrado e ativo com o IPEN informado.");
                    return _validationResult;
                }
                #endregion Validações de duplicidade - Verifica em todas as tenancias

                #region Check if it exists in a different tenancy than mine.
                bool checkAlreadyTenancyDiff;
                try
                {
                    checkAlreadyTenancyDiff = await _detentoRepository.CheckAlreadyTenancyDiff(Convert.ToInt32(detentoViewModel.Ipen), (Guid)tenantId);
                    if (checkAlreadyTenancyDiff)
                        throw new Exception("Detento pertence a outra unidade");
                } catch (Exception ex) { throw ex; }
                #endregion

                #region Verificação de registro existente inativo para ativação - Verifica tem todas as tenancias
                var detentoForAdd = await _detentoRepository
                                                .GetInativoAsync(Convert.ToInt32(detentoViewModel.Ipen));
                if (detentoForAdd == null)
                {
                    var detentoNew = _mapper.Map<Detento>(detentoViewModel);
                    detentoNew.MatriculaFamiliar = RandomExtensions.GenerateIntMaxLength6();

                    detentoNew.TenantId = (Guid)tenantId;
                    _detentoRepository.Add(detentoNew);
                }
                else
                {
                    detentoForAdd.IsDeleted = false;
                    detentoForAdd.TenantId = (Guid)tenantId;
                    _detentoRepository.Update(detentoForAdd);
                }
                #endregion

                _unitOfWork.Commit();                
                return _validationResult;
            }
            catch { throw; }
        }
        public void Remove(Guid id)
        {
            #region Remove Detento
            _detentoRepository.Remove(id);
            #endregion

            #region Update entidades relacionadas
            // Colaborador
            var colaborador = new Colaborador();
            try
            {
                colaborador = _context
                                    .Colaboradores
                                    .FirstOrDefault(x => x.DetentoId == id);
            }
            catch { throw; }
            if (colaborador != null)
            {
                colaborador.IsDeleted = true;
                colaborador.Situacao = ColaboradorSituacaoEnum.DEMITIDO;
                colaborador.DemissaoOcorrencia = ColaboradorDemissaoOcorrenciaEnum.DEMISSAO_VIA_SISTEMA;
                colaborador.DemissaoObservacao = "Houve o egresso do DETENTO manualmente, o que por sua vez gerou a inativação do colaborador automaticamente.";
                colaborador.DemissaoData = DateTime.Now;

                _context.Colaboradores.Remove(colaborador);
            }

            // Aluno
            var aluno = new Aluno();
            try
            {
                aluno = _context
                            .Alunos
                            .FirstOrDefault(x => x.DetentoId == id);
            }
            catch { throw; }
            if (aluno != null)
            {
                aluno.IsDeleted = true;
                _context.Alunos.Remove(aluno);
            }
            
            // AlunoEja
            var alunosEja = new List<AlunoEja>();
            try
            {
                alunosEja = _context
                            .AlunosEja
                            .Include(x => x.AlunoEjaDisciplinas)
                            .Where(x => x.Aluno.DetentoId == id).ToList();
            }
            catch { throw; }
            if (alunosEja != null && alunosEja.Count() > 0)
            {
                foreach (var alunoEja in alunosEja)
                {
                    alunoEja.FaseStatus = AlunoEjaFaseStatusEnum.NAO_CONCLUIDA;
                    alunoEja.EjaOcorrenciaDesistencia = AlunoLeitorOcorrenciaDesistenciaEnum.EGRESSO;
                    alunoEja.DataOcorrenciaDesistencia = DateTime.Now;
                    alunoEja.IsDeleted = true;    

                    foreach (var alunoEjaDisciplina in alunoEja.AlunoEjaDisciplinas)
                    {
                        alunoEjaDisciplina.Conceito = AlunoEjaDisciplinaConceitoEnum.REPROVADO;
                    }
                    _context.Alunos.Update(aluno);
                }
            }

            // AlunoLeitor
            var alunoLeitor = new AlunoLeitor();
            try
            {
                alunoLeitor = _context
                                .AlunosLeitores
                                .FirstOrDefault(x => x.Aluno.DetentoId == id);
            }
            catch { throw; }
            if (alunoLeitor != null)
            {
                alunoLeitor.OcorrenciaDesistencia = AlunoLeitorOcorrenciaDesistenciaEnum.EGRESSO;
                alunoLeitor.DataOcorrenciaDesistencia = DateTime.Now;
                alunoLeitor.IsDeleted = true;

                _context.AlunosLeitores.Update(alunoLeitor);
            }
            #endregion
            
            #region Commmit
            _unitOfWork.Commit();
            #endregion
        }
        public ValidationResult Update(DetentoViewModel detentoViewModel)
        {
            try
            {
                #region Validações gerais
                if (detentoViewModel.Id == null ||
                    detentoViewModel.Id == Guid.Empty)
                {
                    _validationResult.AddErrorMessage("Id requerido");
                    return _validationResult;
                }
                #endregion Validações gerais
                
                #region Obter registro e fazer o mapeamento
                var detentoForUpdate = _detentoRepository
                                            .GetById((Guid) detentoViewModel.Id);
                if (detentoForUpdate == null)
                {
                    _validationResult.AddErrorMessage("Nenhum detento encontrado com o ID informado");
                    return _validationResult;
                }

                detentoViewModel.TenantId = detentoForUpdate.TenantId;
                var detentoMapper = _mapper
                                        .Map<DetentoViewModel, Detento>(detentoViewModel, detentoForUpdate);
            
                _detentoRepository.Update(detentoMapper);
                #endregion Obter registro e fazer o mapeamento
                
                #region Commit
                _unitOfWork.Commit();
                #endregion Commit

                return _validationResult;
            }
            catch { throw; }
        }
        public async Task<DetentoViewModel> TransferByIpenAsync(DetentoViewModel detentoViewModel)
        {
            try
            {
                var detento = await _detentoRepository
                                        .GetByIpenIgnoreQueryFiltersAsync(Convert.ToInt32(detentoViewModel.Ipen));
                
                detento.IsDeleted = true;
                detento.Regime = DetentoRegimeEnum.TRANSFERIDO;
                detento.TransferenciaLocal = detentoViewModel.TransferenciaLocal;
                detento.TransferenciaDataSaida = Convert.ToDateTime(detentoViewModel.TransferenciaDataSaida);
                detento.TransferenciaDataRetornoPrevisto = Convert.ToDateTime(detentoViewModel.TransferenciaDataRetornoPrevisto);
                detento.TransferenciaTipo = (TransferenciaTipoEnum)Enum.Parse(typeof(TransferenciaTipoEnum), detentoViewModel.TransferenciaTipo);

                _detentoRepository.Update(detento);

                if (detentoViewModel.TransferenciaTipo == TransferenciaTipoEnum.MEDIDA_DISCIPLINAR.ToString())
                {
                    var listaAmarelaId = _listaAmarelaRepository.GetIdByDetentoIpen(detento.Ipen);
                    _listaAmarelaRepository.Remove(listaAmarelaId);
                }

                _unitOfWork.Commit();

                return _mapper.Map<DetentoViewModel>(detento);
            }
            catch (System.Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
        public async Task<DetentoViewModel> GetForModalTransferenciaAsync(string ipen)
        {
            try
            {
                if (string.IsNullOrEmpty(ipen))
                    throw new ArgumentException("Ipen requerido");

                var detento = await _detentoRepository
                                    .GetByIpenIgnoreQueryFiltersAsync(Convert.ToInt32(ipen));

                return _mapper.Map<DetentoViewModel>(detento);    
            }
            catch { throw; }
        }
        public async Task<int> TotalMDAsync()
        {
            var totalMD = await _detentoRepository.TotalMDAsync();
            return totalMD;
        }
        public int TotalInstrumentoPrisaoMD()
        {
            var totalInstrumentoPrisaoMD = _detentoRepository.TotalInstrumentoPrisaoMD();
            return totalInstrumentoPrisaoMD;
        }
        public async Task<int> TotalEmAudienciaAsync()
        {
            var totalEmAudiencia = await _detentoRepository.TotalEmAudienciaAsync();
            return totalEmAudiencia;
        }
        public IEnumerable<DetentoViewModel> GetAllByFilterReportTransferidos(ListaAmarelaFilterReportTransferidosViewModel listaAmarelaFilterReportTransferidosViewModel)
        {
            IEnumerable<Detento> detentos = new List<Detento>();

            var transferenciaTipoMapped = 
                    listaAmarelaFilterReportTransferidosViewModel.TransferenciaTipo != null ? (TransferenciaTipoEnum)Enum.Parse(typeof(TransferenciaTipoEnum), listaAmarelaFilterReportTransferidosViewModel.TransferenciaTipo, true) : 0;

            //Filtro 1 - Possui TransferenciaTipo + data saída
            if (transferenciaTipoMapped != 0 && 
                    listaAmarelaFilterReportTransferidosViewModel.DataSaidaPeriodoInicioReportTransferidos != null)
            {
                detentos = _detentoRepository
                                    .GetAllByTransferenciaTipoDataSaida(transferenciaTipoMapped, 
                                                                        Convert.ToDateTime(listaAmarelaFilterReportTransferidosViewModel.DataSaidaPeriodoInicioReportTransferidos),
                                                                        Convert.ToDateTime(listaAmarelaFilterReportTransferidosViewModel.DataSaidaPeriodoFimReportTransferidos)).ToList();
            }
            //Filtro 2 - Possui TransferenciaTipo + data retorno previsto
            else if (transferenciaTipoMapped != 0 && listaAmarelaFilterReportTransferidosViewModel.DataRetornoPrevistoPeriodoInicioReportTransferidos != null)
            {
                detentos = _detentoRepository
                                    .GetAllByTransferenciaTipoDataRetornoPrevisto(transferenciaTipoMapped, 
                                                                    Convert.ToDateTime(listaAmarelaFilterReportTransferidosViewModel.DataRetornoPrevistoPeriodoInicioReportTransferidos),
                                                                    Convert.ToDateTime(listaAmarelaFilterReportTransferidosViewModel.DataRetornoPrevistoPeriodoFimReportTransferidos)).ToList();
            }
            //Filtro 3 - Não possui TransferenciaTipo + possui data saída
            else if (transferenciaTipoMapped == 0
                && listaAmarelaFilterReportTransferidosViewModel.DataSaidaPeriodoInicioReportTransferidos != null)
            {
                detentos = _detentoRepository
                                    .GetAllByDataSaida(
                                                    Convert.ToDateTime(listaAmarelaFilterReportTransferidosViewModel.DataSaidaPeriodoInicioReportTransferidos),
                                                    Convert.ToDateTime(listaAmarelaFilterReportTransferidosViewModel.DataSaidaPeriodoFimReportTransferidos)).ToList();
            }
            //Filtro 4 - Não possui TransferenciaTipo + possui data retorno previsto
            else if (transferenciaTipoMapped == 0
                && listaAmarelaFilterReportTransferidosViewModel.DataRetornoPrevistoPeriodoInicioReportTransferidos != null)
            {
               detentos = _detentoRepository
                                    .GetAllByDataRetornoPrevisto(
                                                    Convert.ToDateTime(listaAmarelaFilterReportTransferidosViewModel.DataRetornoPrevistoPeriodoInicioReportTransferidos),
                                                    Convert.ToDateTime(listaAmarelaFilterReportTransferidosViewModel.DataRetornoPrevistoPeriodoFimReportTransferidos)).ToList();
            }
            //Filtro 5 - Possui TransferenciaTipo + nenhuma data
            else if (transferenciaTipoMapped != 0
                    && listaAmarelaFilterReportTransferidosViewModel.DataSaidaPeriodoInicioReportTransferidos == null
                    && listaAmarelaFilterReportTransferidosViewModel.DataRetornoPrevistoPeriodoInicioReportTransferidos == null)
            {
                detentos = _detentoRepository
                                    .GetAllByTransferenciaTipo(transferenciaTipoMapped).ToList();
            }
            //Filtro 6 - Não possui TransferenciaTipo + nenhuma data
            else
            {
                detentos = _detentoRepository
                                    .GetAllTransferidos();
            }

            var detentosMapped = new List<DetentoViewModel>();
            if (detentos != null & detentos.Count() > 0)
                detentosMapped = _mapper.Map<IEnumerable<DetentoViewModel>>(detentos).ToList();

            return detentosMapped;
        }
        public async Task<IEnumerable<DetentoViewModel>> GetAllByRegimeAsync(string regime)
        {
            try
            {
                DetentoRegimeEnum regimeParsed = DetentoRegimeEnum.NENHUM;
                if (!string.IsNullOrEmpty(regime))
                    Enum.TryParse<DetentoRegimeEnum>(regime, out regimeParsed);
                
                var detentos = await _detentoRepository
                                        .GetAllByRegimeAsync(regimeParsed);
                return _mapper.Map<IEnumerable<DetentoViewModel>>(detentos);    
            }
            catch { throw; }
        }
        public IEnumerable<DetentoViewModel> GetAllByRegime(string regime)
        {
            try
            {
                DetentoRegimeEnum regimeParsed = DetentoRegimeEnum.NENHUM;
                if (!string.IsNullOrEmpty(regime))
                    Enum.TryParse<DetentoRegimeEnum>(regime, out regimeParsed);
                
                var detentos = _detentoRepository
                                        .GetAllByRegime(regimeParsed);
                return _mapper.Map<IEnumerable<DetentoViewModel>>(detentos);    
            }
            catch { throw; }
        }
        public bool IsAlreadyByIpen(int ipen)
        {
            try
            {
                if (ipen == 0)
                    throw new ArgumentException("Ipen requerido");
                    
                return _detentoRepository.IsAlreadyByIpen(ipen);    
            }
            catch { throw; }
        }
        public async Task<DetentoViewModel> GetByIpenAsync(int ipen)
        {
            try
            {
                var detento = await _detentoRepository
                                    .GetByIpenAsync(ipen);
                return _mapper.Map<DetentoViewModel>(detento);
            }
            catch { throw; }
            
        }
        public async Task<DetentoViewModel> GetIpenRegimeByNomeAsync(string nome)
        {
            try
            {
                if (string.IsNullOrEmpty(nome))
                    throw new ArgumentException("Nome requerido");

                var detento = await _detentoRepository.GetIpenRegimeByNomeAsync(nome);
                var detentoMapped = _mapper.Map<DetentoViewModel>(detento);

                return detentoMapped;    
            }
            catch { throw; }
        }
        public async Task<DetentoViewModel> GetForEditByIpenAsync(string ipen)
        {
            try
            {
                if (string.IsNullOrEmpty(ipen))
                    throw new ArgumentException("Ipen requerido");

                var detento = await _detentoRepository.GetForEditByIpenAsync(Convert.ToInt32(ipen));
                var detentoMapped = _mapper.Map<DetentoViewModel>(detento);

                return detentoMapped;
            }
            catch { throw; }
        }
        public async Task<Int64> GetTotalAtivosAsync()
        {
            try
            {
                var result = await _detentoRepository
                                    .GetTotalAtivosAsync();
                return result;    
            }
            catch { throw; }
        }
        public async Task<DataTableServerSideResult<DetentoViewModel>> GetWithDataTableResultAsync(DataTableServerSideRequest request)
        {
            try
            {
                var detentos = await _detentoRepository
                                        .GetWithDataTableResultAsync(request);

                var result = new DataTableServerSideResult<DetentoViewModel>();
                var detentosMapped = _mapper
                                        .Map<IEnumerable<DetentoViewModel>>(detentos.Data);
                
                result.Data = detentosMapped.ToList();
                result.Draw = detentos.Draw;
                result._iRecordsDisplay = detentos._iRecordsDisplay;
                result._iRecordsTotal = detentos._iRecordsTotal;

                return result;
            }
            catch { throw; }
        }
        public async Task<int> ChangeTenancyAsync(string ipen)
        {
            #region Required validations
            if (string.IsNullOrEmpty(ipen))
                throw new ArgumentException("Ipen requerido.");
            #endregion

            #region Tenancy resolve
            Guid tenantId;
            try
            {
                tenantId = (Guid) StringHelpers.ExtractTenantId(await _tenantRepository.GetTenantIdAsync());
            }
            catch (Exception ex) { throw ex; }
            #endregion

            try
            {
                var detento = _detentoRepository.GetByIpen(Convert.ToInt32(ipen));
                if (detento == null)
                    throw new Exception("Detento não encotrado com o IPEN informado. Tente novamente mais tarde. Caso persista o problema informe a equipe técnica do sistema.");
                
                detento.TenantId = tenantId;
                _detentoRepository.Update(detento);
            }
            catch (Exception ex) { throw ex; }
            return await _unitOfWork.CommitAsync();
        }
        
        public void Dispose()
        {
            _detentoRepository.Dispose();
        }
    }
}