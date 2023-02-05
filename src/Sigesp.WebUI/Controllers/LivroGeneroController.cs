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
    [Authorize(Roles = "Master, Livros-Generos_Todos,"+
                       "Livros-Generos_Novo, Livros-Generos_Edicao, Livros-Generos_Delete")]
    public class LivroGeneroController : BaseController
    {
        private readonly ILivroGeneroRepository _livroGeneroRepository;
        private readonly ILivroGeneroAppService _livroGeneroManager;

        public LivroGeneroController(ILivroGeneroRepository livroGeneroRepository,
                                ILivroGeneroAppService livroGeneroManager)                                    
        {
            _livroGeneroRepository = livroGeneroRepository;
            _livroGeneroManager = livroGeneroManager;
        }

        [Authorize(Roles = "Master, Livros-Generos_Todos")]
        public IActionResult Todos()
        {
            //Dados cards
            var livroGeneroCardViewModel = new LivroGeneroCardViewModel()
            {
                Ativos = _livroGeneroManager.GetTotalAtivos(),
                Inativos = _livroGeneroManager.GetTotalInativos(),
                Total = _livroGeneroManager.GetTotalWithIgnoreQueryFilter()
            };

            return View(livroGeneroCardViewModel);
        }

        [Authorize(Roles = "Master, Livros-Generos_Novo")]
        public IActionResult Novo()
        {
            return View();
        }

        [Authorize(Roles = "Master, Livros-Generos_Edicao")]
        public IActionResult Edicao()
        {
            return View();
        }

        [Authorize(Roles = "Master, Livros-Generos_Delete")]
        public IActionResult Delete()
        {
            return View();
        }
    }
}