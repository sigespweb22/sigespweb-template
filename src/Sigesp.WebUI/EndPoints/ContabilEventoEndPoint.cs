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
using Sigesp.Domain.Models.DataTable;
using Sigesp.Application;
using Microsoft.AspNetCore.Authorization;

namespace Sigesp.WebUI.EndPoints
{
    [Route("api/contabil-eventos")]
    [Authorize(Roles = "Contabil-Eventos_Todos, Master")]
    [ApiController]
    public class ContabilEventoEndPoint : ApiController
    {
        private readonly IContabilEventoAppService _contabilEventoManager;

        public ContabilEventoEndPoint(IContabilEventoAppService contabilEventoManager)
        {
            _contabilEventoManager = contabilEventoManager;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<ContabilEventoViewModel>>> GetAllAsync(DataTableServerSideRequest dataTableServerSideRequest)
        {
            var contabilEventos = await _contabilEventoManager.GetAllAsync();

            return Ok(new { success = true, data = contabilEventos });
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<ContabilEventoViewModel>> GetAll(DataTableServerSideRequest dataTableServerSideRequest)
        {
            var contabilEventos = _contabilEventoManager.GetAll();

            return Ok(new { 
                Data = contabilEventos, 
                Success = true
            });
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult Post([FromBody]ContabilEventoViewModel contabilEventoViewModel)
        {
            var commandSend  = _contabilEventoManager.Add(contabilEventoViewModel);

            if (commandSend.IsCompleted)
                if (commandSend.Result.ErrorMessages != null || !commandSend.Result.ErrorMessages.Any())
                    foreach (var error in commandSend.Result.ErrorMessages)
                        AddError(error);

            return CustomResponse(contabilEventoViewModel);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult Put([FromBody]ContabilEventoViewModel contabilEventoViewModel)
        {
            var commandSend  = _contabilEventoManager.Update(contabilEventoViewModel);

            if (commandSend.Result.ErrorMessages != null || !commandSend.Result.ErrorMessages.Any())
                foreach (var error in commandSend.Result.ErrorMessages)
                    AddError(error);

            return CustomResponse(contabilEventoViewModel);
        }

        public IActionResult Delete([FromBody]ContabilEventoViewModel contabilEventoViewModel)
        {
            var commandSend  = _contabilEventoManager.Remove((Guid)contabilEventoViewModel.Id);
            
            if (commandSend.Result.ErrorMessages != null || !commandSend.Result.ErrorMessages.Any())
                foreach (var error in commandSend.Result.ErrorMessages)
                    AddError(error);

            return CustomResponse(contabilEventoViewModel);
        }

        [HttpPost]
        [Route("list")]
        public async Task<IActionResult> PostListAsync([FromForm]  DataTableServerSideRequest request)
        {
            try
            {
                if (request is null)
                    throw new ArgumentNullException(nameof(request));
                
                var contabilEventosForDataTable = await _contabilEventoManager
                                                            .GetAllWithDataTableResultAsync(request);

                return CustomResponse(contabilEventosForDataTable);
            }
            catch { throw; }
        }
    }
}