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
using Sigesp.WebUI.Helpers;
using Sigesp.WebUI.Extensions;

namespace Sigesp.WebUI.EndPoints
{
    [Authorize(Roles = "Master, Disciplinas_Novo,"+
                       "Disciplinas_Edicao, Disciplinas_Delete, Disciplinas_Lista")]
    [ApiController]
    [Route("api/disciplinas")]
    public class DisciplinaEndPoint : ApiController
    {
        private readonly IDisciplinaAppService _disciplinaManager;
        private readonly SigespDbContext _context;
        private readonly IMapper _mapper;

        public DisciplinaEndPoint(IDisciplinaAppService disciplinaManager,
                                    SigespDbContext context,
                                    IMapper mapper)
        {
            _disciplinaManager = disciplinaManager;
            _context = context;
            _mapper = mapper;
        }

        #region Métodos genéricos
        [Authorize(Roles = "Master, Disciplinas_Novo")]
        [Route("novo")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult Novo([FromBody]DisciplinaViewModel disciplinaViewModel)
        {
            var commandSend  = _disciplinaManager.Add(disciplinaViewModel);

            if (commandSend.ErrorMessages != null || !commandSend.ErrorMessages.Any())
                foreach (var error in commandSend.ErrorMessages)
                    AddError(error);

            return CustomResponse(commandSend);
        }

        [Authorize(Roles = "Master, Disciplinas_Edicao")]
        [Route("edicao")]
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult Edicao([FromBody]DisciplinaViewModel disciplinaViewModel)
        {
            var commandSend  = _disciplinaManager.Update(disciplinaViewModel);

            if (commandSend.ErrorMessages != null || !commandSend.ErrorMessages.Any())
                foreach (var error in commandSend.ErrorMessages)
                    AddError(error);

            return CustomResponse(disciplinaViewModel);
        }

        [Authorize(Roles = "Master, Disciplinas_Delete")]
        [Route("delete")]
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult Delete([FromBody]DisciplinaViewModel disciplinaViewModel)
        {
            var commandSend  = _disciplinaManager.Remove((Guid)disciplinaViewModel.Id);
            
            if (commandSend.ErrorMessages != null || !commandSend.ErrorMessages.Any())
                foreach (var error in commandSend.ErrorMessages)
                    AddError(error);

            return CustomResponse(disciplinaViewModel);
        }

        [Authorize(Roles = "Master, Disciplinas_Lista")]
        [Route("lista")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Lista([FromForm] DataTableServerSideRequest request)
        {
            var result = await _context.Disciplinas
                                    .Include(x => x.Professor)
                                    .OrderBy(x => x.IsDeleted)
                                    .GetDatatableResultAsync(request);

            var dataMapped = _mapper.Map<IEnumerable<DisciplinaViewModel>>(result.Data);
            
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