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
using Sigesp.WebUI.Helpers.DataTable;

namespace Sigesp.WebUI.EndPoints
{
    [Route("api/colaboradores")]
    [ApiController]
    public class ColaboradoresEndPoint : ApiController
    {
        private readonly IColaboradorAppService _colaboradorManager;
        private readonly SigespDbContext _context;

        public ColaboradoresEndPoint(IColaboradorAppService colaboradorManager,
                                    SigespDbContext context)
        {
            _colaboradorManager = colaboradorManager;
            _context = context;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<ColaboradorViewModel>>> Get(DataTableServerSideRequest dataTableServerSideRequest)
        {
            var colaboradores = await _colaboradorManager.GetAllAsync();

            return Ok(new { success = true, data = colaboradores });
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult Post([FromBody]ColaboradorViewModel colaboradorViewModel)
        {
            var commandSend  = _colaboradorManager.Add(colaboradorViewModel);

            if (commandSend.ErrorMessages != null || !commandSend.ErrorMessages.Any())
                foreach (var error in commandSend.ErrorMessages)
                    AddError(error);

            return CustomResponse(colaboradorViewModel);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult Put([FromBody]ColaboradorViewModel colaboradorViewModel)
        {
            var commandSend  = _colaboradorManager.Update(colaboradorViewModel);

            if (commandSend.ErrorMessages != null || !commandSend.ErrorMessages.Any())
                foreach (var error in commandSend.ErrorMessages)
                    AddError(error);

            return CustomResponse(colaboradorViewModel);
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult Delete([FromBody]ColaboradorViewModel colaboradorViewModel)
        {
            var commandSend  = _colaboradorManager.Remove((Guid)colaboradorViewModel.Id);
            
            if (commandSend.ErrorMessages != null || !commandSend.ErrorMessages.Any())
                foreach (var error in commandSend.ErrorMessages)
                    AddError(error);

            return CustomResponse(colaboradorViewModel);
        }
    }
}