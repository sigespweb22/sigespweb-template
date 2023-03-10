using System.ComponentModel.DataAnnotations;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Sigesp.Application.Interfaces;
using Sigesp.Application.ViewModels;
using Sigesp.Domain.Interfaces;
using Sigesp.Domain.Models;
using Sigesp.Domain.Enums;

namespace Sigesp.Application.Services
{
    public class LancamentoAppService : ILancamentoAppService
    {
        private readonly ValidationResult _validationResult;
        private readonly IContaCorrenteAppService _contaCorrenteManager;
        private readonly IContaCorrenteRepository _contaCorrenteRepository;
        private readonly ILancamentoRepository _lancamentoRepository;
        private readonly IColaboradorRepository _colaboradorRepository;
        private readonly IDetentoRepository _detentoRepository;
        private readonly IContabilEventoRepository _contabilEventoRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public LancamentoAppService(ValidationResult validationResult,
                                    IContaCorrenteAppService contaCorrenteManager,
                                    IContaCorrenteRepository contaCorrenteRepository,
                                    ILancamentoRepository lancamentoRepository, 
                                    IColaboradorRepository colaboradorRepository,
                                    IDetentoRepository detentoRepository,
                                    IContabilEventoRepository contabilEventoRepository,
                                    IUnitOfWork unitOfWork, IMapper mapper)
        {
            _validationResult = validationResult;
            _contaCorrenteManager = contaCorrenteManager;
            _contaCorrenteRepository = contaCorrenteRepository;
            _lancamentoRepository = lancamentoRepository;
            _colaboradorRepository = colaboradorRepository;
            _detentoRepository = detentoRepository;
            _contabilEventoRepository = contabilEventoRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<LancamentoViewModel> GetById(Guid id)
        {
            var lancamento = _mapper.Map<LancamentoViewModel>(await _lancamentoRepository.GetByIdAsync(id));

            return lancamento;
        }
        public IEnumerable<LancamentoViewModel> GetAll()
        {
            var lancamentosMap = _mapper.Map<IEnumerable<LancamentoViewModel>>(
                                                    _lancamentoRepository
                                                        .AsNoTrackingOnlyIsNotDeleted()
                                                        .OrderByDescending(x => x.CreatedAt));
            
            return lancamentosMap;
        }
        public async Task<IEnumerable<LancamentoViewModel>> GetAllAsync()
        {
            var lancamentosDB = await _lancamentoRepository.GetAllOnlyIsDeletedTrue(); 
            var lancamentosMapper = _mapper.Map<IEnumerable<LancamentoViewModel>>(lancamentosDB);
            
            return lancamentosMapper;
        }
        public async Task<IEnumerable<LancamentoViewModel>> GetAllAsyncWithInclude()
        {
            var lancamentosDB = await _lancamentoRepository.GetAllWithInclude();
            var lancamentosMapper = _mapper.Map<IEnumerable<LancamentoViewModel>>(lancamentosDB);
            
            return lancamentosMapper;
        }
        public ValidationResult Add(LancamentoViewModel lancamentoViewModel)
        {
            var contaCorrente = new ContaCorrente();

            //Conta corrente Tipos -> PESSOA JURIDICA e COFRE
            if (lancamentoViewModel.ColaboradorNome == null)
            {
                //Este padr??o de busca de conta corrente
                //prev?? o caso em que a empresa possui duas contas correntes com tipos diferentes
                //ent??o usu??rio diz qual o tipo da conta corrente desta empresa deseja vincular o lan??amento
                contaCorrente = _contaCorrenteRepository
                                        .GetByEmpresaRazaoSocialAndTipo(lancamentoViewModel.EmpresaRazaoSocial, lancamentoViewModel.ContaCorrenteIsTipoCofre);
                
                //Se o status ?? LIQUIDADO verifico o saldo antes de seguir
                //com o lan??amento
                if (lancamentoViewModel.Status == LancamentoStatusEnum.LIQUIDADO.ToString())
                {
                    lancamentoViewModel.DataLiquidacao = DateTime.Now;

                    //Quando lan??amento liquidado for d??bito, ir?? permitir
                    //somente caso tenha saldo na conta corrente
                    if (lancamentoViewModel.Tipo == LancamentoTipoEnum.DEBITO.ToString())
                    {
                        //Verifica se tem saldo para seguir com o lan??amento
                        if(!ContaCorrenteValidations
                            .HasSaldo(_contaCorrenteRepository
                                            .GetSaldoByEmpresaRazaoSocialAndTipo(lancamentoViewModel.EmpresaRazaoSocial, lancamentoViewModel.ContaCorrenteIsTipoCofre),
                                             lancamentoViewModel.ValorLiquido))
                        {
                            _validationResult.AddErrorMessage("Conta corrente n??o possui saldo suficiente para efetuar o lan??amento.");
                            return _validationResult;
                        }
                    }
                }
            }
            //Conta corrente Tipos -> PESSOA FISICA
            else
            {
                contaCorrente = _contaCorrenteRepository
                                        .GetByColaboradorNome(lancamentoViewModel.ColaboradorNome);
                
                //Se o status ?? LIQUIDADO verifico o saldo antes de seguir
                //com o lan??amento
                if (lancamentoViewModel.Status == LancamentoStatusEnum.LIQUIDADO.ToString())
                {
                    lancamentoViewModel.DataLiquidacao = DateTime.Now;

                    //Quando lan??amento liquidado for d??bito, ir?? permitir
                    //somente caso tenha saldo na conta corrente
                    if (lancamentoViewModel.Tipo == LancamentoTipoEnum.DEBITO.ToString())
                    {
                        //Verifica se tem saldo para seguir com o lan??amento
                        if(!ContaCorrenteValidations
                            .HasSaldo(_contaCorrenteManager
                                            .GetSaldoByColaboradorNome(lancamentoViewModel.ColaboradorNome), lancamentoViewModel.ValorLiquido))
                        {
                            _validationResult.AddErrorMessage("Conta corrente n??o possui saldo suficiente para efetuar o lan??amento.");
                            return _validationResult;
                        }
                    }
                }
            }

            #region Begin - Valida????es gen??ricas

            //N??o permite efetuar lan??amento para colaborador sem conta corrente ou sem conta corrente
            if (lancamentoViewModel.EmpresaRazaoSocial == null
                && lancamentoViewModel.ColaboradorNome == null)
            {
                _validationResult.AddErrorMessage("Conta corrente ou Colaborador ?? obrigat??rio.");
                return _validationResult;
            }
                
            //N??o permite efetuar lan??amento para colaborador sem conta corrente
            if (contaCorrente == null)
            {
                _validationResult.AddErrorMessage("Nenhuma conta corrente encontrada para o lan??amento com as informa????es fornecidas.");
                return _validationResult;
            }

            //N??o permite efetuar lan??amento em conta corrente n??o ativa
            if (contaCorrente.Status != ContaCorrenteStatusEnum.ATIVA)
            {
                _validationResult.AddErrorMessage("Conta corrente do lan??amento n??o est?? ativa.");
                return _validationResult;
            }

            var contabilEvento = _contabilEventoRepository.GetByEspecificacao(lancamentoViewModel.ContabilEventoEspecificacao);
            if (contabilEvento == null)
            {
                _validationResult.AddErrorMessage("Nenhum evento encontrado com a especifica????o informada.");
                return _validationResult;
            }

            #endregion End - Valida????es gen??ricas
            
            var lancamento = _mapper.Map<Lancamento>(lancamentoViewModel); 

            lancamento.ContabilEventoId = contabilEvento.Id;
            lancamento.DataUltimoStatus = DateTime.Now;
            lancamento.ContaCorrenteId = (Guid) contaCorrente.Id;
            
            _lancamentoRepository.Add(lancamento);
            
            _unitOfWork.Commit();
        
            return _validationResult;
        }
        public ValidationResult Remove(Guid id)
        {
            var lancamentoDB = _lancamentoRepository.GetByIdForTipoJuridicaAndCofre((Guid) id);

            //N??o permitir deletar lan??amento 'LIQUIDADO' ou 'CANCELADO'  
            if (lancamentoDB.Status == LancamentoStatusEnum.LIQUIDADO ||
                 lancamentoDB.Status == LancamentoStatusEnum.CANCELADO)
            {
                _validationResult.AddErrorMessage("Lan??amento 'LIQUIDADO' ou 'CANCELADO' n??o pode ser deletado."); 
                return _validationResult;
            }

            _lancamentoRepository.Remove(id);
            _unitOfWork.Commit();

            return _validationResult;
        }
        public ValidationResult Update(LancamentoViewModel lancamentoViewModel)
        {
            var lancamentoMapper = new Lancamento();
            var contaCorrente = new ContaCorrente();
            var lancamentoDB = new Lancamento();

            //Conta corrente Tipos -> PESSOA JURIDICA e COFRE
            if (lancamentoViewModel.ColaboradorNome == null)
            {
                lancamentoDB = _lancamentoRepository
                                    .GetByIdWithEmpresa((Guid) lancamentoViewModel.Id);

                //N??o permitir a mudan??a da empresa do lan??amento
                if (lancamentoDB.ContaCorrente.Empresa.RazaoSocial
                        != lancamentoViewModel.EmpresaRazaoSocial)
                {
                    _validationResult.AddErrorMessage("N??o ?? permitido alterar a empresa do lan??amento.");
                    return _validationResult;
                }

                //Em caso de mudan??a de status e o status foi passado para liquidado
                //atualizo a data da mudan??a de status e a data da liquida????o do lan??amento
                if (lancamentoDB.Status.ToString() != lancamentoViewModel.Status)
                {
                    lancamentoViewModel.DataUltimoStatus = DateTime.Now;
                } 
                
                if (lancamentoViewModel.Status == LancamentoStatusEnum.LIQUIDADO.ToString())
                {
                    lancamentoViewModel.DataUltimoStatus = DateTime.Now;
                    lancamentoViewModel.DataLiquidacao = DateTime.Now;

                    //Quando lan??amento liquidado for d??bito, ir?? permitir
                    //somente caso tenha saldo na conta corrente
                    if (lancamentoViewModel.Tipo == LancamentoTipoEnum.DEBITO.ToString())
                    {
                        //Verifica se tem saldo para seguir com o lan??amento
                        if(!ContaCorrenteValidations
                            .HasSaldo(_contaCorrenteRepository
                                            .GetSaldoSemLCTOByEmpresaRazaoSocialAndTipo((Guid) lancamentoViewModel.Id, 
                                                                                        lancamentoViewModel.EmpresaRazaoSocial,
                                                                                        lancamentoViewModel.ContaCorrenteIsTipoCofre), lancamentoViewModel.ValorLiquido))
                        {
                            _validationResult.AddErrorMessage("Conta corrente da empresa n??o possui saldo para efetuar o lan??amento.");
                            return _validationResult;
                        }
                    }
                }
            }
            //Conta corrente Tipos -> PESSOA FISICA
            else
            {
                lancamentoDB = _lancamentoRepository
                                    .GetByIdWithColaborador((Guid) lancamentoViewModel.Id);
                
                //N??o permitir a mudan??a de colaborador do lan??amento
                if (lancamentoDB.ContaCorrente.Colaborador.Detento.Nome
                        != lancamentoViewModel.ColaboradorNome)
                {
                    _validationResult.AddErrorMessage("N??o ?? permitido alterar o colaborador do lan??amento.");
                    return _validationResult;
                }

                //Em caso de mudan??a de status e o status foi passado para liquidado
                //atualizo a data da mudan??a de status e a data da liquida????o do lan??amento
                if (lancamentoDB.Status.ToString() != lancamentoViewModel.Status)
                {
                    lancamentoViewModel.DataUltimoStatus = DateTime.Now;
                } 
                
                if (lancamentoViewModel.Status == LancamentoStatusEnum.LIQUIDADO.ToString())
                {
                    lancamentoViewModel.DataUltimoStatus = DateTime.Now;
                    lancamentoViewModel.DataLiquidacao = DateTime.Now;

                    //Quando lan??amento liquidado for d??bito, ir?? permitir
                    //somente caso tenha saldo na conta corrente
                    if (lancamentoViewModel.Tipo == LancamentoTipoEnum.DEBITO.ToString())
                    {
                        //Verifica se tem saldo para seguir com o lan??amento
                        if(!ContaCorrenteValidations
                            .HasSaldo(_contaCorrenteManager
                                            .GetSaldoSemLCTOByColaboradorNome(lancamentoViewModel.Id.ToString(), lancamentoViewModel.ColaboradorNome), lancamentoViewModel.ValorLiquido))
                        {
                            _validationResult.AddErrorMessage("Conta corrente do colaborador n??o possui saldo para efetuar o lan??amento.");
                            return _validationResult;
                        }
                    }
                }
            }

            #region Begin - Valida????es gen??ricas
            if (lancamentoDB == null)
            {
                _validationResult.AddErrorMessage("Lan??amento n??o encontrado com o id informado.");
                return _validationResult;
            }

            //Havendo uma troca de status, atualizo a data ultimo status
            if (lancamentoViewModel.Status != lancamentoDB.Status.ToString())
                lancamentoViewModel.DataUltimoStatus = DateTime.Now;

            //N??o permite efetuar lan??amento em conta corrente n??o ativa
            if (lancamentoDB.ContaCorrente.Status != ContaCorrenteStatusEnum.ATIVA)
            {
                _validationResult.AddErrorMessage("Conta corrente n??o est?? ativa, portanto, n??o ?? poss??vel efetuar o lan??amento.");
                return _validationResult;
            }

            var contabilEvento = _contabilEventoRepository.GetByEspecificacao(lancamentoViewModel.ContabilEventoEspecificacao);
            if (contabilEvento == null)
            {
                _validationResult.AddErrorMessage("Nenhum evento encontrado com o evento informado.");
                return _validationResult;
            }
            #endregion End - Valida????es gen??ricas
           
            lancamentoViewModel.ContaCorrenteId = lancamentoDB.ContaCorrente.Id;
            lancamentoMapper = _mapper.Map<LancamentoViewModel, Lancamento>(lancamentoViewModel, lancamentoDB);

            lancamentoMapper.ContabilEventoId = contabilEvento.Id;

            _lancamentoRepository.Update(lancamentoMapper);
            _unitOfWork.Commit();
        
            return _validationResult;
        }
        public IEnumerable<LancamentoViewModel> GetAllForFC()
        {
            var lancamentos = _lancamentoRepository.GetAllForFC();
            var lancamentosMapped = _mapper.Map<IEnumerable<LancamentoViewModel>>(lancamentos);

            return lancamentosMapped;
        }

        public void Dispose()
        {
            _lancamentoRepository.Dispose();
        }
    }
}