using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sigesp.Domain.Interfaces;
using Sigesp.Application.ViewModels.Cards;
using Sigesp.Domain.Enums;
using Sigesp.Application.Interfaces;
using System;
using Microsoft.AspNetCore.Authorization;
using Sigesp.Application.ViewModels.Selects;
using System.Collections.Generic;
using AutoMapper;
using Sigesp.Infra.Data.Context;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Sigesp.WebUI.Helpers.DataTable;
using Sigesp.Application.ViewModels.Reports;
using Sigesp.Application.ViewModels;
using Sigesp.Application.ViewModels.Oficios;
using Sigesp.Application.ViewModels.Oficios.Juridico;
using System.Globalization;
using Sigesp.WebUI.Extensions;
using Sigesp.Application.ViewModels.Requests;

namespace Sigesp.WebUI.Controllers
{
    //Oficio-Juridico_Todos = Acesso a todos os métodos de ofício
    //Oficio-Juridico_PA = Acesso ao método que retorna o ofício de PROGRESSÃO ABERTO

    [Authorize(Roles = "Master, Oficio-Juridico_Todos, "+
                       "Oficio-Juridico_PA, Oficio-Juridico_SAPlusST, "+
                       "Oficio-Juridico_ET, Oficio-Juridico_LC" +
                       "Oficio-Juridico_PAPlusST")]
    public class OficioJuridico : Controller
    {
        public readonly IAndamentoPenalAppService _apManager;
        public readonly ISequenciaOficioAppService _soManager;

        public OficioJuridico(IAndamentoPenalAppService apManager,
                                        IListaAmarelaAppService listaAmarelaManager,
                                        ISequenciaOficioAppService soManager,
                                        IMapper mapper,
                                        SigespDbContext context)
        {
            _apManager = apManager;
            _soManager = soManager;
        }

        [Authorize(Roles = "Master, Oficio-Juridico_Todos, Oficio-Juridico_PA")]
        [HttpPost]
        public IActionResult ProgressaoAberto(string andamentoPenalIdBtn)
        {
            if (andamentoPenalIdBtn == null)
                return BadRequest("Id Andamento Penal requerido.");

            //Obtenho os dados de andamento penal do detento
            var oficioData = _apManager.GetByIdWithInclude(andamentoPenalIdBtn);
            var oficioProgressaoAbertoViewModel = new ProgressaoAbertoViewModel();

            if (oficioData != null)
            {
                //Obtenho uma sequencia de ofício
                var so = _soManager.CriarNova();

                //Dados oficio
                oficioProgressaoAbertoViewModel.OficioNumero = so.Sequencia.ToString();

                //Set data
                CultureInfo culture = new CultureInfo("pt-BR");
                DateTimeFormatInfo dtfi = culture.DateTimeFormat;
                string mes = culture.TextInfo.ToTitleCase(dtfi.GetMonthName(DateTime.Now.Month)).ToLower();
                
                oficioProgressaoAbertoViewModel.OficioData = "Criciúma, " + DateTime.Now.Day.ToString() + " de " + mes + " de " + DateTime.Now.Year + ".";

                oficioProgressaoAbertoViewModel.DetentoNome = oficioData.DetentoNome;
                oficioProgressaoAbertoViewModel.DetentoIpen = oficioData.DetentoIpen;
                oficioProgressaoAbertoViewModel.Pec = oficioData.Pec;
            };

            return View(oficioProgressaoAbertoViewModel);
        }

        [Authorize(Roles = "Master, Oficio-Juridico_Todos, Oficio-Juridico_PAPlusST")]
        [HttpPost]
        public IActionResult ProgressaoAbertoPlusST(string andamentoPenalIdBtn)
        {
            if (andamentoPenalIdBtn == null)
                return BadRequest("Id Andamento Penal requerido.");

            //Obtenho os dados de andamento penal do detento
            var oficioData = _apManager.GetByIdWithInclude(andamentoPenalIdBtn);
            var oficioProgressaoAbertoViewModel = new ProgressaoAbertoViewModel();

            if (oficioData != null)
            {
                //Obtenho uma sequencia de ofício
                var so = _soManager.CriarNova();

                //Dados oficio
                oficioProgressaoAbertoViewModel.OficioNumero = so.Sequencia.ToString();

                //Set data
                CultureInfo culture = new CultureInfo("pt-BR");
                DateTimeFormatInfo dtfi = culture.DateTimeFormat;
                string mes = culture.TextInfo.ToTitleCase(dtfi.GetMonthName(DateTime.Now.Month)).ToLower();
                
                oficioProgressaoAbertoViewModel.OficioData = "Criciúma, " + DateTime.Now.Day.ToString() + " de " + mes + " de " + DateTime.Now.Year + ".";

                oficioProgressaoAbertoViewModel.DetentoNome = oficioData.DetentoNome;
                oficioProgressaoAbertoViewModel.DetentoIpen = oficioData.DetentoIpen;
                oficioProgressaoAbertoViewModel.Pec = oficioData.Pec;
            };

            return View(oficioProgressaoAbertoViewModel);
        }

        [Authorize(Roles = "Master, Oficio-Juridico_Todos, Oficio-Juridico_SAPlusST")]
        [HttpPost]
        public IActionResult ProgressaoSAPlusST(string andamentoPenalIdBtn)
        {
            if (andamentoPenalIdBtn == null)
                return BadRequest("Id Andamento Penal requerido.");

            //Obtenho os dados de andamento penal do detento
            var oficioData = _apManager.GetByIdWithInclude(andamentoPenalIdBtn);
            var oficioProgressaoAbertoViewModel = new ProgressaoAbertoViewModel();

            if (oficioData != null)
            {
                //Obtenho uma sequencia de ofício
                var so = _soManager.CriarNova();

                //Dados oficio
                oficioProgressaoAbertoViewModel.OficioNumero = so.Sequencia.ToString();

                //Set data
                CultureInfo culture = new CultureInfo("pt-BR");
                DateTimeFormatInfo dtfi = culture.DateTimeFormat;
                string mes = culture.TextInfo.ToTitleCase(dtfi.GetMonthName(DateTime.Now.Month)).ToLower();
                
                oficioProgressaoAbertoViewModel.OficioData = "Criciúma, " + DateTime.Now.Day.ToString() + " de " + mes + " de " + DateTime.Now.Year + ".";

                oficioProgressaoAbertoViewModel.DetentoNome = oficioData.DetentoNome;
                oficioProgressaoAbertoViewModel.DetentoIpen = oficioData.DetentoIpen;
                oficioProgressaoAbertoViewModel.Pec = oficioData.Pec;
            };

            return View(oficioProgressaoAbertoViewModel);
        }

        [Authorize(Roles = "Master, Oficio-Juridico_Todos, Oficio-Juridico_ST")]
        [HttpPost]
        public IActionResult SaidaTemporaria(string andamentoPenalIdBtn)
        {
            if (andamentoPenalIdBtn == null)
                return BadRequest("Id Andamento Penal requerido.");

            //Obtenho os dados de andamento penal do detento
            var oficioData = _apManager.GetByIdWithInclude(andamentoPenalIdBtn);
            var oficioProgressaoAbertoViewModel = new ProgressaoAbertoViewModel();

            if (oficioData != null)
            {
                //Obtenho uma sequencia de ofício
                var so = _soManager.CriarNova();

                //Dados oficio
                oficioProgressaoAbertoViewModel.OficioNumero = so.Sequencia.ToString();

                //Set data
                CultureInfo culture = new CultureInfo("pt-BR");
                DateTimeFormatInfo dtfi = culture.DateTimeFormat;
                string mes = culture.TextInfo.ToTitleCase(dtfi.GetMonthName(DateTime.Now.Month)).ToLower();
                
                oficioProgressaoAbertoViewModel.OficioData = "Criciúma, " + DateTime.Now.Day.ToString() + " de " + mes + " de " + DateTime.Now.Year + ".";

                oficioProgressaoAbertoViewModel.DetentoNome = oficioData.DetentoNome;
                oficioProgressaoAbertoViewModel.DetentoIpen = oficioData.DetentoIpen;
                oficioProgressaoAbertoViewModel.Pec = oficioData.Pec;
            };

            return View(oficioProgressaoAbertoViewModel);
        }

        [Authorize(Roles = "Master, Oficio-Juridico_Todos, Oficio-Juridico_LC")]
        [HttpPost]
        public IActionResult LivramentoCondicional(string andamentoPenalIdBtn)
        {
            if (andamentoPenalIdBtn == null)
                return BadRequest("Id Andamento Penal requerido.");

            //Obtenho os dados de andamento penal do detento
            var oficioData = _apManager.GetByIdWithInclude(andamentoPenalIdBtn);
            var oficioProgressaoAbertoViewModel = new ProgressaoAbertoViewModel();

            if (oficioData != null)
            {
                //Obtenho uma sequencia de ofício
                var so = _soManager.CriarNova();

                //Dados oficio
                oficioProgressaoAbertoViewModel.OficioNumero = so.Sequencia.ToString();

                //Set data
                CultureInfo culture = new CultureInfo("pt-BR");
                DateTimeFormatInfo dtfi = culture.DateTimeFormat;
                string mes = culture.TextInfo.ToTitleCase(dtfi.GetMonthName(DateTime.Now.Month)).ToLower();
                
                oficioProgressaoAbertoViewModel.OficioData = "Criciúma, " + DateTime.Now.Day.ToString() + " de " + mes + " de " + DateTime.Now.Year + ".";

                oficioProgressaoAbertoViewModel.DetentoNome = oficioData.DetentoNome;
                oficioProgressaoAbertoViewModel.DetentoIpen = oficioData.DetentoIpen;
                oficioProgressaoAbertoViewModel.Pec = oficioData.Pec;
            };

            return View(oficioProgressaoAbertoViewModel);
        }

        [Authorize(Roles = "Master, Oficio-Juridico_Todos, Oficio-Juridico_ET")]
        [HttpPost]
        public IActionResult InfoEnderecoTelefone(string andamentoPenalIdBtn)
        {
            if (andamentoPenalIdBtn == null)
                return BadRequest("Id Andamento Penal requerido.");

            //Obtenho os dados de andamento penal do detento
            var oficioData = _apManager.GetByIdWithInclude(andamentoPenalIdBtn);
            var oficioETViewModel = new EnderecoTelefoneViewModel();

            if (oficioData != null)
            {
                if (oficioData.Telefone.IsNullOrEmpty() ||
                    oficioData.EnderecoCompleto.IsNullOrEmpty())
                    return BadRequest("Detento não possui endereço/telefone cadastrado no andamento penal para geração do ofício de endereço.");  

                //Obtenho uma sequencia de ofício
                var so = _soManager.CriarNova();

                //Dados oficio
                oficioETViewModel.OficioNumero = so.Sequencia.ToString();

                //Set data
                CultureInfo culture = new CultureInfo("pt-BR");
                DateTimeFormatInfo dtfi = culture.DateTimeFormat;
                string mes = culture.TextInfo.ToTitleCase(dtfi.GetMonthName(DateTime.Now.Month)).ToLower();
                
                oficioETViewModel.OficioData = "Criciúma, " + DateTime.Now.Day.ToString() + " de " + mes + " de " + DateTime.Now.Year + ".";

                oficioETViewModel.DetentoNome = oficioData.DetentoNome;
                oficioETViewModel.DetentoIpen = oficioData.DetentoIpen;
                oficioETViewModel.Pec = oficioData.Pec;
                oficioETViewModel.EnderecoCompleto = oficioData.EnderecoCompleto;
                oficioETViewModel.Telefone = oficioData.Telefone;
            };

            return View(oficioETViewModel);
        }

        [Authorize(Roles = "Master, Oficio-Juridico_Todos, Oficio-Juridico_PAD-Parecer")]
        [HttpPost]
        public IActionResult PADParecer(string inputAndamentoPenalId,
                                        string inputPortariaNumero, 
                                        string inputIsProcedente)
        {
            if (inputPortariaNumero.IsNullOrEmpty())
                return BadRequest("Portaria número requerido");

            if (inputIsProcedente.IsNullOrEmpty())
                return BadRequest("É procedente requerido");

            if (inputAndamentoPenalId.IsNullOrEmpty())
                return BadRequest("Id andamento penal requerido");

            var oficioData = _apManager.GetByIdWithInclude(inputAndamentoPenalId);
            if (oficioData == null)
                return BadRequest("Nenhum registro encontrado no andamento penal com o ID informado. Tente novamente mais tarde, caso o problema persista informe a equipe técnica do sistema");
        
            var padParecerViewModel = new PADParecerViewModel();

            //Obtenho uma sequencia de ofício
            var so = _soManager.CriarNova();

            //Dados oficio
            //Set data
            CultureInfo culture = new CultureInfo("pt-BR");
            DateTimeFormatInfo dtfi = culture.DateTimeFormat;
            string mes = culture.TextInfo.ToTitleCase(dtfi.GetMonthName(DateTime.Now.Month)).ToLower();
            
            padParecerViewModel.OficioData = "Criciúma, " + DateTime.Now.Day.ToString() + " de " + mes + " de " + DateTime.Now.Year + ".";
            padParecerViewModel.DetentoNome = oficioData.DetentoNome;
            padParecerViewModel.DetentoIpen = oficioData.DetentoIpen;
            padParecerViewModel.Pec = oficioData.Pec;
            padParecerViewModel.OficioNumero = so.Sequencia.ToString();
            padParecerViewModel.PortariaNumero = inputPortariaNumero;
            padParecerViewModel.IsProcedente = inputIsProcedente == "SIM" ? true : false;

            return View(padParecerViewModel);
        }
    }
}