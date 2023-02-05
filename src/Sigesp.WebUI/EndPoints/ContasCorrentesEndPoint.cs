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
using Sigesp.Domain.Enums;

namespace Sigesp.WebUI.EndPoints
{
    [Route("api/contas-correntes")]
    [ApiController]
    public class ContasCorrentesEndPoint : ApiController
    {
        private readonly IContaCorrenteAppService _contaCorrenteManager;

        public ContasCorrentesEndPoint(IContaCorrenteAppService contaCorrenteManager)
        {
            _contaCorrenteManager = contaCorrenteManager;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<ContaCorrenteViewModel>>> Get()
        {
            var contasCorrentes = await _contaCorrenteManager.GetAllAsync();

            return Ok(new { success = true, data = contasCorrentes });
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult Post([FromBody]ContaCorrenteViewModel contaCorrenteViewModel)
        {
            var commandSend  =  _contaCorrenteManager.Add(contaCorrenteViewModel);

            if (commandSend.ErrorMessages != null)
                foreach (var error in commandSend.ErrorMessages)
                    AddError(error);

            return CustomResponse(contaCorrenteViewModel);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult Put([FromBody]ContaCorrenteViewModel contaCorrenteViewModel)
        {
            var commandSend  = _contaCorrenteManager.Update(contaCorrenteViewModel);

            if (commandSend.ErrorMessages != null || !commandSend.ErrorMessages.Any())
                foreach (var error in commandSend.ErrorMessages)
                    AddError(error);

            return CustomResponse(contaCorrenteViewModel);
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult Delete([FromBody]ContaCorrenteViewModel contaCorrenteViewModel)
        {
            var commandSend  = _contaCorrenteManager.Remove((Guid)contaCorrenteViewModel.Id);
            
            if (commandSend.ErrorMessages != null || !commandSend.ErrorMessages.Any())
                foreach (var error in commandSend.ErrorMessages)
                    AddError(error);

            return CustomResponse(contaCorrenteViewModel);
        }

        [Route("get-saldoSemLcto-by-lctoId-empresaRazaoSocial-tipo")]
        public IActionResult GetSaldoSemLCTOByLCTOIdEmpresaRazaoSocialAndTipo([FromBody]ContaCorrenteViewModel contaCorrenteViewModel)
        {
            try
            {
                if (contaCorrenteViewModel.EmpresaRazaoSocial.IsNullOrEmpty())
                    return BadRequest("Razão social da empresa requerida.");

                decimal result = _contaCorrenteManager.GetSaldoSemLCTOByEmpresaRazaoSocialAndTipo(
                                                                    contaCorrenteViewModel.LancamentoId,
                                                                    contaCorrenteViewModel.EmpresaRazaoSocial,
                                                                    contaCorrenteViewModel.IsTipoCofre);

                return Ok( new {
                    Data = result,
                    Success= true
                });            
            }
            catch { throw; }
        }

        [Route("get-saldoSemLcto-by-lctoId-colaboradorNome")]
        public IActionResult GetSaldoSemLCTOByLCTOIdColaboradorNome([FromBody]ContaCorrenteViewModel contaCorrenteViewModel)
        {
            try
            {
                if (contaCorrenteViewModel.ColaboradorNome.IsNullOrEmpty())
                    return BadRequest("Nome do colaborador requerido.");

                decimal result = _contaCorrenteManager.GetSaldoSemLCTOByColaboradorNome(
                                                                    contaCorrenteViewModel.LancamentoId,
                                                                    contaCorrenteViewModel.ColaboradorNome);

                return Ok( new {
                    Data = result,
                    Success= true
                });            
            }
            catch { throw; }
        }
    }
}