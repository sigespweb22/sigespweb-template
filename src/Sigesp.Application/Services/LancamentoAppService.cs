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
                //Este padrão de busca de conta corrente
                //prevê o caso em que a empresa possui duas contas correntes com tipos diferentes
                //então usuário diz qual o tipo da conta corrente desta empresa deseja vincular o lançamento
                contaCorrente = _contaCorrenteRepository
                                        .GetByEmpresaRazaoSocialAndTipo(lancamentoViewModel.EmpresaRazaoSocial, lancamentoViewModel.ContaCorrenteIsTipoCofre);
                
                //Se o status é LIQUIDADO verifico o saldo antes de seguir
                //com o lançamento
                if (lancamentoViewModel.Status == LancamentoStatusEnum.LIQUIDADO.ToString())
                {
                    lancamentoViewModel.DataLiquidacao = DateTime.Now;

                    //Quando lançamento liquidado for débito, irá permitir
                    //somente caso tenha saldo na conta corrente
                    if (lancamentoViewModel.Tipo == LancamentoTipoEnum.DEBITO.ToString())
                    {
                        //Verifica se tem saldo para seguir com o lançamento
                        if(!ContaCorrenteValidations
                            .HasSaldo(_contaCorrenteRepository
                                            .GetSaldoByEmpresaRazaoSocialAndTipo(lancamentoViewModel.EmpresaRazaoSocial, lancamentoViewModel.ContaCorrenteIsTipoCofre),
                                             lancamentoViewModel.ValorLiquido))
                        {
                            _validationResult.AddErrorMessage("Conta corrente não possui saldo suficiente para efetuar o lançamento.");
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
                
                //Se o status é LIQUIDADO verifico o saldo antes de seguir
                //com o lançamento
                if (lancamentoViewModel.Status == LancamentoStatusEnum.LIQUIDADO.ToString())
                {
                    lancamentoViewModel.DataLiquidacao = DateTime.Now;

                    //Quando lançamento liquidado for débito, irá permitir
                    //somente caso tenha saldo na conta corrente
                    if (lancamentoViewModel.Tipo == LancamentoTipoEnum.DEBITO.ToString())
                    {
                        //Verifica se tem saldo para seguir com o lançamento
                        if(!ContaCorrenteValidations
                            .HasSaldo(_contaCorrenteManager
                                            .GetSaldoByColaboradorNome(lancamentoViewModel.ColaboradorNome), lancamentoViewModel.ValorLiquido))
                        {
                            _validationResult.AddErrorMessage("Conta corrente não possui saldo suficiente para efetuar o lançamento.");
                            return _validationResult;
                        }
                    }
                }
            }

            #region Begin - Validações genéricas

            //Não permite efetuar lançamento para colaborador sem conta corrente ou sem conta corrente
            if (lancamentoViewModel.EmpresaRazaoSocial == null
                && lancamentoViewModel.ColaboradorNome == null)
            {
                _validationResult.AddErrorMessage("Conta corrente ou Colaborador é obrigatório.");
                return _validationResult;
            }
                
            //Não permite efetuar lançamento para colaborador sem conta corrente
            if (contaCorrente == null)
            {
                _validationResult.AddErrorMessage("Nenhuma conta corrente encontrada para o lançamento com as informações fornecidas.");
                return _validationResult;
            }

            //Não permite efetuar lançamento em conta corrente não ativa
            if (contaCorrente.Status != ContaCorrenteStatusEnum.ATIVA)
            {
                _validationResult.AddErrorMessage("Conta corrente do lançamento não está ativa.");
                return _validationResult;
            }

            var contabilEvento = _contabilEventoRepository.GetByEspecificacao(lancamentoViewModel.ContabilEventoEspecificacao);
            if (contabilEvento == null)
            {
                _validationResult.AddErrorMessage("Nenhum evento encontrado com a especificação informada.");
                return _validationResult;
            }

            #endregion End - Validações genéricas
            
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

            //Não permitir deletar lançamento 'LIQUIDADO' ou 'CANCELADO'  
            if (lancamentoDB.Status == LancamentoStatusEnum.LIQUIDADO ||
                 lancamentoDB.Status == LancamentoStatusEnum.CANCELADO)
            {
                _validationResult.AddErrorMessage("Lançamento 'LIQUIDADO' ou 'CANCELADO' não pode ser deletado."); 
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

                //Não permitir a mudança da empresa do lançamento
                if (lancamentoDB.ContaCorrente.Empresa.RazaoSocial
                        != lancamentoViewModel.EmpresaRazaoSocial)
                {
                    _validationResult.AddErrorMessage("Não é permitido alterar a empresa do lançamento.");
                    return _validationResult;
                }

                //Em caso de mudança de status e o status foi passado para liquidado
                //atualizo a data da mudança de status e a data da liquidação do lançamento
                if (lancamentoDB.Status.ToString() != lancamentoViewModel.Status)
                {
                    lancamentoViewModel.DataUltimoStatus = DateTime.Now;
                } 
                
                if (lancamentoViewModel.Status == LancamentoStatusEnum.LIQUIDADO.ToString())
                {
                    lancamentoViewModel.DataUltimoStatus = DateTime.Now;
                    lancamentoViewModel.DataLiquidacao = DateTime.Now;

                    //Quando lançamento liquidado for débito, irá permitir
                    //somente caso tenha saldo na conta corrente
                    if (lancamentoViewModel.Tipo == LancamentoTipoEnum.DEBITO.ToString())
                    {
                        //Verifica se tem saldo para seguir com o lançamento
                        if(!ContaCorrenteValidations
                            .HasSaldo(_contaCorrenteRepository
                                            .GetSaldoSemLCTOByEmpresaRazaoSocialAndTipo((Guid) lancamentoViewModel.Id, 
                                                                                        lancamentoViewModel.EmpresaRazaoSocial,
                                                                                        lancamentoViewModel.ContaCorrenteIsTipoCofre), lancamentoViewModel.ValorLiquido))
                        {
                            _validationResult.AddErrorMessage("Conta corrente da empresa não possui saldo para efetuar o lançamento.");
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
                
                //Não permitir a mudança de colaborador do lançamento
                if (lancamentoDB.ContaCorrente.Colaborador.Detento.Nome
                        != lancamentoViewModel.ColaboradorNome)
                {
                    _validationResult.AddErrorMessage("Não é permitido alterar o colaborador do lançamento.");
                    return _validationResult;
                }

                //Em caso de mudança de status e o status foi passado para liquidado
                //atualizo a data da mudança de status e a data da liquidação do lançamento
                if (lancamentoDB.Status.ToString() != lancamentoViewModel.Status)
                {
                    lancamentoViewModel.DataUltimoStatus = DateTime.Now;
                } 
                
                if (lancamentoViewModel.Status == LancamentoStatusEnum.LIQUIDADO.ToString())
                {
                    lancamentoViewModel.DataUltimoStatus = DateTime.Now;
                    lancamentoViewModel.DataLiquidacao = DateTime.Now;

                    //Quando lançamento liquidado for débito, irá permitir
                    //somente caso tenha saldo na conta corrente
                    if (lancamentoViewModel.Tipo == LancamentoTipoEnum.DEBITO.ToString())
                    {
                        //Verifica se tem saldo para seguir com o lançamento
                        if(!ContaCorrenteValidations
                            .HasSaldo(_contaCorrenteManager
                                            .GetSaldoSemLCTOByColaboradorNome(lancamentoViewModel.Id.ToString(), lancamentoViewModel.ColaboradorNome), lancamentoViewModel.ValorLiquido))
                        {
                            _validationResult.AddErrorMessage("Conta corrente do colaborador não possui saldo para efetuar o lançamento.");
                            return _validationResult;
                        }
                    }
                }
            }

            #region Begin - Validações genéricas
            if (lancamentoDB == null)
            {
                _validationResult.AddErrorMessage("Lançamento não encontrado com o id informado.");
                return _validationResult;
            }

            //Havendo uma troca de status, atualizo a data ultimo status
            if (lancamentoViewModel.Status != lancamentoDB.Status.ToString())
                lancamentoViewModel.DataUltimoStatus = DateTime.Now;

            //Não permite efetuar lançamento em conta corrente não ativa
            if (lancamentoDB.ContaCorrente.Status != ContaCorrenteStatusEnum.ATIVA)
            {
                _validationResult.AddErrorMessage("Conta corrente não está ativa, portanto, não é possível efetuar o lançamento.");
                return _validationResult;
            }

            var contabilEvento = _contabilEventoRepository.GetByEspecificacao(lancamentoViewModel.ContabilEventoEspecificacao);
            if (contabilEvento == null)
            {
                _validationResult.AddErrorMessage("Nenhum evento encontrado com o evento informado.");
                return _validationResult;
            }
            #endregion End - Validações genéricas
           
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