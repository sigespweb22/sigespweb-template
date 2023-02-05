using System.Threading;
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
    [Route("api/empresas")]
    public class EmpresasEndPoint : ControllerBase
    {
        private readonly IEmpresaAppService _empresaManager;

        public EmpresasEndPoint(IEmpresaAppService empresaManager)
        {
            _empresaManager = empresaManager;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<EmpresaViewModel>>> GetAll()
        {
            var empresas = await _empresaManager.GetAllAsync();

            return Ok(new { success = true, data = empresas });
        }
        
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult Post([FromBody]EmpresaViewModel empresaViewModel)
        {
            _empresaManager.Add(empresaViewModel);

            return Ok(new { data = empresaViewModel });
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult Put([FromBody]EmpresaViewModel empresaViewModel)
        {
            _empresaManager.Update(empresaViewModel);

            return Ok(new { data = empresaViewModel });
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult Delete([FromBody]EmpresaViewModel empresaViewModel)
        {
            _empresaManager.Remove((Guid)empresaViewModel.Id);
            
            return Ok(new { data = empresaViewModel.Id });
        }
    }
}