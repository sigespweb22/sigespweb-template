using System.Net.Mime;
using System.Collections;
using System.Xml.Linq;
using System.Runtime.CompilerServices;
using System.Net.NetworkInformation;
using System.Reflection.Metadata;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sigesp.Infra.Data.Context;
using Sigesp.WebUI.Extensions;
using Sigesp.WebUI.Models;
using Sigesp.Domain.Models;
using Sigesp.Application.ViewModels;
using Sigesp.Application.Services;
using Sigesp.Application.Interfaces;
using AutoMapper;
using Sigesp.Domain.Services;
using Sigesp.Application.ViewModels.Cards;
using Sigesp.Domain.Models.Services;
using Newtonsoft.Json;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Sigesp.WebUI.Helpers.DataTable;

namespace Sigesp.WebUI.Controllers
{
    [Authorize(Roles = "Empresas_Todos, Master")]
    public class EmpresaController : Controller
    {
        private readonly IEmpresaAppService _empresaManager;
        private readonly IIBGEServices _ibgeServices;
        private readonly IGeoNamesEstadosServices _geoNamesServices;
        private readonly IMapper _mapper;
        private readonly SigespDbContext _context;

        public EmpresaController(IEmpresaAppService empresaManager, 
                                IIBGEServices ibgeServices,
                                IGeoNamesEstadosServices geoNamesServices,
                                IMapper mapper,
                                SigespDbContext context)
        {
            _empresaManager = empresaManager;
            _ibgeServices = ibgeServices;
            _geoNamesServices = geoNamesServices;
            _mapper = mapper;
            _context = context;
        }

        public IActionResult Todos()
        {
            try
            {
                var empresas = _empresaManager.GetAll();
                var getEstados = _geoNamesServices.GetAllEstados();
                var estados = getEstados.Result.Geonames;

                //Dados cards
                var empresaCardViewModel = new EmpresaCardViewModel()
                {
                    Ativas = empresas.Where(x => x.IsDeleted == false).Count(),
                    Email = empresas.Where(x => x.Email != null).Count(),
                    WhatsApp =  empresas.Where(x => x.WhatsApp.IsNullOrEmpty()).Count(),
                    Inativas = _empresaManager.GetAllSoftDeleted().Count(),
                    Estados = estados.Select(x => x.Name.ToUpper()).ToList()                   
                };

                return View(empresaCardViewModel);
            }
            catch (System.Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public async Task<IActionResult> List([FromForm] DataTableServerSideRequest request)
        {
            var result = await _context.Empresas
                                    .Include(x => x.EmpresaConvenios)
                                    .OrderBy(x => x.NomeFantasia)
                                    .GetDatatableResultAsync(request);
            
            var dataMapped = _mapper.Map<IEnumerable<EmpresaViewModel>>(result.Data);
            
            var data = new {
                data = dataMapped
            };

            return Ok(new {
                data = data,
                Draw = result.Draw,
                RecordsFiltered  = result._iRecordsDisplay,
                RecordsTotal = result._iRecordsTotal,
                Success = true
            });
        }
    }
}