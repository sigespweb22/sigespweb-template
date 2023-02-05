using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sigesp.Application.Interfaces;
using Sigesp.Application.ViewModels;
using Sigesp.WebUI.Controllers;
using Microsoft.AspNetCore.Authorization;
using AutoMapper;
using Sigesp.Infra.Data.Context;
using Sigesp.Domain.Models.DataTable;
using Sigesp.Infra.Data.Extensions;
using Sigesp.Domain.Interfaces;
using Microsoft.Extensions.Caching.Memory;
using Sigesp.Application.ViewModels.Cards;
using System.Text.Json;

namespace Sigesp.WebUI.EndPoints
{
    [Authorize(Roles = "Master, Professores_Novo, Professores_Edicao,"+
                        "Professores_Delete, Professores_Lista")]
    [ApiController]
    [Route("api/professores")]
    public class ProfessorEndPoint : ApiController
    {
        private readonly IProfessorAppService _professorManager;
        private readonly SigespDbContext _context;
        private readonly IMapper _mapper;
        private readonly ValidationResult _validationResult;
        private readonly IMemoryCache _memoryCache;
        private readonly ITenantRepository _tenantRepository;

        public ProfessorEndPoint(IProfessorAppService professorManager,
                                SigespDbContext context,
                                IMapper mapper,
                                ValidationResult validationResult,
                                IMemoryCache memoryCache,
                                ITenantRepository tenantRepository)
        {
            _professorManager = professorManager;
            _context = context;
            _mapper = mapper;
            _validationResult = validationResult;
            _memoryCache = memoryCache;
            _tenantRepository = tenantRepository;
        }

        #region Métodos Generos
        [Authorize(Roles = "Master, Professores_Novo")]
        [Route("novo")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Novo([FromBody]ProfessorViewModel professorViewModel)
        {
            try
            {
                await _professorManager.AddAsync(professorViewModel);
                return CustomResponse(professorViewModel);
            }
            catch { throw; }
        }

        [Authorize(Roles = "Master, Professores_Edicao")]
        [Route("edicao")]
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Edicao([FromBody]ProfessorViewModel professorViewModel)
        {
            try
            {
                await _professorManager.UpdateAsync(professorViewModel);
                return CustomResponse(professorViewModel);
            }
            catch { throw; }
        }

        [Authorize(Roles = "Master, Professores_Delete")]
        [Route("delete")]
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult Delete([FromBody]ProfessorViewModel professorViewModel)
        {
            var commandSend  = _professorManager.Remove((Guid)professorViewModel.Id);
            
            if (commandSend.ErrorMessages != null || !commandSend.ErrorMessages.Any())
                foreach (var error in commandSend.ErrorMessages)
                    AddError(error);

            return CustomResponse(professorViewModel);
        }

        [Authorize(Roles = "Master, Professores_Lista")]
        [Route("lista")]
        [HttpPost]
        public async Task<IActionResult> ListaAsync([FromForm] DataTableServerSideRequest request)
        {
            try
            {
                var result = await _professorManager
                                    .GetWithDataTableResultAsync(request);
                return Ok(result);
            }
            catch { throw; }
        }
        
        [HttpGet]
        [Route("get-info-cards")]       
        public async Task<IActionResult> GetInfoCards()
        {
            try
            {
                var professorCardViewModel = new ProfessorCardViewModel();
                var tenantId = StringHelpers.ExtractTenantId(await _tenantRepository.GetTenantIdAsync());

                if (tenantId != null && tenantId != Guid.Empty)
                {
                    var cacheKey = "Professor - GetInfoCards | TenantId: " + tenantId;
                    var json = _memoryCache.Get(cacheKey);
                    if(json != null)
                    {
                        var professoresSerializer = JsonSerializer.Deserialize<ProfessorCardViewModel>(json.ToString());
                        professorCardViewModel = professoresSerializer;
                    }
                    else {
                        var cacheEntryOptions = new MemoryCacheEntryOptions()
                        .SetSlidingExpiration(TimeSpan.FromSeconds(5));

                        professorCardViewModel = await _professorManager.GetInfoCardsAsync();
                        json = JsonSerializer.Serialize<ProfessorCardViewModel>(professorCardViewModel);
                        _memoryCache.Set(cacheKey, json, cacheEntryOptions);
                    }
                }
                else
                {
                    professorCardViewModel = await _professorManager.GetInfoCardsAsync();
                }

                return CustomResponse(professorCardViewModel);
            }
            catch { throw; }
        }
        #endregion
    }
}