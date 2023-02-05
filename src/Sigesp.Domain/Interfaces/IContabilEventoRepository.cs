using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Sigesp.Domain.Models;
using Sigesp.Domain.Models.DataTable;

namespace Sigesp.Domain.Interfaces
{
    public interface IContabilEventoRepository : IRepository<ContabilEvento>
    {
        int GetTotalActiveRecords();
        Task<DataTableServerSideResult<ContabilEvento>> GetAllWithDataTableResultAsync(DataTableServerSideRequest request);
        ContabilEvento GetByEspecificacao (string especificacao);
    }
}