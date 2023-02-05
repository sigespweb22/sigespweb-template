using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Sigesp.Domain.Enums;
using Sigesp.Domain.Models;
using Sigesp.Domain.Models.DataTable;

namespace Sigesp.Domain.Interfaces
{
    public interface IAlunoEjaDisciplinaRepository : IRepository<AlunoEjaDisciplina>
    {
        Task<IEnumerable<AlunoEjaDisciplina>> GetAllAsync(Guid alunoEjaId);
    }
}