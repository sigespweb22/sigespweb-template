using System;
using System.Data;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Sigesp.Domain.Interfaces;
using Sigesp.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Sigesp.Domain.Models;
using Sigesp.Domain.Models.DataTable;
using Sigesp.Infra.Data.Extensions.DataTable;
using Sigesp.Domain.Enums;

namespace Sigesp.Infra.Data.Repository
{
    public class ServidorEstadoReforcoRegraRepository : Repository<ServidorEstadoReforcoRegra>, IServidorEstadoReforcoRegraRepository
    {
        public ServidorEstadoReforcoRegraRepository(SigespDbContext context)
            : base(context)
        {
        }

        #region Tenants
        public async Task<bool> AlreadyRuleSameMonthYear(Guid tenantId, DateTime dia1, Guid? id)
        {
            bool result;
            if (id == Guid.Empty)
            {
                try
                {
                    result = await DbSet
                                    .AnyAsync(x => x.Tenant.Id == tenantId &&
                                              x.DataPrimeiraJanela.Month == dia1.Month &&
                                              x.DataPrimeiraJanela.Year == dia1.Year);
                }
                catch (Exception ex) { throw ex; }
            }
            else
            {
                try
                {
                    result = await DbSet
                                    .AnyAsync(x => x.Tenant.Id == tenantId &&
                                              x.DataPrimeiraJanela.Month == dia1.Month &&
                                              x.DataPrimeiraJanela.Year == dia1.Year &&
                                              x.Id != id);
                }
                catch (Exception ex) { throw ex; }
            }
            return result;
        }
        public async Task<ServidorEstadoReforcoRegra> GetAsync(Guid tenantId)
        {
            var result = new ServidorEstadoReforcoRegra();
            try
            {
                result  = await DbSet
                                 .FirstOrDefaultAsync(x => x.Tenant.Id == tenantId);
            }
            catch (Exception ex) { throw ex; }
            return result;
        }
        public async Task<ServidorEstadoReforcoRegra> GetAsync(Guid tenantId, MonthOfYearEnum mesRegra, int anoRegra)
        {
            var result = new ServidorEstadoReforcoRegra();
            try
            {
                result  = await DbSet
                                 .FirstOrDefaultAsync(x => x.Tenant.Id == tenantId &&
                                                      x.MesRegra == mesRegra &&
                                                      x.DataPrimeiraJanela.Year == anoRegra);
            }
            catch { throw; }
            return result;
        }
        public new async Task<ServidorEstadoReforcoRegra> GetByIdAsync(Guid id)
        {
            var result = new ServidorEstadoReforcoRegra();
            try
            {
                result  = await DbSet
                                 .AsNoTracking()
                                 .Include(x => x.Tenant)
                                 .FirstOrDefaultAsync(x => x.Id == id);
            }
            catch (Exception ex) { throw ex; }
            return result;
        }
        public async Task<DataTableServerSideResult<ServidorEstadoReforcoRegra>> GetWithDataTableResultAsync(DataTableServerSideRequest request)
        {
            var result = new DataTableServerSideResult<ServidorEstadoReforcoRegra>();
            try
            {
                result = await DbSet
                                .AsNoTracking()
                                .Include(x => x.VagasPorDia)
                                .OrderBy(x => x.CreatedAt)
                                .Where(x => x.Tenant.Id == request.TenantId)
                                .GetDatatableResultAsync(request);
            }
            catch { throw; }
            return result;
        }
        #endregion

        #region Not tenants
       
        #endregion 
    }
}