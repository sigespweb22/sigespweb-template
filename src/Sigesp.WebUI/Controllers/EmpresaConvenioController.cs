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
using Sigesp.Domain.Interfaces;
using Sigesp.Application.ViewModels.Selects;
using Sigesp.Application.ViewModels.Cards;
using Sigesp.Domain.Enums;
using Microsoft.AspNetCore.Authorization;
using Sigesp.WebUI.Helpers.DataTable;

namespace Sigesp.WebUI.Controllers
{
    [Authorize(Roles = "Empresas-Convenios_Todos, Master")]
    public class EmpresaConvenioController : Controller
    {
        private readonly IEmpresaRepository _empresaRepository;
        private readonly IEmpresaConvenioAppService _empresaConvenioManager;
        private readonly IMapper _mapper;
        private readonly SigespDbContext _context;
        
        public EmpresaConvenioController(IEmpresaRepository empresaRepository, 
                                        IEmpresaConvenioAppService empresaConvenioManager,
                                        IMapper mapper,
                                        SigespDbContext context)
        {
            _empresaRepository = empresaRepository;
            _empresaConvenioManager = empresaConvenioManager;
            _mapper = mapper;
            _context = context;
        }

        public IActionResult Todos()
        {
            try
            {
                var empresasConvenios = _empresaConvenioManager.GetAll();

                //Dados cards
                var empresaConvenioCardViewModel = new EmpresaConvenioCardViewModel()
                {
                    Ativos = empresasConvenios.Where(x => x.Situacao == ConvenioSituacaoEnum.ATIVO.ToString()).Count(),
                    EmAnalise = empresasConvenios.Where(x => x.Situacao == ConvenioSituacaoEnum.EM_ANALISE.ToString()).Count(),
                    RenovacaoAutomatica = empresasConvenios.Where(x => x.IsRenovacaoAutomatica).Count(),
                    Encerrados = empresasConvenios.Where(x => x.Situacao == ConvenioSituacaoEnum.ENCERRADO.ToString()).Count(),
                    Empresas = _empresaRepository.GetAll().Select(x => x.RazaoSocial).ToList(),
                    Situacoes = EnumExtensions<ConvenioSituacaoEnum>.GetNames().ToList()
                };

                return View(empresaConvenioCardViewModel);
            }
            catch (System.Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public async Task<IActionResult> List([FromForm] DataTableServerSideRequest request)
        {
            try
            {
                var result = await _context.EmpresaConvenios
                                    .Include(x => x.Empresa)
                                    .Include(x => x.Colaboradores)
                                    .OrderBy(x => x.Nome)
                                    .GetDatatableResultAsync(request);
            
                var dataMapped = _mapper.Map<IEnumerable<EmpresaConvenioViewModel>>(result.Data);
                
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
            catch (System.Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }
    }
}