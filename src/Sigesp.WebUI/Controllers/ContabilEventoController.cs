using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sigesp.Application.Interfaces;
using Sigesp.Application.ViewModels.Cards;

namespace Sigesp.WebUI.Controllers
{
    [Authorize(Roles = "Contabil-Eventos_Todos, Master")]
    public class ContabilEventoController : Controller
    {
        private readonly IContabilEventoAppService _contabilEventoManager;

        public ContabilEventoController(IContabilEventoAppService contabilEventoManager)
        {
            _contabilEventoManager = contabilEventoManager;
        }

        public IActionResult Todos()
        {
            try
            {
                var contabilEventoCardViewModel = new ContabilEventoCardViewModel
                {
                    Eventos = _contabilEventoManager.GetTotalActiveRecords()
                };
                
                return View(contabilEventoCardViewModel);
            }
            catch { throw; }
        }
    }
}