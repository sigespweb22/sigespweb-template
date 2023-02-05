using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sigesp.Infra.Data.Context;
using Sigesp.WebUI.Extensions;
using Sigesp.Application.Interfaces;
using AutoMapper;
using Sigesp.Domain.Models.DataTable;
using Sigesp.Domain.Enums;
using Sigesp.Application.ViewModels.Cards;
using Microsoft.AspNetCore.Authorization;
using Sigesp.WebUI.Helpers;

namespace Sigesp.WebUI.Controllers
{
    [Authorize(Roles = "Detentos_Todos, Master")]
    public class DetentoController : Controller
    {
        private readonly IDetentoAppService _detentoManager;
        private readonly IMapper _mapper;
        private readonly SigespDbContext _context;

        public DetentoController(IDetentoAppService detentoManager,
                                    IMapper mapper,
                                    SigespDbContext context)
        {
            _detentoManager = detentoManager;
            _mapper = mapper;
            _context = context;
        }

        public async Task<IActionResult> Todos()
        {
            var detentos = await _detentoManager.GetAllAsync();

            //Dados cards
            var detentoCardViewModel = new DetentoCardViewModel()
            {
                Total = detentos.Where(x => x.Regime == DetentoRegimeEnum.RECOLHIDO_EDI.ToString()
                                            || x.Regime == DetentoRegimeEnum.RECOLHIDO_IMPORTACAO.ToString() 
                                            || x.Regime == DetentoRegimeEnum.RECOLHIDO_FECHADO.ToString() 
                                            || x.Regime == DetentoRegimeEnum.RECOLHIDO_SEMIABERTO.ToString()
                                            || x.Regime == DetentoRegimeEnum.SAIDA_TEMPORARIA.ToString()
                                            || x.Regime == DetentoRegimeEnum.PROVISORIO.ToString()
                                            || x.Regime == DetentoRegimeEnum.PROVISORIO_EXECUCAO_SUSPENSA.ToString()
                                            || x.Regime == DetentoRegimeEnum.PRISAO_TEMPORARIA.ToString()
                                            || x.Regime == DetentoRegimeEnum.ALIMENTOS.ToString()).Count(),
                Recolhidos = detentos.Where(x => x.Regime == DetentoRegimeEnum.RECOLHIDO_EDI.ToString() 
                                                    || x.Regime == DetentoRegimeEnum.RECOLHIDO_IMPORTACAO.ToString() 
                                                    || x.Regime == DetentoRegimeEnum.RECOLHIDO_FECHADO.ToString() 
                                                    || x.Regime == DetentoRegimeEnum.RECOLHIDO_SEMIABERTO.ToString()
                                                    || x.Regime == DetentoRegimeEnum.PROVISORIO.ToString()
                                                    || x.Regime == DetentoRegimeEnum.PROVISORIO_EXECUCAO_SUSPENSA.ToString()
                                                    || x.Regime == DetentoRegimeEnum.PRISAO_TEMPORARIA.ToString()
                                                    || x.Regime == DetentoRegimeEnum.ALIMENTOS.ToString()).Count(),
                Condenados =  detentos.Where(x => x.Regime == DetentoRegimeEnum.RECOLHIDO_EDI.ToString() 
                                                    || x.Regime == DetentoRegimeEnum.RECOLHIDO_IMPORTACAO.ToString() 
                                                    || x.Regime == DetentoRegimeEnum.RECOLHIDO_FECHADO.ToString() 
                                                    || x.Regime == DetentoRegimeEnum.SAIDA_TEMPORARIA.ToString()
                                                    || x.Regime == DetentoRegimeEnum.RECOLHIDO_SEMIABERTO.ToString()).Count(),
                SaidaTemporaria = detentos.Where(x => x.Regime == DetentoRegimeEnum.SAIDA_TEMPORARIA.ToString()).Count(),
                DetentoRegimes = EnumExtensions<DetentoRegimeEnum>.GetNames().ToList(),
                TiposConta = EnumExtensions<TipoContaEnum>.GetNames().ToList(),
                Galerias = EnumExtensions<GaleriaEnum>.GetNames().ToList(),
                InstrumentosPrisao = EnumExtensions<InstrumentoPrisaoTipoEnum>.GetNames().ToList(),
                CondenacaoTipos = EnumExtensions<CondenacaoTipoEnum>.GetNames().ToList(),
                TransferenciaTipos = EnumExtensions<TransferenciaTipoEnum>.GetNames().ToList(),
                Provisorios = detentos.Where(x => x.Regime == DetentoRegimeEnum.PROVISORIO.ToString()
                                                || x.Regime == DetentoRegimeEnum.PROVISORIO_EXECUCAO_SUSPENSA.ToString()
                                                || x.Regime == DetentoRegimeEnum.ALIMENTOS.ToString()
                                                || x.Regime == DetentoRegimeEnum.PRISAO_TEMPORARIA.ToString()).Count()
            };

            return View(detentoCardViewModel);
        }
        
        [HttpPost]
        public async Task<IActionResult> GetDetentoDataByIdAsync([FromBody]string detentoId)
        {
            var detento = await _detentoManager
                                    .GetDetentoDataByIdAsync(detentoId);
            return Ok(new { detento });
        }
        public IActionResult GetDetentoRegimeByNome([FromBody]string detentoNome)
        {
            var detentoRegime = _detentoManager.GetDetentoRegimeByNome(detentoNome);
            return Ok(new { detentoRegime });
        }
        public async Task<IActionResult> GetIpenByNomeAsync([FromBody]string detentoNome)
        {
            var detentoIpen = await _detentoManager
                                    .GetIpenByNomeAsync(detentoNome);
            
            return Ok(new { detentoIpen });
        }
        public async Task<IActionResult> GetIpenById([FromBody]string detentoId)
        {
            var detentoIpen = await _detentoManager
                                        .GetIpenByIdAsync(detentoId);
            
            return Ok(new { detentoIpen });
        }
        public IActionResult GetIpenAndRegimeByColaboradorId([FromBody]string colaboradorId)
        {
            var detentoIpenAndRegime = _detentoManager
                                                .GetIpenAndRegimeByColaboradorId(colaboradorId);
            
            return Ok(new { detentoIpenAndRegime });
        }
        public async Task<IActionResult> GetIpenAndRegimeByNome([FromBody]string detentoNome)
        {
            var detentoIpenAndRegime = await _detentoManager
                                                .GetIpenAndRegimeByNomeAsync(detentoNome);
            
            return Ok(new { detentoIpenAndRegime });
        }
        public async Task<IActionResult> GetIpenAndGaleriaByNome([FromBody]string detentoNome)
        {
            var detentoIpenAndGaleria = await _detentoManager
                                            .GetIpenAndGaleriaByNomeAsync(detentoNome);
            
            return Ok(new { detentoIpenAndGaleria });
        }

        [HttpGet]
        public async Task<IActionResult> GetByDetentoIpenOrDetentoNome(string term)
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

            var colaboradorSelect2Result = await _detentoManager
                                                    .GetByIpenOrNomeAsync(property, term);
            return Ok(new { colaboradorSelect2Result });
        }
        
        [HttpPost]
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
                        if (item.Name != "Ipen")
                            item.Searchable = false;
                    }
                }
                else
                {
                    //não havendo números na string
                    //deixo ativado somente o searcheable do nome
                    foreach (var item in request.Columns)
                    {
                        if (item.Name != "Nome")
                            item.Searchable = false;
                    }
                }
            }

            var result = await _detentoManager
                                    .GetWithDataTableResultAsync(request);
            return Ok(new {
                data = result.Data,
                Draw = result.Draw,
                RecordsFiltered  = result._iRecordsDisplay,
                RecordsTotal = result._iRecordsTotal,
                Success = true
            });
        }
    }
}