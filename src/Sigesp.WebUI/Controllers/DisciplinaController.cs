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
using System.Threading.Tasks;

namespace Sigesp.WebUI.Controllers
{
    [Authorize(Roles = "Master, Disciplinas_Todos, Disciplinas_Novo,"+
                        "Disciplinas_Edicao, Disciplinas_Delete")]
    public class DisciplinaController : BaseController
    {
        private readonly IDisciplinaAppService _disciplinaManager;
        private readonly IProfessorAppService _professorManager;
        
        public DisciplinaController(IDisciplinaAppService disciplinaManager,
                                    IProfessorAppService professorManager)
                                    
        {
            _disciplinaManager = disciplinaManager;
            _professorManager = professorManager;
        }

        [Authorize(Roles = "Master, Disciplinas_Todos")]
        public async Task<IActionResult> TodosAsync()
        {
            var total = _disciplinaManager.GetTotalWithIgnoreQueryFilter();
            var ativas = _disciplinaManager.GetTotalAtivos();
            var inativas = _disciplinaManager.GetTotalInativos();
            var professores = await _professorManager.GetAllNomesAsync();

            //Dados cards
            var disciplinaCardViewModel = new DisciplinaCardViewModel()
            {
                Total = total,
                Ativas = ativas,
                Inativas = inativas,
                Fases = EnumExtensions<FaseEnum>.GetNames().ToList(),
                Cursos = EnumExtensions<CursoEnum>.GetNames().ToList(),
                Professores = professores.ToList()
            };

            return View(disciplinaCardViewModel);
        }

        [Authorize(Roles = "Master, Disciplinas_Novo")]
        public IActionResult Novo()
        {
            return View();
        }

        [Authorize(Roles = "Master, Disciplinas_Edicao")]
        public IActionResult Edicao()
        {
            return View();
        }

        [Authorize(Roles = "Master, Disciplinas_Delete")]
        public IActionResult Delete()
        {
            return View();
        }
    }
}