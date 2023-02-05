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
using Sigesp.Application.ViewModels.Requests;
using Sigesp.Domain.Enums;

namespace Sigesp.WebUI.EndPoints
{
    [ApiController]
    [Route("api/galerias")]
    public class GaleriaEndPoint : ApiController
    {

        public GaleriaEndPoint()
        {
        }

        [Route("get-all")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetAll()
        {
            try
            {
                var commandSend = EnumExtensions<GaleriaEnum>.GetNames().ToList();
                return CustomResponse(commandSend);
            }
            catch { throw; }            
        }

        [Route("get-all-celas")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetAllCelas()
        {
            try
            {
                var commandSend = EnumExtensions<CelaEnum>.GetNames().ToList();
                return CustomResponse(commandSend);
            }
            catch { throw; }            
        }
    }
}