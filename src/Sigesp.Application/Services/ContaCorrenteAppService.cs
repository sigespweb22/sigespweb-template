using System.Linq;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Sigesp.Domain.Interfaces;
using Sigesp.Domain.Models;
using Sigesp.Application.Interfaces;
using Sigesp.Application.ViewModels;
using Sigesp.Domain.Enums;
using Sigesp.Application.Extensions;

namespace Sigesp.Application.Services
{
    public class ContaCorrenteAppService : IContaCorrenteAppService
    {
        private readonly ValidationResult _validationResult;
        private readonly IContaCorrenteRepository _contaCorrenteRepository;
        private readonly IColaboradorRepository _colaboradorRepository;
        private readonly IEmpresaRepository _empresaRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ContaCorrenteAppService(IContaCorrenteRepository contaCorrenteRepository, 
                                        IColaboradorRepository colaboradorRepository,
                                        IEmpresaRepository empresaRepository,
                                        IUnitOfWork unitOfWork, IMapper mapper,
                                        ValidationResult validationResult)
        {
            _contaCorrenteRepository = contaCorrenteRepository;
            _colaboradorRepository = colaboradorRepository;
            _empresaRepository = empresaRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _validationResult = validationResult; 
        }
        public ContaCorrente GetById(Guid id)
        {
            var contaCorrente = _contaCorrenteRepository.GetById(id);
            return contaCorrente;
        }
        public async Task<IEnumerable<ContaCorrenteViewModel>> GetAllAsync()
        {
            var contasCorrentesDB = await _contaCorrenteRepository
                                                .GetAllWithIncludeAsync();

            var contasCorrentesMapper = _mapper.Map<IEnumerable<ContaCorrenteViewModel>>(contasCorrentesDB);
            
            return contasCorrentesMapper;
        }       
        public decimal GetSaldoByColaboradorId(Guid colaboradorId)
        {
            var saldo = _contaCorrenteRepository.GetSaldoByColaboradorId(colaboradorId);
            
            return saldo;
        }
        public decimal GetSaldoByColaboradorNome(string colaboradorNome)
        {
            var saldo = _contaCorrenteRepository.GetSaldoByColaboradorNome(colaboradorNome);
            
            return saldo;
        }
        public decimal GetSaldoSemLCTOByEmpresaRazaoSocialAndTipo(string lancamentoId, 
                                                                    string empresaRazaoSocial, 
                                                                    bool isTipoCofre)
        {   
            decimal saldo = 0;

            if (lancamentoId == null || lancamentoId == "")
            {
                saldo = _contaCorrenteRepository.GetSaldoByEmpresaRazaoSocialAndTipo(empresaRazaoSocial, isTipoCofre);
            }
            else
            {
                saldo = _contaCorrenteRepository
                                    .GetSaldoSemLCTOByEmpresaRazaoSocialAndTipo(Guid.Parse(lancamentoId), empresaRazaoSocial, isTipoCofre);
            }
            
            return saldo;
        }
        public ValidationResult Add(ContaCorrenteViewModel contaCorrenteViewModel)
        {
            try
            {
                //Tipos -> PESSOA JURIDICA e COFRE
                if (contaCorrenteViewModel.Tipo == ContaCorrenteTipoEnum.PESSOA_JURIDICA.ToString()
                    || contaCorrenteViewModel.Tipo == ContaCorrenteTipoEnum.COFRE.ToString())
                {
                    var empresa = _empresaRepository
                                    .GetByRazaoSocial(contaCorrenteViewModel.EmpresaRazaoSocial);

                    if (empresa == null)
                    {
                        _validationResult.AddErrorMessage("Nenhuma empresa encontrada com a razão social informada!");
                        return _validationResult;
                    }

                    var contaCorrenteEmpresa = _contaCorrenteRepository
                                                        .GetAllByEmpresaId(empresa.Id);
                     
                    if (contaCorrenteEmpresa.Count() <= 0)
                    {
                        if (contaCorrenteViewModel.Descricao == null 
                            || contaCorrenteViewModel.Descricao == "")
                        {
                            _validationResult.AddErrorMessage("Descrição obrigatória!");
                            return _validationResult;
                        }

                        var contaCorrenteMapped = _mapper.Map<ContaCorrente>(contaCorrenteViewModel);
                        contaCorrenteMapped.EmpresaId = empresa.Id;
                        //Gerar número de conta corrente e verificar se não existe
                        GetNumero:
                        contaCorrenteMapped.Numero = Convert.ToInt32(RandomExtensions.GenerateIntMaxLength6());

                        if (_contaCorrenteRepository.NumeroAlready(contaCorrenteMapped.Numero))
                            goto GetNumero;

                        _contaCorrenteRepository.Add(contaCorrenteMapped);
                    }
                    else
                    {
                        if (contaCorrenteViewModel.Descricao == null 
                            || contaCorrenteViewModel.Descricao == "")
                        {
                            _validationResult.AddErrorMessage("Descrição obrigatória!");
                            return _validationResult;
                        }

                        //verifica se possui alguma ativa com o mesmo tipo
                        var tipoAlready = contaCorrenteEmpresa
                                            .Any(x => x.Tipo
                                                 == (ContaCorrenteTipoEnum) Enum.Parse(typeof(ContaCorrenteTipoEnum), contaCorrenteViewModel.Tipo));
                        if (tipoAlready)
                        {
                            _validationResult.AddErrorMessage("Empresa já possui uma conta corrente do mesmo tipo cadastrada.");
                            return _validationResult;
                        }

                        var contaCorrenteMapped = _mapper.Map<ContaCorrente>(contaCorrenteViewModel);
                        contaCorrenteMapped.EmpresaId = empresa.Id;
                        //Gerar número de conta corrente e verificar se não existe
                        GetNumero:
                        contaCorrenteMapped.Numero = Convert.ToInt32(RandomExtensions.GenerateIntMaxLength6());

                        if (_contaCorrenteRepository.NumeroAlready(contaCorrenteMapped.Numero))
                            goto GetNumero;

                        _contaCorrenteRepository.Add(contaCorrenteMapped);
                    }
                }
                //Tipos -> PESSOA FISICA
                else 
                {
                    var colaborador = _colaboradorRepository
                                         .GetByDetentoNome(contaCorrenteViewModel.ColaboradorNome);

                    if (colaborador == null)
                    {
                        _validationResult.AddErrorMessage("Nenhum colaborador encontrado com o nome informado!");
                        return _validationResult;
                    }

                    var contaCorrenteColaborador = _contaCorrenteRepository
                                                        .GetAllByColaboradorId(colaborador.Id);
                     
                    if (contaCorrenteColaborador.Count() <= 0)
                    {
                        var contaCorrenteMapped = _mapper.Map<ContaCorrente>(contaCorrenteViewModel);
                        contaCorrenteMapped.Numero = colaborador.Detento.Ipen;
                        contaCorrenteMapped.ColaboradorId = colaborador.Id;
                        
                        _contaCorrenteRepository.Add(contaCorrenteMapped);
                    }
                    else
                    {
                        //verifica se possui alguma ativa com o mesmo tipo
                        var tipoAlready = contaCorrenteColaborador
                                            .Any(x => x.Tipo
                                                 == (ContaCorrenteTipoEnum) Enum.Parse(typeof(ContaCorrenteTipoEnum), contaCorrenteViewModel.Tipo));
                        if (tipoAlready)
                        {
                            _validationResult.AddErrorMessage("Colaborador já possui uma conta corrente do mesmo tipo cadastrada.");
                            return _validationResult;
                        }
                    }
                }

                _unitOfWork.Commit();
                return _validationResult;                
            }
            catch (System.Exception ex)
            {
                if (ex.InnerException == null)
                    _validationResult.AddErrorMessage(ex.Message);
                _validationResult.AddErrorMessage(ex.InnerException.Message);
                
                return _validationResult;
            }
        }
        public ValidationResult Update(ContaCorrenteViewModel contaCorrenteViewModel)
        {
            try
            {
                var contaCorrenteDB = new ContaCorrente();
                var contaCorrenteMapped = new ContaCorrente();

                if (contaCorrenteViewModel.Tipo == ContaCorrenteTipoEnum.PESSOA_FISICA.ToString())
                {
                    contaCorrenteDB = _contaCorrenteRepository
                                            .GetByIdWithColaborador((Guid) contaCorrenteViewModel.Id);
                }
                else
                {
                    contaCorrenteDB = _contaCorrenteRepository
                                        .GetByIdWithIncludeOne((Guid) contaCorrenteViewModel.Id, "Empresa");
                }

                if (contaCorrenteDB == null)
                {
                    _validationResult.AddErrorMessage("Nenhuma conta corrente encontrada para atualização com o id informado.");
                    return _validationResult;
                }

                #region Begin - Validações genéricas
                //Não permitir encerrar uma conta que possui saldo
                if (contaCorrenteViewModel.Status == ContaCorrenteStatusEnum.ENCERRADA.ToString()
                    && contaCorrenteDB.Status != ContaCorrenteStatusEnum.ENCERRADA)
                {
                    if (ContaCorrenteValidations.HasSaldoByCreditoDebito(
                            contaCorrenteDB.Lancamentos
                                .Where(x => x.Tipo == LancamentoTipoEnum.CREDITO)
                                .Sum(x => x.ValorLiquido), 
                            contaCorrenteDB.Lancamentos
                                .Where(x => x.Tipo == LancamentoTipoEnum.DEBITO)
                                .Sum(x => x.ValorLiquido)))
                    {
                        _validationResult.AddErrorMessage("Não é possível encerrar uma conta corrente com saldo.");
                        return _validationResult;
                    }
                }

                //Não permitir bloquear uma conta encerrada uma conta que possui saldo
                if (contaCorrenteViewModel.Status
                        == ContaCorrenteStatusEnum.BLOQUEADA.ToString())
                {
                    if (contaCorrenteDB.Status == ContaCorrenteStatusEnum.ENCERRADA)
                    {
                        _validationResult.AddErrorMessage("Não é possível bloquear uma conta corrente encerrada.");
                        return _validationResult;
                    }
                }                       
                #endregion End - Validações genéricas                

                //Verifica qual tipo da conta corrente para aplicar
                //as validações específicas a cada tipo de conta, bem como finalizar as atualizações
                if (contaCorrenteDB.Tipo == ContaCorrenteTipoEnum.PESSOA_FISICA)
                {
                    //Validações conta de colaboradores e detentos

                    //Não permitir trocar colaborador da conta corrente
                    if (contaCorrenteViewModel.ColaboradorNome 
                            != contaCorrenteDB.Colaborador.Detento.Nome)
                    {
                        _validationResult.AddErrorMessage("Não é permitido trocar o colaborador da conta corrente.");
                        return _validationResult;
                    }

                    //Verifica se possui alguma ativa com o mesmo tipo
                    var already = _contaCorrenteRepository.ContaCorrenteColaboradorAlreadyByTipoAndColaboradorIdAndDiffId(
                                                            contaCorrenteDB.Id,
                                                            contaCorrenteDB.Colaborador.Id,
                                                            (ContaCorrenteTipoEnum) Enum.Parse(typeof(ContaCorrenteTipoEnum), contaCorrenteViewModel.Tipo));
                    if (already)
                    {
                        _validationResult.AddErrorMessage("Colaborador já possui uma conta corrente do mesmo tipo cadastrada.");
                        return _validationResult;
                    }

                    contaCorrenteViewModel.ColaboradorId = contaCorrenteDB.Colaborador.Id;
                    contaCorrenteMapped = _mapper.Map<ContaCorrenteViewModel, ContaCorrente>(contaCorrenteViewModel, contaCorrenteDB);
                    
                }
                else
                {
                    if (contaCorrenteViewModel.Descricao == null 
                        || contaCorrenteViewModel.Descricao == "")
                    {
                        _validationResult.AddErrorMessage("Descrição obrigatória!");
                        return _validationResult;
                    }

                    //Verifica se possui alguma ativa com o mesmo tipo
                    var already = _contaCorrenteRepository.ContaCorrenteEmpresaAlreadyByTipoAndEmpresaIdAndDiffId(
                                                            contaCorrenteDB.Id,
                                                            contaCorrenteDB.Empresa.Id, 
                                                            (ContaCorrenteTipoEnum) Enum.Parse(typeof(ContaCorrenteTipoEnum), contaCorrenteViewModel.Tipo));
                    if (already)
                    {
                        _validationResult.AddErrorMessage("Empresa já possui uma conta corrente do mesmo tipo cadastrada.");
                        return _validationResult;
                    }

                    //Não permite trocar empresa da conta corrente
                    if (contaCorrenteViewModel.EmpresaRazaoSocial 
                            != contaCorrenteDB.Empresa.RazaoSocial)
                    {
                        _validationResult.AddErrorMessage("Não é permitido trocar a empresa da conta corrente.");
                        return _validationResult;
                    }

                    contaCorrenteViewModel.EmpresaId = contaCorrenteDB.EmpresaId;
                    contaCorrenteMapped = _mapper.Map<ContaCorrenteViewModel, ContaCorrente>(contaCorrenteViewModel, contaCorrenteDB);
                }                             

                _contaCorrenteRepository.Update(contaCorrenteMapped);
                _unitOfWork.Commit();

                return _validationResult;
            }
            catch (System.Exception ex)
            {
                if (ex.InnerException == null)
                {
                    _validationResult.AddErrorMessage(ex.Message);
                }
                else
                {
                    _validationResult.AddErrorMessage(ex.InnerException.Message);
                } 

                return _validationResult;
            }
        }
        public ContaCorrenteViewModel GetByColaboradorNome(string colaboradorNome)
        {
            var contaCorrente = _mapper.Map<ContaCorrenteViewModel>(_contaCorrenteRepository.GetByColaboradorNomeIgnoreFilter(colaboradorNome));
            
            return contaCorrente;
        }
        public ContaCorrenteViewModel GetByColaboradorNomeWithInclude(string colaboradorNome)
        {
            var contaCorrente = _mapper.Map<ContaCorrenteViewModel>(_contaCorrenteRepository.GetByColaboradorNomeWithInclude(colaboradorNome));
            
            return contaCorrente;
        }
        public bool NumeroAlready(int numero)
        {
            return _contaCorrenteRepository
                    .AsNoTracking()
                    .Where(x => x.Numero == numero)
                    .Any();
        }
        public bool AlreadyByColaboradorId(Guid colaboradorId)
        {
            return _contaCorrenteRepository
                    .AsNoTracking()
                    .Where(x => x.ColaboradorId == colaboradorId)
                    .Any();
        }
        public ValidationResult Remove(Guid id)
        {
            var contaCorrente = _contaCorrenteRepository.GetByIdWithIncludeOne(id, "Lancamentos");

            //Não permitir deletar conta corrente que possua lançamento
            if (contaCorrente.Lancamentos.Count() > 0)
            {
                _validationResult.AddErrorMessage("Não é possível excluir 'CONTA CORRENTE' que possui lançamento."); 
                return _validationResult;
            }

            _contaCorrenteRepository.Remove(id);
            _unitOfWork.Commit();

            return _validationResult;
        }
        public IEnumerable<ContaCorrenteViewModel> GetAllForFC()
        {
            var contasCorrentes = _contaCorrenteRepository.GetAllForFC();
            var contasCorrentesMapped = _mapper
                                            .Map<IEnumerable<ContaCorrenteViewModel>>(contasCorrentes);

            return contasCorrentesMapped;
        }
        public IEnumerable<ContaCorrenteViewModel> GetAll()
        {
            var contasCorrentes = _contaCorrenteRepository.GetAll();
            var contasCorrentesMapped = _mapper.Map<IEnumerable<ContaCorrenteViewModel>>(contasCorrentes);

            return contasCorrentesMapped;
        }
        public IEnumerable<ContaCorrenteViewModel> GetAllByTipos(List<ContaCorrenteTipoEnum> tipos)
        {
            var contasCorrentes = _contaCorrenteRepository.GetAllByTipos(tipos);
            var contasCorrentesMapped = _mapper.Map<IEnumerable<ContaCorrenteViewModel>>(contasCorrentes);

            return contasCorrentesMapped;
        }
        public decimal GetSaldoSemLCTOByColaboradorNome(string lancamentoId, string colaboradorNome)
        {
            decimal saldo = 0;

            if (lancamentoId == null || lancamentoId == "")
            {
                saldo = _contaCorrenteRepository
                                    .GetSaldoByColaboradorNome(colaboradorNome);
            }
            else
            {
                saldo = _contaCorrenteRepository
                            .GetSaldoSemLCTOByColaboradorNome(Guid.Parse(lancamentoId), colaboradorNome);
            }

            return saldo;
        }

        public void Dispose()
        {
            _contaCorrenteRepository.Dispose();
        }
    }
}