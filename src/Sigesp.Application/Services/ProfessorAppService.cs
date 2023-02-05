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
using Sigesp.Domain.Models.DataTable;
using Sigesp.Application.ViewModels.Cards;
using System.Linq;

namespace Sigesp.Application.Services
{
    public class ProfessorAppService : IProfessorAppService
    {
        private readonly ValidationResult _validationResult;
        private readonly IProfessorRepository _professorRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ITenantRepository _tenantRepository;

        public ProfessorAppService(ValidationResult validationResult,
                                    IProfessorRepository professorRepository,
                                    IUnitOfWork unitOfWork, IMapper mapper,
                                    ITenantRepository tenantRepository)
        {
            _validationResult = validationResult;
            _professorRepository = professorRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _tenantRepository = tenantRepository;
        }

        #region Métodos multitenants
        public async Task <Int64> GetTotalInativosAsync()
        {
            var tenantId = StringHelpers.ExtractTenantId(await _tenantRepository.GetTenantIdAsync());
            try
            {
                var result = await _professorRepository
                                        .GetTotalInativosAsync((Guid) tenantId);
                return result;
            }
            catch { throw new Exception("Problemas ao obter uma UNIDADE PRISIONAL para o usuário logado. <br><br>Faça login novamente, caso o problema persista, informe a equipe técnica do sistema."); }
        }
        public async Task<IEnumerable<ProfessorViewModel>> GetAllAsync()
        {
            var tenantId = StringHelpers.ExtractTenantId(await _tenantRepository.GetTenantIdAsync());
            IEnumerable<Professor> professores = new List<Professor>();
            try
            {
                professores = await _professorRepository
                                         .GetAllAsync((Guid) tenantId);
            }
            catch { throw new Exception("Problemas ao obter uma UNIDADE PRISIONAL para o usuário logado. <br><br>Faça login novamente, caso o problema persista, informe a equipe técnica do sistema."); }

            try
            {
                var professoresMapped = _mapper.Map<IEnumerable<ProfessorViewModel>>(professores).ToSafeList();
                return professoresMapped.ToSafeList();
            }
            catch { throw new Exception("Problemas no mapeamento do professor. <br><br>Tente novamente, caso o problema persista, informe a equipe técnica do sistema."); }
        }
        public async Task<IEnumerable<string>> GetAllNomesAsync()
        {
            var tenantId = StringHelpers.ExtractTenantId(await _tenantRepository.GetTenantIdAsync());
            IEnumerable<string> nomes = new List<string>();
            try
            {
                nomes = await _professorRepository
                                         .GetAllNomesAsync((Guid) tenantId);
            }
            catch { throw new Exception("Problemas ao obter uma UNIDADE PRISIONAL para o usuário logado. <br>Faça login novamente, caso o problema persista, informe a equipe técnica do sistema."); }
            return nomes;
        }
        public async Task<DataTableServerSideResult<ProfessorViewModel>> GetWithDataTableResultAsync(DataTableServerSideRequest request)
        {
            var tenantId = StringHelpers.ExtractTenantId(await _tenantRepository.GetTenantIdAsync());
            var professores = new DataTableServerSideResult<Professor>();
            try
            {
                request.TenantId = (Guid) tenantId;
                professores = await _professorRepository
                                            .GetWithDataTableResultAsync(request);
            }
            catch { throw new Exception("Problemas ao obter uma UNIDADE PRISIONAL para o usuário logado. <br><br>Faça login novamente, caso o problema persista, informe a equipe técnica do sistema."); }
            
            var result = new DataTableServerSideResult<ProfessorViewModel>();
            var professoresMapped = _mapper
                                        .Map<IEnumerable<ProfessorViewModel>>(professores.Data).ToSafeList();

            result.Data = professoresMapped;
            result.Draw = professores.Draw;
            result._iRecordsDisplay = professores._iRecordsDisplay;
            result._iRecordsTotal = professores._iRecordsTotal;
            return result;
        }
        public async Task<ProfessorCardViewModel> GetInfoCardsAsync()
        {
            var tenantId = StringHelpers.ExtractTenantId(await _tenantRepository.GetTenantIdAsync());
            var result = new List<Professor>();
            try
            {
                result = await _professorRepository
                                        .GetInfoCardsAsync((Guid) tenantId);
            }
            catch { throw new Exception("Problemas ao obter uma UNIDADE PRISIONAL para o usuário logado. <br><br>Faça login novamente, caso o problema persista, informe a equipe técnica do sistema."); }
            
            var resultMapped = new ProfessorCardViewModel();
            try
            {
                resultMapped.Total = result.Count();
                resultMapped.Ativos = result.Count(x => !x.IsDeleted);
                resultMapped.Inativos = result.Count(x => x.IsDeleted);
            }
            catch { throw; }
            return resultMapped;
        }
        public async Task AddAsync(ProfessorViewModel professorViewModel)
        {
            #region Validações de obrigatoriedade
            try
            {
                if (professorViewModel.Nome.IsNullOrEmpty())
                    throw new Exception("Nome requerido.");
                
                if (professorViewModel.Galeria.IsNullOrEmpty())
                    throw new Exception("Galeria requerido.");

                if (professorViewModel.ApplicationUserId.IsNullOrEmpty())
                    throw new Exception("Usuário requerido.");
            }
            catch { throw; }
            #endregion

            #region Validações tamanho de campo
            if (professorViewModel.Cpf.Count() > 11)
                throw new Exception("Campo CPF aceita no máximo 11 caracteres. Favor limpar o campo e redigitar o CPF novamente.");
            #endregion

            #region Validação professor já existente e ativo com o usuário informado
            try
            {
                if (_professorRepository.AlreadySameUserId(professorViewModel.ApplicationUserId))
                    throw new Exception("Professor já cadastrado e ativo com o USUÁRIO informado.");
            }
            catch { throw; }
            #endregion

            #region Validação professor já existente com o CPF cadastrado
            var professorDB = new Professor();
            try
            {
                professorDB = await _professorRepository
                                        .GetAtivoInativoAsync(professorViewModel.Cpf);
                if (professorDB != null && !professorDB.IsDeleted)
                    throw new Exception("Professor já cadastrado e ativo com o CPF informado.");
            }
            catch { throw; }
            #endregion

            #region Resolve Tenant
            var tenantId = StringHelpers.ExtractTenantId(await _tenantRepository.GetTenantIdAsync());
            try
            {
                if (tenantId == null || tenantId == Guid.Empty)
                    throw new Exception("Problemas ao obter os dados da UNIDADE PRISIONAL para finalizar o cadastrado. <br><br>Tente novamente, caso o problema persista informe o suporte técnico do sistema.");
            }
            catch { throw; }
            #endregion

            #region Mapeamento e persistência
            try
            {
                professorViewModel.TenantId = tenantId;
                var professoresMapped = new Professor();

                if (professorDB != null && professorDB.IsDeleted)
                {
                    professorViewModel.Id = professorDB.Id;
                    professorViewModel.IsDeleted = false;
                    professoresMapped = _mapper
                                            .Map<ProfessorViewModel, Professor>(professorViewModel, professorDB);
                    _professorRepository.Update(professoresMapped);
                }
                else
                {
                    professoresMapped = _mapper.Map<Professor>(professorViewModel);
                    _professorRepository.Add(professoresMapped);
                }
            }
            catch { throw; }
            #endregion

            #region Commit
            try
            {
                _unitOfWork.Commit();
            }
            catch { throw; }
            #endregion Commit
        }
        public async Task UpdateAsync(ProfessorViewModel professorViewModel)
        {
            #region Validações de obrigatoriedade
            try
            {
                if (professorViewModel.Id == null || professorViewModel.Id == Guid.Empty)
                    throw new Exception("Id do professor requerido.");

                if (professorViewModel.Nome.IsNullOrEmpty())
                    throw new Exception("Nome requerido.");
                
                if (professorViewModel.Galeria.IsNullOrEmpty())
                    throw new Exception("Galeria requerido.");

                if (professorViewModel.ApplicationUserId.IsNullOrEmpty())
                    throw new Exception("Usuário requerido.");
            }
            catch { throw; }
            #endregion

            #region Validações tamanho de campo
            if (professorViewModel.Cpf.Count() > 11)
                throw new Exception("Campo CPF aceita no máximo 11 caracteres. Favor limpar o campo e redigitar o CPF novamente.");
            #endregion

            #region Obtenção do objeto para atualização
            var professores = new Professor();
            try
            {
                professores = await _professorRepository.GetByIdAsync((Guid) professorViewModel.Id);
            }
            catch { throw; }
            #endregion

            #region Validação professor já existente e ativo com o usuário informado
            try
            {
                if (await _professorRepository.AlreadySameUserIdAsync(professorViewModel.ApplicationUserId, (Guid) professorViewModel.Id))
                    throw new Exception("Professor já cadastrado e ativo com o USUÁRIO informado.");
            }
            catch { throw; }
            #endregion

            #region Validação professor já existente com o CPF cadastrado
            try
            {
                if (await _professorRepository.AlreadyAtivoSameCPFAsync(professorViewModel.Cpf, (Guid) professorViewModel.Id))
                    throw new Exception("Professor já cadastrado e ativo com o CPF informado.");
            }
            catch { throw; }
            #endregion

            #region Mapeamento do objeto e atualização
            try
            {
                professorViewModel.TenantId = professores.TenantId;
                var professoresMapped = _mapper.Map<ProfessorViewModel, Professor>(professorViewModel, professores);
                _professorRepository.Update(professoresMapped);    
            }
            catch { throw; }
            #endregion

            #region Commit
            try
            {
                _unitOfWork.Commit();
            }
            catch { throw; }
            #endregion
        }
        public Int64 GetTotalAtivos()
        {
            var ativos = _professorRepository.GetTotalAtivos();
            return ativos;
        }
        public Int64 GetTotalWithIgnoreQueryFilter()
        {
            var total = _professorRepository.GetTotalWithIgnoreQueryFilter();
            return total;
        }
        #endregion

        #region Métodos is not multitenants
        public ValidationResult Remove(Guid id)
        {
            try
            {
                _professorRepository.Remove(id);
                _unitOfWork.Commit();

                return _validationResult;
            }
            catch { throw; }
        }
        #endregion

        #region Métodos pendentes para implementar tenancy
        #endregion

        public void Dispose()
        {
            _professorRepository.Dispose();
        }
    }
}