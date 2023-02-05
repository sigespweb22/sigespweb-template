using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sigesp.WebUI.Controllers;
using Microsoft.AspNetCore.Authorization;
using Sigesp.Domain.Enums;

namespace Sigesp.WebUI.EndPoints
{
    [AllowAnonymous]
    [ApiController]
    [Route("api/enums")]
    public class EnumEndPoint : ApiController
    {
        public EnumEndPoint()
        {
        }

        [Route("months-of-year")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetMonthsOfYear()
        {
            var result = new List<string>();
            try
            {
                result = EnumExtensions<MonthOfYearEnum>.GetNames().ToList();
            }
            catch (Exception ex) { return StatusCode(500, ex); }

            if (result.Count() == 0) return StatusCode(404, "Nenhum mês encontrado.");
            return Ok(result);
        }

        [Route("plantoes")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetPlantoes()
        {
            var result = new List<string>();
            try
            {
                result = EnumExtensions<PlantaoNomeEnum>.GetNames().ToList();
            }
            catch (Exception ex) { return StatusCode(500, ex); }

            if (result.Count() == 0) return StatusCode(404, "Nenhum plantão encontrado.");
            return Ok(result);
        }

        [Route("turnos")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetTurnos()
        {
            var result = new List<string>();
            try
            {
                result = EnumExtensions<TurnoEnum>.GetNames().ToList();
            }
            catch (Exception ex) { return StatusCode(500, ex); }

            if (result.Count() == 0) return StatusCode(404, "Nenhum turno encontrado.");
            return Ok(result);
        }
    }
}