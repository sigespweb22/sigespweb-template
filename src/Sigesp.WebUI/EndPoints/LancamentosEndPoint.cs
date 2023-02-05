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

namespace Sigesp.WebUI.EndPoints
{
    [ApiController]
    [Route("api/lancamentos")]
    public class LancamentosEndPoint : ApiController
    {
        private readonly ILancamentoAppService _lancamentoManager;

        public LancamentosEndPoint(ILancamentoAppService lancamentoManager)
        {
            _lancamentoManager = lancamentoManager;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<LancamentoViewModel>>> Get()
        {
            var lancamentos = await _lancamentoManager
                                            .GetAllAsyncWithInclude();

            return Ok(new { success = true, data = lancamentos });
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult Post([FromBody]LancamentoViewModel lancamentoViewModel)
        {
            var commandSend  = _lancamentoManager.Add(lancamentoViewModel);

            if (commandSend.ErrorMessages != null)
                foreach (var error in commandSend.ErrorMessages)
                    AddError(error);

            return CustomResponse(lancamentoViewModel);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult Put([FromBody]LancamentoViewModel lancamentoViewModel)
        {
            var commandSend  = _lancamentoManager.Update(lancamentoViewModel);

            if (commandSend.ErrorMessages != null || !commandSend.ErrorMessages.Any())
                foreach (var error in commandSend.ErrorMessages)
                    AddError(error);

            return CustomResponse(lancamentoViewModel);
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult Delete([FromBody]LancamentoViewModel lancamentoViewModel)
        {
            var commandSend  = _lancamentoManager.Remove((Guid)lancamentoViewModel.Id);
            
            if (commandSend.ErrorMessages != null || !commandSend.ErrorMessages.Any())
                foreach (var error in commandSend.ErrorMessages)
                    AddError(error);

            return CustomResponse(lancamentoViewModel);
        }
    }
}