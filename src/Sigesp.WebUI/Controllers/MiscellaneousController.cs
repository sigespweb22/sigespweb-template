using Microsoft.AspNetCore.Mvc;

namespace Sigesp.WebUI.Controllers
{
    public class MiscellaneousController : Controller
    {
        public IActionResult Fullcalendar() => View();
        public IActionResult Lightgallery() => View();
        public IActionResult Treeview() => View();
    }
}
