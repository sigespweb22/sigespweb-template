using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sigesp.Domain.Interfaces;
using Sigesp.Application.ViewModels.Cards;
using Sigesp.Domain.Enums;
using Sigesp.Application.Interfaces;
using System;
using Microsoft.AspNetCore.Authorization;
using Sigesp.Application.ViewModels.Selects;
using System.Collections.Generic;
using AutoMapper;
using Sigesp.Infra.Data.Context;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Sigesp.WebUI.Helpers.DataTable;
using Sigesp.Application.ViewModels.AndamentoPenal;
using Sigesp.Application.ViewModels;
using System.Globalization;

namespace Sigesp.WebUI.Controllers
{
    [Authorize(Roles = "Master, Andamento-Penal_Todos,"+
                        "Andamento-Penal_Novo, Andamento-Penal_Edicao"+
                        "Andamento-Penal_IHM")]
    public class AndamentoPenalController : Controller
    {
        public readonly IDetentoAppService _detentoManager;
        public readonly IAndamentoPenalAppService _andamentoPenalManager;
        private readonly IMapper _mapper;
        private readonly SigespDbContext _context;

        public AndamentoPenalController(IDetentoAppService detentoManager,
                                        IAndamentoPenalAppService andamentoPenalAppService,
                                        IMapper mapper,
                                        SigespDbContext context)
        {
            _detentoManager = detentoManager;
            _andamentoPenalManager = andamentoPenalAppService;
            _mapper = mapper;
            _context = context;
        }

        [Authorize(Roles = "Andamento-Penal_Todos, Master")]
        public IActionResult Todos()
        {
            try
            {
                var detentos = _detentoManager.GetAll();
                var normal = _andamentoPenalManager.GetTotalByStatus(AndamentoPenalStatusEnum.NORMAL);
                var provisorios = detentos.Where(x => x.Regime == DetentoRegimeEnum.PROVISORIO.ToString()).Count();
                var ctcs = _andamentoPenalManager.GetTotalByStatus(AndamentoPenalStatusEnum.CTC_EM_ANDAMENTO);
                var pads = _andamentoPenalManager.GetTotalByStatus(AndamentoPenalStatusEnum.PAD_EM_ANDAMENTO);
                var sts = _andamentoPenalManager.GetTotalByStatus(AndamentoPenalStatusEnum.SAIDA_TEMPORARIA);
                var regimes = EnumExtensions<DetentoRegimeEnum>.GetNames().ToList();
                var ip = EnumExtensions<InstrumentoPrisaoTipoEnum>.GetNames().ToList();
                var ct = EnumExtensions<CondenacaoTipoEnum>.GetNames().ToList();
                var ef = _andamentoPenalManager.GetTotalByStatus(AndamentoPenalStatusEnum.EVASAO_FUGA);
                var pd = _andamentoPenalManager.GetTotalByStatus(AndamentoPenalStatusEnum.PRISAO_DOMICILIAR);

                //Dados cards
                var andamentoPenalCardViewModel = new AndamentoPenalCardViewModel()
                {
                    Total = _andamentoPenalManager.GetTotal(),
                    Normal = normal,
                    Provisorios = provisorios,
                    CTCs = ctcs,
                    PADs = pads,
                    SaidasTemporarias = sts,
                    Detentos = detentos.Select(x => x.Nome).ToList(),
                    Regimes = regimes,
                    InstrumentosPrisao = ip,
                    CondenacaoTipos = ct,
                    EvasoesFugas = ef,
                    PrisaoDomiciliar = pd
                };
                
                return View(andamentoPenalCardViewModel);

            }
            catch { throw; }
        }

        [Authorize(Roles = "Andamento-Penal_Novo, Master")]
        [HttpPost]
        public IActionResult Novo()
        {
            var detentosDB = _detentoManager
                                .GetAll();
            var detentos = new List<Generic2Select2ViewModel>();
            foreach (var tmp in detentosDB)
            {
                var detento = new Generic2Select2ViewModel
                                {
                                    Id = tmp.Id.ToString(),
                                    Nome = tmp.Nome
                                };

                detentos.Add(detento);
            };

            var andamentoPenalNovoSelect2ViewModel = new AndamentoPenalNovoSelect2ViewModel()
            {
                Detentos = detentos,
                Statuses = EnumExtensions<AndamentoPenalStatusEnum>.GetNames().ToList()
            };

            return View(andamentoPenalNovoSelect2ViewModel);
        }

        [Authorize(Roles = "Andamento-Penal_Edicao, Master")]
        [HttpPost]
        public IActionResult Edicao(string id)
        {
            var andamentoPenalViewModel = _andamentoPenalManager.GetByIdWithInclude(id);

            var andamentoPenalEdicaoViewModel = new AndamentoPenalEdicaoViewModel()
            {
                AndamentoPenalViewModel = andamentoPenalViewModel,
                Statuses = EnumExtensions<AndamentoPenalStatusEnum>.GetNames().ToList()
            };

            return View(andamentoPenalEdicaoViewModel);
        }

        [Authorize(Roles = "Master, Andamento-Penal_IHM")]
        [HttpPost]
        public IActionResult ImprimirHistoricoMemorando(string andamentoPenalIdBtn)
        {
            if (andamentoPenalIdBtn == null)
                return BadRequest("Id Andamento Penal requerido.");

            //Obtenho os dados de andamento penal do detento
            var apForView = _andamentoPenalManager.GetByIdWithInclude(andamentoPenalIdBtn);
            var andamentoPenalViewModel = new AndamentoPenalViewModel();

            if (apForView != null)
            {
                // Set data
                // CultureInfo culture = new CultureInfo("pt-BR");
                // DateTimeFormatInfo dtfi = culture.DateTimeFormat;
                // string mes = culture.TextInfo.ToTitleCase(dtfi.GetMonthName(DateTime.Now.Month)).ToLower();
                
                // andamentoPenalViewModel.OficioData = "Criciúma, " + DateTime.Now.Day.ToString() + " de " + mes + " de " + DateTime.Now.Year + ".";

                andamentoPenalViewModel.Id = apForView.Id;
                andamentoPenalViewModel.DataEventoPrincipal = apForView.DataEventoPrincipal.Substring(8, 2) + "/" + apForView.DataEventoPrincipal.Substring(5, 2) + "/" + apForView.DataEventoPrincipal.Substring(0, 4);
                andamentoPenalViewModel.Status = apForView.Status;
                andamentoPenalViewModel.DetentoNome = apForView.DetentoNome;
                andamentoPenalViewModel.DetentoIpen = apForView.DetentoIpen;
                andamentoPenalViewModel.Historico = apForView.Historico;
            };

            return View(andamentoPenalViewModel);
        }
    }
}