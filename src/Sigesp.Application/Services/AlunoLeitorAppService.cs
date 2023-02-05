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
using Sigesp.Domain.Models.DataTable;
using Sigesp.Infra.Data.Extensions;
using Sigesp.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Sigesp.Application.Services
{
    public class AlunoLeitorAppService : IAlunoLeitorAppService
    {
        private readonly SigespDbContext _context;
        private readonly ValidationResult _validationResult;
        private readonly IAlunoLeitorRepository _alunoLeitorRepository;
        private readonly IAlunoRepository _alunoRepository;
        private readonly IProfessorRepository _professorRepository;
        private readonly ILivroGeneroRepository _livroGeneroRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IDetentoRepository _detentoRepository;
        private readonly ITenantRepository _tenantRepository;

        public AlunoLeitorAppService(ValidationResult validationResult,
                                    IAlunoLeitorRepository alunoLeitorRepository,
                                    IAlunoRepository alunoRepository,
                                    IProfessorRepository professorRepository,
                                    ILivroGeneroRepository livroGeneroRepository,
                                    IUnitOfWork unitOfWork, IMapper mapper,
                                    IDetentoRepository detentoRepository,
                                    ITenantRepository tenantRepository,
                                    SigespDbContext context)
        {
            _validationResult = validationResult;
            _alunoLeitorRepository = alunoLeitorRepository;
            _alunoRepository = alunoRepository;
            _professorRepository = professorRepository;
            _livroGeneroRepository = livroGeneroRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _detentoRepository = detentoRepository;
            _tenantRepository = tenantRepository;
            _context = context;
        }

        public async Task<IEnumerable<AlunoLeitorViewModel>> GetAllAsync()
        {
            #region Tenant resolve
            var tenantId = StringHelpers.ExtractTenantId(await _tenantRepository.GetTenantIdAsync());
            IEnumerable<AlunoLeitor> als = new List<AlunoLeitor>();
            try
            {
                als = await _alunoLeitorRepository
                                        .GetAllAsync((Guid) tenantId);
            }
            catch { throw; }
            #endregion

            #region Mapeamento
            IEnumerable<AlunoLeitorViewModel> alunosLeitoresViewModel = new List<AlunoLeitorViewModel>();
            try
            {
                alunosLeitoresViewModel = _mapper
                                                .Map<IEnumerable<AlunoLeitorViewModel>>(als);
            }
            catch { throw; }
            #endregion

            #region Method Return
            return alunosLeitoresViewModel;
            #endregion
        }
        public async Task<IEnumerable<AlunoLeitorESViewModel>> GetAllForAddAsync()
        {
            #region Tenancy resolve
            var tenantId = StringHelpers.ExtractTenantId(await _tenantRepository.GetTenantIdAsync());
            IEnumerable<AlunoLeitor> als = new List<AlunoLeitor>();
            try
            {
                als = await _alunoLeitorRepository
                                        .GetAllAsync((Guid) tenantId);
            }
            catch { throw; }
            #endregion

            #region Mapeamento
            IEnumerable<AlunoLeitorESViewModel> alunosLeitoresViewModel = new List<AlunoLeitorESViewModel>();
            try
            {
                alunosLeitoresViewModel = _mapper
                                                .Map<IEnumerable<AlunoLeitorESViewModel>>(als);
            }
            catch { throw; }
            #endregion

            #region Method Return
            return alunosLeitoresViewModel;
            #endregion
        }
        public IEnumerable<AlunoLeitorViewModel> GetAllWithInclude()
        {
            try
            {
                var alunoLeitores  = _alunoLeitorRepository.GetAllWithIncludes();
                var alunoLeitoresMapped = _mapper.Map<IEnumerable<AlunoLeitorViewModel>>(alunoLeitores);

                return alunoLeitoresMapped;    
            }
            catch { throw; }
        }
        public async Task<ValidationResult> AddAsync(AlunoLeitorViewModel alunoLeitorViewModel)
        {
            try
            {
                #region Required validations
                if (alunoLeitorViewModel.DetentoIpen.IsNullOrEmpty())
                {
                    _validationResult.AddErrorMessage("Ipen requerido.");
                    return _validationResult;
                }

                if (alunoLeitorViewModel.ProfessorNome.IsNullOrEmpty())
                {
                    _validationResult.AddErrorMessage("Professor requerido.");
                    return _validationResult;
                }

                if (alunoLeitorViewModel.LivroGeneroNome.IsNullOrEmpty())
                {
                    _validationResult.AddErrorMessage("Livro gênero requerido.");
                    return _validationResult;
                }

                if ((!alunoLeitorViewModel.OcorrenciaDesistencia.IsNullOrEmpty()
                     && alunoLeitorViewModel.OcorrenciaDesistencia != AlunoLeitorOcorrenciaDesistenciaEnum.NENHUMA.ToString()))
                {
                    _validationResult.AddErrorMessage("Não é permitido ocorrência de desistência ao adicionar um leitor.");
                    return _validationResult;
                }
                #endregion

                #region Tenancy resolve
                var tenantId = StringHelpers.ExtractTenantId(await _tenantRepository.GetTenantIdAsync());
                #endregion

                #region Already validations
                var aluno = _alunoRepository
                                .GetByDetentoIpen(Convert.ToInt32(alunoLeitorViewModel.DetentoIpen));

                if (aluno == null)
                {
                    _validationResult.AddErrorMessage("Aluno não encontrado com o IPEN informado.");
                    return _validationResult;
                }

                var professor = await _professorRepository
                                                    .GetByNomeAsync((Guid) tenantId, alunoLeitorViewModel.ProfessorNome);

                if (professor == null)
                {
                    _validationResult.AddErrorMessage("Professor não encontrado com o NOME informado.");
                    return _validationResult;
                }

                var livroGenero = await _livroGeneroRepository
                                                .GetByNomeAsync(alunoLeitorViewModel.LivroGeneroNome);
                
                if (livroGenero == null)
                {
                    _validationResult.AddErrorMessage("Livro gênero não encontrado com o GÊNERO informado.");
                    return _validationResult;
                }
                #endregion Validações dados encontrados

                #region Already alunoLeitor
                var alunoLeitor = new AlunoLeitor();
                try
                {
                    alunoLeitor = await _context
                                            .AlunosLeitores
                                            .IgnoreQueryFilters()
                                            .Include(x => x.Aluno)
                                            .ThenInclude(x => x.Detento)
                                            .FirstOrDefaultAsync(x => x.Aluno.Detento.Ipen == Convert.ToInt32(alunoLeitorViewModel.DetentoIpen));
                }
                catch { throw; }

                if (alunoLeitor != null)
                {
                    if (alunoLeitor.TenantId == tenantId && alunoLeitor.IsDeleted == false)
                    {
                        _validationResult.AddErrorMessage("Aluno Leitor já cadastrado e ativo com IPEN informado.");
                        return _validationResult;
                    } else {
                        alunoLeitor.TenantId = (Guid) tenantId;
                        alunoLeitor.AlunoId = aluno.Id;
                        alunoLeitor.ProfessorId = professor.Id;
                        alunoLeitor.LivroGeneroId = livroGenero.Id;
                        alunoLeitor.DataIngresso = Convert.ToDateTime(alunoLeitorViewModel.DataIngresso);
                        alunoLeitor.OcorrenciaDesistencia = AlunoLeitorOcorrenciaDesistenciaEnum.NENHUMA;
                        alunoLeitor.DataOcorrenciaDesistencia = new DateTime(0001,01,01,00,00,00);

                        _context.AlunosLeitores.Update(alunoLeitor);
                        _unitOfWork.Commit();
                        return _validationResult;
                    }
                }
                #endregion

                #region Mapped and persistence
                alunoLeitorViewModel.AlunoId = aluno.Id;
                alunoLeitorViewModel.ProfessorId = professor.Id;
                alunoLeitorViewModel.LivroGeneroId = livroGenero.Id;    

                var alunoLeitorMapped = _mapper
                                        .Map<AlunoLeitor>(alunoLeitorViewModel);
                alunoLeitorMapped.TenantId = (Guid) tenantId;
                try
                {   
                    _alunoLeitorRepository.Add(alunoLeitorMapped);    
                }
                catch { throw; }
                #endregion

                #region UnitOfwork - Commit
                _unitOfWork.Commit();
                #endregion

                return _validationResult;
            }
            catch (Exception expt)
            {
                if (!(expt.InnerException is null))
                    _validationResult.AddErrorMessage(expt.InnerException.Message);
                _validationResult.AddErrorMessage(expt.Message);
                return _validationResult;
            }
        }
        public ValidationResult Remove(Guid id)
        {
            try
            {
                _alunoLeitorRepository.Remove(id);
                _unitOfWork.Commit();

                return _validationResult;
            }
            catch { throw; }
        }
        public async Task<ValidationResult> UpdateAsync(AlunoLeitorViewModel alunoLeitorViewModel)
        {
            try
            {
                #region Required validations
                if (alunoLeitorViewModel.Id == Guid.Empty 
                    || alunoLeitorViewModel.Id == null)
                {
                    _validationResult.AddErrorMessage("Id requerido.");
                    return _validationResult;
                }
                #endregion

                #region Tenancy resolve
                var tenantId = StringHelpers.ExtractTenantId(await _tenantRepository.GetTenantIdAsync());
                #endregion

                #region Already validations
                var alunoLeitor = new AlunoLeitor();
                try
                {
                    alunoLeitor = _alunoLeitorRepository
                                        .GetByIdIncludes((Guid) alunoLeitorViewModel.Id);
                }
                catch { throw; }

                if (alunoLeitor == null)
                {
                    _validationResult.AddErrorMessage("Nenhum leitor encontrado com o id informado.");
                    return _validationResult;
                }
                #endregion

                #region Required generals validations
                if (alunoLeitor.Aluno.Detento.Nome != alunoLeitorViewModel.DetentoNome)
                {
                    _validationResult.AddErrorMessage("Não é possível trocar o leitor.");
                    return _validationResult;
                }

                if (alunoLeitorViewModel.ProfessorNome.IsNullOrEmpty())
                {
                    _validationResult.AddErrorMessage("Professor requerido.");
                    return _validationResult;
                }
                else
                {
                    if (alunoLeitor.Professor.Nome != alunoLeitorViewModel.ProfessorNome)
                    {
                        var professorIdDB = _professorRepository.GetIdByNome(alunoLeitorViewModel.ProfessorNome);
                        if (professorIdDB != Guid.Empty)
                        {
                            alunoLeitorViewModel.ProfessorId = professorIdDB;
                        }
                    }
                    else
                    {
                        alunoLeitorViewModel.ProfessorId = alunoLeitor.ProfessorId;
                    }
                }

                if (alunoLeitorViewModel.LivroGeneroNome.IsNullOrEmpty())
                {
                    _validationResult.AddErrorMessage("Livro gênero requerido.");
                    return _validationResult;
                }
                else
                {
                    if (alunoLeitor.LivroGenero.Nome != alunoLeitorViewModel.LivroGeneroNome)
                    {
                        var livroGeneroIdDB = _livroGeneroRepository
                                                .GetIdByNome(alunoLeitorViewModel.LivroGeneroNome);
                        if (livroGeneroIdDB != Guid.Empty)
                        {
                            alunoLeitorViewModel.LivroGeneroId = livroGeneroIdDB;
                        }
                    }
                    else
                    {
                        alunoLeitorViewModel.LivroGeneroId = alunoLeitor.LivroGeneroId;
                    }
                }
                #endregion

                #region Occurrences validations
                if ((!alunoLeitorViewModel.DataOcorrenciaDesistencia.IsNullOrEmpty()
                        && alunoLeitorViewModel.DataOcorrenciaDesistencia != "0001-01-01")
                    &&
                   (alunoLeitorViewModel.OcorrenciaDesistencia.IsNullOrEmpty()
                        || alunoLeitorViewModel.OcorrenciaDesistencia == AlunoLeitorOcorrenciaDesistenciaEnum.NENHUMA.ToString()))
                {
                    _validationResult.AddErrorMessage("Foi informado uma data de ocorrência de desistência, porém não fora informado uma ocorrência.<br><br>Favor informar uma ocorrência ou limpar a data de ocorrência.");
                    return _validationResult;
                }

                if (!alunoLeitorViewModel.OcorrenciaDesistencia.IsNullOrEmpty()
                    && alunoLeitorViewModel.OcorrenciaDesistencia != AlunoLeitorOcorrenciaDesistenciaEnum.NENHUMA.ToString())
                {
                    alunoLeitorViewModel.IsDeleted = true;

                    if (alunoLeitorViewModel.DataOcorrenciaDesistencia.IsNullOrEmpty()
                        || alunoLeitorViewModel.DataOcorrenciaDesistencia == "0001-01-01 00:00:00")
                    {
                        alunoLeitorViewModel.DataOcorrenciaDesistencia = DateTime.Now.ToString();
                    }
                }

                if (string.IsNullOrEmpty(alunoLeitorViewModel.OcorrenciaDesistencia) &&
                    string.IsNullOrEmpty(alunoLeitorViewModel.DataOcorrenciaDesistencia) &&
                    alunoLeitor.DataOcorrenciaDesistencia != null &&
                    alunoLeitor.DataOcorrenciaDesistencia != new DateTime(0001, 01, 01, 00, 00, 00) &&
                    alunoLeitor.OcorrenciaDesistencia != 0)
                {
                    // check to locked since are trying reactivate it
                    if (alunoLeitor.LockoutEndByOcorrencia >= DateTime.Now)
                    {
                        _validationResult.AddErrorMessage($"Usuário bloquedo até {alunoLeitor.LockoutEndByOcorrencia.ToString("dd/MM/yyyy")}, portanto, não pode reingressar ao projeto até a data final do bloqueio. <br>Para desbloqueio imediato, solicite ao usuário administrador de sua UNIDADE.");
                        return _validationResult;
                    }
                }
                #endregion

                #region Mapper
                alunoLeitorViewModel.Id = alunoLeitor.Id;
                alunoLeitorViewModel.AlunoId = alunoLeitor.AlunoId;
                alunoLeitorViewModel.CreatedAt = alunoLeitor.CreatedAt;
                alunoLeitorViewModel.CreatedBy = alunoLeitor.CreatedBy;
                
                var alunoLeitorMapped = _mapper
                                            .Map<AlunoLeitorViewModel, 
                                                AlunoLeitor>(alunoLeitorViewModel, alunoLeitor);

                alunoLeitorMapped.TenantId = (Guid) tenantId;
                try
                {
                    _alunoLeitorRepository.Update(alunoLeitorMapped);    
                }
                catch { throw; }
                #endregion
                
                #region Commit
                _unitOfWork.Commit();    
                #endregion Commit

                return _validationResult;
            }   
            catch (Exception e)
            {
                if (e.InnerException != null)
                    _validationResult.AddErrorMessage(e.InnerException.Message);
                _validationResult.AddErrorMessage(e.Message);
                
                return _validationResult;
            }
        }
        public Int64 GetTotalAtivos()
        {
            var ativos = _alunoLeitorRepository.GetTotalAtivos();
            return ativos;
        }
        public Int64 GetTotalInativos()
        {
            var inativos = _alunoLeitorRepository.GetTotalInativos();
            return inativos;
        }
        public Int64 GetTotalWithIgnoreQueryFilter()
        {
            var total = _alunoLeitorRepository.GetTotalWithIgnoreQueryFilter();
            return total;
        }
        public AlunoLeitorViewModel GetByDetentoIpen(int ipen)
        {
            try
            {
                var alunoLeitor = _alunoLeitorRepository
                                    .GetByDetentoIpen(ipen);
                var alunoLeitorMapped = _mapper
                                            .Map<AlunoLeitorViewModel>(alunoLeitor);
                return alunoLeitorMapped;
            }
            catch { throw; }
        }
        public IEnumerable<AlunoLeitorViewModel> GetAllByDetentoNome(string nome)
        {
            try
            {
                if (nome.IsNullOrEmpty())
                    throw new Exception("Nome requerido.");
                
                var alunosLeitores = _alunoLeitorRepository
                                        .GetAllByDetentoNome(nome);
                var alunosLeitoresMapped = _mapper
                                            .Map<IEnumerable<AlunoLeitorViewModel>>(alunosLeitores);

                return alunosLeitoresMapped;
            }
            catch { throw; }
        }
        public async Task<DataTableServerSideResult<AlunoLeitorViewModel>> GetWithDataTableResultAsync(DataTableServerSideRequest request)
        {
            try
            {
                var als = await _alunoLeitorRepository
                                            .GetWithDataTableResultAsync(request);
                var alsMapped = _mapper
                                    .Map<IEnumerable<AlunoLeitorViewModel>>(als.Data);
                var result = new DataTableServerSideResult<AlunoLeitorViewModel>();
                
                result.Data = alsMapped.ToList();
                result.Draw = als.Draw;
                result._iRecordsDisplay = als._iRecordsDisplay;
                result._iRecordsTotal = als._iRecordsTotal;

                return result;
            }
            catch { throw; }
        }

        public void Dispose()
        {
            _alunoLeitorRepository.Dispose();
        }
    }
}