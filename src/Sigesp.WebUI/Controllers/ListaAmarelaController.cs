using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sigesp.Domain.Interfaces;
using Sigesp.Application.ViewModels.Cards;
using Sigesp.Domain.Enums;
using Sigesp.Application.Interfaces;
using System;
using Microsoft.AspNetCore.Authorization;
using Sigesp.Application.ViewModels.Selects;
using System.Collections.Generic;
using AutoMapper;
using Sigesp.Infra.Data.Context;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Sigesp.WebUI.Helpers.DataTable;
using Sigesp.Application.ViewModels.Reports;
using Sigesp.Application.ViewModels;
using Sigesp.Application.ViewModels.Oficios;

namespace Sigesp.WebUI.Controllers
{
    [Authorize(Roles = "Lista-Amarela_Todos, Lista-Amarela_Relatorios, Master")]
    public class ListaAmarelaController : Controller
    {
        public readonly IDetentoAppService _detentoManager;
        public readonly IDetentoSaidaTemporariaAppService _detentoSTManager;
        public readonly IListaAmarelaAppService _listaAmarelaManager;
        private readonly IMapper _mapper;
        private readonly SigespDbContext _context;

        public ListaAmarelaController(IDetentoAppService detentoManager,
                                      IDetentoSaidaTemporariaAppService detentoSTManager,
                                      IListaAmarelaAppService listaAmarelaManager,
                                      IMapper mapper,
                                      SigespDbContext context)
        {
            _detentoManager = detentoManager;
            _detentoSTManager = detentoSTManager;
            _listaAmarelaManager = listaAmarelaManager;
            _mapper = mapper;
            _context = context;
        }

        public async Task<IActionResult> TodosAsync([FromForm]string ipen)
        {
            try
            {
                var detentos = await _detentoManager.GetAllWithInactiveAsync();

                var listasAmarelas = _listaAmarelaManager.GetAllWithInclude();
                var detentosMD = await _detentoManager.TotalMDAsync();
                var mdsRecebidos = _detentoManager.TotalInstrumentoPrisaoMD();
                var emAudiencia = await _detentoManager.TotalEmAudienciaAsync();

                //Dados cards
                var detentoListaAmarelaCardViewModel = new ListaAmarelaCardViewModel()
                {
                    Ativos = listasAmarelas.Count(x => x.DetentoViewModel.Regime != DetentoRegimeEnum.INTERNACAO_HOSPITALAR.ToString()),
                    Fechados = listasAmarelas
                                    .Where(x => x.DetentoViewModel.Regime == DetentoRegimeEnum.RECOLHIDO_FECHADO.ToString())
                                    .Count(),
                    SemiAbertos = listasAmarelas
                                    .Where(x => x.DetentoViewModel.Regime == DetentoRegimeEnum.RECOLHIDO_SEMIABERTO.ToString())
                                    .Count(),
                    Provisorios = listasAmarelas
                                    .Where(x => x.DetentoViewModel.Regime == DetentoRegimeEnum.PROVISORIO.ToString() ||
                                                x.DetentoViewModel.Regime == DetentoRegimeEnum.PROVISORIO_EXECUCAO_SUSPENSA.ToString())
                                    .Count(),
                    Condenados =  listasAmarelas
                                    .Where(x => x.DetentoViewModel.Regime == DetentoRegimeEnum.RECOLHIDO_FECHADO.ToString()
                                                || x.DetentoViewModel.Regime == DetentoRegimeEnum.RECOLHIDO_SEMIABERTO.ToString()
                                                || x.DetentoViewModel.Regime == DetentoRegimeEnum.SAIDA_TEMPORARIA.ToString())
                                    .Count(),
                    SaidaTemporaria = listasAmarelas
                                        .Where(x => x.DetentoViewModel.Regime == DetentoRegimeEnum.SAIDA_TEMPORARIA.ToString())
                                        .Count(),
                    Alimentos = listasAmarelas
                                        .Where(x => x.DetentoViewModel.Regime == DetentoRegimeEnum.ALIMENTOS.ToString())
                                        .Count(),
                    Temporarias = listasAmarelas
                                        .Where(x => x.DetentoViewModel.Regime == DetentoRegimeEnum.PRISAO_TEMPORARIA.ToString())
                                        .Count(),
                    Outros = listasAmarelas
                                        .Where(x => x.DetentoViewModel.Regime == DetentoRegimeEnum.REGIME_ABERTO.ToString()
                                                    || x.DetentoViewModel.Regime == DetentoRegimeEnum.LIBERDADE_CONDICIONAL.ToString()
                                                    || x.DetentoViewModel.Regime == DetentoRegimeEnum.LIBERDADE_PROVISORIA.ToString()
                                                    || x.DetentoViewModel.Regime == DetentoRegimeEnum.EGRESSO_EDI.ToString()
                                                    || x.DetentoViewModel.Regime == DetentoRegimeEnum.RECOLHIDO_IMPORTACAO.ToString()
                                                    || x.DetentoViewModel.Regime == DetentoRegimeEnum.RECOLHIDO_EDI.ToString())
                                        .Count(),
                    InternacaoHospitalar = listasAmarelas
                                            .Where(x => x.DetentoViewModel.Regime == DetentoRegimeEnum.INTERNACAO_HOSPITALAR.ToString())
                                            .Count(),                                                                                
                    TransferenciasMD = detentosMD,
                    MDsRecebidos = mdsRecebidos,
                    EmAudiencia = emAudiencia,
                    InstrumentosPrisao = EnumExtensions<InstrumentoPrisaoTipoEnum>.GetNames().ToList(),
                    CondenacaoTipos = EnumExtensions<CondenacaoTipoEnum>.GetNames().ToList(),
                    Detentos = detentos.Select(x => x.Nome).ToList(),
                    TransferenciaTipos = EnumExtensions<TransferenciaTipoEnum>.GetNames().ToList(),
                    Regimes = EnumExtensions<DetentoRegimeEnum>.GetNames().ToList(),
                    AguardandoTransferenciaTipos = EnumExtensions<DetentoAguardandoTransferenciaTipoEnum>.GetNames().ToList()
                };
                
                return View(detentoListaAmarelaCardViewModel);

            }
            catch { throw; }
        }

        [Authorize(Roles = "Lista-Amarela_Todos, Master")]
        public IActionResult Relatorios()
        {
            var opcoesOrdenacao = EnumExtensions<STOpcoesOrdenacaoRelatorioEnum>.GetNames().ToList();

            var listaAmarelaSelectViewModel = new ListaAmarelaSelectViewModel()
            {
                TransferenciaTipos = EnumExtensions<TransferenciaTipoEnum>.GetNames().ToList(),
                Regimes = EnumExtensions<DetentoRegimeEnum>.GetNames().ToList(),
                SaidaTemporariaOpcoesOrdenacaoRelatorio = opcoesOrdenacao
            };

            return View(listaAmarelaSelectViewModel);
        }
        
        [Authorize(Roles = "Lista-Amarela_Relatorios, Master")]
        [HttpPost]
        public IActionResult RelatorioTransferidosAsync(ListaAmarelaFilterReportTransferidosViewModel  listaAmarelaFilterReportTransferidosViewModel) 
        {
            ListaAmarelaReportTransferidosViewModel listaAmarelaReportTransferidosViewModel = new ListaAmarelaReportTransferidosViewModel();
            listaAmarelaReportTransferidosViewModel.DetentosTransferidos = new List<DetentoViewModel>();

            listaAmarelaReportTransferidosViewModel.DetentosTransferidos = _detentoManager
                                                                                  .GetAllByFilterReportTransferidos(listaAmarelaFilterReportTransferidosViewModel).ToList();
            listaAmarelaReportTransferidosViewModel.TotalRegistros = listaAmarelaReportTransferidosViewModel.DetentosTransferidos.Count();
            listaAmarelaReportTransferidosViewModel.DataSaidaPeriodo = listaAmarelaFilterReportTransferidosViewModel.DataSaidaPeriodoInicioReportTransferidos != null ?
                                                                        listaAmarelaFilterReportTransferidosViewModel.DataSaidaPeriodoInicioReportTransferidos + " a " + listaAmarelaFilterReportTransferidosViewModel.DataSaidaPeriodoFimReportTransferidos
                                                                        : "Todo";
            listaAmarelaReportTransferidosViewModel.DataRetornoPrevistoPeriodo = listaAmarelaFilterReportTransferidosViewModel.DataRetornoPrevistoPeriodoInicioReportTransferidos != null ?
                                                                                    listaAmarelaFilterReportTransferidosViewModel.DataRetornoPrevistoPeriodoInicioReportTransferidos + " a " + listaAmarelaFilterReportTransferidosViewModel.DataRetornoPrevistoPeriodoFimReportTransferidos
                                                                                    : "Todo";
            listaAmarelaReportTransferidosViewModel.CategoriaNome1 = listaAmarelaFilterReportTransferidosViewModel.TransferenciaTipo == null ||
                                                                        listaAmarelaFilterReportTransferidosViewModel.TransferenciaTipo == TransferenciaTipoEnum.NENHUM.ToString() ? "Todos" : listaAmarelaFilterReportTransferidosViewModel.TransferenciaTipo;

            return View(listaAmarelaReportTransferidosViewModel);
        }

        [Authorize(Roles = "Lista-Amarela_Relatorios, Master")]
        [HttpPost]
        public IActionResult RelatorioPrevisaoBeneficio(ListaAmarelaFilterReportPrevisaoBeneficioViewModel  listaAmarelaFilterReportPrevisaoBeneficioViewModel) 
        {
            ListaAmarelaReportPrevisaoBeneficioViewModel listaAmarelaReportPrevisaoBeneficioViewModel = new ListaAmarelaReportPrevisaoBeneficioViewModel();
            listaAmarelaReportPrevisaoBeneficioViewModel.ListasAmarela = new List<ListaAmarelaViewModel>();

            listaAmarelaReportPrevisaoBeneficioViewModel.ListasAmarela = _listaAmarelaManager
                                                                            .GetAllByFilterReportPrevisaoBeneficio(listaAmarelaFilterReportPrevisaoBeneficioViewModel).ToList();
            listaAmarelaReportPrevisaoBeneficioViewModel.TotalRegistros = listaAmarelaReportPrevisaoBeneficioViewModel.ListasAmarela.Count();
            listaAmarelaReportPrevisaoBeneficioViewModel.DataPrevisaoBeneficioPeriodo = listaAmarelaFilterReportPrevisaoBeneficioViewModel.DataPrevisaoBeneficioInicio != null ?
                                                                        listaAmarelaFilterReportPrevisaoBeneficioViewModel.DataPrevisaoBeneficioInicio + " a " + listaAmarelaFilterReportPrevisaoBeneficioViewModel.DataPrevisaoBeneficioFim
                                                                        : "Todo";
            listaAmarelaReportPrevisaoBeneficioViewModel.CategoriaNome1 = listaAmarelaFilterReportPrevisaoBeneficioViewModel.Regime != null 
                                                                            ? listaAmarelaFilterReportPrevisaoBeneficioViewModel.Regime
                                                                            : "Todos";
            listaAmarelaReportPrevisaoBeneficioViewModel.IsRegimeAlimentosOrTemporaria = listaAmarelaFilterReportPrevisaoBeneficioViewModel.Regime == DetentoRegimeEnum.ALIMENTOS.ToString() ?
                                                                                         true : listaAmarelaFilterReportPrevisaoBeneficioViewModel.Regime == DetentoRegimeEnum.PRISAO_TEMPORARIA.ToString() ? true : false;
            return View(listaAmarelaReportPrevisaoBeneficioViewModel);
        }

        [Authorize(Roles = "Lista-Amarela_Relatorios, Master")]
        [HttpPost]
        public IActionResult RelatorioDataIngresso(ListaAmarelaFilterReportDataIngressoViewModel  listaAmarelaFilterReportDataIngressoViewModel) 
        {
            ListaAmarelaReportDataIngressoViewModel listaAmarelaReportDataIngressoViewModel = new ListaAmarelaReportDataIngressoViewModel();
            listaAmarelaReportDataIngressoViewModel.ListasAmarela = new List<ListaAmarelaViewModel>();

            listaAmarelaReportDataIngressoViewModel.ListasAmarela = _listaAmarelaManager
                                                                            .GetAllByFilterReportDataIngresso(listaAmarelaFilterReportDataIngressoViewModel).ToList();
            listaAmarelaReportDataIngressoViewModel.TotalRegistros = listaAmarelaReportDataIngressoViewModel.ListasAmarela.Count();
            listaAmarelaReportDataIngressoViewModel.DataIngressoPeriodo = listaAmarelaFilterReportDataIngressoViewModel.DataIngressoInicio != null ?
                                                                        listaAmarelaFilterReportDataIngressoViewModel.DataIngressoInicio + " a " + listaAmarelaFilterReportDataIngressoViewModel.DataIngressoFim
                                                                        : "Todo";
            listaAmarelaReportDataIngressoViewModel.CategoriaNome1 = listaAmarelaFilterReportDataIngressoViewModel.Regime != null 
                                                                            ? listaAmarelaFilterReportDataIngressoViewModel.Regime
                                                                            : "Todos";
            return View(listaAmarelaReportDataIngressoViewModel);
        }

        [Authorize(Roles = "Lista-Amarela_Relatorios, Master")]
        [HttpPost]
        public IActionResult RelatorioTotalizadorGaleriaRegime(ListaAmarelaFilterReportTotalizadorGaleriaRegimeViewModel  listaAmarelaFilterReportTotalizadorGaleriaRegimeViewModel) 
        {
            ListaAmarelaReportTotalizadorGaleriaRegimeViewModel listaAmarelaReportTotalizadorGaleriaRegimeViewModel = new ListaAmarelaReportTotalizadorGaleriaRegimeViewModel();
            listaAmarelaReportTotalizadorGaleriaRegimeViewModel.Totalizadores = new List<Totalizador>();

            var detentos = _detentoManager
                                .GetAllByRegime(listaAmarelaFilterReportTotalizadorGaleriaRegimeViewModel.Select2RegimeReportTotalizadorGaleriaRegime);

            foreach (var item in detentos.GroupBy(x => x.Galeria).ToList())
            {
                var totalizador = new Totalizador {
                    Regime = listaAmarelaFilterReportTotalizadorGaleriaRegimeViewModel.Select2RegimeReportTotalizadorGaleriaRegime != null 
                                                                            ? listaAmarelaFilterReportTotalizadorGaleriaRegimeViewModel.Select2RegimeReportTotalizadorGaleriaRegime
                                                                            : "Todos",
                    Galeria = item.Key.ToString(),
                    Total = item.Count()
                };

                listaAmarelaReportTotalizadorGaleriaRegimeViewModel.Totalizadores.Add(totalizador);
            }

            listaAmarelaReportTotalizadorGaleriaRegimeViewModel.TotalRegistros = listaAmarelaReportTotalizadorGaleriaRegimeViewModel.Totalizadores.Count();
            listaAmarelaReportTotalizadorGaleriaRegimeViewModel.CategoriaNome1 = listaAmarelaFilterReportTotalizadorGaleriaRegimeViewModel.Select2RegimeReportTotalizadorGaleriaRegime != null 
                                                                            ? listaAmarelaFilterReportTotalizadorGaleriaRegimeViewModel.Select2RegimeReportTotalizadorGaleriaRegime
                                                                            : "Todos";
            listaAmarelaReportTotalizadorGaleriaRegimeViewModel.TotalRegistros = detentos.Count();
            
            return View(listaAmarelaReportTotalizadorGaleriaRegimeViewModel);
        }

        [Authorize(Roles = "Lista-Amarela_Relatorios, Master")]
        [HttpPost]
        public IActionResult ReportSaidasPrevistas(ListaAmarelaFilterReportSaidasPrevistasViewModel listaAmarelaFilterReportSaidasPrevistasViewModel) 
        {
            ListaAmarelaReportSaidasPrevistasViewModel listaAmarelaReportSaidasPrevistasViewModel = new ListaAmarelaReportSaidasPrevistasViewModel();
            listaAmarelaReportSaidasPrevistasViewModel.DetentosST = new List<DetentoSaidaTemporariaViewModel>();

            var detentosST = _detentoSTManager
                                        .GetAllByFilterReportSaidasPrevistas(listaAmarelaFilterReportSaidasPrevistasViewModel);

            listaAmarelaReportSaidasPrevistasViewModel.DetentosST = detentosST.ToList();
            listaAmarelaReportSaidasPrevistasViewModel.SaidaTemporariaDataSaidaPeriodo = listaAmarelaFilterReportSaidasPrevistasViewModel.DataSaidaPrevistaSTInicio != null ?
                                                                                            listaAmarelaFilterReportSaidasPrevistasViewModel.DataSaidaPrevistaSTInicio + " a " + listaAmarelaFilterReportSaidasPrevistasViewModel.DataSaidaPrevistaSTFim
                                                                                            : "Todo";

            listaAmarelaReportSaidasPrevistasViewModel.TotalRegistros = listaAmarelaReportSaidasPrevistasViewModel.DetentosST.Count();
            listaAmarelaReportSaidasPrevistasViewModel.CategoriaNome1 = "Todos";
            
            return View(listaAmarelaReportSaidasPrevistasViewModel);
        }

        [Authorize(Roles = "Lista-Amarela_Relatorios, Master")]
        [HttpPost]
        public IActionResult ReportAguardandoTransferencia() 
        {
            var listasAmarelas = _listaAmarelaManager
                                        .GetAllAguardandoTransferencia();
            return View(listasAmarelas);
        }

        [Authorize(Roles = "Lista-Amarela_Relatorios, Master")]
        [HttpPost]
        public IActionResult ReportTotalizadorCondenacaoTipo() 
        {
            var totalizadorCondenacaoTipo = _listaAmarelaManager
                                                .TotalizadorByCondenacaoTipo();
            return View(totalizadorCondenacaoTipo);
        }

        [Authorize(Roles = "Oficios-Alimentos, Master")]
        [HttpPost]
        public IActionResult OficioAlimentos([FromForm]string ipen) 
        {
            if (ipen == null)
                return BadRequest("Ipen requerido!");

            var oficio = _listaAmarelaManager.GetByDetentoIpen(ipen);
            var oficioAlimentosViewModel = new OficioAlimentosViewModel();

            if (oficio != null)
            {
                //Dados oficio
                oficioAlimentosViewModel.Nome = oficio.DetentoViewModel.Nome;
                oficioAlimentosViewModel.Ipen = oficio.DetentoViewModel.Ipen;
                oficioAlimentosViewModel.Comarca = oficio.Comarca;
                oficioAlimentosViewModel.Autos = oficio.AcaoPenal;
                oficioAlimentosViewModel.PrazoPrisao = oficio.PenaDia;
                oficioAlimentosViewModel.DataPrisao = oficio.DataPrisao;
                oficioAlimentosViewModel.DataSaida = oficio.DataSaidaPrevista;
            }

            return View(oficioAlimentosViewModel);
        }
    }
}