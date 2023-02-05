using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Sigesp.Domain.Enums;
using Sigesp.Domain.Models;
using Sigesp.Domain.Models.DataTable;

namespace Sigesp.Domain.Interfaces
{
    public interface IServidorEstadoReforcoRepository : IRepository<ServidorEstadoReforco>
    {
        bool AlreadyReforcoForDate(Guid tenantId, DateTime date);
        Task<bool> AlreadyRuleSameMonthYear(Guid tenantId, int mesRegra, int anoRegra);
    }
}