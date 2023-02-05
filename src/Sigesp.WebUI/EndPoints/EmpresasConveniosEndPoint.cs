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

namespace Sigesp.WebUI.EndPoints
{
    [ApiController]
    [Route("api/empresas-convenios")]
    public class EmpresasConveniosEndPoint : ControllerBase
    {
        private readonly IEmpresaConvenioAppService _empresaConvenioManager;

        public EmpresasConveniosEndPoint(IEmpresaConvenioAppService empresaConvenioManager)
        {
            _empresaConvenioManager = empresaConvenioManager;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<EmpresaConvenioViewModel>>> Get()
        {
            var empresasConvenios = await _empresaConvenioManager
                                            .GetAllAsync();

            return Ok(new { success = true, data = empresasConvenios });
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult Post([FromBody]EmpresaConvenioViewModel empresaConvenioViewModel)
        {
            _empresaConvenioManager.Add(empresaConvenioViewModel);

            return Ok(new { data = _empresaConvenioManager });
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult Put([FromBody]EmpresaConvenioViewModel empresaConvenioViewModel)
        {
            _empresaConvenioManager.Update(empresaConvenioViewModel);

            return Ok(new { data = empresaConvenioViewModel });
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult Delete([FromBody]EmpresaConvenioViewModel empresaConvenioViewModel)
        {
            _empresaConvenioManager.Remove((Guid)empresaConvenioViewModel.Id);
            
            return Ok(new { data = empresaConvenioViewModel.Id });
        }
    }
}