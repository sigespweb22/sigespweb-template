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
using Sigesp.Application.ViewModels.Selects;

namespace Sigesp.WebUI.EndPoints
{
    [Authorize(Roles = "Master, Livros-Generos_Novo,"+
                       "Livros-Generos_Edicao, Livros-Generos_Delete, Livros-Generos_Lista")]
    [ApiController]
    [Route("api/livros-Generos")]
    public class LivrosGenerosEndPoint : ApiController
    {
        private readonly ILivroGeneroAppService _livroGeneroManager;
        private readonly SigespDbContext _context;
        private readonly IMapper _mapper;

        public LivrosGenerosEndPoint(ILivroGeneroAppService livroGeneroManager,
                                SigespDbContext context,
                                IMapper mapper)
        {
            _livroGeneroManager = livroGeneroManager;
            _context = context;
            _mapper = mapper;
        }

        #region Métodos Generos
        [Authorize(Roles = "Master, Livros-Generos_Novo")]
        [Route("novo")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult Novo([FromBody]LivroGeneroViewModel livroGeneroViewModel)
        {
            var commandSend  = _livroGeneroManager.Add(livroGeneroViewModel);

            if (commandSend.ErrorMessages != null)
                foreach (var error in commandSend.ErrorMessages)
                    AddError(error);

            return CustomResponse(livroGeneroViewModel);
        }

        [Authorize(Roles = "Master, Livros-Generos_Edicao")]
        [Route("edicao")]
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult Edicao([FromBody]LivroGeneroViewModel livroGeneroViewModel)
        {
            var commandSend  = _livroGeneroManager.Update(livroGeneroViewModel);

            if (commandSend.ErrorMessages != null || !commandSend.ErrorMessages.Any())
                foreach (var error in commandSend.ErrorMessages)
                    AddError(error);

            return CustomResponse(livroGeneroViewModel);
        }

        [Authorize(Roles = "Master, Livros-Generos_Delete")]
        [Route("delete")]
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult Delete([FromBody]LivroGeneroViewModel livroGeneroViewModel)
        {
            var commandSend  = _livroGeneroManager.Remove((Guid)livroGeneroViewModel.Id);
            
            if (commandSend.ErrorMessages != null || !commandSend.ErrorMessages.Any())
                foreach (var error in commandSend.ErrorMessages)
                    AddError(error);

            return CustomResponse(livroGeneroViewModel);
        }

        [Authorize(Roles = "Master, Livros-Generos_Lista")]
        [Route("lista")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Lista([FromForm] DataTableServerSideRequest request)
        {
            var result = await _context.LivrosGeneros
                                    .OrderByDescending(x => x.CreatedAt)
                                    .GetDatatableResultAsync(request);

            var dataMapped = _mapper.Map<IEnumerable<LivroGeneroViewModel>>(result.Data);
            
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