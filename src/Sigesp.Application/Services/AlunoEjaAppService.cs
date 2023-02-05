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
using Sigesp.Domain.Enums;
using Sigesp.Application.Helpers;
using Sigesp.Infra.Data.Extensions;
using Sigesp.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Sigesp.Application.Services
{
    public class AlunoEjaAppService : IAlunoEjaAppService
    {
        private readonly ValidationResult _validationResult;
        private readonly IAlunoEjaRepository _alunoEjaRepository;
        private readonly IAlunoRepository _alunoRepository;
        private readonly IDisciplinaRepository _disciplinaRepository;
        private readonly IAlunoEjaDisciplinaRepository _alunoEjaDisciplinaRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ITenantRepository _tenantRepository;
        private readonly SigespDbContext _context;

        public AlunoEjaAppService(ValidationResult validationResult,
                                    IAlunoEjaRepository alunoEjaRepository,
                                    IAlunoRepository alunoRepository,
                                    IDisciplinaRepository disciplinaRepository,
                                    IAlunoEjaDisciplinaRepository alunoEjaDisciplinaRepository,
                                    IUnitOfWork unitOfWork, 
                                    IMapper mapper,
                                    ITenantRepository tenantRepository,
                                    SigespDbContext context)
        {
            _validationResult = validationResult;
            _alunoEjaRepository = alunoEjaRepository;
            _alunoRepository = alunoRepository;
            _disciplinaRepository = disciplinaRepository;
            _alunoEjaDisciplinaRepository = alunoEjaDisciplinaRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _tenantRepository = tenantRepository;
            _context = context;
        }

        #region Tenants methods
        public async Task<IEnumerable<AlunoEjaViewModel>> GetAllAsync()
        {
            var tenantId = StringHelpers.ExtractTenantId(await _tenantRepository.GetTenantIdAsync());
            IEnumerable<AlunoEja> result = new List<AlunoEja>();
            try
            {
                result = await _alunoEjaRepository
                                    .GetAllAsync((Guid)tenantId);
            }
            catch { throw; }

            #region Mapper
            IEnumerable<AlunoEjaViewModel> resultMapped = new List<AlunoEjaViewModel>();
            try
            {
                resultMapped = _mapper.Map<IEnumerable<AlunoEjaViewModel>>(result);
            }
            catch { throw; }
            #endregion
            return resultMapped;
        }
        public async Task<ValidationResult> AddAsync(AlunoEjaViewModel alunoEjaViewModel)
        {
            try
            {
                //Regras pendentes
                //1 - Não posso ter 2 alunos ativos matriculados em cursos (medio, fundamental ...) diferentes
                //2 - Não posso ter 2 alunos ativos cursando disciplinas iguais no mesmo ou em cursos diferentes, na mesma fase ou em fases diferentes
                //3 - Não posso ter 2 alunos ativos matriculados em fases iguais no mesmo curso ou não
                //4 - Ao editar e informar ocorrência de desistência, alterar fase status para não incluída
                //5 - Ao importar EDI Detentos, e o detento foi embora, alterar fase status para não concluída e ocorrência desistência por egresso_via_edi
                //6 - 
                #region Required validations
                if (alunoEjaViewModel.DetentoIpen.IsNullOrEmpty())
                {
                    _validationResult.AddErrorMessage("Ipen aluno requerido.");
                }

                if (alunoEjaViewModel.DetentoNome.IsNullOrEmpty())
                {
                    _validationResult.AddErrorMessage("Nome aluno requerido.");
                }

                if (alunoEjaViewModel.TurnoPeriodo.IsNullOrEmpty())
                {
                    _validationResult.AddErrorMessage("Turno requerido.");
                }

                if (alunoEjaViewModel.Fase.IsNullOrEmpty())
                {
                    _validationResult.AddErrorMessage("Fase requerida.");
                }

                if (alunoEjaViewModel.Curso.IsNullOrEmpty())
                {
                    _validationResult.AddErrorMessage("Curso requerido.");
                }

                if (alunoEjaViewModel.AlunoEjaDisciplinas.IsNullOrEmpty()
                    || !alunoEjaViewModel.AlunoEjaDisciplinas.Any())
                {
                    _validationResult.AddErrorMessage("Ao menos uma disciplina é requerida.");
                }
                #endregion

                #region Valid data validations
                if (!DateHelpers.IsDateStringValid(alunoEjaViewModel.DataIngresso))
                {
                    _validationResult.AddErrorMessage("Data inválida.");
                }

                if (alunoEjaViewModel.DataIngresso == null 
                    || alunoEjaViewModel.DataIngresso == "0001-01-01")
                {
                    _validationResult.AddErrorMessage("Data requerida.");
                }                
                #endregion

                #region Get foreign keys
                var aluno = _alunoRepository
                                .GetByDetentoIpen(Convert.ToInt32(alunoEjaViewModel.DetentoIpen));
                if (aluno == null)
                {
                    _validationResult.AddErrorMessage("Nenhum aluno encontrado com o ipen informado.");
                }

                if (_validationResult.ErrorMessages != null 
                    && _validationResult.ErrorMessages.Any())
                {
                    return _validationResult;
                }
                #endregion

                #region Tenant resolve
                var tenantId = StringHelpers.ExtractTenantId(await _tenantRepository.GetTenantIdAsync());
                #endregion

                #region Mapper and persistence
                var alunoEjaMapped = new AlunoEja();
                try
                {
                    alunoEjaMapped = _mapper.Map<AlunoEja>(alunoEjaViewModel);
                }
                catch { throw; }
                
                alunoEjaMapped.TenantId = (Guid) tenantId;
                alunoEjaMapped.AlunoId = aluno.Id;

                try
                {
                    _alunoEjaRepository.Add(alunoEjaMapped);    
                }
                catch { throw; }
                #endregion

                #region Children object mapper
                foreach (var item in alunoEjaMapped.AlunoEjaDisciplinas)
                {
                    item.AlunoEjaId = alunoEjaMapped.Id;
                    try
                    {
                        _alunoEjaDisciplinaRepository.Add(item);
                    }
                    catch { throw; }
                }
                #endregion

                #region UnitOfwork - Commit
                _unitOfWork.Commit();
                #endregion

                return _validationResult;
            }
            catch { throw; }
        }
        public async Task<Int64> GetTotalInativosAsync()
        {
            var tenantId = StringHelpers.ExtractTenantId(await _tenantRepository.GetTenantIdAsync());
            Int64 inativos;

            try
            {
                inativos = await _alunoEjaRepository.GetTotalInativosAsync((Guid) tenantId);
            }
            catch { throw; }
            return inativos;
        }
        public async Task<Int64> GetTotalByFaseStatusAsync(AlunoEjaFaseStatusEnum faseStatus)
        {
            Int64 result;
            var tenantId = StringHelpers.ExtractTenantId(await _tenantRepository.GetTenantIdAsync());
            try
            {
                result = await _alunoEjaRepository
                                    .GetTotalByFaseStatusAsync((Guid) tenantId, faseStatus);
            }
            catch { throw; }            
            return result;
        }
        public async Task<Int64> GetTotalByCursoAsync(CursoEnum curso)
        {
            Int64 result;
            var tenantId = StringHelpers.ExtractTenantId(await _tenantRepository.GetTenantIdAsync());
            try
            {
                result = await _alunoEjaRepository
                                    .GetTotalByCursoAsync((Guid) tenantId, curso);
            }
            catch { throw; }
            return result;
        }
        public async Task<Int64> GetTotalByTurnoPeriodoAsync(TurnoEnum turnoPeriodo)
        {
            Int64 result;
            var tenantId = StringHelpers.ExtractTenantId(await _tenantRepository.GetTenantIdAsync());
            try
            {
                result = await _alunoEjaRepository
                                    .GetTotalByTurnoPeriodoAsync((Guid) tenantId, turnoPeriodo);
            }
            catch { throw; }
            return result;
        }
        #endregion

        public ValidationResult Update(AlunoEjaViewModel alunoEjaViewModel)
        {
            try
            {
                #region Required validations
                if (alunoEjaViewModel.Id ==  Guid.Empty)
                {
                    _validationResult.AddErrorMessage("Id requerido.");
                }

                if (alunoEjaViewModel.DetentoIpen.IsNullOrEmpty())
                {
                    _validationResult.AddErrorMessage("Ipen aluno requerido.");
                }

                if (alunoEjaViewModel.DetentoNome.IsNullOrEmpty())
                {
                    _validationResult.AddErrorMessage("Nome aluno requerido.");
                }

                if (alunoEjaViewModel.TurnoPeriodo.IsNullOrEmpty())
                {
                    _validationResult.AddErrorMessage("Turno requerido.");
                }

                if (alunoEjaViewModel.Fase.IsNullOrEmpty())
                {
                    _validationResult.AddErrorMessage("Fase requerida.");
                }

                if (alunoEjaViewModel.Curso.IsNullOrEmpty())
                {
                    _validationResult.AddErrorMessage("Curso requerido.");
                }

                if (alunoEjaViewModel.AlunoEjaDisciplinas.IsNullOrEmpty()
                    || !alunoEjaViewModel.AlunoEjaDisciplinas.Any())
                {
                    _validationResult.AddErrorMessage("Ao menos uma disciplina é requerida.");
                }

                if (alunoEjaViewModel.DataIngresso == null 
                    || alunoEjaViewModel.DataIngresso == "0001-01-01")
                {
                    _validationResult.AddErrorMessage("Data requerida.");
                }

                var aluno = _alunoRepository
                                .GetByDetentoIpen(Convert.ToInt32(alunoEjaViewModel.DetentoIpen));
                if (aluno == null)
                {
                    _validationResult.AddErrorMessage("Nenhum aluno encontrado com o ipen informado.");
                }

                var alunoEjaForUpdate = _context
                                            .AlunosEja
                                            .IgnoreQueryFilters()
                                            .Include(x => x.AlunoEjaDisciplinas)
                                            .FirstOrDefault(x => x.Id == alunoEjaViewModel.Id);
                if (alunoEjaForUpdate == null)
                {
                    _validationResult.AddErrorMessage("Nenhum aluno eja encontrado para atualizar.");
                }

                if (_validationResult.ErrorMessages != null 
                    && _validationResult.ErrorMessages.Any())
                {
                    return _validationResult;
                }
                #endregion

                #region type check update
                /// if has ocorrencia desistência deactive alunoEja and faseStatus,
                /// disciplinas, change and update dataOcorrencia
                if (alunoEjaViewModel.EjaOcorrenciaDesistencia != null &&
                    alunoEjaViewModel.EjaOcorrenciaDesistencia != AlunoLeitorOcorrenciaDesistenciaEnum.NENHUMA.ToString())
                {
                    alunoEjaViewModel.IsDeleted = true;
                    alunoEjaViewModel.FaseStatus = AlunoEjaFaseStatusEnum.NAO_CONCLUIDA.ToString();
                    foreach (var disciplina in alunoEjaViewModel.AlunoEjaDisciplinas)
                    {
                        disciplina.Conceito = AlunoEjaDisciplinaConceitoEnum.REPROVADO;
                    }
                }
                #endregion

                #region Map main and childrean
                alunoEjaViewModel.Id = alunoEjaForUpdate.Id;
                alunoEjaViewModel.AlunoId = aluno.Id;

                //remove all chilfreans before mapped object main
                foreach (var item in alunoEjaForUpdate.AlunoEjaDisciplinas.ToList())
                {
                    _alunoEjaDisciplinaRepository.Remove(item.Id);
                    alunoEjaForUpdate.AlunoEjaDisciplinas.Remove(item);
                }

                var alunoEjaMapped = _mapper
                                        .Map<AlunoEjaViewModel, 
                                             AlunoEja>(alunoEjaViewModel, alunoEjaForUpdate);

                //add new childreans before persistence object main
                foreach (var item in alunoEjaMapped.AlunoEjaDisciplinas)
                {
                    item.AlunoEjaId = alunoEjaMapped.Id;
                }

                _alunoEjaRepository.Update(alunoEjaMapped);
                #endregion

                #region UnitOfwork - Commit
                _unitOfWork.Commit();
                #endregion

                return _validationResult;
            }
            catch { throw; }
        }
        public ValidationResult UpdateWithoutCommitFromEdiDetentos(Guid id)
        {
            try
            {
                #region Validações campos obrigatórios
                if (id ==  Guid.Empty)
                {
                    _validationResult.AddErrorMessage("Id requerido.");
                }

                var alunoEjaForUpdate = _context
                                            .AlunosEja
                                            .IgnoreQueryFilters()
                                            .FirstOrDefault(x => x.Id == id);

                alunoEjaForUpdate = null;

                if (alunoEjaForUpdate == null)
                {
                    _validationResult.AddErrorMessage("Nenhum aluno eja encontrado para atualizar.");
                }

                if (_validationResult.ErrorMessages != null 
                    && _validationResult.ErrorMessages.Any())
                {
                    return _validationResult;
                }
                #endregion Validações campos obrigatórios

                #region Mapeamento dos objetos
                alunoEjaForUpdate.FaseStatus = AlunoEjaFaseStatusEnum.NAO_CONCLUIDA;
                alunoEjaForUpdate.EjaOcorrenciaDesistencia = AlunoLeitorOcorrenciaDesistenciaEnum.EGRESSO;
                alunoEjaForUpdate.DataOcorrenciaDesistencia = DateTime.Now;

                _alunoEjaRepository.Update(alunoEjaForUpdate);
                #endregion Mapeamento dos objetos

                return _validationResult;
            }
            catch { throw; }
        }
        public ValidationResult Remove(Guid id)
        {
            try
            {
                _alunoEjaRepository.Remove(id);
                _unitOfWork.Commit();

                return _validationResult;
            }
            catch { throw; }
        }
        
        public void Dispose()
        {
            _alunoEjaRepository.Dispose();
        }
    }
}