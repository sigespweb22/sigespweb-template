using Microsoft.AspNetCore.Mvc;

namespace Sigesp.WebUI.Controllers
{
    public class DocsController : Controller
    {
        public IActionResult Buildnotes() => View();
        public IActionResult CommunitySupport() => View();
        public IActionResult FlavorsEditions() => View();
        public IActionResult General() => View();
        public IActionResult Licensing() => View();
    }
}
