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
    [Authorize(Roles = "Master, Livros-Autores_Todos, Livros-Autores_Novo, Livros-Autores_Edicao, Livros-Autores_Delete")]
    public class LivroAutorController : BaseController
    {
        private readonly ILivroAutorRepository _livroAutorRepository;
        private readonly ILivroAutorAppService _livroAutorManager;

        public LivroAutorController(ILivroAutorRepository livroAutorRepository,
                                ILivroAutorAppService livroAutorManager)
                                    
        {
            _livroAutorRepository = livroAutorRepository;
            _livroAutorManager = livroAutorManager;
        }

        [Authorize(Roles = "Master, Livros-Autores_Todos")]
        public IActionResult Todos()
        {
            //Dados cards
            var livroAutorCardViewModel = new LivroAutorCardViewModel()
            {
                Ativos = _livroAutorManager.GetTotalAtivos(),
                Inativos = _livroAutorManager.GetTotalInativos(),
                Total = _livroAutorManager.GetTotalWithIgnoreQueryFilter()
            };

            return View(livroAutorCardViewModel);
        }

        [Authorize(Roles = "Master, Livros-Autores_Novo")]
        public IActionResult Novo()
        {
            return View();
        }

        [Authorize(Roles = "Master, Livros-Autores_Edicao")]
        public IActionResult Edicao()
        {
            return View();
        }

        [Authorize(Roles = "Master, Livros-Autores_Delete")]
        public IActionResult Delete()
        {
            return View();
        }
    }
}