using System.Data;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Sigesp.Domain.Interfaces;
using Sigesp.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Sigesp.Domain.Enums;
using Sigesp.Domain.Models;
using Sigesp.Infra.Data.Extensions;

namespace Sigesp.Infra.Data.Repository
{
    public class AlunoRepository : Repository<Aluno>, IAlunoRepository
    {
        private readonly ITenantRepository _tenantRepository;

        public AlunoRepository(SigespDbContext context,
                               ITenantRepository tenantRepository)
            : base(context)
        {
            _tenantRepository = tenantRepository;
        }

        public async Task<IEnumerable<Aluno>> GetAllAsync(Guid tenantId)
        {   
            IEnumerable<Aluno> result = new List<Aluno>();
            try
            {
                result = await DbSet
                                .Include(x => x.Detento)
                                .Where(x => x.TenantId == tenantId)
                                .ToListAsync();
            }                   
            catch { throw; }
            return result;
        }
        public Aluno GetByDetentoIpen(int ipen)
        {
            var result = new Aluno();

            try
            {
                result = DbSet
                            .AsNoTracking()
                            .IgnoreQueryFilters()
                            .Include(x => x.Tenant)
                            .Include(x => x.Detento)
                            .Where(x => x.Detento.IsDeleted == false || x.Detento.IsDeleted == true)
                            .Where(x => x.IsDeleted == false || x.IsDeleted == true)
                            .Where(x => x.Detento.Ipen == ipen)
                            .FirstOrDefault();
            }
            catch { throw; }
            return result;
        }
        public IEnumerable<Aluno> GetAllWithIncludes()
        {
            var tenantId = StringHelpers.ExtractTenantId(_tenantRepository.GetTenantId());
            var result = new List<Aluno>();

            if (tenantId != null && tenantId != Guid.Empty)
            {
                result = DbSet
                            .IgnoreQueryFilters()
                            .Include(x => x.Tenant)
                            .Include(c => c.Detento)
                            .Where(x => x.Tenant.Id == tenantId &&
                                    x.Detento.Tenant.Id == tenantId)
                            .Where(x => x.IsDeleted == true || x.IsDeleted == false)
                            .Where(x => x.Detento.IsDeleted == true || x.Detento.IsDeleted == false)
                            .ToList();
            }
            return result;
        }
        public Aluno GetByIdWithIncludes(Guid id)
        {
            var tenantId = StringHelpers.ExtractTenantId(_tenantRepository.GetTenantId());
            var result = new Aluno();

            if (tenantId != null && tenantId != Guid.Empty)
            {
                result = DbSet
                            .AsNoTracking()
                            .IgnoreQueryFilters()
                            .Include(x => x.Tenant)
                            .Include(x => x.Detento)
                            .Where(x => x.Tenant.Id == tenantId &&
                                   x.Detento.Tenant.Id == tenantId)
                            .Where(x => x.IsDeleted == false && x.Id == id)
                            .Where(x => x.Detento.IsDeleted == false || x.Detento.IsDeleted == true)
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
                            .Include(c => c.Detento)
                            .Where(x => x.Tenant.Id == tenantId && 
                                   x.Detento.Tenant.Id == tenantId)
                            .Where(x => x.IsDeleted == false)
                            .Where(x => x.Detento.IsDeleted == false ||
                                   x.Detento.IsDeleted == true)
                            .Count();
            }
            return result;
        }
        public Int64 GetTotalByEscolaridade(EscolaridadeEnum escolaridade)
        {
            var tenantId = StringHelpers.ExtractTenantId(_tenantRepository.GetTenantId());
            Int64 result = 0;

            if (tenantId != null && tenantId != Guid.Empty)
            {
                result = DbSet
                            .Include(x => x.Tenant)
                            .Where(x => x.Tenant.Id == tenantId)
                            .Count(x => x.Escolaridade.Equals(escolaridade));
            }
            return result;
        }

        #region Methods that are not tenants
        public async Task<Aluno> GetAsync(int ipen)
        {
            var result = new Aluno();
            try
            {
                result = await DbSet
                                .IgnoreQueryFilters()
                                .Include(x => x.Detento)
                                .Where(x => x.IsDeleted == false)
                                .FirstOrDefaultAsync(x => x.Detento.Ipen == ipen);
            }
            catch { throw; }
            return result;
        }
        public async Task<string> GetNomeAsync(Guid id)
        {
            String result;
            try
            {
                result = await DbSet
                                .IgnoreQueryFilters()
                                .Where(x => x.Id == id)
                                .Include(x => x.Detento)
                                .Select(x => x.Detento.Nome)
                                .FirstOrDefaultAsync();
                            
            }
            catch { throw; }
            return result;
        }
        public async Task<Aluno> GetAtivoInativoAsync(Guid id)
        {
            var result  = new Aluno();
            try
            {
                result = await DbSet
                                .IgnoreQueryFilters()
                                .FirstOrDefaultAsync(x => x.Id == id);
            }
            catch (Exception ex) { throw ex; }
            return result;
        }
        #endregion
    }
}