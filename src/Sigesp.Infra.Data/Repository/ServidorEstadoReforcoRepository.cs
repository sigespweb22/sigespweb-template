using System;
using System.Data;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Sigesp.Domain.Interfaces;
using Sigesp.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Sigesp.Domain.Models;

namespace Sigesp.Infra.Data.Repository
{
    public class ServidorEstadoReforcoRepository : Repository<ServidorEstadoReforco>, IServidorEstadoReforcoRepository
    {
        public ServidorEstadoReforcoRepository(SigespDbContext context)
            : base(context)
        {
        }
        #region Tenants
        public bool AlreadyReforcoForDate(Guid tenantId, 
                                          DateTime date)
        {
            bool result;
            try
            {
                result = DbSet
                            .Any(x => x.ServidorEstado.Tenant.Id == tenantId &&
                                 x.DataPrevistaInicio == date);
            }
            catch (Exception ex) { throw ex; }
            return result;
        }
        public async Task<bool> AlreadyRuleSameMonthYear(Guid tenantId, int mesRegra, int anoRegra)
        {
            bool result;
            try
            {
                result = await DbSet
                                .AnyAsync(x => x.ServidorEstado.Tenant.Id == tenantId &&
                                          x.MesNumeral == mesRegra &&
                                          x.DataPrevistaInicio.Year == anoRegra);
            }
            catch { throw; }
            return result;
        }
        #endregion

        #region Not tenants
        
        #endregion 
    }
}