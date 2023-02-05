using System.Security.Cryptography;
using Microsoft.AspNetCore.Mvc;
using Sigesp.Application.ViewModels;

namespace Sigesp.WebUI.Controllers
{
    public class DatatablesController : Controller
    {
        public IActionResult Alteditor()
        {
            return View();
        } 
        public IActionResult Autofill() => View();
        public IActionResult Basic() => View();
        public IActionResult Buttons() => View();
        public IActionResult Colreorder() => View();
        public IActionResult Columnfilter() => View();
        public IActionResult Export() => View();
        public IActionResult Fixedcolumns() => View();
        public IActionResult Fixedheader() => View();
        public IActionResult Keytable() => View();
        public IActionResult Responsive() => View();
        public IActionResult ResponsiveAlt() => View();
        public IActionResult Rowgroup() => View();
        public IActionResult Rowreorder() => View();
        public IActionResult Scroller() => View();
        public IActionResult Select() => View();
    }
}
