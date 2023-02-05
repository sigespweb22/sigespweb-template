using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Sigesp.Application.Interfaces;
using Sigesp.Application.ViewModels.Cards;
using Sigesp.Domain.Interfaces;
using System.Linq;
using Sigesp.Domain.Enums;

namespace Sigesp.WebUI.Controllers
{
    [Authorize(Roles = "Fluxo-Caixa-Lancamentos_Todos, Fluxo-Caixa-Contas-Correntes_Todos, Master")]
    public class FluxoCaixaController : BaseController
    {
        public readonly ILancamentoAppService _lancamentoManager;
        public readonly ILancamentoRepository _lancamentoRepository;
        public readonly IContaCorrenteAppService _contaCorrenteManager;
        public readonly IContabilEventoAppService _contabilEventosManager;
        public readonly IEmpresaAppService _empresaManager;

        public FluxoCaixaController(ILancamentoAppService lancamentoManager,
                                    IEmpresaAppService empresaManager,
                                    ILancamentoRepository lancamentoRepository,
                                    IContabilEventoAppService contabilEventosManager,
                                    IContaCorrenteAppService contaCorrenteManager
                                    )
        {
            _lancamentoManager = lancamentoManager;
            _contaCorrenteManager = contaCorrenteManager;
            _lancamentoRepository = lancamentoRepository;
            _contabilEventosManager = contabilEventosManager;
            _empresaManager = empresaManager;
        }

        [Authorize(Roles = "Fluxo-Caixa-Contas-Correntes_Todos, Master")]
        public IActionResult ContasCorrentes()
        {
            try
            {
                var contasCorrentes = _contaCorrenteManager
                                        .GetAllForFC();
                
                var empresas = _empresaManager.GetAll();
                var tipos = EnumExtensions<ContaCorrenteTipoEnum>
                                .GetNamesWithRemove(ContaCorrenteTipoEnum.PESSOA_FISICA.ToString()).ToList();

                var contaCorrenteCardViewModel = new ContaCorrenteCardViewModel()
                {
                    Ativas = contasCorrentes
                                    .Where(x => x.Status == ContaCorrenteStatusEnum.ATIVA.ToString())
                                    .Count(),
                    Encerradas = contasCorrentes
                                    .Where(x => x.Status == ContaCorrenteStatusEnum.ENCERRADA.ToString())
                                    .Count(),
                    Bloqueadas = contasCorrentes
                                    .Where(x => x.Status == ContaCorrenteStatusEnum.BLOQUEADA.ToString())
                                    .Count(),
                    Saldos = (decimal)contasCorrentes.Sum(x => x.Saldo),
                    Empresas = empresas.Select(x => x.RazaoSocial).ToList(),
                    Status = EnumExtensions<ContaCorrenteStatusEnum>.GetNames().ToList(),
                    Tipos = tipos
                };

                return View(contaCorrenteCardViewModel);
            }
            catch {  throw; }
        }

        [Authorize(Roles = "Fluxo-Caixa-Lancamentos_Todos, Master")]
        public IActionResult Lancamentos() 
        {
            try
            {
                var empresas = _empresaManager.GetAll();

                var lancamentos = _lancamentoManager
                                    .GetAllForFC();

                var contasCorrente = _contaCorrenteManager
                                        .GetAllForFC();

                var contabilEventos = _contabilEventosManager
                                        .GetAll();
                                        
                //Dados cards
                var lancamentoCardViewModel = new LancamentoCardViewModel()
                {
                    Pendentes = lancamentos.Where(x => x.Status == LancamentoStatusEnum.PENDENTE.ToString()).Count(),
                    Liquidados = lancamentos.Where(x => x.Status == LancamentoStatusEnum.LIQUIDADO.ToString()).Count(),
                    Creditos =  lancamentos.Where(x => x.Tipo == LancamentoTipoEnum.CREDITO.ToString()).Count(),
                    Debitos = lancamentos.Where(x => x.Tipo == LancamentoTipoEnum.DEBITO.ToString()).Count(),
                    ContasCorrentes = contasCorrente.Select(x => x.Descricao).ToList(),
                    PeriodosReferencia = EnumExtensions<LancamentoPeriodoReferenciaEnum>.GetNames().ToList(),
                    Status = EnumExtensions<LancamentoStatusEnum>.GetNames().ToList(),
                    TiposLancamento = EnumExtensions<LancamentoTipoEnum>.GetNames().ToList(),
                    Empresas = empresas.Select(x => x.RazaoSocial).ToList(),
                    ContabilEventos = contabilEventos.Select(x => x.Especificacao).ToList()
                };
                
                return View(lancamentoCardViewModel);

            }
            catch { throw; }
        }
    }
}
