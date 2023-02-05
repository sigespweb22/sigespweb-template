using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Sigesp.Domain.Enums;
using Sigesp.Domain.Models;
using Sigesp.Domain.Models.DataTable;

namespace Sigesp.Domain.Interfaces
{
    public interface ITenantRepository : IRepository<Tenant>
    {
        Task <string> GetTenantIdAsync(Guid apiKey);
        Task <string> GetTenantIdAsync();
        string GetTenantId(Guid apiKey);
        string GetTenantId();
        Task<string> GetNomeAsync(Guid tenantId);
        Task<Tenant> GetForOficioLeituraAsync(Guid tenantId);
    }
}