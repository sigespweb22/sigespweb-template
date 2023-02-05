using System.Data;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Sigesp.Domain.Interfaces;
using Sigesp.Domain.Models;
using Sigesp.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Numerics;
using Sigesp.Domain.Models.DataTable;
using Sigesp.Infra.Data.Extensions.DataTable;
using Sigesp.Infra.Data.Extensions;

namespace Sigesp.Infra.Data.Repository
{
    public class LivroRepository : Repository<Livro>, ILivroRepository
    {
        private readonly ITenantRepository _tenantRepository;

        public LivroRepository(SigespDbContext context,
                                ITenantRepository tenantRepository)
            : base(context)
        {
            _tenantRepository = tenantRepository;
        }

        public Livro GetAtivoInativoById(Guid id)
        {
            var tenantId = StringHelpers.ExtractTenantId(_tenantRepository.GetTenantId());
            var result = new Livro();

            if (tenantId != null && tenantId != Guid.Empty)
            {
                result = DbSet
                            .IgnoreQueryFilters()
                            .Include(x => x.Tenant)
                            .Where(x => x.Tenant.Id == tenantId)
                            .FirstOrDefault(x => x.Id == id);
            }

            return result;
        }
        public async Task<IEnumerable<Livro>> GetAllAsync(Guid tenantId)
        {
            IEnumerable<Livro> result = new List<Livro>();
            try
            {
                result = await DbSet
                                .Where(x => x.Tenant.Id == tenantId)
                                .ToListAsync();
            }
            catch { throw; }
            return result;
        }
        public async Task<IEnumerable<Livro>> GetAllAtivoInativoAsync(Guid tenantId)
        {
            var result = new List<Livro>();
            try
            {
                result = await DbSet
                                .IgnoreQueryFilters()
                                .Include(x => x.Tenant)
                                .Where(x => x.Tenant.Id == tenantId)
                                .ToListAsync();
            }
            catch { throw; }
            return result;
        }
        public IEnumerable<Livro> GetAllDisponiveis()
        {
            var tenantId = StringHelpers.ExtractTenantId(_tenantRepository.GetTenantId());
            var result = new List<Livro>();

            if (tenantId != null && tenantId != Guid.Empty)
            {
                result = DbSet
                            .Include(x => x.Tenant)
                            .Include(x => x.LivroGenero)
                            .OrderBy(x => x.CreatedAt)
                            .Where(x => x.Tenant.Id == tenantId &&
                                   x.IsDisponivel == true).ToList();
            }

            return result;
        }
        public IEnumerable<Livro> GetAllDisponiveis(string livroGeneroNome)
        {
            var tenantId = StringHelpers.ExtractTenantId(_tenantRepository.GetTenantId());
            var result = new List<Livro>();

            if (tenantId != null && tenantId != Guid.Empty)
            {
                result = DbSet
                            .Include(x => x.Tenant)
                            .Include(x => x.LivroGenero)
                            .OrderBy(x => x.CreatedAt)
                            .Where(x => x.Tenant.Id == tenantId &&
                                   x.IsDisponivel == true &&
                                   x.LivroGenero.Nome == livroGeneroNome).ToList();
            }

            return result;
        }
        public BigInteger GetNextLocalizacao()
        {
            try
            {
                var tenantId = StringHelpers.ExtractTenantId(_tenantRepository.GetTenantId());
                int result = 0;

                if (tenantId != null && tenantId != Guid.Empty)
                {
                    var localizacoes = DbSet
                                        .Include(x => x.Tenant)
                                        .Where(x => x.Tenant.Id == tenantId)
                                        .Select(x => x.Localizacao);
                    
                    if (localizacoes.Count() > 0)
                    {
                        result = (int)localizacoes.Max();
                    }
                }
                
                return result;
            }
            catch { throw; }
        }
        public async Task<DataTableServerSideResult<Livro>> GetWithDataTableResultAsync(DataTableServerSideRequest request)
        {
            var tenantId = StringHelpers.ExtractTenantId(await _tenantRepository.GetTenantIdAsync());
            var result = new DataTableServerSideResult<Livro>();

            if (tenantId != null && tenantId != Guid.Empty)
            {
                result = await DbSet
                                .IgnoreQueryFilters()
                                .AsNoTracking()
                                .Include(x => x.Tenant)
                                .Include(x => x.LivroAutor)
                                .Include(x => x.LivroGenero)
                                .OrderBy(x => x.CreatedAt)
                                .Where(x => x.Tenant.Id == tenantId)
                                .Where(x => x.IsDeleted == false || 
                                       x.IsDeleted == true)
                                .GetDatatableResultAsync(request);
            }

            return result;
        }
        public async Task<bool> AlreadyLocalizacaoAsync(Guid tenantId, Int64 localizacao,
                                                        Guid? id)
        {
            bool already = false;
            if (id == null || id == Guid.Empty)
            {
                try
                {
                    already = await DbSet
                                        .Include(x => x.Tenant)
                                        .Where(x => x.Tenant.Id == tenantId)
                                        .AnyAsync(x => x.Localizacao == localizacao);
                }
                catch { throw; }    
            }
            else
            {
                try
                {
                    already = await DbSet
                                        .Include(x => x.Tenant)
                                        .Where(x => x.Tenant.Id == tenantId)
                                        .AnyAsync(x => x.Localizacao == localizacao &&
                                             x.Id != id);    
                }
                catch { throw; }
            }
            return already;            
        }
        public Int64 GetTotalInativos()
        {
            Int64 inativos = 0;
            var tenantId = StringHelpers.ExtractTenantId(_tenantRepository.GetTenantId());

            if (tenantId != null && tenantId != Guid.Empty)
            {
                inativos = DbSet
                            .IgnoreQueryFilters()
                            .Include(x => x.Tenant)
                            .Where(x => x.Tenant.Id == tenantId &&
                                   x.IsDeleted == true)
                            .Count();
            }
            
            return inativos;
        }
        public Int64 GetTotalAtivos()
        {
            Int64 ativos = 0;
            var tenantId = StringHelpers.ExtractTenantId(_tenantRepository.GetTenantId());

            if (tenantId != null && tenantId != Guid.Empty)
            {
                ativos = DbSet
                            .Include(x => x.Tenant)
                            .Where(x => x.Tenant.Id == tenantId)
                            .Count();
            }
            
            return ativos;
        }
        public Int64 GetTotalDisponiveis()
        {
            Int64 disponiveis = 0;
            var tenantId = StringHelpers.ExtractTenantId(_tenantRepository.GetTenantId());

            if (tenantId != null && tenantId != Guid.Empty)
            {
                disponiveis = DbSet
                                .Include(x => x.Tenant)
                                .Where(x => x.Tenant.Id == tenantId &&
                                       x.IsDisponivel)
                                .Count();
            }

            return disponiveis;
        }
        public Int64 GetTotalIndisponiveis()
        {
            Int64 indisponiveis = 0;
            var tenantId = StringHelpers.ExtractTenantId(_tenantRepository.GetTenantId());

            if (tenantId != null && tenantId != Guid.Empty)
            {
                indisponiveis = DbSet
                                    .Include(x => x.Tenant)
                                    .Where(x => x.Tenant.Id == tenantId &&
                                          !x.IsDisponivel)
                                    .Count();
            }

            return indisponiveis;
        }
        public async Task<Livro> GetByLocalizacaoAsync(Guid tenantId, Int64 localizacao)
        {
            var result = new Livro();
            try
            {
                result = await DbSet
                                .Include(x => x.Tenant)
                                .Where(x => x.Tenant.Id == tenantId)
                                .FirstOrDefaultAsync(x => x.Localizacao == localizacao);
            }
            catch { throw; }
            return result;
        }
        public Int64 GetTotalWithIgnoreQueryFilter()
        {
            Int64 result = 0;
            var tenantId = StringHelpers.ExtractTenantId(_tenantRepository.GetTenantId());

            if (tenantId != null && tenantId != Guid.Empty)
            {
                result = DbSet
                            .IgnoreQueryFilters()
                            .Include(x => x.Tenant)
                            .Where(x => x.Tenant.Id == tenantId)
                            .Count();
            }
            return result;
        }
        public Livro GetOneTituloDisponivelRemovingList(IEnumerable<Livro> leitorTitulosLidos,
                                                        string generoNome)
        {
            var result = new Livro();
            var tenantId = StringHelpers.ExtractTenantId(_tenantRepository.GetTenantId());
            
            if (tenantId != null && tenantId != Guid.Empty)
            {
                var livros = DbSet
                                .Include(x => x.LivroGenero)
                                .Include(x => x.Tenant)
                                .Where(x => x.Tenant.Id == tenantId &&
                                       x.IsDisponivel == true &&
                                       x.LivroGenero.Nome == generoNome)
                                .ToList();

                if (leitorTitulosLidos.Count() > 0)
                {
                    foreach (var ltl in leitorTitulosLidos)
                    {
                        //Localizar pelo título e retirar da lista
                        var findLivroByTitulo = livros.Where(x => x.Titulo.StartsWith(ltl.Titulo));
                        foreach (var flbt in findLivroByTitulo.ToList())
                        {
                            livros.Remove(flbt);
                        }

                        //Localizar pelo id e retirar da lista
                        var findLivroById = livros.Where(x => x.Id == ltl.Id);
                        foreach (var flbi in findLivroById.ToList())
                        {
                            livros.Remove(flbi);
                        }
                    }
                }

                result = livros.FirstOrDefault();
            }
            return result;
        }
        public Int64 GetLocalizacao(Guid id)
        {
            Int64 result = 0;
            var tenantId = StringHelpers.ExtractTenantId(_tenantRepository.GetTenantId());

            if (tenantId != null && tenantId != Guid.Empty)
            {
                result = DbSet
                            .Include(x => x.Tenant)
                            .Where(x => x.Tenant.Id == tenantId &&
                                   x.Id == id)
                            .Select(x => x.Localizacao)
                            .FirstOrDefault();
            }

            return result;
        }
        public Livro GetOneTituloDisponivel(string generoNome)
        {
            var result = new Livro();
            var tenantId = StringHelpers.ExtractTenantId(_tenantRepository.GetTenantId());

            if (tenantId != null && tenantId != Guid.Empty)
            {
                result = DbSet
                            .Include(x => x.Tenant)
                            .Include(x => x.LivroGenero)
                            .Where(x => x.Tenant.Id == tenantId)
                            .FirstOrDefault(x => x.IsDisponivel == true &&
                                            x.LivroGenero.Nome == generoNome);
            }
            return result;
        }
    }
}