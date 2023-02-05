using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Sigesp.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using System.Data;
using Sigesp.Infra.Data.Context;
using System.Collections.Generic;
using Sigesp.Application.ViewModels.Cards;
using System;
using System.Threading.Tasks;
using Sigesp.Domain.Models;
using Sigesp.Infra.Data.Extensions;
using Sigesp.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Sigesp.Domain.Enums;
using Sigesp.Application.ViewModels.Reports;
using Sigesp.Application.ViewModels;

namespace Sigesp.WebUI.Controllers
{
    [Authorize(Roles = "Master, "+
                       "Meu-Reforco_Relatorios")]
    public class MeuReforcoController : BaseController
    {
        private readonly SigespDbContext _context;
        private readonly ITenantRepository _tenantRepository;
        
        public MeuReforcoController(SigespDbContext context,
                                    ITenantRepository tenantRepository)
        {
            _context = context;
            _tenantRepository = tenantRepository;
        }

        [Authorize(Roles = "Master, Meu-Reforco_Relatorios")]
        public IActionResult Relatorios()
        {
            return View();
        }

        [Authorize(Roles = "Master, Meu-Reforco_Relatorios")]
        [HttpPost]
        public async Task<IActionResult> RelatorioReforcosAgendados(MeuReforcoFilterRelatorioDataReforcoViewModel  mRFrDrVM)
        {
            MeuReforcoRelatorioDataReforcoViewModel meuReforcoRelatorioDataReforcoViewModel = new MeuReforcoRelatorioDataReforcoViewModel();
            meuReforcoRelatorioDataReforcoViewModel.Reforcos = new List<ServidorEstadoReforco>();

            var dataInicio = DateTime.Now;
            var dataFim = DateTime.Now;
            try
            {
                if (!string.IsNullOrEmpty(mRFrDrVM.DataReforcoInicio))
                {
                    dataInicio = Convert.ToDateTime(mRFrDrVM.DataReforcoInicio);
                }

                if (!string.IsNullOrEmpty(mRFrDrVM.DataReforcoFim))
                {
                    dataFim = Convert.ToDateTime(mRFrDrVM.DataReforcoFim);
                }
            }
            catch { throw; }

            meuReforcoRelatorioDataReforcoViewModel.Reforcos = await _context
                                                                        .ServidoresEstadoReforcos
                                                                        .Include(x => x.ServidorEstado)
                                                                        .ThenInclude(x => x.ApplicationUser)
                                                                        .ThenInclude(x => x.ContaUsuario)
                                                                        .Where(x => x.DataPrevistaInicio.Date >= dataInicio.Date &&
                                                                               x.DataPrevistaInicio.Date <= dataFim.Date)
                                                                        .OrderBy(x => x.DataPrevistaInicio)
                                                                        .ToListAsync();

            meuReforcoRelatorioDataReforcoViewModel.TotalRegistros = meuReforcoRelatorioDataReforcoViewModel.Reforcos.Count();
            meuReforcoRelatorioDataReforcoViewModel.DataReforcoPeriodo = mRFrDrVM.DataReforcoInicio != null ?
                                                                         mRFrDrVM.DataReforcoInicio + " a " + mRFrDrVM.DataReforcoFim
                                                                        : "Todo";

            return View(meuReforcoRelatorioDataReforcoViewModel);
        }
    }
}