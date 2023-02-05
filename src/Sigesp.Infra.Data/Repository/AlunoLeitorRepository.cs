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
using Sigesp.Domain.Enums;
using Sigesp.Domain.Models.DataTable;
using Sigesp.Infra.Data.Extensions;
using Sigesp.Infra.Data.Extensions.DataTable;

namespace Sigesp.Infra.Data.Repository
{
    public class AlunoLeitorRepository : Repository<AlunoLeitor>, IAlunoLeitorRepository
    {
        private readonly ITenantRepository _tenantRepository;

        public AlunoLeitorRepository(SigespDbContext context,
                                    ITenantRepository tenantRepository)
            : base(context)
        {
            _tenantRepository = tenantRepository;
        }

        #region Métodos multitenants
        public async Task<IEnumerable<AlunoLeitor>> GetAllAsync(Guid tenantId)
        {
            var result = new List<AlunoLeitor>();
            try
            {
                result = await DbSet
                                .Include(x => x.Aluno)
                                .ThenInclude(x => x.Detento)
                                .Where(x => x.Tenant.Id == tenantId)
                                .ToListAsync();
            }
            catch { throw; }
            return result;
        }
        public IEnumerable<AlunoLeitor> GetAllWithIncludes()
        {
            var tenantId = StringHelpers.ExtractTenantId(_tenantRepository.GetTenantId());
            var result = new List<AlunoLeitor>();

            if (tenantId != null && tenantId != Guid.Empty)
            {
                result = DbSet
                            .IgnoreQueryFilters()
                            .Include(x => x.Tenant)                            
                            .Include(x => x.Aluno)
                            .ThenInclude(x => x.Detento)
                            .Where(x => x.Tenant.Id == tenantId)
                            .Where(d => d.Aluno.Detento.IsDeleted == true || d.Aluno.Detento.IsDeleted == false)
                            .Where(d => d.IsDeleted == false)
                            .ToList();
            }
            return result;
        }
        public AlunoLeitor GetByIdIncludes(Guid id)
        {
            var tenantId = StringHelpers.ExtractTenantId(_tenantRepository.GetTenantId());
            var result = new AlunoLeitor();

            if (tenantId != null && tenantId != Guid.Empty)
            {
                result = DbSet
                            .AsNoTracking()
                            .IgnoreQueryFilters()
                            .Include(x => x.Tenant)
                            .Include(x => x.Aluno)
                            .ThenInclude(x => x.Detento)
                            .Include(x => x.LivroGenero)
                            .Include(x => x.Professor)
                            .Where(x => x.Tenant.Id == tenantId)
                            .Where(x => x.Aluno.IsDeleted == false ||
                                x.Aluno.IsDeleted == true)
                            .Where(x => x.Aluno.Detento.IsDeleted == false ||
                                x.Aluno.Detento.IsDeleted == true)
                            .Where(x => x.LivroGenero.IsDeleted == false ||
                                x.LivroGenero.IsDeleted == true)
                            .Where(x => x.Professor.IsDeleted == false ||
                                x.Professor.IsDeleted == true)
                            .Where(x => x.Id == id)
                            .FirstOrDefault();
            }
            return result;
        }
        public Int64 GetTotalAtivos()
        {
            var tenantId = StringHelpers.ExtractTenantId(_tenantRepository.GetTenantId());
            Int64 result = 0;

            if (tenantId != null && tenantId != Guid.Empty)
            {
                result = DbSet
                            .Include(x => x.Tenant)
                            .Where(x => x.Tenant.Id == tenantId)
                            .Count();
            }
            return result;
        }
        public Int64 GetTotalInativos()
        {
            var tenantId = StringHelpers.ExtractTenantId(_tenantRepository.GetTenantId());
            Int64 result = 0;

            if (tenantId != null && tenantId != Guid.Empty)
            {
                result = DbSet
                            .IgnoreQueryFilters()
                            .Include(x => x.Tenant)
                            .Where(x => x.Tenant.Id == tenantId &&
                                   x.IsDeleted == true)
                            .Count();
            }
            return result;
        }
        public Int64 GetTotalWithIgnoreQueryFilter()
        {
            var tenantId = StringHelpers.ExtractTenantId(_tenantRepository.GetTenantId());
            Int64 result = 0;

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
        public AlunoLeitor GetByDetentoIpen(int ipen)
        {
            var tenantId = StringHelpers.ExtractTenantId(_tenantRepository.GetTenantId());
            var result = new AlunoLeitor();

            if (tenantId != null && tenantId != Guid.Empty)
            {
                result = DbSet
                            .IgnoreQueryFilters()
                            .Include(x => x.Tenant)
                            .Include(x => x.Professor)
                            .Include(x => x.LivroGenero)
                            .Include(c => c.Aluno)
                            .ThenInclude(c => c.Detento)
                            .Where(x => x.Tenant.Id == tenantId)
                            .FirstOrDefault(x => x.Aluno.Detento.Ipen == ipen);
            }
            return result;
        }
        public async Task<bool> AlreadyAnyAtivoByDetentoIpenAsync(Guid tenantId, int ipen)
        {
            bool result = false;
            try
            {
                result = await DbSet
                                .Include(x => x.Tenant)
                                .Include(x => x.Aluno)
                                .ThenInclude(x => x.Detento)
                                .Where(x => x.Tenant.Id == tenantId)
                                .AnyAsync(x => x.Aluno.Detento.Ipen == ipen);
            }
            catch{ throw; }
            return result;
        }
        public IEnumerable<AlunoLeitor> GetAllByDetentoNome(string nome)
        {
            var tenantId = StringHelpers.ExtractTenantId(_tenantRepository.GetTenantId());
            var result = new List<AlunoLeitor>();

            if (tenantId != null && tenantId != Guid.Empty)
            {
                result = DbSet
                            .Include(x => x.Tenant)
                            .Include(x => x.Aluno)
                            .ThenInclude(x => x.Detento)
                            .Where(x => x.Tenant.Id == tenantId &&
                                   x.Aluno.Detento.Nome == nome)
                            .ToList();
            }
            return result;
        }
        public string GetGeneroByIpen(int ipen) 
        {
            var tenantId = StringHelpers.ExtractTenantId(_tenantRepository.GetTenantId());
            string result = null;

            if (tenantId != null && tenantId != Guid.Empty)
            {
                var tmp = DbSet
                            .Include(x => x.Tenant)
                            .Include(x => x.Aluno)
                            .ThenInclude(x => x.Detento)
                            .Where(x => x.Tenant.Id == tenantId)
                            .Select(x => new {
                                x.Aluno.Detento.Ipen,
                                x.LivroGenero.Nome 
                            })
                            .FirstOrDefault(x => x.Ipen == ipen);
                
                if (tmp != null)
                    result = tmp.Nome;
            }
            return result;
        }
        public IEnumerable<AlunoLeitor> GetAllByDetentoGaleria(string galeria)
        {
            var tenantId = StringHelpers.ExtractTenantId(_tenantRepository.GetTenantId());
            var result = new List<AlunoLeitor>();

            if (tenantId != null && tenantId != Guid.Empty)
            {
                result = DbSet
                            .AsNoTracking()
                            .Include(x => x.Tenant)
                            .Include(x => x.Aluno)
                            .ThenInclude(x => x.Detento)
                            .Include(x => x.LivroGenero)
                            .Where(x => x.Tenant.Id == tenantId &&
                                   x.Aluno.Detento.Galeria == galeria)
                            .ToList();
            }
            return result;
        }
        public IEnumerable<AlunoLeitor> GetAllRemoveRangeCelas(IEnumerable<int> celas,
                                                               string galeria)
        {
            var tenantId = StringHelpers.ExtractTenantId(_tenantRepository.GetTenantId());
            var result = new List<AlunoLeitor>();

            if (tenantId != null && tenantId != Guid.Empty)
            {
                var leitores = DbSet
                                .Include(x => x.Tenant)
                                .Include(x => x.Aluno)
                                .ThenInclude(x => x.Detento)
                                .Include(x => x.LivroGenero)
                                .Where(x => x.Tenant.Id == tenantId &&
                                       x.Aluno.Detento.Galeria == galeria)
                                .ToList();

                if (leitores.Count() > 0)
                {
                    if (celas == null || celas.Count() <= 0)
                    {
                        result = leitores;
                    }
                    else
                    {
                        foreach (var cela in celas)
                        {
                            //Localizar leitores da cela da iteração para adicionar
                            //na nova lista de leitores
                            var findLeitoresCela = leitores
                                                        .Where(x => x.Aluno.Detento.Cela == cela);
                            foreach (var flc in findLeitoresCela)
                            {
                                result.Add(flc);
                            }
                        }
                    }
                }
            }
            return result;
        }
        public async Task<DataTableServerSideResult<AlunoLeitor>> GetWithDataTableResultAsync(DataTableServerSideRequest request)
        {
            var tenantId = StringHelpers.ExtractTenantId(await _tenantRepository.GetTenantIdAsync());
            var result = new DataTableServerSideResult<AlunoLeitor>();

            if (tenantId != null && tenantId != Guid.Empty)
            {
                result = await DbSet
                                .IgnoreQueryFilters()
                                .Include(x => x.LivroGenero)
                                .Include(x => x.Professor)
                                .Include(x => x.Aluno)
                                .ThenInclude(x => x.Detento)
                                .Where(x => x.Tenant.Id == tenantId)
                                .Where(x => x.IsDeleted == false ||
                                       x.IsDeleted == true)
                                .OrderBy(x => x.IsDeleted)
                                .GetDatatableResultAsync(request);
            }
            return result;
        }
        #endregion

        #region Métodos pendentes para implementar tenancy
        #endregion

        #region Methos is not tenants
        public async Task<AlunoLeitor> GetAsync(int ipen)
        {
            var result = new AlunoLeitor();
            try
            {
                result = await DbSet
                                .IgnoreQueryFilters()
                                .Include(x => x.Aluno)
                                .ThenInclude(x => x.Detento)
                                .Where(x => x.IsDeleted == false)
                                .FirstOrDefaultAsync(x => x.Aluno.Detento.Ipen == ipen);
            }
            catch { throw; }
            return result;
        }
        #endregion
    }
}