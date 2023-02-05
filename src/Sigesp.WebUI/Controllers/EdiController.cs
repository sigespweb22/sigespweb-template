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
    [Authorize(Roles = "Edis_Todos, Edi-Detentos-XLS_Todos, Master")]
    public class EdiController : Controller
    {
        private readonly IEdiRepository _ediRepository;
        private readonly IEdiLogRepository _ediLogRepository;
        private readonly IMapper _mapper;
        private readonly SigespDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IEdiAppService _ediAppService;

        public EdiController(IEdiRepository ediRepository,
                             IEdiLogRepository ediLogRepository,
                             IMapper mapper,
                             SigespDbContext context,
                             IWebHostEnvironment webHostEnvironment,
                             IEdiAppService ediAppService)
                                    
        {
            _ediRepository = ediRepository;
            _ediLogRepository = ediLogRepository;
            _mapper = mapper;
            _context = context;
            _webHostEnvironment = webHostEnvironment;
            _ediAppService = ediAppService;
        }

        [Authorize(Roles = "Edis_Todos, Edi-Detentos-XLS_Todos, Master")]
        public IActionResult Todos() => View();
        public IActionResult Novo() => View();
        public IActionResult DetentoAtualizacaoRegime() => View();
        public IActionResult ColaboradorImportPonto() => View();
        public IActionResult DetentoUpdateST() => View();
        public IActionResult APEnderecoTelefoneST() => View();
        public IActionResult Livros() => View();
        public IActionResult DetentoDiversos() => View();
        public IActionResult Logs(string btnLog)
        {
            ViewData["Id"] = btnLog;
            var edi = new Edi();
            IEnumerable<EdiLogViewModel> ediLogs;
            var ediLogCardViewModel = new EdiLogCardViewModel();

            if (btnLog != null)
            {
                edi = _ediRepository.GetById(Guid.Parse(btnLog));
                ediLogs = _mapper.Map<IEnumerable<EdiLogViewModel>>(_ediLogRepository.GetAllByEdiId(edi.Id).ToList());

                ediLogCardViewModel.Intervencoes = ediLogs.Count();
                ediLogCardViewModel.Mudancas = ediLogs.Where(x => x.Tipo == EdiLogTipoEnum.MUDANCA.ToString()).Count();
                ediLogCardViewModel.Ativacoes = ediLogs.Where(x => x.Tipo == EdiLogTipoEnum.ATIVACAO.ToString()).Count();
                ediLogCardViewModel.Desativacoes = ediLogs.Where(x => x.Tipo == EdiLogTipoEnum.DESATIVACAO.ToString()).Count();
                ediLogCardViewModel.Exclusoes = ediLogs.Where(x => x.Tipo == EdiLogTipoEnum.EXCLUSAO.ToString()).Count();
                ediLogCardViewModel.Inclusoes = ediLogs.Where(x => x.Tipo == EdiLogTipoEnum.INCLUSAO.ToString()).Count();
            }

            ViewData["NomeArquivo"] = edi.ArquivoNome;
            return View(ediLogCardViewModel);
        }
    }
}