using System.Runtime.CompilerServices;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sigesp.WebUI.Extensions;
using Sigesp.Domain.Interfaces;
using Sigesp.Application.Interfaces;
using Sigesp.Application.ViewModels;
using Sigesp.WebUI.Controllers;
using Sigesp.Infra.Data.Extensions;
using Sigesp.Application.ViewModels.Cards;
using Sigesp.Domain.Enums;
using Microsoft.Extensions.Caching.Memory;
using System.Text.Json;
using Sigesp.Infra.Data.Context;
using Sigesp.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Sigesp.WebUI.EndPoints
{
    [ApiController]
    [Route("api/detentos")]
    public class DetentosEndPoint : ApiController
    {
        private readonly IDetentoAppService _detentoManager;
        private readonly ITenantRepository _tenantRepository;
        private readonly IMemoryCache _memoryCache;
        private readonly SigespDbContext _context;
        private readonly IUnitOfWork _unitOfWork;

        public DetentosEndPoint(IDetentoAppService detentoManager,
                                ITenantRepository tenantRepository,
                                IMemoryCache memoryCache,
                                SigespDbContext context,
                                IUnitOfWork unitOfWork)
        {
            _detentoManager = detentoManager;
            _tenantRepository = tenantRepository;
            _memoryCache = memoryCache;
            _context = context;
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Post([FromBody]DetentoViewModel detentoViewModel)
        {
            var commandSend = new ValidationResult();
            try
            {
                commandSend  = await _detentoManager.AddAsync(detentoViewModel);
            }
            catch (Exception ex) { return StatusCode(400, ex.Message); }

            if (commandSend.ErrorMessages != null)
                foreach (var error in commandSend.ErrorMessages)
                    AddError(error);

            return CustomResponse(detentoViewModel);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult Edicao([FromBody]DetentoViewModel detentoViewModel)
        {
            var commandSend  = _detentoManager
                                    .Update(detentoViewModel);

            if (commandSend.ErrorMessages != null || !commandSend.ErrorMessages.Any())
                foreach (var error in commandSend.ErrorMessages)
                    AddError(error);

            return CustomResponse(detentoViewModel);
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult Delete([FromBody]DetentoViewModel detentoViewModel)
        {
            _detentoManager.Remove((Guid)detentoViewModel.Id);
            return Ok(new { data = detentoViewModel.Id });
        }

        [Route("get-all")]
        public async Task<IActionResult> GetAllAsync([FromBody]string ipen)
        {
            var result = await _detentoManager.GetAllAsync();

            return Ok( new {
                Data = result,
                Success= true
            });
        }

        [Route("transfer")]
        public async Task<IActionResult> PostTransferByIpen([FromBody]DetentoViewModel detentoViewModel)
        {
            var transferResult = await _detentoManager.TransferByIpenAsync(detentoViewModel);

            return Ok( new {
                Data = transferResult,
                Success= true
            });
        }

        [Route("getByIpen-forModalTransferencia")]
        public async Task<IActionResult> PostGetForModalTransferencia([FromBody]string ipen)
        {
            var result = await _detentoManager.GetForModalTransferenciaAsync(ipen);

            return Ok( new {
                Data = result,
                Success= true
            });
        }

        [Route("get-ipen-regime-by-nome")]
        public async Task<IActionResult> GetIpenRegimeByNome([FromBody]string nome)
        {
            var result = await _detentoManager.GetIpenRegimeByNomeAsync(nome);

            return Ok( new {
                Data = result,
                Success= true
            });
        }

        [Route("get-for-edit-by-ipen")]
        public async Task<IActionResult> GetForEditByIpen([FromBody]string ipen)
        {
            try
            {
                if (ipen.IsNullOrEmpty())
                    return BadRequest("Ipen requerido!");

                var result = await _detentoManager.GetForEditByIpenAsync(ipen);

                return Ok( new {
                    Data = result,
                    Success= true
                });            
            }
            catch { throw; }
        }

        [Route("get-by-nome")]
        public async Task<IActionResult> GetByNomeAsync([FromBody]string nome)
        {
            try
            {
                if (nome.IsNullOrEmpty())
                    return BadRequest("Ipen requerido!");

                var result = await _detentoManager
                                     .GetByNomeAsync(nome);

                if (result == null)
                {
                    AddError("Nenhum detento encontrado com o nome informado.");
                }

                return CustomResponse(result);         
            }
            catch { throw; }
        }

        [Route("get-all-by-nome")]
        public async Task<IActionResult> GetAllByNomeAsync([FromBody]string nome)
        {
            try
            {
                if (nome.IsNullOrEmpty())
                    return BadRequest("Nome requerido!");

                var result = await _detentoManager
                                     .GetAllByNomeAsync(nome);

                if (result == null)
                {
                    AddError("Nenhum detento encontrado com o nome informado.");
                }

                return CustomResponse(result);           
            }
            catch { throw; }
        }

        [Route("get-by-ipen")]
        public async Task<IActionResult> GetByIpen([FromBody]string ipen)
        {
            try
            {
                if (ipen.IsNullOrEmpty())
                    return BadRequest("Ipen requerido!");

                var result = await _detentoManager
                                    .GetByIpenAsync(Convert.ToInt32(ipen));

                if (result == null)
                {
                    AddError("Nenhum detento encontrado com o ipen informado.");
                }

                return CustomResponse(result);
            }
            catch { throw; }
        }

        [Route("get-by-id")]
        public async Task<IActionResult> GetById([FromBody]string id)
        {
            try
            {
                if (id.IsNullOrEmpty())
                    return BadRequest("Id requerido!");

                var result = await _detentoManager
                                        .GetDetentoDataByIdAsync(id);

                if (result == null)
                {
                    AddError("Nenhum detento encontrado com o id informado.");
                }

                return CustomResponse(result);
            }
            catch { throw; }
        }

        [HttpGet]
        [Route("get-info-cards")]
        public async Task<IActionResult> GetInfoCards()
        {
            //Padronizar método, de acordo com o padrão implementado em
            //no método GetInfoCards em DetentosEndPoint
            try
            {
                var tenantId = StringHelpers.ExtractTenantId(_tenantRepository.GetTenantId());
                IEnumerable<DetentoViewModel> detentos = 
                                                    new List<DetentoViewModel>();

                if (tenantId != null && tenantId != Guid.Empty)
                {
                    var cacheKey = "Detentos | TenantId: " + tenantId;

                    var json = _memoryCache.Get(cacheKey);
                    if(json != null)
                    {
                        detentos = JsonSerializer.Deserialize<List<DetentoViewModel>>(json.ToString());
                    }
                    else {
                        var cacheEntryOptions = new MemoryCacheEntryOptions()
                        .SetSlidingExpiration(TimeSpan.FromSeconds(5));

                        detentos = _detentoManager.GetAll();
                        json = JsonSerializer.Serialize<List<DetentoViewModel>>(detentos.ToList());
                        _memoryCache.Set(cacheKey, json, cacheEntryOptions);
                    }
                }
                else
                {
                    detentos = await _detentoManager.GetAllAsync();
                }

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
                    Provisorios = detentos.Where(x => x.Regime == DetentoRegimeEnum.PROVISORIO.ToString()
                                                    || x.Regime == DetentoRegimeEnum.PROVISORIO_EXECUCAO_SUSPENSA.ToString()
                                                    || x.Regime == DetentoRegimeEnum.ALIMENTOS.ToString()
                                                    || x.Regime == DetentoRegimeEnum.PRISAO_TEMPORARIA.ToString()).Count()
                };

                if (detentos == null)
                    AddError("Nenhuma informação encontrada para os CARDS.");

                return CustomResponse(detentoCardViewModel);
            }
            catch { throw; }
        }

        [HttpGet]
        [Route("change-tenancy/{ipen}")]
        public async Task<IActionResult> ChangeTenancyAsync(string ipen)
        {
            #region Required validations
            try
            {
                if (string.IsNullOrEmpty(ipen))
                    throw new ArgumentException("Ipen requerido.");
            }
            catch (Exception ex) { return StatusCode(400, ex.Message); }
            #endregion

            try
            {
                return CustomResponse(await _detentoManager.ChangeTenancyAsync(ipen));
            }
            catch { throw; }
        }

        /// <summary>
        /// Adiciona ou altera o PEC de um detento egresso da minha unidade
        /// </summary>
        /// <param name="ipen"></param>
        /// <param name="pec"></param>
        /// <returns>Código 204 se atualizado com sucesso</returns>
        /// <response code="400">Problemas de validação ou dados nulos</response>
        /// <response code="404">Não encontrado</response>
        /// <response code="500">Erro desconhecido</response>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        [Route("alter-pec/{ipen}/{pec}")]
        [HttpPut]
        public async Task<IActionResult> AlterPecAsync(int ipen, string pec)
        {
            #region Required validations
            if (ipen == 0)
            {
                AddError("Ipen requerido.");
                return CustomResponsePassCode(400);
            }

            if (string.IsNullOrEmpty(pec))
            {
                AddError("Pec requerido.");
                return CustomResponsePassCode(400);
            }
            #endregion

            #region Tenancy resolve
            Guid tenantId;
            try
            {
                tenantId = (Guid)StringHelpers.ExtractTenantId(await _tenantRepository.GetTenantIdAsync());
            }
            catch (Exception ex) { AddError(ex.Message); return CustomResponse(500); }
            
            if (tenantId == Guid.Empty)
            {
                AddError("Problemas ao obter os dados de sua UNIDADE. \n Tente novamente, persistindo o erro informe a equipe técnica do SigespWeb.");
                return CustomResponsePassCode(400);
            }
            #endregion

            #region Get data Detento and in Andamento Penal
            var detento = new Detento();
            try
            {
                detento = await _context
                                    .Detentos
                                    .IgnoreQueryFilters()
                                    .Include("AndamentoPenal")
                                    .Where(x => x.Ipen == ipen)
                                    .FirstOrDefaultAsync();
            }
            catch (Exception ex) { AddError(ex.Message); return CustomResponse(500); }

            if (detento == null)
            {
                AddError("Detento não encontrado");
                return CustomResponsePassCode(404);
            }
            #endregion

            #region Generals validations
            if (detento.AndamentoPenal == null)
            {
                var andamentoPenal = new AndamentoPenal()
                {
                    Id = Guid.NewGuid(), 
                    Historico = "Adicionado automaticamente pelo sistema a partir da atualização de PEC de detento egresso.",
                    Pec = pec,
                    DetentoId = detento.Id,
                    DataEventoPrincipal = DateTime.Now.AddDays(7)
                };
               
                _context.AndamentoPenal.Add(andamentoPenal);
                _unitOfWork.Commit();

                if (detento.IsDeleted)
                {
                    andamentoPenal.IsDeleted = true;
                    _context.AndamentoPenal.Update(andamentoPenal);
                }
            }
            else
            {
                detento.AndamentoPenal.Pec = pec;
                _context.Detentos.Update(detento);
            }
            #endregion

            #region Commit
            try
            {
                _unitOfWork.Commit();
            }
            catch (Exception ex) { AddError(ex.Message); return CustomResponse(500); }
            #endregion

            return CustomResponsePassCode(204);
        }
    }
}