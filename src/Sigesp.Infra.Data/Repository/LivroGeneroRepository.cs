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
    public class LivroGeneroRepository : Repository<LivroGenero>, ILivroGeneroRepository
    {
        public LivroGeneroRepository(SigespDbContext context)
            : base(context)
        {
        }
        public async Task<LivroGenero> GetByIdAsync(int id)
        {
            return await DbSet.FindAsync(id);
        }
         public async Task<LivroGenero> GetByIdAsyncIncludes(Guid id)
        {
            return await DbSet
                            .Include(x => x.Livros)
                            .FirstOrDefaultAsync(x => x.Id == id);
        }
        public LivroGenero GetByIdIncludes(Guid id)
        {
            var genero = DbSet
                        .Include(x => x.Livros)
                        .FirstOrDefault(x => x.Id == id);
            return genero;
        }
        public IEnumerable<LivroGenero> GetAllIncludes()
        {
            var generos = DbSet
                            .Include(x => x.Livros)
                            .OrderBy(x => x.CreatedAt)
                            .ToList();

            return generos;
        }
        public async Task<IEnumerable<LivroGenero>> GetAllAsyncIncludes()
        {
            var generos = await DbSet
                                .Include(x => x.Livros)
                                .OrderBy(x => x.CreatedAt)
                                .ToListAsync();

            return generos;
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

        public async Task<LivroGenero> GetByNomeAsync(string nome)
        {
            var livroGenero = new LivroGenero();
            try
            {
                livroGenero = await DbSet
                                        .FirstOrDefaultAsync(x => x.Nome == nome);
            }
            catch { throw; }
            return livroGenero;
        }

        public Guid GetIdByNome(string nome)
        {
            var id = DbSet
                        .Where(x => x.Nome == nome)
                        .Select(x => x.Id)
                        .FirstOrDefault();
            return id;
        }

        public bool AlreadyEqualsNome(string nome)
        {
            var already = DbSet.Any(x => x.Nome == nome);
            return already;
        }
    }
}