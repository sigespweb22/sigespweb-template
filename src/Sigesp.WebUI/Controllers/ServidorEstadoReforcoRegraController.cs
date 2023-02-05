using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Sigesp.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace Sigesp.WebUI.Controllers
{
    [AllowAnonymous]
    public class ServidorEstadoReforcoRegraController : BaseController
    {
        public ServidorEstadoReforcoRegraController()
        {
        }

        [Authorize(Roles = "Master, Servidor-Estado-Reforco-Regra_List")]
        public IActionResult List()
        {
            return View();
        }

        [Authorize(Roles = "Master, Servidor-Estado-Reforco-Regra_Create")]
        public IActionResult Create()
        {
            return View();
        }

        [Authorize(Roles = "Master, Servidor-Estado-Reforco-Regra_Edit")]
        public IActionResult Edit()
        {
            return View();
        }

        [Authorize(Roles = "Master, Servidor-Estado-Reforco-Regra_Delete")]
        public IActionResult Delete()
        {
            return View();
        }
    }
}