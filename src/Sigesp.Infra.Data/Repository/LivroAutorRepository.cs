using System.Xml.Linq;
using System.ComponentModel.DataAnnotations;
using System.Net.Mime;
using System.Xml;
using System.Security.AccessControl;
using Microsoft.VisualBasic.CompilerServices;
using System.Linq.Expressions;
using System.Reflection.PortableExecutable;
using System.Data;
using System.Diagnostics;
using System.Data.Common;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Sigesp.Domain.Interfaces;
using Sigesp.Domain.Models;
using Sigesp.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Numerics;

namespace Sigesp.Infra.Data.Repository
{
    public class LivroAutorRepository : Repository<LivroAutor>, ILivroAutorRepository
    {
        public LivroAutorRepository(SigespDbContext context)
            : base(context)
        {
        }
        public async Task<LivroAutor> GetByIdAsync(int id)
        {
            return await DbSet.FindAsync(id);
        }
         public async Task<LivroAutor> GetByIdAsyncIncludes(Guid id)
        {
            return await DbSet
                            .Include(x => x.Livros)
                            .FirstOrDefaultAsync(x => x.Id == id);
        }
        public LivroAutor GetByIdIncludes(Guid id)
        {
            var autor = DbSet
                        .Include(x => x.Livros)
                        .FirstOrDefault(x => x.Id == id);
            return autor;
        }
        public IEnumerable<LivroAutor> GetAllIncludes()
        {
            var autores = DbSet
                            .Include(x => x.Livros)
                            .OrderBy(x => x.CreatedAt)
                            .ToList();

            return autores;
        }
        public async Task<IEnumerable<LivroAutor>> GetAllAsyncIncludes()
        {
            var autores = await DbSet
                                .Include(x => x.Livros)
                                .OrderBy(x => x.CreatedAt)
                                .ToListAsync();

            return autores;
        }
        public Int64 GetTotalInativos()
        {
            var inativos = DbSet
                            .IgnoreQueryFilters()
                            .Where(x => x.IsDeleted == true)
                            .Count();
            return inativos;
        }
        public Int64 GetTotalAtivos()
        {
            var ativos = DbSet
                            .Count();
            return ativos;
        }
        public Int64 GetTotalWithIgnoreQueryFilter()
        {
            var total = DbSet
                            .IgnoreQueryFilters()
                            .Count();
            return total;
        }
        public bool AlreadyEqualsNome(string nome)
        {
            var already = DbSet.Any(x => x.Nome == nome);
            return already;
        }
    }
}