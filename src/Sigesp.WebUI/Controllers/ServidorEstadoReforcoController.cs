using Microsoft.AspNetCore.Mvc;
using Sigesp.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Sigesp.Application.ViewModels.Cards;
using System;
using Sigesp.Infra.Data.Context;
using System.Globalization;
using System.Security.Claims;
using Sigesp.Domain.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;

namespace Sigesp.WebUI.Controllers
{
    public class ServidorEstadoReforcoController : BaseController
    {
        private readonly IDetentoAppService _detentoManager;
        private readonly SigespDbContext _context;
        
        public ServidorEstadoReforcoController(IDetentoAppService detentoManager,
                                               SigespDbContext context)
        {
            _detentoManager = detentoManager;
            _context = context;
        }

        [Authorize(Roles = "Master, Servidor-Estado-Reforco_Schedule")]
        public IActionResult Schedule()
        {
            return View();
        }

        [Authorize(Roles = "Master, Servidor-Estado-Reforco_List")]
        public async Task<IActionResult> List()
        {
            #region User resolve
            String userId;
            try
            {
                if (HttpContext.User == null) throw new Exception("Problemas ao obter usuário logado."+"\nSaia e entre no sistema novamente, persistindo o problema informe a equipe técnica.");
                userId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            }
            catch (Exception ex) { return StatusCode(500, ex); }
            if (string.IsNullOrEmpty(userId)) throw new Exception("Usuário não encontrado.");
            #endregion

            #region Variables
            var cardData = new ServidorEstadoReforcoCardViewModel();
            var currentDate = DateTime.Now;
            var secondDate = currentDate.AddMonths(-1);
            var thirdDate = currentDate.AddMonths(-2);

            CultureInfo culture = new CultureInfo("pt-BR");
            DateTimeFormatInfo dtfi = culture.DateTimeFormat;
            #endregion

            #region Servidor Estado resolve
            var se = new ServidorEstado();
            try
            {
                se = await _context
                             .ServidoresEstado
                                .Include(x => x.ServidoresEstadoReforcos)
                                .Include(x => x.Tenant)
                                .Where(x => x.UserId == userId)
                                .FirstOrDefaultAsync();
                                       
            }
            catch (Exception ex) { return StatusCode(404, ex.Message); }
            if (se == null) throw new Exception("Servidor Estado não encontrado com o ID usuário fornecido.");
            #endregion

            #region Last three month
            cardData.CurrentMonthLabel = culture.TextInfo.ToTitleCase(dtfi.GetMonthName(currentDate.Month));
            cardData.SecondMonthLabel = culture.TextInfo.ToTitleCase(dtfi.GetMonthName(secondDate.Month));
            cardData.ThirdMonthLabel = culture.TextInfo.ToTitleCase(dtfi.GetMonthName(thirdDate.Month));
            #endregion

            // get data
            #region Get data
            IEnumerable<ServidorEstadoReforco> reforcosAll = new List<ServidorEstadoReforco>();
            try
            {
                reforcosAll = se.ServidoresEstadoReforcos
                                    .Where(x => x.ServidorEstadoId == se.Id &&
                                            x.MesNumeral == currentDate.Month ||
                                            x.MesNumeral == secondDate.Month ||
                                            x.MesNumeral == thirdDate.Month);
            }
            catch { throw; }

            if (reforcosAll.Count() > 0)
            {
                cardData.CurrentMonthTotal = reforcosAll.Count(x => x.MesNumeral == currentDate.Month);
                cardData.SecondMonthTotal = reforcosAll.Count(x => x.MesNumeral == secondDate.Month);
                cardData.ThirdMonthTotal = reforcosAll.Count(x => x.MesNumeral == thirdDate.Month);
            }
            #endregion

            return View(cardData);
        }

        [Authorize(Roles = "Master, Servidor-Estado-Reforco_Create")]
        public IActionResult Create()
        {
            return View();
        }

        [Authorize(Roles = "Master, Servidor-Estado-Reforco_Edit")]
        public IActionResult Edit()
        {
            return View();
        }

        [Authorize(Roles = "Master, Servidor-Estado-Reforco_Delete")]
        public IActionResult Delete()
        {
            return View();
        }
    }
}