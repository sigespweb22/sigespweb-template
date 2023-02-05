using System.Net.Mime;
using System.Collections;
using System.Xml.Linq;
using System.Runtime.CompilerServices;
using System.Net.NetworkInformation;
using System.Reflection.Metadata;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sigesp.Infra.Data.Context;
using Sigesp.WebUI.Extensions;
using Sigesp.WebUI.Models;
using Sigesp.Domain.Models;
using Sigesp.Application.ViewModels;
using Sigesp.Application.Services;
using Sigesp.Application.Interfaces;
using AutoMapper;
using Sigesp.Domain.Enums;
using Sigesp.Application.ViewModels.Cards;
using Sigesp.Application.ViewModels.Selects;
using Sigesp.Domain.Interfaces;
using Sigesp.Application.ViewModels.Reports;
using static Sigesp.Application.ViewModels.Reports.ColaboradorReportViewModel;
using Microsoft.AspNetCore.Authorization;
using static Sigesp.Application.ViewModels.Reports.ContaCorrenteReport2ViewModel;
using Sigesp.WebUI.Helpers.DataTable;
using Sigesp.WebUI.Helpers;

namespace Sigesp.WebUI.Controllers
{
    [Authorize(Roles = "Contas-Correntes_Todos, Contas-Correntes_Relatorios, Master")]
    public class ContaCorrenteController : Controller
    {
        private readonly IColaboradorAppService _colaboradorManager;
        private readonly IContaCorrenteAppService _contaCorrenteManager;
        private readonly IContaCorrenteRepository _contaCorrenteRepository;
        private readonly IMapper _mapper;
        private readonly SigespDbContext _context;
        private readonly IColaboradorRepository _colaboradorRepository;

        public ContaCorrenteController(IColaboradorAppService colaboradorManager,
                                    IContaCorrenteAppService contaCorrenteManager,
                                    IContaCorrenteRepository contaCorrenteRepository,
                                    SigespDbContext context,
                                    IMapper mapper,
                                    IColaboradorRepository colaboradorRepository)
        {
            _colaboradorManager = colaboradorManager;
            _contaCorrenteManager = contaCorrenteManager;
            _contaCorrenteRepository = contaCorrenteRepository;
            _context = context;
            _mapper = mapper;
            _colaboradorRepository = colaboradorRepository;
        }

        [Authorize(Roles = "Contas-Correntes_Todos, Master")]
        public IActionResult Todas()
        {
            // var colaboradores = _colaboradorManager
            //                           .GetAll();

            var colaboradores = _colaboradorManager
                                      .GetAll();
                                      
            var tipos = new List<ContaCorrenteTipoEnum>();
            tipos.Add(ContaCorrenteTipoEnum.PESSOA_FISICA);

            var contasCorrentes = _contaCorrenteManager
                                        .GetAllByTipos(tipos);

            decimal saldoContaCorrente = 0;
            
            saldoContaCorrente = (decimal)contasCorrentes
                                        .Sum(x => x.Saldo);

            //Dados cards
            var contaCorrenteCardViewModel = new ContaCorrenteCardViewModel()
            {
                Ativas = contasCorrentes.Where(x => x.Status == ContaCorrenteStatusEnum.ATIVA.ToString()).Count(),
                Encerradas = contasCorrentes.Where(x => x.Status == ContaCorrenteStatusEnum.ENCERRADA.ToString()).Count(),
                Bloqueadas =  contasCorrentes.Where(x => x.Status == ContaCorrenteStatusEnum.BLOQUEADA.ToString()).Count(),
                Saldos = saldoContaCorrente,
                Colaboradores = colaboradores.Select(x => x.Detento.Nome).ToList(),
                Status = EnumExtensions<ContaCorrenteStatusEnum>.GetNames().ToList(),
                Tipos = EnumExtensions<ContaCorrenteTipoEnum>.GetNames().ToList()
            };  

            return View(contaCorrenteCardViewModel);
        }

        [Authorize(Roles = "Contas-Correntes_Relatorios, Master")]
        public IActionResult Relatorios()
        {
            var colaboradores = _colaboradorManager
                                      .AsNoTrackingWithInclude()
                                      .Where(x => x.HasContaCorrente);

            var contaCorrenteRelatorioSelect2ViewModel = new ContaCorrenteRelatorioSelect2ViewModel()
            {
                Colaboradores = colaboradores.Select(x => x.DetentoNome).ToList()
            };

            return View(contaCorrenteRelatorioSelect2ViewModel);
        }

        [Authorize(Roles = "Contas-Correntes_Relatorios, Master")]
        [HttpPost]
        public IActionResult RelatorioPrint(ContaCorrenteFilterReportViewModel  contaCorrenteFilterReportViewModel) 
        {
            try
            {
                if (contaCorrenteFilterReportViewModel.PeriodoInicioRel1 == null 
                    || contaCorrenteFilterReportViewModel.PeriodoInicioRel1.Date.ToString() == "01/01/0001 00:00:00"
                    || contaCorrenteFilterReportViewModel.PeriodoFimRel1 == null
                    || contaCorrenteFilterReportViewModel.PeriodoInicioRel1.Date.ToString() == "01/01/0001 00:00:00")
                {
                    return BadRequest("Período não informado.");
                }

                if (contaCorrenteFilterReportViewModel.ColaboradorNome.IsNullOrEmpty())
                {
                    return BadRequest("Colaborador não informado.");
                }
            }
            catch { throw; }

            ContaCorrenteReportViewModel contaCorrenteReportViewModel = new ContaCorrenteReportViewModel();
            contaCorrenteReportViewModel.LancamentosReportViewModel = new List<ContaCorrenteReportViewModel.LancamentoReportViewModel>();
            List<Lancamento> contaCorrenteLancamentosSaldoAnterior = new List<Lancamento>();
            List<Lancamento> contaCorrenteLancamentos = new List<Lancamento>();

            var contaCorrente = _contaCorrenteManager
                                    .GetByColaboradorNomeWithInclude(contaCorrenteFilterReportViewModel.ColaboradorNome);
            
            //Verifica se o colaborador em questão possui conta corrente
            //caso tenha obtenho os lançamentos filtrados
            if (contaCorrente == null)
            {
                return BadRequest("Colaborador informado não possui conta corrente.");
            }
            else
            {
                //Obtendo primeiro o saldo anterior
                contaCorrenteLancamentosSaldoAnterior = contaCorrente.Lancamentos
                                                .Where(x => x.Status == LancamentoStatusEnum.LIQUIDADO
                                                            && x.DataLiquidacao.Date < contaCorrenteFilterReportViewModel.PeriodoInicioRel1.Date)
                                                .OrderBy(x => x.DataLiquidacao)
                                                .ToList();
                                                
                contaCorrenteLancamentos = contaCorrente.Lancamentos
                                                .Where(x => x.Status == LancamentoStatusEnum.LIQUIDADO
                                                            && x.DataLiquidacao.Date >= contaCorrenteFilterReportViewModel.PeriodoInicioRel1.Date
                                                            && x.DataLiquidacao.Date <= contaCorrenteFilterReportViewModel.PeriodoFimRel1.Date)
                                                .OrderBy(x => x.DataLiquidacao)
                                                .ToList();
            }

            //Cálculo saldo anterior
            var saldoAnterior = contaCorrenteLancamentosSaldoAnterior
                                    .Where(x => x.Tipo == LancamentoTipoEnum.CREDITO)
                                    .Select(x => x.ValorLiquido).Sum()
                                -
                                contaCorrenteLancamentosSaldoAnterior
                                    .Where(x => x.Tipo == LancamentoTipoEnum.DEBITO)
                                    .Select(x => x.ValorLiquido).Sum();

            //Cálculo saldo do período
            var saldoPeriodo = contaCorrenteLancamentos
                                .Where(x => x.Tipo == LancamentoTipoEnum.CREDITO)
                                .Select(x => x.ValorLiquido).Sum()
                            -
                            contaCorrenteLancamentos
                                .Where(x => x.Tipo == LancamentoTipoEnum.DEBITO)
                                .Select(x => x.ValorLiquido).Sum();
                                                
            if (contaCorrenteLancamentos.Count() > 0)
            {
                //Montagem dos objetos da list
                Int64 id = 1;

                //1º Lançamento - Saldo Anterior ao período escolhido            
                contaCorrenteReportViewModel
                    .LancamentosReportViewModel
                        .Add(new ContaCorrenteReportViewModel.LancamentoReportViewModel()
                            {
                                Id = id,
                                DataLiquidacao = !contaCorrenteLancamentosSaldoAnterior.IsNullOrEmpty() ? 
                                                    contaCorrenteLancamentosSaldoAnterior.Last().DataLiquidacao.ToString("dd/MM/yyyy")
                                                    : "",
                                Descricao = "Saldo Anterior",
                                Saldo = saldoAnterior == 0 ? saldoAnterior.ToString() : 
                                        saldoAnterior < 0 ? saldoAnterior + "D" : saldoAnterior + "C"
                            });

                //Demais lançamentos
                foreach (var lancamento in contaCorrenteLancamentos)
                {
                    //Filtro de periodo - Data inicio e fim lançamento - IMPLEMENTAR
                    decimal saldoDia = 0;

                    // DateTime yesterday = DateTime.Now;
                    // yesterday = yesterday.Date.AddDays(-1);

                    //Saldo atual - Saldo até a data de liquidação do lançamento atual
                    var creditoDia = contaCorrenteLancamentos
                                        .Where(x => x.Tipo == LancamentoTipoEnum.CREDITO
                                                && x.DataLiquidacao.Date == lancamento.DataLiquidacao.Date)
                                        .Sum(x => x.ValorLiquido);

                    var debitoDia = contaCorrenteLancamentos
                                        .Where(x => x.Tipo == LancamentoTipoEnum.DEBITO
                                                && x.DataLiquidacao.Date == lancamento.DataLiquidacao.Date)
                                        .Sum(x => x.ValorLiquido);
                    
                    saldoDia = creditoDia - debitoDia;
                                    
                    contaCorrenteReportViewModel.LancamentosReportViewModel
                                        .Add(new ContaCorrenteReportViewModel.LancamentoReportViewModel()
                                            {
                                                Id = id,
                                                DataLiquidacao = lancamento.DataLiquidacao.ToString("dd/MM/yyyy"),
                                                Descricao = lancamento.Descricao,
                                                LancamentoTipo = lancamento.Tipo.ToString(),
                                                ValorLiquido = lancamento.ValorLiquido,
                                                Saldo = saldoDia < 0 ? saldoDia + "D" : saldoDia + "C"
                                            });

                    id = id + 1;
                }

                contaCorrenteReportViewModel.Numero = contaCorrente.Numero.ToString();
                contaCorrenteReportViewModel.Nome = contaCorrente.Colaborador.Detento.Nome;
                contaCorrenteReportViewModel.Ipen = contaCorrente.Colaborador.Detento.Ipen.ToString();
                contaCorrenteReportViewModel.Galeria = contaCorrente.Colaborador.Detento.Galeria;
                contaCorrenteReportViewModel.LocalTrabalho = contaCorrente.Colaborador.LocalTrabalho;
                contaCorrenteReportViewModel.Status = contaCorrente.Status.ToString();
                contaCorrenteReportViewModel.CategoriaNome1 = "Lançamentos";
                contaCorrenteReportViewModel.CategoriaNome2 = "Liquidados por período";
                contaCorrenteReportViewModel.TotalLancamentos = saldoAnterior + saldoPeriodo;
                contaCorrenteReportViewModel.TotalCreditos = contaCorrenteLancamentos
                                                                .Where(x => x.Tipo == LancamentoTipoEnum.CREDITO)
                                                                .Sum(x => x.ValorLiquido)
                                                            +
                                                            contaCorrenteLancamentosSaldoAnterior
                                                                .Where(x => x.Tipo == LancamentoTipoEnum.CREDITO)
                                                                .Sum(x => x.ValorLiquido);
                contaCorrenteReportViewModel.TotalDebitos = (decimal) contaCorrenteLancamentos
                                                                .Where(x => x.Tipo == LancamentoTipoEnum.DEBITO)
                                                                .Sum(x => x.ValorLiquido)
                                                                +
                                                                contaCorrenteLancamentosSaldoAnterior
                                                                .Where(x => x.Tipo == LancamentoTipoEnum.DEBITO)
                                                                .Sum(x => x.ValorLiquido);
                contaCorrenteReportViewModel.PeriodoInicio = contaCorrenteFilterReportViewModel.PeriodoInicioRel1.ToString("dd/MM/yyyy");
                contaCorrenteReportViewModel.PeriodoFim = contaCorrenteFilterReportViewModel.PeriodoFimRel1.ToString("dd/MM/yyyy");
            }

            return View(contaCorrenteReportViewModel);

        }

        [Authorize(Roles = "Contas-Correntes_Relatorios, Master")]
        [HttpPost]
        public IActionResult RelatorioPrint2(ContaCorrenteFilterReport2ViewModel  contaCorrenteFilterReport2ViewModel) 
        {
            ContaCorrenteReport2ViewModel contaCorrenteReport2ViewModel = new ContaCorrenteReport2ViewModel();
            contaCorrenteReport2ViewModel.RegistrosReport2ViewModel = new List<ContaCorrenteReport2ViewModel.RegistroReport2ViewModel>();
            List<ContaCorrente> contasCorrentes = new List<ContaCorrente>();

            //Aplicação primeiro filtro - colaboradores
            //Quando ao menos um colaborador é informado não observo o 
            //Filtro de status da conta (ATIVO/ENCERRADO/BLOQUEADO)
            if (!contaCorrenteFilterReport2ViewModel.ColaboradoresNomes.IsNullOrEmpty())
            {
                foreach (var colaboradorNome in contaCorrenteFilterReport2ViewModel.ColaboradoresNomes)
                {
                    var contaCorrente = _contaCorrenteRepository
                                            .GetByColaboradorNomeWithInclude(colaboradorNome);

                    contasCorrentes.Add(contaCorrente);
                }
            }
            else
            {
                contasCorrentes = _contaCorrenteRepository
                                        .GetAll()
                                        .Where(x => 
                                            x.Status == (contaCorrenteFilterReport2ViewModel.Ativa ? ContaCorrenteStatusEnum.ATIVA : ContaCorrenteStatusEnum.BLOQUEADA)
                                            ||
                                            x.Status == (contaCorrenteFilterReport2ViewModel.Ativa ? ContaCorrenteStatusEnum.ATIVA : ContaCorrenteStatusEnum.ENCERRADA))
                                        .ToList();
            }

            if (contasCorrentes.Count() > 0)
            {
                //Montagem dos objetos da list
                Int64 id = 1;

                var contasCorrentesViewModel = _mapper.Map<IEnumerable<ContaCorrenteViewModel>>(contasCorrentes);

                contasCorrentesViewModel = contasCorrentesViewModel.OrderByDescending(x => x.Saldo);

                foreach (var contaCorrenteViewModel in contasCorrentesViewModel)
                {
                    if (contaCorrenteViewModel.Saldo > 0)
                    {
                        contaCorrenteReport2ViewModel.RegistrosReport2ViewModel
                            .Add(new RegistroReport2ViewModel()
                                {
                                    Id = id,
                                    Ipen = contaCorrenteViewModel.Colaborador.Detento.Ipen.ToString(),
                                    ColaboradorNome = contaCorrenteViewModel.Colaborador.Detento.Nome,
                                    VisitanteMatricula = contaCorrenteViewModel.Colaborador.Detento.MatriculaFamiliar.ToString(),
                                    VisitanteNome = contaCorrenteViewModel.Colaborador.Detento.NomeFamiliar,
                                    Agencia = contaCorrenteViewModel.Colaborador.BancoAgencia,
                                    ContaCorrenteNumero = contaCorrenteViewModel.Colaborador.BancoConta,
                                    ContaCorrenteTipo = contaCorrenteViewModel.Colaborador.TipoConta.ToString(),
                                    Status = contaCorrenteViewModel.Status.ToString(),
                                    ValorDeposito = (decimal) contaCorrenteViewModel.Saldo
                                });

                        id = id + 1;
                    }
                }
                
                //Ordernar por maior saldo
                contaCorrenteReport2ViewModel.RegistrosReport2ViewModel.OrderByDescending(x => x.ValorDeposito);

                //Cálculo saldo total
                var saldoTotal = _mapper.Map<IEnumerable<ContaCorrenteViewModel>>(contasCorrentes)
                                    .Sum(x => x.Saldo);

                contaCorrenteReport2ViewModel.Colaboradores = !contaCorrenteFilterReport2ViewModel
                                                                .ColaboradoresNomes.IsNullOrEmpty() ?
                                                            "Por escolha (s)" : "Todos";
                contaCorrenteReport2ViewModel.Status = !contaCorrenteFilterReport2ViewModel.ColaboradoresNomes.IsNullOrEmpty() ? "TODOS" : (contaCorrenteFilterReport2ViewModel.Ativa ? "ATIVA" : "ENCERRADA/BLOQUEADA");
                contaCorrenteReport2ViewModel.CategoriaNome1 = "Lançamentos";
                contaCorrenteReport2ViewModel.CategoriaNome2 = "Liquidados por período";
                contaCorrenteReport2ViewModel.TotalDeposito = (decimal)saldoTotal;
                contaCorrenteReport2ViewModel.PeriodoInicio = contaCorrenteFilterReport2ViewModel.PeriodoInicioRel2.ToString("dd/MM/yyyy");
                contaCorrenteReport2ViewModel.PeriodoFim = contaCorrenteFilterReport2ViewModel.PeriodoFimRel2.ToString("dd/MM/yyyy");
            }

            return View(contaCorrenteReport2ViewModel);

        }

        public IActionResult GetSaldoByColaboradorNome([FromBody]string colaboradorNome)
        {
            var colaboradorSaldo = _contaCorrenteManager.GetSaldoByColaboradorNome(colaboradorNome);
            return Ok(new { colaboradorSaldo });
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> List([FromForm] DataTableServerSideRequest request)
        {
            //Quando o método for acionado por uma busca
            //Deverá identificar qual o tipo de dado, afim de direcionar a coluna de pesquisa
            //Permitindo assim somente pesquisa de uma condicional (Ipen/Nome)
            if (!request.Search.Value.IsNullOrEmpty())
            {
                var valueSearch = request.Search.Value;

                if (NumericHelpers.HasNumber(valueSearch))
                {
                    //havendo numeros na string
                    //deixo ativado somente o searcheable do ipen
                    foreach (var item in request.Columns)
                    {
                        if (item.Name != "Colaborador.Detento.Ipen")
                            item.Searchable = false;
                    }
                }
                else
                {
                    //não havendo números na string
                    //deixo ativado somente o searcheable do nome
                    foreach (var item in request.Columns)
                    {
                        if (item.Name != "Colaborador.Detento.Nome")
                            item.Searchable = false;
                    }
                }
            }

            var result = await _context.ContasCorrentes
                                    .IgnoreQueryFilters()
                                    .Include(x => x.Lancamentos)
                                    .Include(x => x.Colaborador)
                                    .ThenInclude(x => x.Detento)
                                    .Where(d => d.Colaborador.Detento.IsDeleted == true || d.Colaborador.Detento.IsDeleted == false)
                                    .Where(x => x.Colaborador.IsDeleted == true || x.Colaborador.IsDeleted == false)
                                    .Where(x => x.IsDeleted == false)
                                    .OrderByDescending(x => x.CreatedAt)
                                    .GetDatatableResultAsync(request);
            
            var dataMapped = _mapper.Map<IEnumerable<ContaCorrenteViewModel>>(result.Data);
            
            var data = new {
                data = dataMapped
            };

            return Ok(new {
                data = data,
                Draw = result.Draw,
                RecordsFiltered  = result._iRecordsDisplay,
                RecordsTotal = result._iRecordsTotal,
                Success = true
            });
        }
    }
}