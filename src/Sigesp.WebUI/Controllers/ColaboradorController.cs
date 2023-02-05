using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sigesp.Infra.Data.Context;
using Sigesp.WebUI.Extensions;
using Sigesp.Application.ViewModels;
using Sigesp.Application.Interfaces;
using AutoMapper;
using Sigesp.Domain.Enums;
using Sigesp.Application.ViewModels.Cards;
using Sigesp.Application.ViewModels.Selects;
using Sigesp.Domain.Interfaces;
using Sigesp.Application.ViewModels.Reports;
using static Sigesp.Application.ViewModels.Reports.ColaboradorReportViewModel;
using Microsoft.AspNetCore.Authorization;
using Sigesp.WebUI.Helpers.DataTable;
using Sigesp.WebUI.Helpers;
using System.Text;

namespace Sigesp.WebUI.Controllers
{
    [Authorize(Roles = "Colaboradores_Todos, Colaboradores_Relatorios, Master")]
    public class ColaboradorController : Controller
    {
        private readonly IColaboradorAppService _colaboradorManager;
        private readonly IColaboradorRepository _colaboradorRepository;
        private readonly IContaCorrenteAppService _contaCorrenteManager;
        private readonly IEmpresaConvenioRepository _empresaConvenioRepository;
        private readonly IDetentoRepository _detentoRepository;
        private readonly IMapper _mapper;
        private readonly SigespDbContext _context;

        public ColaboradorController(IColaboradorAppService colaboradorManager,
                                    IColaboradorRepository colaboradorRepository,
                                    IContaCorrenteAppService contaCorrenteManager,
                                    IEmpresaConvenioRepository empresaConvenioRepository,
                                    IDetentoRepository detentoRepository, 
                                    IMapper mapper,
                                    SigespDbContext context)
                                    
        {
            _colaboradorManager = colaboradorManager;
            _colaboradorRepository = colaboradorRepository;
            _contaCorrenteManager = contaCorrenteManager;
            _empresaConvenioRepository = empresaConvenioRepository;
            _detentoRepository = detentoRepository;
            _mapper = mapper;
            _context = context;
        }

        [Authorize(Roles = "Colaboradores_Todos, Master")]
        public IActionResult Todos()
        {
            var detentos = _detentoRepository
                                    .GetAllDeletedTrueAndFalseWithoutInclude();

            var colaboradores = _colaboradorManager
                                    .GetAll();

            var empresasConvenios = _empresaConvenioRepository
                                        .GetAll();
            
            //Dados cards
            var colaboradorCardViewModel = new ColaboradorCardViewModel()
            {
                Ativos = colaboradores.Where(x => x.Situacao == ColaboradorSituacaoEnum.ADMITIDO.ToString()).Count(),
                Admitidos = colaboradores.Where(x => x.Situacao == ColaboradorSituacaoEnum.ADMITIDO.ToString()).Count(),
                Demitidos =  colaboradores.Where(x => x.Situacao == ColaboradorSituacaoEnum.DEMITIDO.ToString()).Count(),
                EmProcessoAdmissao = colaboradores.Where(x => x.Situacao == ColaboradorSituacaoEnum.EM_PROCESSO_ADMISSAO.ToString()).Count(),
                EmpresasConvenios = empresasConvenios.Select(x => x.Nome).ToList(),
                Situacoes = EnumExtensions<ColaboradorSituacaoEnum>.GetNames().ToList(),
                TiposPagamento = EnumExtensions<TipoPagamentoEnum>.GetNames().ToList(),
                TiposConta = EnumExtensions<TipoContaEnum>.GetNames().ToList(),
                Detentos = detentos.Select(x => x.Nome).ToList(),
                DemissaoOcorrencias = EnumExtensions<ColaboradorDemissaoOcorrenciaEnum>.GetNames().ToList(),
                Funcoes = EnumExtensions<ColaboradorFuncaoEnum>.GetNames().ToList()
            };

            return View(colaboradorCardViewModel);
        }
        
        [Authorize(Roles = "Colaboradores_Relatorios, Master")]
        public IActionResult Relatorios()
        {
            var empresasConvenios = _empresaConvenioRepository
                                        .AsNoTrackingOnlyIsNotDeleted();

            var colaboradorSelectViewModel = new ColaboradorSelectViewModel()
            {
                Galerias = EnumExtensions<GaleriaEnum>.GetNames().ToList(),
                Situacoes = EnumExtensions<ColaboradorSituacaoEnum>.GetNames().ToList(),
                EmpresasConvenios = empresasConvenios.Select(x => x.Nome).ToList()
            };

            return View(colaboradorSelectViewModel);
        }

        [Authorize(Roles = "Colaboradores_Relatorios, Master")]
        [HttpPost]
        public IActionResult RelatorioPrint(ColaboradorFilterReportViewModel  colaboradorFilterReportViewModel) 
        {
            List<ColaboradorViewModel> colaboradores = new List<ColaboradorViewModel>();
            var colaboradoresFilterFinally = new List<ColaboradorViewModel>();
            var colaboradorReportViewModel = new ColaboradorReportViewModel();
            colaboradorReportViewModel.ColaboradoresReportViewModel = new List<ColaboradorReportViewModelBase>();

            //Aplicação do filtro primário
            if (!colaboradorFilterReportViewModel.Galeria.IsNullOrEmpty())
            {
                colaboradores = _colaboradorManager
                                .AsNoTrackingWithInclude()
                                .Where(x => x.DetentoGaleria == colaboradorFilterReportViewModel.Galeria)
                                .OrderBy(x => x.Detento.Galeria)
                                .OrderBy(x => x.Detento.Cela)
                                .ToList();
            }
            else
            {
                colaboradores = _colaboradorManager
                                                .AsNoTrackingWithInclude()
                                                .OrderBy(x => x.Detento.Galeria)
                                                .OrderBy(x => x.Detento.Cela)
                                                .ToList();
            }

            //Aplicação do filtro secundário
            if (!colaboradorFilterReportViewModel.Situacoes.IsNullOrEmpty())
            {
                foreach (var situacao in colaboradorFilterReportViewModel.Situacoes)
                {
                    var _colaboradoresBySituacao = colaboradores
                                                    .Where(x => x.Situacao == situacao)
                                                    .ToList();
                    
                    if (_colaboradoresBySituacao.Count() > 0)
                    {
                        foreach (var _colaboradorBySituacao in _colaboradoresBySituacao.ToList())
                        {
                            colaboradoresFilterFinally.Add(_colaboradorBySituacao);
                        }
                    }
                }
            }

            //Montagem dos objetos da list
            Int64 id = 1;

            colaboradoresFilterFinally = colaboradorFilterReportViewModel.Situacoes.IsNullOrEmpty() ?
                                            colaboradores :
                                            colaboradoresFilterFinally;

            foreach (var colaboradorFilterFinally in colaboradoresFilterFinally)
            {
                var colaboradorSaldo = _contaCorrenteManager.GetSaldoByColaboradorId((Guid)colaboradorFilterFinally.Id);
                
                colaboradorReportViewModel.ColaboradoresReportViewModel
                    .Add(new ColaboradorReportViewModelBase()
                {
                    Id = id,
                    Ipen = colaboradorFilterFinally.DetentoIpen,
                    Nome = colaboradorFilterFinally.DetentoNome,
                    Galeria = colaboradorFilterFinally.DetentoGaleria,
                    Cela = colaboradorFilterFinally.Detento.Cela.ToString(),
                    LocalTrabalho = colaboradorFilterFinally.LocalTrabalho,
                    Saldo = colaboradorSaldo,
                    Ativo = colaboradorFilterFinally.Situacao == ColaboradorSituacaoEnum.ADMITIDO.ToString() ? "SIM" : "NÃO"
                });

                id = id + 1;
            }
            
            colaboradorReportViewModel.Total = colaboradorReportViewModel.ColaboradoresReportViewModel.Sum(x => x.Saldo);
            colaboradorReportViewModel.CategoriaNome1 = colaboradorFilterReportViewModel.Situacoes.IsNullOrEmpty() ? "Todas as situações" : "Por situação";
            colaboradorReportViewModel.CategoriaNome2 = colaboradorFilterReportViewModel.Galeria.IsNullOrEmpty() ? "Todas as galerias" : "Por galeria";

            return View(colaboradorReportViewModel);
        }

        [Authorize(Roles = "Colaboradores_Relatorios, Master")]
        [HttpPost]
        public IActionResult RelatorioPrint2(ColaboradorFilterReportViewModel  colaboradorFilterReportViewModel) 
        {
            List<ColaboradorViewModel> colaboradores = new List<ColaboradorViewModel>();
            var colaboradoresFilterFinally = new List<ColaboradorViewModel>();
            var colaboradorReportViewModel = new ColaboradorReportViewModel();
            colaboradorReportViewModel.ColaboradoresReportViewModel = new List<ColaboradorReportViewModelBase>();

            //Aplicação do filtro primário
            if (!colaboradorFilterReportViewModel.Galeria.IsNullOrEmpty())
            {
                colaboradores = _colaboradorManager
                                .AsNoTrackingWithInclude()
                                .Where(x => x.DetentoGaleria == colaboradorFilterReportViewModel.Galeria)
                                .OrderBy(x => x.DetentoGaleria)
                                .ToList();
            }
            else
            {
                colaboradores = _colaboradorManager
                                                .AsNoTrackingWithInclude()
                                                .OrderBy(x => x.DetentoGaleria)
                                                .ToList();
            }

            //Aplicação do filtro secundário
            if (!colaboradorFilterReportViewModel.Situacoes.IsNullOrEmpty())
            {
                foreach (var situacao in colaboradorFilterReportViewModel.Situacoes)
                {
                    var _colaboradoresBySituacao = colaboradores
                                                    .Where(x => x.Situacao == situacao)
                                                    .ToList();
                    
                    if (_colaboradoresBySituacao.Count() > 0)
                    {
                        foreach (var _colaboradorBySituacao in _colaboradoresBySituacao.ToList())
                        {
                            colaboradoresFilterFinally.Add(_colaboradorBySituacao);
                        }
                    }
                }
            }

            //Aplicação do filtro final - empresa convênio
            
            if (!colaboradorFilterReportViewModel.EmpresaConvenio.IsNullOrEmpty())
            {
                colaboradoresFilterFinally = colaboradorFilterReportViewModel.Situacoes.IsNullOrEmpty() ?
                                                colaboradores.Where(x => x.EmpresaConvenio.Nome == 
                                                        colaboradorFilterReportViewModel.EmpresaConvenio)
                                                            .OrderBy(x => x.EmpresaConvenio.Nome)
                                                            .ToList() :
                                                colaboradoresFilterFinally.Where(x => x.EmpresaConvenio.Nome == 
                                                        colaboradorFilterReportViewModel.EmpresaConvenio)
                                                            .OrderBy(x => x.EmpresaConvenio.Nome)
                                                            .ToList();;
            }
            else
            {
                colaboradoresFilterFinally = colaboradorFilterReportViewModel.Situacoes.IsNullOrEmpty() ?
                                            colaboradores :
                                            colaboradoresFilterFinally;
            }
           
            //Montagem dos objetos da list
            Int64 id = 1;

            foreach (var colaborador in colaboradoresFilterFinally)
            {
                colaboradorReportViewModel.ColaboradoresReportViewModel
                    .Add(new ColaboradorReportViewModelBase()
                {
                    Id = id,
                    EmpresaConvenioNome = colaborador.EmpresaConvenioNome,
                    Ipen = colaborador.DetentoIpen,
                    Nome = colaborador.DetentoNome,
                    Galeria = colaborador.DetentoGaleria,
                    LocalTrabalho = colaborador.LocalTrabalho,
                    JornadaInicio = colaborador.JornadaInicio,
                    JornadaFim = colaborador.JornadaFim,
                    Ativo = colaborador.Situacao == ColaboradorSituacaoEnum.ADMITIDO.ToString() ? "SIM" : "NÃO"
                });

                id = id + 1;
            }

            colaboradorReportViewModel.CategoriaNome1 = colaboradorFilterReportViewModel.EmpresaConvenio.IsNullOrEmpty() ? "Todos os convênios" : "Por convênio";
            colaboradorReportViewModel.CategoriaNome2 = colaboradorFilterReportViewModel.Situacoes.IsNullOrEmpty() ? "Todas as situações" : "Por situação";

            return View(colaboradorReportViewModel);
        }

        [HttpGet]
        public IActionResult GetByDetentoIpenOrDetentoNome(string term)
        {
            if (term.IsNullOrEmpty())
                return BadRequest("Parâmetro de busca não informado.");

            string property;
            //Quando o método for acionado por uma busca
            //Deverá identificar qual o tipo de dado, afim de direcionar o tipo do argumento
            //Permitindo assim somente pesquisa de uma condicional (Ipen/Nome)
           if (NumericHelpers.HasNumber(term))
            {
               property = "Ipen";
            }
            else
            {
                property = "Nome";
            }

            var detentoSelect2Result = _colaboradorManager.GetByDetentoIpenOrDetentoNome(property, term);
            return Ok(new { detentoSelect2Result });
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
                        if (item.Name != "Detento.Ipen")
                            item.Searchable = false;
                    }
                }
                else
                {
                    //não havendo números na string
                    //deixo ativado somente o searcheable do nome
                    foreach (var item in request.Columns)
                    {
                        if (item.Name != "Detento.Nome")
                            item.Searchable = false;
                    }
                }
            }

            var result = await _context
                                .Colaboradores
                                    .IgnoreQueryFilters()
                                    .Include(x => x.Detento)
                                    .Include(x => x.EmpresaConvenio)
                                    .Include(x => x.ContaCorrente)
                                    .OrderByDescending(x => x.CreatedAt)
                                    .GetDatatableResultAsync(request);

            var dataMapped = _mapper.Map<IEnumerable<ColaboradorViewModel>>(result.Data);
            
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
