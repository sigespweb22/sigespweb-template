using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sigesp.Infra.Data.Context;
using Sigesp.WebUI.Extensions;
using Sigesp.Application.ViewModels;
using Sigesp.Application.Interfaces;
using AutoMapper;
using Sigesp.Domain.Enums;
using Sigesp.Application.ViewModels.Cards;
using Sigesp.Application.ViewModels.Selects;
using Sigesp.Domain.Interfaces;
using Sigesp.Application.ViewModels.Reports;
using static Sigesp.Application.ViewModels.Reports.ColaboradorReportViewModel;
using Microsoft.AspNetCore.Authorization;
using Sigesp.WebUI.Helpers.DataTable;
using Sigesp.WebUI.Helpers;
using Sigesp.Infra.CrossCutting.Identity.Services;
using System.Globalization;
using Sigesp.Domain.Models;

namespace Sigesp.WebUI.Controllers
{
    [Authorize(Roles = "Sequencias-Oficios_Todos, Master")]
    public class SequenciaOficioController : Controller
    {
        private readonly SigespDbContext _context;
        private readonly UserResolverService _userResolverService;
        private readonly ITenantRepository _tenantRepository;
        private readonly IContaUsuarioRepository _contaUsuarioRepository;

        public SequenciaOficioController(SigespDbContext context,
                                         UserResolverService userResolverService,
                                         ITenantRepository tenantRepository,
                                         IContaUsuarioRepository contaUsuarioRepository)
                                    
        {
            _context = context;
            _userResolverService = userResolverService;
            _tenantRepository = tenantRepository;
            _contaUsuarioRepository = contaUsuarioRepository;
        }

        [Authorize(Roles = "Sequencias-Oficios_Todos, Master")]
        public async Task<IActionResult> Todos()
        {
            #region Tenancy resolve
            Guid tenantId;
            try
            {
                tenantId = (Guid) StringHelpers.ExtractTenantId(await _tenantRepository.GetTenantIdAsync());
            }
            catch (Exception ex) { return StatusCode(500, ex); }
            #endregion

            #region Get current user id
            Guid currenteUserId;
            try
            {
                currenteUserId = _userResolverService.GetUserId();
            }
            catch (Exception ex) { return StatusCode(500, ex); }
            #endregion

            #region Get account user and user data
            var accountUser = new ContaUsuario();
            try
            {
                accountUser = _contaUsuarioRepository.GetByUserId(currenteUserId.ToString());
            }
            catch (Exception ex) { return StatusCode(500, ex); }
            #endregion

            #region Get all sequencies to tenancy and user sector
            IEnumerable<SequenciaOficio> sequencias = new List<SequenciaOficio>();
            try
            {
                sequencias = _context
                                .SequenciasOficios
                                .Where(x => x.Tenant.Id == tenantId &&
                                       x.Setor == accountUser.Setor);

                if (sequencias == null)
                    throw new Exception("Problemas ao obter as sequências. Tente novamente mais tarde.");
            }
            catch (Exception ex) { return StatusCode(500, ex); }
            #endregion
            
            #region Get sequencies last
            String ultimaSequencia;
            try
            {
                if (sequencias.Count() <= 0)
                {
                    ultimaSequencia = "0";
                }
                else
                {
                    ultimaSequencia = sequencias.Select(x => x.Sequencia).Max().ToString();
                }
            }
            catch (Exception ex) { return StatusCode(500, ex); }
            #endregion

            #region Get userName that generate sequence last in sector
            String usuarioNomeUltimaSequencia;
            try
            {
                usuarioNomeUltimaSequencia = _context
                                                .SequenciasOficios
                                                .Where(x => x.TenantId == tenantId &&
                                                       x.Setor == accountUser.Setor &&
                                                       x.Sequencia == Convert.ToInt32(ultimaSequencia)).Select(x => x.UsuarioNomeUltimaSequencia).FirstOrDefault();
            }
            catch (Exception ex) { return StatusCode(500, ex); }
            #endregion

            #region Mapper            
            var minhasSequencias = new List<SequenciaOficioViewModel>();
            if (currenteUserId != null)
            {
                var minhasSequenciasDB = _context
                                            .SequenciasOficios
                                            .Include(x => x.Tenant)
                                            .Where(x => x.CreatedBy == (Guid) currenteUserId);
                if (minhasSequenciasDB.Count() > 0)
                {
                    foreach (var item in minhasSequenciasDB)
                    {
                        try
                        {
                            minhasSequencias.Add(
                                new SequenciaOficioViewModel{
                                    SequenciaGerada = item.Sequencia.ToString(),
                                    CreatedAt = item.CreatedAt.ToLocalTime().ToString("dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture),
                                    UserSetor = item.Setor.ToString(),
                                    TenantNomeExibicao = item.Tenant.NomeExibicao
                                }
                            );    
                        }
                        catch (Exception ex) { return StatusCode(500, ex); }
                    }
                }
            }
            #endregion

            #region Check currentUserSetor
            String userSetorMapped;
            try
            {
                if (accountUser.Setor == 0)
                    return NotFound("Você não está vinculado a um setor. Para prosseguir, acesse sua área de usuário em Usuários perfil e informe o seu setor de trabalho.");

                userSetorMapped = accountUser.Setor.ToString();
            }
            catch (Exception ex) { return StatusCode(500, ex); }
            #endregion

            #region Mapper data cards
            var sequenciaOficioViewModel = new SequenciaOficioViewModel();
            try
            {
                sequenciaOficioViewModel.UltimaSequencia = ultimaSequencia;
                sequenciaOficioViewModel.UsuarioNomeUltimaSequencia = usuarioNomeUltimaSequencia;
                sequenciaOficioViewModel.MinhasSequencias = minhasSequencias.OrderByDescending(x => x.CreatedAt).ToList();
                sequenciaOficioViewModel.UserSetor = userSetorMapped;
            }
            catch (Exception ex) { return StatusCode(500, ex); }
            #endregion
            
            return View(sequenciaOficioViewModel); 
        }
    }
}