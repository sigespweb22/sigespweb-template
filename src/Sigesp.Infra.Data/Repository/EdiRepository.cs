using System.Xml.Linq;
using System.ComponentModel.DataAnnotations;
using System.Net.Mime;
using System.Xml;
using System.Security.AccessControl;
using Microsoft.VisualBasic.CompilerServices;
using System.Linq.Expressions;
using System.Reflection.PortableExecutable;
using System.Data;
using System.Diagnostics;
using System.Data.Common;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Sigesp.Domain.Interfaces;
using Sigesp.Domain.Models;
using Sigesp.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Sigesp.Infra.Data.Extensions;
using Sigesp.Domain.Enums;
using Sigesp.Domain.Models.DataTable;
using Sigesp.Infra.Data.Extensions.DataTable;

namespace Sigesp.Infra.Data.Repository
{
    public class EdiRepository : Repository<Edi>, IEdiRepository
    {
        private readonly ITenantRepository _tenantRepository;

        public EdiRepository(SigespDbContext context,
                             ITenantRepository tenantRepository)
            : base(context)
        {
            _tenantRepository = tenantRepository;
        }

        #region Métodos multitenants
        public new async Task<IEnumerable<Edi>> GetAllAsync()
        {
            var tenantId = StringHelpers.ExtractTenantId(await _tenantRepository.GetTenantIdAsync());
            var result = new List<Edi>();

            if (tenantId != null && tenantId != Guid.Empty)
            {
                result =  await DbSet
                                    .AsNoTracking()
                                    .Where(x => x.Tenant.Id == tenantId)
                                    .ToListAsync();
            }
            return result;
        }
        public async Task<List<Edi>> GetInfoCardsAsync()
        {
            var tenantId = StringHelpers.ExtractTenantId(await _tenantRepository.GetTenantIdAsync());
            var result = new List<Edi>();

            if (tenantId != null && tenantId != Guid.Empty)
            {   
                // var query = await DbSet
                //                     .Where(x => x.Tenant.Id == tenantId)
                //                     .GroupBy(x => new  { x.Status })
                //                     .Select(g => new {
                //                         g.Key.Status,
                //                         Total = g.Count()
                //                     })
                //                     .OrderBy(x => x.Status)
                //                     .ToListAsync();
                
                result = await DbSet
                                .Where(x => x.Tenant.Id == tenantId)
                                .ToListAsync();
            }
            return result;
        }
        public async Task<DataTableServerSideResult<Edi>> GetWithDataTableResultAsync(DataTableServerSideRequest request)
        {
            var tenantId = StringHelpers.ExtractTenantId(await _tenantRepository.GetTenantIdAsync());
            var result = new DataTableServerSideResult<Edi>();

            if (tenantId != null && tenantId != Guid.Empty)
            {
                result = await DbSet
                                .AsNoTracking()
                                .Include(x => x.Tenant)
                                .Include(x => x.EdiLogs)
                                .OrderBy(x => x.CreatedAt)
                                .Where(x => x.Tenant.Id == tenantId)
                                .GetDatatableResultAsync(request);
            }
            return result;
        }
        #endregion

        #region Métodos is not multitenants
        #endregion

        #region Métodos pendentes para implementar tenancy
        #endregion
    }
}