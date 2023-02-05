using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using AutoMapper;
using Sigesp.Domain.Interfaces;
using Sigesp.Domain.Models;
using Sigesp.Application.Interfaces;
using Sigesp.Application.ViewModels;
using Sigesp.Domain.Enums;
using Sigesp.Infra.Data.Extensions;
using Sigesp.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Sigesp.Application.Services
{
    public class AlunoAppService : IAlunoAppService
    {
        private readonly SigespDbContext _context;
        private readonly ValidationResult _validationResult;
        private readonly IAlunoRepository _alunoRepository;
        private readonly IAlunoLeituraRepository _alunoLeituraRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IDetentoRepository _detentoRepository;
        private readonly ITenantRepository _tenantRepository;

        public AlunoAppService(ValidationResult validationResult,
                                IAlunoRepository alunoRepository,
                                IAlunoLeituraRepository alunoLeituraRepository,
                                IUnitOfWork unitOfWork, 
                                IMapper mapper,
                                IDetentoRepository detentoRepository,
                                ITenantRepository tenantRepository,
                                SigespDbContext context)
        {
            _validationResult = validationResult;
            _alunoRepository = alunoRepository;
            _alunoLeituraRepository = alunoLeituraRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _detentoRepository = detentoRepository;
            _tenantRepository = tenantRepository;
            _context = context;
        }

        #region Methods multitenancies
        public async Task<IEnumerable<AlunoViewModel>> GetAllAsync()
        {
            #region Resolve tenancy
            var tenantId = StringHelpers.ExtractTenantId(await _tenantRepository.GetTenantIdAsync());
            IEnumerable<Aluno> result = new List<Aluno>();
            try
            {
                result = await _alunoRepository
                                    .GetAllAsync((Guid) tenantId);
            }
            catch { throw; }
            #endregion

            #region Mapper
            IEnumerable<AlunoViewModel> resultMapped = new List<AlunoViewModel>();
            try
            {
                resultMapped = _mapper
                                    .Map<IEnumerable<AlunoViewModel>>(result);    
            }
            catch { throw; }
            #endregion

            #region Method return
            return resultMapped;
            #endregion
        }
        #endregion

        #region Methods that are not tenants
        public async Task<string> GetNomeAsync(string id)
        {
            #region Required validations
            try
            {
                if (string.IsNullOrEmpty(id))
                    throw new ArgumentException("Id requerido.");
            }
            catch { throw; }
            #endregion

            #region Convert and get
            String result;
            try
            {
                Guid idMapped;
                Guid.TryParse(id, out idMapped);

                result = await _alunoRepository.GetNomeAsync(idMapped);
            }
            catch { throw; }
            #endregion

            return result;
        }
        #endregion 

        public AlunoViewModel GetByDetentoIpen(int ipen)
        {
            var aluno = _alunoRepository.GetByDetentoIpen(ipen);
            var alunoMapped = _mapper.Map<AlunoViewModel>(aluno);

            return alunoMapped;
        }
        
        /// <summary>
        /// To ContextDB refactoring
        /// </summary>
        public ValidationResult Add(AlunoViewModel alunoViewModel)
        {
            try
            {
                #region    Begin - Obtenho os dados do detento
                var detento = new Detento();
                detento = _detentoRepository.GetByIpen(Convert.ToInt32(alunoViewModel.DetentoIpen));
            
                if (detento == null)
                {
                    _validationResult.AddErrorMessage("Nenhum detento encontrado com o nome/ipen informado para o cadastro de aluno.");
                    return _validationResult;
                }
                #endregion End - Obtenho os dados do detento
                
                #region Tenancy resolve
                Guid tenantId;
                try
                {
                    tenantId = (Guid)StringHelpers.ExtractTenantId(_tenantRepository.GetTenantId());
                }
                catch { throw; }
                if (tenantId == Guid.Empty)
                {
                    _validationResult.AddErrorMessage("Problemas ao obter a UNIDADE PRISIONAL do usuário logado. Tente novamente, persistindo o erro informe a equipe técnica do sistema.");
                    return _validationResult;
                }
                #endregion

                #region Aluno resolve
                var aluno = new Aluno();
                try
                {
                    aluno = _alunoRepository.GetByDetentoIpen(detento.Ipen);
                }
                catch { throw; }
                #endregion

                #region Map
                var alunoMapped = new Aluno();
                #endregion

                #region Generals validations
                if (aluno != null)
                {
                    if (!aluno.IsDeleted && aluno.TenantId == tenantId)
                    {
                        _validationResult.AddErrorMessage("Aluno já cadastrado e ativo com o ipen informado.");
                        return _validationResult;
                    }
                    else
                    {
                        alunoViewModel.TenantId = tenantId;
                        alunoViewModel.IsDeleted = false;
                        alunoViewModel.Id = aluno.Id;
                        alunoViewModel.DetentoId = aluno.Detento.Id;

                        alunoMapped = _mapper.Map<AlunoViewModel, Aluno>(alunoViewModel, aluno);
                        alunoMapped.Tenant = null;

                        _alunoRepository.Update(alunoMapped);
                    }
                }
                else
                {
                    //Cadastro um novo aluno, pois não há registro ativo com o ipen informado
                    alunoViewModel.TenantId = tenantId;
                    alunoMapped = _mapper.Map<Aluno>(alunoViewModel);
                    alunoMapped.DetentoId = detento.Id;

                    _alunoRepository.Add(alunoMapped);
                }
                #endregion

                #region    Begin - Router para criação do (s) registro (s) de aluno (s) de acordo com as atividades educacionais informadas
                // foreach (var atividadeEducacional in alunoViewModel.AtividadesEducacionais)
                // {
                //     switch (atividadeEducacional)
                //     { 
                //         case "LEITURA":
                //             //Criar um registro de leitura
                //             var alunoLeitura = new AlunoLeitura();
                //             alunoLeitura.DataIngresso = DateTime.Now;
                //             alunoLeitura.AlunoId = alunoMapped.Id;
                //             alunoLeitura.ProfessorId = Guid.Parse("8268d82c-7699-4598-8c8a-1efc69228c43");
                //             alunoLeitura.LivroGeneroId = Guid.Parse("16b3e93c-8836-43a7-822b-4e2dccc3879d");

                //             _alunoLeituraRepository.Add(alunoLeitura);
                //             continue;
                //         case "ESTUDO_EJA":
                //             //Criar um registro para estudo regular
                //             continue;
                //         case "ENEM":
                //             //Criar um registro de inscrição ENEM
                //             continue;
                //         case "ENCCEJA":
                //             //Criar um registro de inscrição ENCCEJA
                //             continue;
                //         case "REDACAO_DPU":
                //             //Criar um registro de inscrição REDAÇÃO DPU
                //             continue;
                //         case "PROJETOS_ESPECIAIS":
                //             //Criar um registro de inscrição Projetos especiais
                //             continue;
                //     }
                // }
                #endregion End - Router para criação do (s) registro (s) de aluno (s) de acordo com as atividades educacionais informadas

                #region    Begin - Commit global e retorno do método
                _unitOfWork.Commit();
                return _validationResult;
                #endregion End - Commit global e retorno do método
            }
            catch (System.Exception ex)
            {
                _validationResult.AddErrorMessage(ex.Message);
                return _validationResult;
            }
        }
        public ValidationResult Remove(Guid id)
        {
            _alunoRepository.Remove(id);
            _unitOfWork.Commit();

            return _validationResult;
        }
        public ValidationResult Update(AlunoViewModel alunoViewModel)
        {
            try
            {
                if (alunoViewModel.Id == null ||
                    alunoViewModel.Id == Guid.Empty)
                {
                    _validationResult.AddErrorMessage("Id requerido");
                    return _validationResult;
                }
                
                var alunoDB = _alunoRepository
                                    .GetByIdWithIncludes((Guid) alunoViewModel.Id);

                alunoViewModel.DetentoId = alunoDB.DetentoId;
                var alunoMapper = _mapper.Map<AlunoViewModel, Aluno>
                                                (alunoViewModel, alunoDB);

                _alunoRepository.Update(alunoMapper);
                _unitOfWork.Commit();

                return _validationResult;
            }
            catch (System.Exception ex)
            {
                if (ex.InnerException != null)
                    _validationResult.AddErrorMessage(ex.InnerException.Message);
                _validationResult.AddErrorMessage(ex.Message);

                return _validationResult;
            }
        }
        public async Task<bool> ActivateOrDeactivateAsync (string id)
        {
            #region Required validations
            if (string.IsNullOrEmpty(id))
                throw new ArgumentException("Id requerido.");
            #endregion

            #region Get data
            var dataForUpdate = new Aluno();
            try
            {
                dataForUpdate = await _alunoRepository.GetAtivoInativoAsync(Guid.Parse(id));
                if (dataForUpdate == null)
                    return false;
            }
            catch (Exception ex) { throw ex; }
            #endregion
            
            #region Data update
            try
            {
                if (dataForUpdate.IsDeleted)
                {
                    dataForUpdate.IsDeleted = false;
                }
                else
                {
                    dataForUpdate.IsDeleted = true;
                }

                _alunoRepository.Update(dataForUpdate);
                await _unitOfWork.CommitAsync();
            }
            catch (Exception ex) { throw ex; }
            #endregion
            return true;
        }
        public Int64 GetTotalAtivos()
        {
            var ativos = _alunoRepository.GetTotalAtivos();
            return ativos;
        }
        public Int64 GetTotalByEscolaridade(EscolaridadeEnum escolaridade)
        {
            var result = _alunoRepository
                            .GetTotalByEscolaridade(escolaridade);
            return result;
        }
        
        public void Dispose()
        {
            _alunoRepository.Dispose();
        }
    }
}