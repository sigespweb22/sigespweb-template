using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections;
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
using Sigesp.Domain.Models;
using Sigesp.Domain.Interfaces;
using Sigesp.Application.Services;
using Sigesp.Application.Interfaces;
using Sigesp.Application.ViewModels;
using Sigesp.WebUI.Controllers;
using Microsoft.AspNetCore.Authorization;
using AutoMapper;
using Sigesp.Domain.Models.DataTable;
using Sigesp.WebUI.Helpers;
using Sigesp.Infra.Data.Extensions.DataTable;

namespace Sigesp.WebUI.EndPoints
{
    [Authorize(Roles = "Master, Andamento-Penal_Todos")]
    [ApiController]
    [Route("api/andamento-penal")]
    public class AndamentoPenalEndPoint : ApiController
    {
         private readonly IAndamentoPenalAppService _apManager;
        private readonly IDetentoAppService _detentoManager;
        private readonly SigespDbContext _context;
        private readonly IMapper _mapper;

        public AndamentoPenalEndPoint(IAndamentoPenalAppService apManager,
                                        IDetentoAppService detentoManager,
                                        SigespDbContext context,
                                        IMapper mapper)
        {
            _apManager = apManager;
            _detentoManager = detentoManager;
            _context = context;
            _mapper = mapper;
        }

        [Authorize(Roles = "Master, Andamento-Penal_Novo")]
        [Route("novo")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult Novo([FromBody]AndamentoPenalViewModel apViewModel)
        {
            var commandSend  = _apManager.Add(apViewModel);

            if (commandSend.ErrorMessages != null)
                foreach (var error in commandSend.ErrorMessages)
                    AddError(error);

            return CustomResponse(apViewModel);
        }

        [Authorize(Roles = "Master, Andamento-Penal_Edicao")]
        [Route("edicao")]
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult Edicao([FromBody]AndamentoPenalViewModel apViewModel)
        {
            var commandSend  = _apManager.Update(apViewModel);

            if (commandSend.ErrorMessages != null || !commandSend.ErrorMessages.Any())
                foreach (var error in commandSend.ErrorMessages)
                    AddError(error);

            return CustomResponse(apViewModel);
        }

        [Authorize(Roles = "Master, Andamento-Penal_Delete")]
        [Route("delete")]
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult Delete([FromBody]AndamentoPenalViewModel apViewModel)
        {
            var commandSend  = _apManager.Remove((Guid)apViewModel.Id);
            
            if (commandSend.ErrorMessages != null || !commandSend.ErrorMessages.Any())
                foreach (var error in commandSend.ErrorMessages)
                    AddError(error);

            return CustomResponse(apViewModel);
        }

        [HttpPost]
        [Route("lista")]
        public async Task<IActionResult> PostListaAsync([FromForm]  DataTableServerSideRequest request)
        {
            //Quando o método for acionado por uma busca
            //Deverá identificar qual o tipo de dado, afim de direcionar a coluna de pesquisa
            //Permitindo assim somente pesquisa de uma condicional (Ipen/Nome)
            if (!request.Search.Value.IsNullOrEmpty())
            {
                var valueSearch = request.Search.Value;

                if (NumericHelpers.HasNumber(valueSearch) && !StringHelpers.HasBar(valueSearch))
                {
                    //havendo numeros na string
                    //deixo ativado somente o searcheable do ipen
                    if (valueSearch.Count() > 3)
                    {
                        foreach (var item in request.Columns)
                        {
                            if (!item.Name.IsNullOrEmpty() &&
                                item.Name != "Detento.Ipen")
                                item.Searchable = false;
                        }
                    }
                    else 
                    {
                        return Ok(new {
                            Data = new List<AndamentoPenal>(),
                            Draw = 0,
                            RecordsFiltered  = 0,
                            RecordsTotal = 0,
                            Success = true
                        });
                    }
                    
                }
                else if (StringHelpers.HasBar(valueSearch))
                {
                    //somente segue para busca caso houver uma data válida´
                    if (!DateHelpers.IsDateStringValid(valueSearch))            
                        return Ok();

                    //não havendo números na string
                    //deixo ativado somente o searcheable do nome
                    foreach (var item in request.Columns) 
                    {
                        if (!item.Name.IsNullOrEmpty() &&
                            item.Name != "DataEventoPrincipal")
                            item.Searchable = false;
                    }
                } 
                else if (request.FetchHistory)
                {
                    //não havendo números na string
                    //deixo ativado somente o searcheable do nome
                    foreach (var item in request.Columns) 
                    {
                        if (!item.Name.IsNullOrEmpty() && item.Name != "Historico")
                        {
                            item.Searchable = false;
                        }

                        if (!item.Name.IsNullOrEmpty() && item.Name == "Historico")
                        {
                            item.Searchable = true;
                        }
                    }
                }
                else
                {
                    //não havendo números na string
                    //deixo ativado somente o searcheable do nome
                    foreach (var item in request.Columns) 
                    {
                        if (!item.Name.IsNullOrEmpty() &&
                            item.Name != "Detento.Nome")
                            item.Searchable = false;
                    }
                }
            }
            
            var result = await _context.AndamentoPenal
                                    .IgnoreQueryFilters()
                                    .Include(x => x.Detento)
                                    .Where(x => x.Detento.IsDeleted == false || x.Detento.IsDeleted == true)
                                    .Where(x => x.IsDeleted == false)
                                    .OrderBy(x => x.DataEventoPrincipal)
                                    .GetDatatableResultAsync(request);

            var dataMapped = _mapper.Map<IEnumerable<AndamentoPenalViewModel>>(result.Data);

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

        [Route("get-by-id")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetById([FromBody]string id)
        {
            var getById = _apManager
                                    .GetByIdWithInclude(id);

             return Ok(new {
                Data = getById,
                Success = true
            });
        }

        [Route("already-ativo-by-ipen")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult AlreadyAtivoByIpen([FromBody]string ipen)
        {
            try
            {
                if(ipen.IsNullOrEmpty())
                    throw new Exception("Ipen requerido.");
                    
                    
                var alreadyAtivoByIpen = _apManager
                                        .AlreadyAtivoByIpen(Convert.ToInt32(ipen));

                return Ok(new {
                    Data = alreadyAtivoByIpen,
                    Success = true
                });
            }
            catch { throw; }            
        }
        
        [Route("rescue-inactive-by-ipen")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult RescueInactiveByIpen([FromBody]string ipen)
        {
            try
            {
                if(ipen.IsNullOrEmpty())
                    throw new Exception("Ipen requerido.");
                    
                    
                var rescueInactiveByIpen = _apManager
                                                .RescueInactiveByIpen(Convert.ToInt32(ipen));

                return Ok(new {
                    Data = rescueInactiveByIpen,
                    Success = true
                });
            }
            catch { throw; } 
        }
    }
}