using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sigesp.WebUI.Models;
using Sigesp.Domain.Models;
using Sigesp.Application.ViewModels;
using Sigesp.Application.Interfaces;
using AutoMapper;
using Sigesp.Domain.Enums;
using Sigesp.Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Sigesp.Infra.CrossCutting.Identity.Services;
using System;

namespace Sigesp.WebUI.Controllers
{
    [AllowAnonymous]
    public class ErrorController : ControllerBase
    {
        [Route("/error-local-development")]
        public IActionResult ErrorLocalDevelopment() => Problem(); // Add extra details here

        [Route("/error")]
        public IActionResult Error() => Problem();
    }
}