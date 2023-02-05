using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Sigesp.Domain.Models;

namespace Sigesp.Domain.Interfaces
{
    public interface IEdiLogRepository : IRepository<EdiLog>
    {
        IEnumerable<EdiLog> GetAllByEdiId(Guid ediId);
    }
}