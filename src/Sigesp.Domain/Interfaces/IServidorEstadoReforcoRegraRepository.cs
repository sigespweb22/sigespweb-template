using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Sigesp.Domain.Enums;
using Sigesp.Domain.Models;
using Sigesp.Domain.Models.DataTable;

namespace Sigesp.Domain.Interfaces
{
    public interface IServidorEstadoReforcoRegraRepository : IRepository<ServidorEstadoReforcoRegra>
    {
        Task<bool> AlreadyRuleSameMonthYear(Guid tenantId, DateTime dia1, Guid? id);
        Task<ServidorEstadoReforcoRegra> GetAsync(Guid servidorEstadoId);
        Task<ServidorEstadoReforcoRegra> GetAsync(Guid tenantId, MonthOfYearEnum mesRegra, int anoRegra);
        new Task<ServidorEstadoReforcoRegra> GetByIdAsync(Guid id);
        Task<DataTableServerSideResult<ServidorEstadoReforcoRegra>> GetWithDataTableResultAsync(DataTableServerSideRequest request);
    }
}