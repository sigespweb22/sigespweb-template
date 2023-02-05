using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Sigesp.Infra.Data.Context;
using Sigesp.Application.ViewModels.Cards;
using System;
using System.Threading.Tasks;
using Sigesp.Infra.Data.Extensions;
using Sigesp.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Sigesp.WebUI.Controllers
{
    [AllowAnonymous]
    public class FormularioLeituraController : BaseController
    {
        private readonly SigespDbContext _context;
        private readonly ITenantRepository _tenantRepository;
        
        public FormularioLeituraController(SigespDbContext context,
                                           ITenantRepository tenantRepository)
        {
            _context = context;
            _tenantRepository = tenantRepository;
        }

        public async Task<IActionResult> DicaEscritaListaAsync()
        {
            #region Tenant resolve
            Guid tenantId;
            try
            {
                tenantId = (Guid) StringHelpers.ExtractTenantId(await _tenantRepository.GetTenantIdAsync());
            }
            catch (Exception ex) { return StatusCode(500, ex.Message); }

            if (tenantId == Guid.Empty) return StatusCode(404, "Unidade Prisional não encontrada.");
            #endregion
            
            #region Get Grupos dicas
            int dicasGrupos;
            try
            {
                dicasGrupos = await _context
                                        .FormularioLeituraDicasEscrita
                                        .CountAsync(x => x.TenantId == tenantId);
            }
            catch { throw; }
            #endregion

            #region Get Grupos dicas
            int dicas;
            try
            {
                dicas = await _context
                                    .FormularioLeituraDicasEscritaDicas
                                    .Include(x => x.FormularioLeituraDicaEscrita)
                                    .CountAsync(x => x.FormularioLeituraDicaEscrita.TenantId == tenantId);
            }
            catch { throw; }
            #endregion

            #region Map
            var flDECVM = new FormularioLeituraDicaEscritaCardViewModel();
            try
            {
                flDECVM.TotalGrupos = dicasGrupos;
                flDECVM.TotalDicas = dicas;
            }
            catch { throw; }
            #endregion
            
            return View(flDECVM);
        }

        public IActionResult Novo()
        {
            return View();
        }

        public IActionResult Edicao()
        {
            return View();
        }

        public IActionResult Delete()
        {
            return View();
        }
    }
}