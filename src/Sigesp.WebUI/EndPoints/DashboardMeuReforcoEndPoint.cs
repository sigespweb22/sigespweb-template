using System.Reflection.Emit;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sigesp.Application.ViewModels;
using Sigesp.WebUI.Controllers;
using Microsoft.AspNetCore.Authorization;
using AutoMapper;
using Sigesp.Infra.Data.Context;
using Sigesp.WebUI.Helpers.DataTable;
using Sigesp.WebUI.Helpers;
using Sigesp.Domain.Interfaces;
using Sigesp.Domain.Models;
using System;
using System.Security.Claims;
using Sigesp.Domain.Enums;

namespace Sigesp.WebUI.EndPoints
{
    [Authorize(Roles = "Master, Dashboard_Meu-Reforco")]
    [ApiController]
    [Route("api/dashboard-meu-reforco")]
    public class DashboardMeuReforcoEndPoint : ApiController
    {
        private readonly SigespDbContext _context;
        private readonly IMapper _mapper;

        public DashboardMeuReforcoEndPoint(SigespDbContext context,
                                      IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [Authorize(Roles = "Master, Dashboard_Meu-Reforco")]
        [Route("vagas-versus-marcacoes")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> VagasVersusMarcacoesAsync()
        {
            #region Get regra
            int monthToMarkupInt = DateTime.Now.AddMonths(1).Month;
            String monthToMarkupString = Enum.GetName(typeof(MonthOfYearEnum), monthToMarkupInt);
            MonthOfYearEnum monthToMarkupEnum = Enum.Parse<MonthOfYearEnum>(monthToMarkupString);
            #endregion

            #region Get total vagas do mês | dia a dia - estes dados comporão as labeis
            IEnumerable<ServidorEstadoReforcoRegra> reforcos = new List<ServidorEstadoReforcoRegra>();
            try
            {
                reforcos = await _context
                                    .ServidorEstadoReforcoRegras
                                    .Include(x => x.VagasPorDia)
                                    .Where(x => x.MesRegra == monthToMarkupEnum)
                                    .ToListAsync();            }
            catch { throw; }
            
            #endregion

            #region Get total reforços já marcados para o mês | dia a dia - estes dados comporão as series
            var reforcosMarcados = await _context
                                            .ServidoresEstadoReforcos
                                            .Where(x => x.MesNumeral == monthToMarkupInt)
                                            .OrderBy(x => x.DataPrevistaInicio.Date.Day)
                                            .ToListAsync();
            #endregion

            #region Map
            string[] labels = new string[1];
            string[] series = new string[2];
            
            foreach (var vagaPorDia in reforcos.Select(x => x.VagasPorDia))
            {
                labels.Append(vagaPorDia.Select(x => x.Dia).ToString());
            }
            #endregion

            var data = new {
                MesReforco = monthToMarkupString,
                Labels = labels,
                Series = series
            };

            return Ok(data);
        }
    }
}