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
    [Authorize(Roles = "Master, Livros_Todos, Livros_Novo, Livros_Edicao, Livros_Delete")]
    public class LivroController : BaseController
    {
        private readonly ILivroRepository _livroRepository;
        private readonly ILivroAppService _livroManager;
        private readonly ILivroAutorAppService _livroAutorManager;
        private readonly ILivroGeneroAppService _livroGeneroManager;

        public LivroController(ILivroRepository livroRepository,
                                ILivroAppService livroManager,
                                ILivroAutorAppService livroAutorManager,
                                ILivroGeneroAppService livroGeneroManager)
                                    
        {
            _livroRepository = livroRepository;
            _livroManager = livroManager;
            _livroAutorManager = livroAutorManager;
            _livroGeneroManager = livroGeneroManager;
        }

        [Authorize(Roles = "Master, Livros_Todos")]
        public IActionResult Todos()
        {
            var autores = _livroAutorManager.GetAll();
            var generos = _livroGeneroManager.GetAll();

            //Dados cards
            var livroCardViewModel = new LivroCardViewModel()
            {
                Ativos = _livroManager.GetTotalAtivos(),
                Inativos = _livroManager.GetTotalInativos(),
                Disponiveis = _livroManager.GetTotalDisponiveis(),
                Indisponiveis = _livroManager.GetTotalIndisponiveis(),
                Autores = autores.Select(x => x.Nome).ToList(),
                Generos = generos.Select(x => x.Nome).ToList()
            };

            return View(livroCardViewModel);
        }

        [Authorize(Roles = "Master, Livros_Novo")]
        public IActionResult Novo()
        {
            return View();
        }

        [Authorize(Roles = "Master, Livros_Edicao")]
        public IActionResult Edicao()
        {
            return View();
        }

        [Authorize(Roles = "Master, Livros_Delete")]
        public IActionResult Delete()
        {
            return View();
        }
    }
}