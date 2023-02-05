using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sigesp.Application.Interfaces;
using Sigesp.WebUI.Controllers;
using Sigesp.Application.ViewModels;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Sigesp.Infra.Data.Context;
using Sigesp.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Sigesp.Domain.Interfaces;

namespace Sigesp.WebUI.EndPoints
{
    [Authorize(Roles = "Master, Conta-Usuario_Todos, Conta-Usuario_Dados")]
    [Route("api/conta-usuarios")]
    [ApiController]
    public class ContaUsuarioEndPoint : ApiController
    {
        private readonly IContaUsuarioAppService _contaUsuarioAppService;
        private readonly SigespDbContext _context;
        private readonly IUnitOfWork _unitOfWork;

        public ContaUsuarioEndPoint(IContaUsuarioAppService contaUsuarioAppService,
                                    SigespDbContext context,
                                    IUnitOfWork unitOfWork)
        {
            _contaUsuarioAppService = contaUsuarioAppService;
            _context = context;
            _unitOfWork = unitOfWork;
        }

        [HttpGet("{id}")]
        public async Task<ContaUsuarioViewModel> Get([FromRoute]Guid id)
        {
            var contaUsuario = await _contaUsuarioAppService.GetByIdAsync(id);
            return contaUsuario;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<ContaUsuarioViewModel>>> Get()
        {
            var contaUsuarios = await _contaUsuarioAppService.GetAll();

            return Ok(new { success = true, data = contaUsuarios });
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult Post([FromBody]ContaUsuarioViewModel contaUsuarioViewModel)
        {
            _contaUsuarioAppService.Add(contaUsuarioViewModel);

            return Ok(new { data = contaUsuarioViewModel });
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult Put([FromBody]ContaUsuarioViewModel contaUsuarioViewModel)
        {
            var commandSend  = _contaUsuarioAppService.Update(contaUsuarioViewModel);

            if (commandSend.ErrorMessages != null || !commandSend.ErrorMessages.Any())
                foreach (var error in commandSend.ErrorMessages)
                    AddError(error);

            return CustomResponse(contaUsuarioViewModel);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult Delete([FromRoute] Guid id)
        {
            _contaUsuarioAppService.Remove(id);
            return Ok(new { data = id });
        }

        [Authorize(Roles = "Master, Conta-Usuario_Todos, Conta-Usuario_Dados")]
        [Route("tema")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> TemaAsync()
        {
            #region User resolve
            String userId;
            try
            {
                if (HttpContext.User == null) throw new Exception("Problemas ao obter usuário logado. Saia e entre no sistema novamente, persistindo o problema informe a equipe técnica.");
                userId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            }
            catch (Exception ex) { return StatusCode(500, ex.Message); }

            if (string.IsNullOrEmpty(userId)) return StatusCode(404, "Usuário não encontrado.");
            #endregion

            #region Get data
            var cu = new ContaUsuario();
            try
            {
                cu = await _context.ContaUsuarios.FirstOrDefaultAsync(x => x.UserId == userId);
            }
            catch (Exception ex) { AddError(ex.Message); return StatusCode(500); }

            if (cu == null) return StatusCode(404, "Usuário não encontrado.");
            #endregion

            #region Map
            String tema;
            try
            {
                tema = cu.TemaAtual;
            }
            catch (Exception ex) { AddError(ex.Message); return StatusCode(500); }
            #endregion

            return StatusCode(200, new { result = tema });
        }

        [Authorize(Roles = "Master, Conta-Usuario_Todos, Conta-Usuario_Edit")]
        [Route("tema-change/{tema}")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> TemaChangeAsync([FromRoute] string tema)
        {
            #region Required validations
            if (string.IsNullOrEmpty(tema)) return StatusCode(400, "Tema requerido");
            #endregion

            #region User resolve
            String userId;
            try
            {
                if (HttpContext.User == null) throw new Exception("Problemas ao obter usuário logado. Saia e entre no sistema novamente, persistindo o problema informe a equipe técnica.");
                userId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            }
            catch (Exception ex) { return StatusCode(500, ex.Message); }

            if (string.IsNullOrEmpty(userId)) return StatusCode(404, "Usuário não encontrado.");
            #endregion

            #region Get data
            var cu = new ContaUsuario();
            try
            {
                cu = await _context.ContaUsuarios.FirstOrDefaultAsync(x => x.UserId == userId);
            }
            catch (Exception ex) { AddError(ex.Message); return StatusCode(500); }

            if (cu == null) return StatusCode(404, "Usuário não encontrado.");
            #endregion

            #region Map and persistance
            try
            {
                cu.TemaAtual = tema;
                _context.ContaUsuarios.Update(cu);
                _unitOfWork.Commit();
            }
            catch (Exception ex) { AddError(ex.Message); return StatusCode(500); }
            #endregion

            return StatusCode(204);
        }
    }
}