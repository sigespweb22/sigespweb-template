using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Sigesp.Application.ViewModels.Dashboards.Educacao;
using System;
using System.Linq;
using Sigesp.Application.Interfaces;
using Sigesp.Domain.Enums;
using Sigesp.Application.ViewModels;
using System.Threading.Tasks;

namespace Sigesp.WebUI.Controllers
{
    [Authorize(Roles = "Master, Mural_Todos")]
    public class MuralController : BaseController
    {
        public MuralController()
        {
        }

        [Authorize(Roles = "Master, Mural_Todos")]
        public IActionResult Todos() => View();
    }
}