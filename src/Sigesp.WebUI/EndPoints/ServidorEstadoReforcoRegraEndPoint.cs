using System;
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
using Sigesp.Domain.Models.DataTable;
using Sigesp.Domain.Models;
using Sigesp.Domain.Enums;

namespace Sigesp.WebUI.EndPoints
{
    [ApiController]
    [Route("api/servidores-estado-reforcos-regras")]
    public class ServidorEstadoReforcoRegraEndPoint : ApiController
    {
        private readonly SigespDbContext _context;
        private readonly IMapper _mapper;
        private readonly IServidorEstadoReforcoRegraAppService _serrManager;

        public ServidorEstadoReforcoRegraEndPoint(SigespDbContext context,
                                                  IMapper mapper,
                                                  IServidorEstadoReforcoRegraAppService serrManager)
        {
            _context = context;
            _mapper = mapper;
            _serrManager = serrManager;
        }

        [Authorize(Roles = "Master, Servidor-Estado-Reforco-Regra_Create ")]
        [Route("create")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> CreateAsync([FromBody] ServidorEstadoReforcoRegraViewModel
                                                                servidorEstadoReforcoRegraViewModel)
        {
            int result = 0;
            try
            {
                result = await _serrManager.CreateAsync(servidorEstadoReforcoRegraViewModel);
            }
            catch (Exception ex) { return StatusCode(400, ex.Message); }
            return StatusCode(201, result);
        }

        [Authorize(Roles = "Master, Servidor-Estado-Reforco-Regra_Edit")]
        [Route("edit")]
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateAsync([FromBody] ServidorEstadoReforcoRegraViewModel
                                                                servidorEstadoReforcoRegraViewModel)
        {
            int result = 0;
            try
            {
                result = await _serrManager.UpdateAsync(servidorEstadoReforcoRegraViewModel);
            }
            catch (Exception ex) { return StatusCode(400, ex.Message); }
            return StatusCode(200, result);
        }

        [Authorize(Roles = "Master, Servidor-Estado-Reforco-Regra_Delete")]
        [Route("delete")]
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteAsync([FromBody] ServidorEstadoReforcoRegraViewModel
                                                                servidorEstadoReforcoRegraViewModel)
        {
            #region Required validations
            if (servidorEstadoReforcoRegraViewModel.Id == Guid.Empty)
            {
                AddError("Id requerido.");
                return CustomResponse();
            }
            #endregion
            
            int commandSend = 0;
            try
            {
                commandSend = await _serrManager.DeleteAsync((Guid) servidorEstadoReforcoRegraViewModel.Id);
            }
            catch (Exception ex) {
                AddError(ex.Message);
                return CustomResponse(); 
            }

            return CustomResponse(commandSend);
        }

        [Authorize(Roles = "Master, Servidor-Estado-Reforco-Regra_List-One")]
        [Route("list-one-by-month/{month}")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ListOneMonthAsync([FromRoute] string month)
        {
            #region Required validations
            if (string.IsNullOrEmpty(month))
                return StatusCode(400, "Mês requerido.");
            #endregion

            #region Month resolve
            var monthToRule = Enum.Parse<MonthOfYearEnum>(month);
            #endregion
            
            #region Get data
            var result = new ServidorEstadoReforcoRegra();
            try
            {
                result = await _context
                                    .ServidorEstadoReforcoRegras
                                    .FirstOrDefaultAsync(x => x.MesRegra == monthToRule);
            }
            catch (Exception ex) { return StatusCode(400, ex.Message); }
            if (result == null) return StatusCode(404, "Nenhuma regra encontrada.");
            #endregion

            #region Map
            var resultMap = new ServidorEstadoReforcoRegraViewModel();
            try
            {
                resultMap = _mapper.Map<ServidorEstadoReforcoRegraViewModel>(result);
            }
            catch (Exception ex) { return StatusCode(400, ex.Message); }
            #endregion

            return Ok(resultMap);
        }

        [Authorize(Roles = "Master, Servidor-Estado-Reforco-Regra_List")]
        [Route("list")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ListAsync([FromForm] DataTableServerSideRequest request)
        {
            var result = new DataTableServerSideResult<ServidorEstadoReforcoRegraViewModel>();
            
            try
            {
                result = await _serrManager
                                    .GetWithDataTableResultAsync(request);   
            }
            catch (Exception ex) { return StatusCode(500, ex.Message); }
            return Ok(result);
        }
    }
}