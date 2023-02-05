using System.Runtime.InteropServices;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Sigesp.Infra.Data.Context;
using Sigesp.Application.Interfaces;
using AutoMapper;
using Sigesp.Domain.Enums;
using Sigesp.Application.ViewModels.Cards;
using Sigesp.Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;
using Sigesp.Application.ViewModels;
using Microsoft.AspNetCore.Http;
using System.IO;
using ExcelDataReader;
using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.AspNetCore.Hosting;
using System.Data;
using System.Text;
using System;
using Sigesp.Domain.Models;

namespace Sigesp.WebUI.Controllers
{
    [Authorize(Roles = "Master, Leituras_Todos")]
    public class LeituraController : BaseController
    {
        public LeituraController()
        {
        }

        [Authorize(Roles = "Master, Leituras_Todos")]
        public IActionResult Todos()
        {
            //Dados cards
            var leituraCardViewModel = new LeituraCardViewModel()
            {
                Ativas = 5589,
            };

            return View(leituraCardViewModel);
        }
    }
}