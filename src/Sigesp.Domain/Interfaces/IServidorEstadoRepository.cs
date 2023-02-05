using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Sigesp.Domain.Enums;
using Sigesp.Domain.Models;
using Sigesp.Domain.Models.DataTable;

namespace Sigesp.Domain.Interfaces
{
    public interface IServidorEstadoRepository : IRepository<ServidorEstado>
    {
        Task<ServidorEstado> GetAsync(string userId);
    }
}