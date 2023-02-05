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
using Sigesp.Infra.Data.Extensions;
using Sigesp.Domain.Models.DataTable;
using Sigesp.Infra.Data.Extensions.DataTable;

namespace Sigesp.Infra.Data.Repository
{
    public class ProfessorRepository : Repository<Professor>, IProfessorRepository
    {
        private ITenantRepository _tenantRepository;

        public ProfessorRepository(SigespDbContext context,
                                   ITenantRepository tenantRepository)
            : base(context)
        {
            _tenantRepository = tenantRepository;
        }

        #region Métodos multitenants
        public async Task<Int64> GetTotalInativosAsync(Guid tenantId)
        {
            try
            {
                Int64 result;
                result = await DbSet
                                .IgnoreQueryFilters()
                                .Include(x => x.Tenant)
                                .Where(x => x.Tenant.Id == tenantId)
                                .Where(x => x.IsDeleted == true)
                                .CountAsync();
                return result;
            }
            catch { throw; }
        }
        public async Task<IEnumerable<Professor>> GetAllAsync(Guid tenantId)
        {
            IEnumerable<Professor> result = new List<Professor>();
            try
            {
                result = await DbSet
                                .Where(x => x.Tenant.Id == tenantId)
                                .ToListAsync();
            }
            catch { throw; }
            return result;
        }
        public async Task<IEnumerable<string>> GetAllNomesAsync(Guid tenantId)
        {
            IEnumerable<string> result = new List<string>();
            try
            {
                result = await DbSet
                                .Where(x => x.Tenant.Id == tenantId)
                                .Select(x => x.Nome)
                                .ToListAsync();
            }
            catch { throw; }
            return result;
        }
        public async Task<DataTableServerSideResult<Professor>> GetWithDataTableResultAsync(DataTableServerSideRequest request)
        {
            var result = new DataTableServerSideResult<Professor>();
            try
            {
                result = await DbSet
                                .AsNoTracking()
                                .Include(x => x.ApplicationUser)
                                .ThenInclude(x => x.ContaUsuario)
                                .Include(x => x.Tenant)
                                .OrderBy(x => x.CreatedAt)
                                .Where(x => x.Tenant.Id == request.TenantId)
                                .GetDatatableResultAsync(request);
            }
            catch { throw; }
            return result;
        }
        public async Task<List<Professor>> GetInfoCardsAsync(Guid tenantId)
        {
            var result = new List<Professor>();
            try
            {
                result = await DbSet
                                .IgnoreQueryFilters()
                                .Where(x => x.Tenant.Id == tenantId)
                                .ToListAsync();
            }
            catch { throw; }
            return result;
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
        #endregion

        #region Métodos is not multitenants
        public async Task<Professor> GetAtivoInativoAsync(string cpf)
        {
            try
            {
                return await DbSet
                                .AsNoTracking()
                                .IgnoreQueryFilters()
                                .Include(x => x.ApplicationUser)
                                .FirstOrDefaultAsync(x => x.Cpf.Contains(cpf));
            }
            catch { throw; }
        }
        public async Task<Professor> GetByNomeAsync(Guid tenantId, string nome)
        {
            var professor = new Professor();
            try
            {
                professor = await DbSet
                                    .FirstOrDefaultAsync(x => x.Tenant.Id == tenantId &&
                                                         x.Nome == nome);
            }
            catch { throw; }
            return professor;
        }
        public Guid GetIdByNome(string nome)
        {
            var id = DbSet
                        .Where(x => x.Nome == nome)
                        .Select(x => x.Id)
                        .FirstOrDefault();
            return id;
        }
        public bool AlreadySameUserId(string applicationUserId)
        {
            var result = DbSet
                            .Include(x => x.ApplicationUser)
                            .Any(x => x.ApplicationUser.Id == applicationUserId);
            return result;
        }
        public async Task<bool> AlreadySameUserIdAsync(string applicationUserId, Guid id)
        {
            bool result;
            try
            {
                result = await DbSet
                                .Include(x => x.ApplicationUser)
                                .AnyAsync(x => x.ApplicationUser.Id == applicationUserId &&
                                          x.Id != id);
            }
            catch { throw; }
            return result;
        }
        public async Task<bool> AlreadyAtivoSameCPFAsync(string cpf, Guid id)
        {
            bool result;
            try
            {
                result = await DbSet
                                .Include(x => x.ApplicationUser)
                                .AnyAsync(x => x.Cpf == cpf &&
                                          x.Id != id);
            }
            catch { throw; }
            return result;
        }
        #endregion

        #region Métodos pendentes para implementar tenancy
        #endregion
    }
}