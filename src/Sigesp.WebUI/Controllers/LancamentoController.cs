using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sigesp.Domain.Interfaces;
using Sigesp.Application.ViewModels.Cards;
using Sigesp.Domain.Enums;
using Sigesp.Application.Interfaces;
using System;
using Microsoft.AspNetCore.Authorization;
using AutoMapper;
using Sigesp.Infra.Data.Context;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Sigesp.WebUI.Helpers.DataTable;
using System.Collections.Generic;
using Sigesp.Application.ViewModels;
using Sigesp.WebUI.Helpers;
using Sigesp.WebUI.Extensions;

namespace Sigesp.WebUI.Controllers
{
    [Authorize(Roles = "Lancamentos_Todos, Master")]
    public class LancamentoController : Controller
    {
        private readonly IColaboradorRepository _colaboradorRepository;
        private readonly ILancamentoAppService _lancamentoManager;
        private readonly IContabilEventoAppService _contabilEventoAppService;
        private readonly IMapper _mapper;
        private readonly SigespDbContext _context;

        
        public LancamentoController(IColaboradorRepository colaboradorRepository,
                                    ILancamentoAppService lancamentoManager,
                                    IContabilEventoAppService contabilEventoAppService,
                                    IMapper mapper,
                                    SigespDbContext context)
        {
            _colaboradorRepository = colaboradorRepository;
            _lancamentoManager = lancamentoManager;
            _contabilEventoAppService = contabilEventoAppService;
            _mapper = mapper;
            _context = context;
        }

        public IActionResult Todos()
        {
            try
            {
                var lancamentos = _lancamentoManager.GetAll();

                var colaboradores = _colaboradorRepository
                                        .GetAllDeletedTrueAndFalseWithInclude()
                                        .Select(x => x.Detento.Nome)
                                        .ToList();

                //Dados cards
                var lancamentoCardViewModel = new LancamentoCardViewModel()
                {
                    Pendentes = lancamentos.Where(x => x.Status == LancamentoStatusEnum.PENDENTE.ToString()).Count(),
                    Liquidados = lancamentos.Where(x => x.Status == LancamentoStatusEnum.LIQUIDADO.ToString()).Count(),
                    Creditos =  lancamentos.Where(x => x.Tipo == LancamentoTipoEnum.CREDITO.ToString()).Count(),
                    Debitos = lancamentos.Where(x => x.Tipo == LancamentoTipoEnum.DEBITO.ToString()).Count(),
                    Colaboradores = colaboradores,
                    PeriodosReferencia = EnumExtensions<LancamentoPeriodoReferenciaEnum>.GetNames().ToList(),
                    Status = EnumExtensions<LancamentoStatusEnum>.GetNames().ToList(),
                    TiposLancamento = EnumExtensions<LancamentoTipoEnum>.GetNames().ToList(),
                    ContabilEventos = _contabilEventoAppService.GetAll().Select(x => x.Especificacao).ToList()
                };
                
                return View(lancamentoCardViewModel);

            }
            catch (System.Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
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
                        if (item.Name != "ContaCorrente.Colaborador.Detento.Ipen")
                            item.Searchable = false;
                    }
                }
                else
                {
                    //não havendo números na string
                    //deixo ativado somente o searcheable do nome
                    foreach (var item in request.Columns)
                    {
                        if (item.Name != "ContaCorrente.Colaborador.Detento.Nome")
                            item.Searchable = false;
                    }
                }
            }

            var result = await _context.Lancamentos
                                    .IgnoreQueryFilters()
                                    .Include(x => x.ContaCorrente)
                                    .ThenInclude(x => x.Colaborador)
                                    .ThenInclude(x => x.Detento)
                                    .Include(x => x.ContabilEvento)
                                    .Where(d => d.ContaCorrente.Colaborador.Detento.IsDeleted == true || d.ContaCorrente.Colaborador.Detento.IsDeleted == false)
                                    .Where(x => x.IsDeleted == false)
                                    .OrderByDescending(x => x.CreatedAt)
                                    .GetDatatableResultAsync(request);

            var totalLancamentos = result.Data.Select(x => x.ValorLiquido).Sum();

            var dataMapped = _mapper.Map<IEnumerable<LancamentoViewModel>>(result.Data);
            
            var data = new {
                data = dataMapped
            };

            return Ok(new {
                Data = data,
                Draw = result.Draw,
                RecordsFiltered  = result._iRecordsDisplay,
                RecordsTotal = result._iRecordsTotal,
                Success = true
            });
        }
    }
}