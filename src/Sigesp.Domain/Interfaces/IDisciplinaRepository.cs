using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Sigesp.Domain.Enums;
using Sigesp.Domain.Models;
using Sigesp.Domain.Models.DataTable;

namespace Sigesp.Domain.Interfaces
{
    public interface IDisciplinaRepository : IRepository<Disciplina>
    {
        IEnumerable<Disciplina> GetAllWithIncludes();
        Int64 GetTotalAtivos();
        Int64 GetTotalInativos();
        Int64 GetTotalWithIgnoreQueryFilter();
    }
}