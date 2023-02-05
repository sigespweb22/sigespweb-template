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

namespace Sigesp.WebUI.Controllers
{
    [Authorize(Roles = "Master, Alunos_Todos, Alunos_Novo, Alunos_Edicao,"+
                        "Alunos_Delete")]
    public class AlunoController : BaseController
    {
        private readonly IDetentoAppService _detentoManager;
        
        public AlunoController(IDetentoAppService detentoManager)
        {
            _detentoManager = detentoManager;
        }

        [Authorize(Roles = "Master, Alunos_Todos")]
        public IActionResult Todos()
        {
            var detentos = _detentoManager
                                .GetAll()
                                .Select(x => x.Nome)
                                .ToList();          
            
            //Dados cards
            var alunoCardViewModel = new AlunoCardViewModel()
            {
                Ativos = 450,
                Inativos = 100,
                Leitores = 200,
                Ejas = 80,
                Enems = 140,
                Enccejas = 200,
                Dpus = 200,
                ProjetosEspeciais = 10,
                Escolaridades = EnumExtensions<EscolaridadeEnum>.GetNames().ToList(),
                AtividadesEducacionais = EnumExtensions<AtividadeEducacionalTipoEnum>.GetNames().ToList(),
                Detentos = detentos
            };

            return View(alunoCardViewModel);
        }

        [Authorize(Roles = "Master, Alunos_Novo")]
        public IActionResult Novo()
        {
            return View();
        }

        [Authorize(Roles = "Master, Alunos_Edicao")]
        public IActionResult Edicao()
        {
            return View();
        }

        [Authorize(Roles = "Master, Alunos_Delete")]
        public IActionResult Delete()
        {
            return View();
        }
    }
}