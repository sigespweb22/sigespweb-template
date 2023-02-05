using Microsoft.AspNetCore.Mvc;

namespace Sigesp.WebUI.Controllers
{
    public class TablesController : Controller
    {
        public IActionResult Basic() => View();
        public IActionResult GenerateStyle() => View();
    }
}
