using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Sigesp.Domain.Models;
using Sigesp.Domain.Enums;
using Sigesp.Domain.Models.DataTable;

namespace Sigesp.Domain.Interfaces
{
    public interface IEdiRepository : IRepository<Edi>
    {
        new Task<IEnumerable<Edi>> GetAllAsync();
        Task<List<Edi>> GetInfoCardsAsync();
        Task<DataTableServerSideResult<Edi>> GetWithDataTableResultAsync(DataTableServerSideRequest request);
    }
}