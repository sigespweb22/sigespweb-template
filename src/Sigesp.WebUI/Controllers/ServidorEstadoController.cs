using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Sigesp.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using System.Data;
using Sigesp.Infra.Data.Context;
using System.Collections.Generic;
using Sigesp.Application.ViewModels.Cards;
using System;
using System.Threading.Tasks;
using Sigesp.Domain.Models;
using Sigesp.Infra.Data.Extensions;
using Sigesp.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Sigesp.Domain.Enums;

namespace Sigesp.WebUI.Controllers
{
    [Authorize(Roles = "Master, "+
                       "Servidor-Estado_Novo"+
                       "Servidor-Estado_Edicao"+
                       "Servidor-Estado_Delete"+
                       "Servidor-Estado_Lista")]
    public class ServidorEstadoController : BaseController
    {
        private readonly SigespDbContext _context;
        private readonly ITenantRepository _tenantRepository;
        
        public ServidorEstadoController(SigespDbContext context,
                                        ITenantRepository tenantRepository)
        {
            _context = context;
            _tenantRepository = tenantRepository;
        }

        [Authorize(Roles = "Master, Servidor-Estado_Novo")]
        public IActionResult Novo()
        {
            return View();
        }

        [Authorize(Roles = "Master, Servidor-Estado_Edicao")]
        public IActionResult Editar()
        {
            return View();
        }

        [Authorize(Roles = "Master, Servidor-Estado_Delete")]
        public IActionResult Delete()
        {
            return View();
        }

        [Authorize(Roles = "Master, Servidor-Estado_Lista")]
        public async Task<IActionResult> Lista()
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
            
            #region Get data
            var ses = new List<ServidorEstado>();
            try
            {
                ses = await _context.ServidoresEstado.Where(x => x.TenantId == tenantId).ToListAsync();
            }
            catch { throw; }
            #endregion

            #region Map
            var seLista = new ServidorEstadoCardViewModel();
            try
            {
                seLista.Total = ses.Count();
                seLista.Expedientes = ses.Count(x => x.IsExpediente);
                seLista.NaoExpedientes = ses.Count(x => !x.IsExpediente);
                seLista.FeriasAgendadasToCurrentYear = ses.Count(x => x.HasFeriasAgendadas);
                seLista.LicencaPremioToCurrentYear = ses.Count(x => x.HasLicencaPremioAgendada);
                seLista.Plantoes = EnumExtensions<PlantaoNomeEnum>.GetNames().ToList();
                seLista.Galerias = EnumExtensions<GaleriaEnum>.GetNames().ToList();
            }
            catch { throw; }
            #endregion
            
            return View(seLista);
        }
    }
}