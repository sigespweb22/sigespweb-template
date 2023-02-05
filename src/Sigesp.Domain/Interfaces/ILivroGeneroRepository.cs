using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Sigesp.Domain.Models;
using System.Numerics;

namespace Sigesp.Domain.Interfaces
{
    public interface ILivroGeneroRepository : IRepository<LivroGenero>
    {
        Task<LivroGenero> GetByIdAsync(int id);
        Task<LivroGenero> GetByIdAsyncIncludes(Guid id);
        LivroGenero GetByIdIncludes(Guid id);
        IEnumerable<LivroGenero> GetAllIncludes();
        Task<IEnumerable<LivroGenero>> GetAllAsyncIncludes();
        Int64 GetTotalInativos();
        Int64 GetTotalAtivos();
        Int64 GetTotalWithIgnoreQueryFilter();
        Task<LivroGenero> GetByNomeAsync(string nome);
        Guid GetIdByNome(string nome);
        bool AlreadyEqualsNome(string nome);
    }
}