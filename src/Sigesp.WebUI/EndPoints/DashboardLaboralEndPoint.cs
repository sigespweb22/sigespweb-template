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
using Sigesp.WebUI.Helpers.DataTable;

namespace Sigesp.WebUI.EndPoints
{
    [Route("api/dashboard-laboral")]
    [ApiController]
    public class DashboardLaboralEndPoint : ApiController
    {
        private readonly IColaboradorAppService _colaboradorManager;

        public DashboardLaboralEndPoint(IColaboradorAppService colaboradorManager)
        {
            _colaboradorManager = colaboradorManager;
        }

        [HttpPost]
        [Route("info-colaboradores-por-convenio")]
        //Padrão de nomes de rotas =>
        //Quando tratar-se de info gráfico a rota começa com info
        //Quando tratar-se de indicador gráfico a rota começa com indi
        public async Task<IActionResult> PostInfoColaboradoresPorConvenio()
        {
            var result = await _colaboradorManager
                                .GetAllColaboradorPorConvenioSituacaoAdmitido();

            return Ok(new {
                data = result,
                Success = true
            });
        }
    }
}