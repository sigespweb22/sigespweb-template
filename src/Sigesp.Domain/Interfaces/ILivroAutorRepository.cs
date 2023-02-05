using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Sigesp.Domain.Models;
using System.Numerics;

namespace Sigesp.Domain.Interfaces
{
    public interface ILivroAutorRepository : IRepository<LivroAutor>
    {
        Task<LivroAutor> GetByIdAsync(int id);
        Task<LivroAutor> GetByIdAsyncIncludes(Guid id);
        LivroAutor GetByIdIncludes(Guid id);
        IEnumerable<LivroAutor> GetAllIncludes();
        Task<IEnumerable<LivroAutor>> GetAllAsyncIncludes();
        Int64 GetTotalInativos();
        Int64 GetTotalAtivos();
        Int64 GetTotalWithIgnoreQueryFilter();
        bool AlreadyEqualsNome(string nome);        
    }
}