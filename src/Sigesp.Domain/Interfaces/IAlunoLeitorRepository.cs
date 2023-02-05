using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Sigesp.Domain.Models;
using System.Numerics;
using Sigesp.Domain.Enums;
using Sigesp.Domain.Models.DataTable;

namespace Sigesp.Domain.Interfaces
{
    public interface IAlunoLeitorRepository : IRepository<AlunoLeitor>
    {
        Task<IEnumerable<AlunoLeitor>> GetAllAsync(Guid tenantId);
        AlunoLeitor GetByIdIncludes(Guid id);
        IEnumerable<AlunoLeitor> GetAllWithIncludes();
        Int64 GetTotalAtivos();
        Int64 GetTotalInativos();
        Int64 GetTotalWithIgnoreQueryFilter();
        AlunoLeitor GetByDetentoIpen(int ipen);
        Task<bool> AlreadyAnyAtivoByDetentoIpenAsync(Guid tenantId, int ipen);
        IEnumerable<AlunoLeitor> GetAllByDetentoNome(string nome);
        string GetGeneroByIpen(int ipen);
        IEnumerable<AlunoLeitor> GetAllByDetentoGaleria(string galeria);
        IEnumerable<AlunoLeitor> GetAllRemoveRangeCelas(IEnumerable<int> celas, string galeria);
        Task<DataTableServerSideResult<AlunoLeitor>> GetWithDataTableResultAsync(DataTableServerSideRequest request);
        Task<AlunoLeitor> GetAsync(int ipen);
    }
}