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
using Sigesp.WebUI.Helpers.DataTable;
using Sigesp.WebUI.Helpers;
using Sigesp.Domain.Enums;
using AutoMapper;

namespace Sigesp.WebUI.EndPoints
{
    [Authorize(Roles = "Master, Fluxo-Caixa-Lancamentos_Todos, Fluxo-Caixa-Contas-Correntes_Todos")]
    [ApiController]
    [Route("api/fluxo-caixa")]
    public class FluxoCaixaEndPoint : ApiController
    {
        private readonly ILancamentoAppService _lancamentoManager;
        private readonly IContaCorrenteAppService _contaCorrenteManager;
        private readonly SigespDbContext _context;
        private readonly IMapper _mapper;

        public FluxoCaixaEndPoint(ILancamentoAppService lancamentoManager,
                                  IContaCorrenteAppService contaCorrenteManager,
                                    SigespDbContext context,
                                    IMapper mapper)
        {
            _lancamentoManager = lancamentoManager;
            _contaCorrenteManager = contaCorrenteManager;
            _context = context;
            _mapper = mapper;
        }

        #region Métodos contas corrente
        [Authorize(Roles = "Master, Fluxo-Caixa-ContasCorrentes_Novo")]
        [Route("contas-correntes/novo")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult ContasCorrentesNovo([FromBody]ContaCorrenteViewModel contaCorrenteViewModel)
        {
            var commandSend  = _contaCorrenteManager.Add(contaCorrenteViewModel);

            if (commandSend.ErrorMessages != null)
                foreach (var error in commandSend.ErrorMessages)
                    AddError(error);

            return CustomResponse(contaCorrenteViewModel);
        }

        [Authorize(Roles = "Master, Fluxo-Caixa-Caixa-ContasCorrentes_Edicao")]
        [Route("contas-correntes/edicao")]
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult ContasCorrentesEdicao([FromBody]ContaCorrenteViewModel contaCorrenteViewModel)
        {
            var commandSend  = _contaCorrenteManager.Update(contaCorrenteViewModel);

            if (commandSend.ErrorMessages != null || !commandSend.ErrorMessages.Any())
                foreach (var error in commandSend.ErrorMessages)
                    AddError(error);

            return CustomResponse(contaCorrenteViewModel);
        }

        [Authorize(Roles = "Master, Fluxo-Caixa-ContasCorrentes_Delete")]
        [Route("contas-correntes/delete")]
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult ContasCorrentesDelete([FromBody]ContaCorrenteViewModel contaCorrenteViewModel)
        {
            var commandSend  = _contaCorrenteManager.Remove((Guid)contaCorrenteViewModel.Id);
            
            if (commandSend.ErrorMessages != null || !commandSend.ErrorMessages.Any())
                foreach (var error in commandSend.ErrorMessages)
                    AddError(error);

            return CustomResponse(contaCorrenteViewModel);
        }

        [Authorize(Roles = "Master, Fluxo-Caixa-ContasCorrentes_Lista")]
        [Route("contas-correntes/lista")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> ContasCorrentesLista([FromForm] DataTableServerSideRequest request)
        {
            var result = await _context.ContasCorrentes
                                    .Include(x => x.Empresa)
                                    .Include(x => x.Lancamentos)
                                    .Where(x => x.Tipo 
                                            == ContaCorrenteTipoEnum.PESSOA_JURIDICA
                                            || x.Tipo
                                            == ContaCorrenteTipoEnum.COFRE)
                                    .Include(x => x.Lancamentos)
                                    .OrderByDescending(x => x.CreatedAt)
                                    .GetDatatableResultAsync(request);

            var dataMapped = _mapper.Map<IEnumerable<ContaCorrenteViewModel>>(result.Data);
            
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
        #endregion

        #region Métodos Lançamentos
        [Authorize(Roles = "Master, Fluxo-Caixa-Lancamentos_Novo")]
        [Route("lancamentos/novo")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult LancamentosNovo([FromBody]LancamentoViewModel lancamentoViewModel)
        {
            var commandSend  = _lancamentoManager.Add(lancamentoViewModel);

            if (commandSend.ErrorMessages != null)
                foreach (var error in commandSend.ErrorMessages)
                    AddError(error);

            return CustomResponse(lancamentoViewModel);
        }

        [Authorize(Roles = "Master, Fluxo-Caixa-Lancamentos_Edicao")]
        [Route("lancamentos/edicao")]
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult LancamentosEdicao([FromBody]LancamentoViewModel lancamentoViewModel)
        {
            var commandSend  = _lancamentoManager.Update(lancamentoViewModel);

            if (commandSend.ErrorMessages != null || !commandSend.ErrorMessages.Any())
                foreach (var error in commandSend.ErrorMessages)
                    AddError(error);

            return CustomResponse(lancamentoViewModel);
        }

        [Authorize(Roles = "Master, Fluxo-Caixa-Lancamentos_Delete")]
        [Route("lancamentos/delete")]
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult LancamentosDelete([FromBody]LancamentoViewModel lancamentoViewModel)
        {
            var commandSend  = _lancamentoManager.Remove((Guid)lancamentoViewModel.Id);
            
            if (commandSend.ErrorMessages != null || !commandSend.ErrorMessages.Any())
                foreach (var error in commandSend.ErrorMessages)
                    AddError(error);

            return CustomResponse(lancamentoViewModel);
        }

        [Authorize(Roles = "Master, Fluxo-Caixa-Lancamentos_Lista")]
        [Route("lancamentos/lista")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> LancamentosLista([FromForm] DataTableServerSideRequest request)
        {
            var result = await _context.Lancamentos
                                    .Include(x => x.ContaCorrente)
                                    .ThenInclude(x => x.Empresa)
                                    .Include(x => x.ContabilEvento)
                                    .Where(x => x.ContaCorrente.Tipo == ContaCorrenteTipoEnum.PESSOA_JURIDICA
                                            || x.ContaCorrente.Tipo == ContaCorrenteTipoEnum.COFRE)
                                    .OrderByDescending(x => x.CreatedAt)
                                    .GetDatatableResultAsync(request);

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
        #endregion
    }
}