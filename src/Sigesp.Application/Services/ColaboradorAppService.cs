using System.Linq;
using System.Globalization;
using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Sigesp.Application.Interfaces;
using Sigesp.Application.ViewModels;
using Sigesp.Domain.Interfaces;
using Sigesp.Domain.Models;
using Sigesp.Application.Extensions;
using Sigesp.Domain.Enums;
using Sigesp.Application.ViewModels.Selects;
using Sigesp.Application.ViewModels.Charts.Info;

namespace Sigesp.Application.Services
{
    public class ColaboradorAppService : IColaboradorAppService
    {
        private readonly ValidationResult _validationResult;
        private readonly IContaCorrenteAppService _contaCorrenteManager;
        private readonly IContaCorrenteRepository _contaCorrenteRepository;
        private readonly IColaboradorRepository _colaboradorRepository;
        private readonly IEmpresaConvenioRepository _empresaConvenioRepository;
        private readonly IDetentoAppService _detentoManager;
        private readonly IDetentoRepository _detentoRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ColaboradorAppService(ValidationResult validationResult,
                                    IContaCorrenteAppService contaCorrenteManager,
                                    IContaCorrenteRepository contaCorrenteRepository,
                                    IColaboradorRepository colaboradorRepository,
                                    IEmpresaConvenioRepository empresaConvenioRepository,
                                    IDetentoAppService detentoManager,
                                    IDetentoRepository detentoRepository,
                                    IUnitOfWork unitOfWork, IMapper mapper)
        {
            _validationResult = validationResult;
            _contaCorrenteManager = contaCorrenteManager;
            _contaCorrenteRepository = contaCorrenteRepository;
            _colaboradorRepository = colaboradorRepository;
            _empresaConvenioRepository = empresaConvenioRepository;
            _detentoManager = detentoManager;
            _detentoRepository = detentoRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public ColaboradorViewModel GetByIdWithInclude(Guid id)
        {
            return _mapper
                    .Map<ColaboradorViewModel>(_colaboradorRepository
                                                .AsNoTracking()
                                                .Select(x => x.Detento));
        }
        public IEnumerable<ColaboradorViewModel> GetAll()
        {
            var colaborador = _colaboradorRepository.GetAll();
            var colaboradoresMapper = _mapper.Map<IEnumerable<ColaboradorViewModel>>(colaborador);
            
            return colaboradoresMapper;
        }
        public IEnumerable<ColaboradorViewModel> AsNoTrackingWithInclude()
        {
            var colaborador = _colaboradorRepository.AsNoTrackingWithInclude();
            var colaboradoresMapper = _mapper.Map<IEnumerable<ColaboradorViewModel>>(colaborador);
            
            return colaboradoresMapper;
        }
        public async Task<IEnumerable<ColaboradorViewModel>> GetAllAsync()
        {
            var colaboradoresMapped = _mapper.Map<IEnumerable<ColaboradorViewModel>>(await _colaboradorRepository.GetAllWithIncludeAsync());
                                     
            return colaboradoresMapped;
        }
        public IEnumerable<ColaboradorViewModel> GetAllSoftDeleted()
        {
            var colaboradoresMapper = _mapper.Map<IEnumerable<ColaboradorViewModel>>(
                                                    _colaboradorRepository.GetAllSoftDeleted());
            
            return colaboradoresMapper;
        }
        public ValidationResult Add(ColaboradorViewModel colaboradorViewModel)
        {
            var detento = _detentoManager
                                    .GetByNome(colaboradorViewModel.DetentoNome);
            
            if (detento == null)
            {
                 _validationResult.AddErrorMessage("N??o foi poss??vel localizar um detento com o nome informado para seguir com o cadastro de um colaborador. Favor informar equipe t??cnica do sistema com o seguinte c??digo do erro: Erro=1500.");
                 return _validationResult;
            }

            //Verifica se j?? existe um ou mais colaboradores cadastrados para o mesmo detento informado
            //Caso exista, devo demiti-los antes de cadastrar um novo;
            var colaboradoresDB = _colaboradorRepository.GetAllByDetentoNome(detento.Nome);

            if (colaboradoresDB.Count() > 0)
            {
                foreach (var colaboradorDB in colaboradoresDB)
                {
                    if(colaboradorDB.Situacao != ColaboradorSituacaoEnum.DEMITIDO)
                    {
                        colaboradorDB.Situacao = ColaboradorSituacaoEnum.DEMITIDO;
                        colaboradorDB.DataUltimaSituacao = DateTime.Now;
                        colaboradorDB.DemissaoData = DateTime.Now;
                        colaboradorDB.DemissaoOcorrencia = ColaboradorDemissaoOcorrenciaEnum.DEMISSAO_VIA_SISTEMA;
                        colaboradorDB.DemissaoObservacao = "Demiss??o ocorreu automaticamente via sistema. Ao adicionar um novo colaborador, foi identificado que j?? existia outro vinculado ao mesmo detento, portanto, para cria????o de um novo, o colaborador anterior fora demitido.";

                        _colaboradorRepository
                                .Update(colaboradorDB);
                    }
                }
            }

            //Add Colaborador
            colaboradorViewModel.EmpresaConvenioId = _empresaConvenioRepository.GetIdFromPropertyAny("Nome", colaboradorViewModel.EmpresaConvenioNome);
            colaboradorViewModel.DetentoId = (Guid) detento.Id;

            //Caso o status seja EM_PROCESSO_ADMISSAO, for??a o colaborador a n??o
            //ter conta corrente - Conta corrente somente para colaborador admitido
            if (colaboradorViewModel.Situacao == ColaboradorSituacaoEnum.ADMITIDO.ToString()
                    && colaboradorViewModel.IsRemunerado)
            {
                colaboradorViewModel.HasContaCorrente = true;
            }
            else
            {
                colaboradorViewModel.HasContaCorrente = false;
            }

            var colaboradorMapped = _mapper.Map<Colaborador>(colaboradorViewModel);
            
            _colaboradorRepository.Add(colaboradorMapped);

            //Verifico se o colaborador ingresso possui conta corrente para o detentoNome informado
            //caso haja, eu atualizo o vinculo da conta para o id do colaborador ingresso
            var colaboradorContaCorrente = _contaCorrenteRepository.GetByColaboradorNomeIgnoreFilter(colaboradorViewModel.DetentoNome);
            if (colaboradorContaCorrente != null)
            {
                colaboradorContaCorrente.ColaboradorId = colaboradorMapped.Id;
                //Reativo a conta caso esteja deletada
                colaboradorContaCorrente.IsDeleted = false;
                
                _contaCorrenteRepository.Update(colaboradorContaCorrente);
            }
            else
            {
                //Verifica se ?? pra criar uma conta corrente
                if (colaboradorViewModel.HasContaCorrente && 
                        colaboradorViewModel.Situacao == ColaboradorSituacaoEnum.ADMITIDO.ToString())
                {
                    var numero = detento.Ipen;

                    var contaCorrente = new ContaCorrenteViewModel
                    {
                        Numero = Convert.ToInt32(numero),
                        Status = ContaCorrenteStatusEnum.ATIVA.ToString(),
                        DataUltimoStatus = DateTime.Now,
                        ColaboradorId = colaboradorMapped.Id,
                        ColaboradorNome = colaboradorViewModel.DetentoNome,
                        Tipo = ContaCorrenteTipoEnum.PESSOA_FISICA.ToString()
                    };
                    _contaCorrenteRepository.Add(_mapper.Map<ContaCorrente>(contaCorrente));
                }
            }

            _unitOfWork.Commit();

            // //Valida????o troca Situa????o
            // if (colaboradoDB.Situacao == ColaboradorSituacaoEnum.ADMITIDO &&
            //         colaboradorViewModel.Situacao == ColaboradorSituacaoEnum.EM_PROCESSO_ADMISSAO.ToString())
            // {
            //     _validationResult.AddErrorMessage("Colaborador situa????o 'ADMITIDO' s?? permite mudan??a de situa????o para 'DEMITIDO'.");
            //     return _validationResult;
            // }

            return _validationResult;
        }
        public ValidationResult Update(ColaboradorViewModel colaboradorViewModel)
        {
            var colaboradoDB = _colaboradorRepository
                                    .GetByIdWithInclude((Guid) colaboradorViewModel.Id);

            //Valida????o troca Situa????o
            if (colaboradoDB.Situacao == ColaboradorSituacaoEnum.ADMITIDO &&
                    colaboradorViewModel.Situacao == ColaboradorSituacaoEnum.EM_PROCESSO_ADMISSAO.ToString())
            {
                _validationResult.AddErrorMessage("Colaborador situa????o 'ADMITIDO' s?? permite mudan??a de situa????o para 'DEMITIDO'.");
                return _validationResult;
            }

            //Valida????o troca Detento
            if (colaboradoDB.Detento.Nome != colaboradorViewModel.DetentoNome)
            {
                _validationResult.AddErrorMessage("N??o ?? permitido a troca de 'DETENTO' na edi????o de 'COLABORADOR'.");
                return _validationResult;
            }
                                                
            //Caso o status seja EM_PROCESSO_ADMISSAO, for??a o colaborador a n??o
            //ter conta corrente - Conta corrente somente para colaborador admitido
            if (colaboradorViewModel.Situacao 
                == ColaboradorSituacaoEnum.EM_PROCESSO_ADMISSAO.ToString()
                && colaboradorViewModel.HasContaCorrente == true)
            {
                _validationResult.AddErrorMessage("N??o ?? permitido colaborador com conta corrente quando sua situa????o ?? 'EM_PROCESSO_ADMISSAO'.");
                return _validationResult;
            }

            //For??ar hasContaCorrente true, caso atenda alguns crit??rios
            if (colaboradorViewModel.Situacao 
                == ColaboradorSituacaoEnum.ADMITIDO.ToString()
                && colaboradorViewModel.IsRemunerado)
                colaboradorViewModel.HasContaCorrente = true;

            colaboradorViewModel.DetentoId = colaboradoDB.DetentoId;
            colaboradorViewModel.EmpresaConvenioId = _empresaConvenioRepository
                                                        .GetIdFromPropertyAny("Nome", colaboradorViewModel.EmpresaConvenioNome);
            
            var colaboradorMapped = _mapper.Map<ColaboradorViewModel, Colaborador>(colaboradorViewModel, colaboradoDB);
            
            _colaboradorRepository.Update(colaboradorMapped);
            _unitOfWork.Commit();

            //Add conta corrente caso ainda n??o tenha
            if (colaboradorViewModel.HasContaCorrente && colaboradorMapped.Situacao 
                    == ColaboradorSituacaoEnum.ADMITIDO && colaboradorViewModel.IsRemunerado)
            {
                var hasContaCorrente = _contaCorrenteManager.AlreadyByColaboradorId((Guid) colaboradorMapped.Id);
                if (!hasContaCorrente)            
                {
                    var detento = _detentoManager.GetByNome(colaboradorViewModel.DetentoNome);

                    var numero = detento.Ipen;
                    var contaCorrente = new ContaCorrenteViewModel
                    {
                        Numero = Convert.ToInt32(numero),
                        Status = ContaCorrenteStatusEnum.ATIVA.ToString(),
                        DataUltimoStatus = DateTime.Now,
                        ColaboradorId = (Guid) colaboradorMapped.Id,
                        ColaboradorNome = colaboradorViewModel.DetentoNome,
                        Tipo = ContaCorrenteTipoEnum.PESSOA_FISICA.ToString()
                    };
                    _contaCorrenteManager.Add(contaCorrente);
                }
            }

            return _validationResult;
        }
        public Generic2Select2ViewModel GetByDetentoIpenOrDetentoNome(string property, string arg)
        {
            var colaboradorIdAndNome = _colaboradorRepository.GetByDetentoIpenOrDetentoNome(property, arg);

            var colaboradorSelect2Result = new Generic2Select2ViewModel()
            {
                Id = colaboradorIdAndNome.Id.ToString(),
                Nome = colaboradorIdAndNome.Detento.Nome
            };

            return colaboradorSelect2Result;
        }
        public ValidationResult Remove(Guid id)
        {
            // var lancamentoDB = _lancamentoRepository.GetByIdForTipoJuridicaAndCofre((Guid) id);

            // //N??o permitir deletar lan??amento 'LIQUIDADO' ou 'CANCELADO'  
            // if (lancamentoDB.Status == LancamentoStatusEnum.LIQUIDADO ||
            //      lancamentoDB.Status == LancamentoStatusEnum.CANCELADO)
            // {
            //     _validationResult.AddErrorMessage("Lan??amento 'LIQUIDADO' ou 'CANCELADO' n??o pode ser deletado."); 
            //     return _validationResult;
            // }

            _colaboradorRepository.Remove(id);
            _unitOfWork.Commit();

            return _validationResult;
        }

        public ColaboradorViewModel GetByDetentoIpenAndEmpresaConvenioId(int ipen, string ecId)
        {
            try
            {
                if (ipen == 0)
                    throw new Exception("Ipen n??o informado.");
                
                if (ecId == null)
                    throw new Exception("Empresa conv??nio Id n??o informado");

                var colaborador = _colaboradorRepository.GetByDetentoIpenAndEmpresaConvenioId(ipen, Guid.Parse(ecId));
                var colaboradorMapped = _mapper.Map<ColaboradorViewModel>(colaborador);

                return colaboradorMapped;
            } catch { throw; }
        }

        //M??todos indicadores
        public async Task<ColaboradorPorConvenioViewModel> GetAllColaboradorPorConvenioSituacaoAdmitido()
        {
            var colaboradores = await _colaboradorRepository.GetAllColaboradorPorConvenioSituacaoAdmitido();
            colaboradores = colaboradores.Where(x => x.EmpresaConvenio.Situacao == ConvenioSituacaoEnum.ATIVO);
            
            var colaboradoresMapped = new ColaboradorPorConvenioViewModel();
            colaboradoresMapped.Label = new List<string>();
            colaboradoresMapped.Data = new List<int>();

            var empresasConvenios = colaboradores.Select(x => x.EmpresaConvenio.Nome).Distinct();

            colaboradoresMapped.Label.AddRange(empresasConvenios);

            foreach (var empresaConvenio in empresasConvenios.ToList())
            {
                var tmp = colaboradores.Where(x => x.EmpresaConvenio.Nome == empresaConvenio.ToString()).Count();
                
                colaboradoresMapped.Data.Add(tmp);
            }

            return colaboradoresMapped;
        }

        public void Dispose()
        {
            _colaboradorRepository.Dispose();
        }
    }
}