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
using Sigesp.WebUI.Helpers.DataTable;

namespace Sigesp.WebUI.EndPoints
{
    [Authorize(Roles = "Master, Livros-Autores_Novo, Livros-Autores_Edicao, Livros-Autores_Delete, Livros-Autores_Lista")]
    [ApiController]
    [Route("api/livros-autores")]
    public class LivrosAutoresEndPoint : ApiController
    {
        private readonly ILivroAutorAppService _livroAutorManager;
        private readonly SigespDbContext _context;
        private readonly IMapper _mapper;

        public LivrosAutoresEndPoint(ILivroAutorAppService livroAutorManager,
                                SigespDbContext context,
                                IMapper mapper)
        {
            _livroAutorManager = livroAutorManager;
            _context = context;
            _mapper = mapper;
        }

        #region Métodos autores
        [Authorize(Roles = "Master, Livros-Autores_Novo")]
        [Route("novo")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult Novo([FromBody]LivroAutorViewModel livroAutorViewModel)
        {
            var commandSend  = _livroAutorManager.Add(livroAutorViewModel);

            if (commandSend.ErrorMessages != null)
                foreach (var error in commandSend.ErrorMessages)
                    AddError(error);

            return CustomResponse(livroAutorViewModel);
        }

        [Authorize(Roles = "Master, Livros-Autores_Edicao")]
        [Route("edicao")]
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult Edicao([FromBody]LivroAutorViewModel livroAutorViewModel)
        {
            var commandSend  = _livroAutorManager.Update(livroAutorViewModel);

            if (commandSend.ErrorMessages != null || !commandSend.ErrorMessages.Any())
                foreach (var error in commandSend.ErrorMessages)
                    AddError(error);

            return CustomResponse(livroAutorViewModel);
        }

        [Authorize(Roles = "Master, Livros-Autores_Delete")]
        [Route("delete")]
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult Delete([FromBody]LivroAutorViewModel livroAutorViewModel)
        {
            var commandSend  = _livroAutorManager.Remove((Guid)livroAutorViewModel.Id);
            
            if (commandSend.ErrorMessages != null || !commandSend.ErrorMessages.Any())
                foreach (var error in commandSend.ErrorMessages)
                    AddError(error);

            return CustomResponse(livroAutorViewModel);
        }

        [Authorize(Roles = "Master, Livros-Autores_Lista")]
        [Route("lista")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Lista([FromForm] DataTableServerSideRequest request)
        {
            var result = await _context.LivrosAutores
                                    .OrderByDescending(x => x.CreatedAt)
                                    .GetDatatableResultAsync(request);

            var dataMapped = _mapper.Map<IEnumerable<LivroAutorViewModel>>(result.Data);
            
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