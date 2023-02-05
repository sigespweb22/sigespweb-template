using System.Runtime.InteropServices;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
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
using Sigesp.Infra.Data.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Sigesp.WebUI.Controllers
{
    [Authorize(Roles = "Master, Professores_Todos, Professores_Novo, Professores_Edicao, Professores_Delete")]
    public class ProfessorController : BaseController
    {
        private readonly IProfessorAppService _professorManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public ProfessorController(IProfessorAppService professorManager,
                                   UserManager<ApplicationUser> userManager)
                                    
        {
            _professorManager = professorManager;
            _userManager = userManager;
        }

        [Authorize(Roles = "Master, Professores_Todos")]
        public IActionResult Todos()
        {
            //Dados cards
            var professorCardViewModel = new ProfessorCardViewModel();
            try
            {
                professorCardViewModel.Galerias = EnumExtensions<GaleriaEnum>.GetNames().ToList();
            }
            catch { throw; }

            return View(professorCardViewModel);
        }

        [Authorize(Roles = "Master, Professores_Novo")]
        public IActionResult Novo()
        {
            return View();
        }

        [Authorize(Roles = "Master, Professores_Edicao")]
        public IActionResult Edicao()
        {
            return View();
        }

        [Authorize(Roles = "Master, Professores_Delete")]
        public IActionResult Delete()
        {
            return View();
        }
    }
}