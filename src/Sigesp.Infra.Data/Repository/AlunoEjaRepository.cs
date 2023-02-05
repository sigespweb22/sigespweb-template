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
using Sigesp.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Sigesp.Domain.Enums;
using Sigesp.Domain.Models;
using Sigesp.Domain.Models.DataTable;
using Sigesp.Infra.Data.Extensions.DataTable;

namespace Sigesp.Infra.Data.Repository
{
    public class AlunoEjaRepository : Repository<AlunoEja>, IAlunoEjaRepository
    {
        public AlunoEjaRepository(SigespDbContext context)
            : base(context)
        {
        }

        public async Task<IEnumerable<AlunoEja>> GetAllAsync(Guid tenantId) 
        {
            IEnumerable<AlunoEja> result = new List<AlunoEja>();
            try
            {
                result = await DbSet
                                .Where(x => x.Tenant.Id == tenantId)
                                .ToListAsync(); 
            }
            catch { throw; }
            return result;
        }
        public IEnumerable<AlunoEja> GetAllWithIncludes()
        {
             var alunosEjas = DbSet
                                .IgnoreQueryFilters()
                                .Include(c => c.Aluno)
                                .ThenInclude(c => c.Detento)
                                .Where(x => x.Aluno.Detento.IsDeleted == false
                                        ||
                                        x.Aluno.Detento.IsDeleted == true)
                                .Where(x => x.IsDeleted == false)
                                .ToList();
            
            return alunosEjas;
        }
        public AlunoEja GetByIdIncludes(Guid id)
        {
             var alunoEja = DbSet
                            .AsNoTracking()
                            .IgnoreQueryFilters()
                            .Include(c => c.AlunoEjaDisciplinas)
                            .Include(c => c.Aluno)
                            .ThenInclude(c => c.Detento)
                            .Where(x => x.Aluno.IsDeleted == false
                                    ||
                                    x.Aluno.IsDeleted == true)
                            .Where(x => x.Aluno.Detento.IsDeleted == false
                                    ||
                                    x.Aluno.Detento.IsDeleted == true)
                            .Where(x => x.IsDeleted == false && x.Id == id)
                            .FirstOrDefault();

            return alunoEja;
        }
        public Int64 GetTotalAtivos()
        {
            var ativos = DbSet
                            .IgnoreQueryFilters()
                            .Include(c => c.Aluno)
                            .ThenInclude(c => c.Detento)
                            .Where(x => x.Aluno.Detento.IsDeleted == false
                                    ||
                                    x.Aluno.Detento.IsDeleted == true)
                            .Where(x => x.IsDeleted == false)
                            .Select(x => x.Aluno.Detento.Ipen)
                            .Distinct()
                            .Count();
            return ativos;
        }
        public async Task<Int64> GetTotalInativosAsync(Guid tenantId)
        {
            Int64 result;
            try
            {
                result = await DbSet
                                .IgnoreQueryFilters()
                                .Include(c => c.Aluno)
                                .ThenInclude(c => c.Detento)
                                .Where(x => x.Tenant.Id == tenantId)
                                .Where(x => x.Aluno.Detento.IsDeleted == false
                                        ||
                                        x.Aluno.Detento.IsDeleted == true)
                                .Where(x => x.IsDeleted == true)
                                .Select(x => x.Aluno.Detento.Ipen)
                                .Distinct()
                                .CountAsync();
            }
            catch { throw; }
            return result;
        }
        public Int64 GetTotalWithIgnoreQueryFilter()
        {
            var total = DbSet
                            .IgnoreQueryFilters()
                            .Include(c => c.Aluno)
                            .ThenInclude(c => c.Detento)
                            .Where(x => x.Aluno.Detento.IsDeleted == false
                                    ||
                                    x.Aluno.Detento.IsDeleted == true)
                            .Where(x => x.IsDeleted == false)
                            .Select(x => x.Aluno.Detento.Ipen)
                            .Distinct()
                            .Count();
            return total;
        }
        public bool AlreadyAlunoEjaAtivoByIpen(int ipen)
        {
            var alreadyAlunoEjaAtivoByIpen = DbSet
                                                .Any(x => x.Aluno.Detento.Ipen == ipen);
                                            
            return alreadyAlunoEjaAtivoByIpen;
        }
        public AlunoEja GetByDetentoIpen(int ipen)
        {
            var alunoEja = DbSet
                                .Include(c => c.Aluno)
                                .ThenInclude(c => c.Detento)
                                .FirstOrDefault(x => x.Aluno.Detento.Ipen == ipen);

            return alunoEja;
        }
        public AlunoEja GetInativoByDetentoIpen(int ipen)
        {
            var alunoEja = DbSet
                                .AsNoTracking()
                                .IgnoreQueryFilters()
                                .Include(c => c.Aluno)
                                .ThenInclude(c => c.Detento)
                                .Where(x => x.Aluno.Detento.IsDeleted == false
                                        ||
                                        x.Aluno.Detento.IsDeleted == true)
                                .Where(x => x.IsDeleted == true
                                       && 
                                       x.Aluno.Detento.Ipen == ipen)
                                .FirstOrDefault();

            return alunoEja;
        }
        public AlunoEja GetAtivoOrInativoByDetentoIpen(int ipen)
        {
            var alunoEja = DbSet
                                .AsNoTracking()
                                .IgnoreQueryFilters()
                                .Include(c => c.Aluno)
                                .ThenInclude(c => c.Detento)
                                .Where(x => x.Aluno.Detento.IsDeleted == false
                                        ||
                                        x.Aluno.Detento.IsDeleted == true)
                                .Where(x => x.IsDeleted == false
                                        || x.IsDeleted == true
                                        &&
                                        x.Aluno.Detento.Ipen == ipen)
                                .FirstOrDefault();

            return alunoEja;
        }
        public async Task<Int64> GetTotalByFaseStatusAsync(Guid tenantId, AlunoEjaFaseStatusEnum faseStatus)
        {
            Int64 result;
            
            try
            {
                result = await DbSet
                                .IgnoreQueryFilters()
                                .Include(c => c.Aluno)
                                .ThenInclude(c => c.Detento)
                                .Where(x => x.Tenant.Id == tenantId)
                                .Where(x => x.Aluno.Detento.IsDeleted == false
                                        ||
                                        x.Aluno.Detento.IsDeleted == true)
                                .Where(e => EF.Property<AlunoEjaFaseStatusEnum>(e, "FaseStatus") == faseStatus
                                        && e.IsDeleted == false)
                                .Select(x => new
                                {
                                    x.Aluno.Detento.Ipen
                                })
                                .Distinct()
                                .CountAsync();
            }
            catch { throw; }
            return result;
        }
        public async Task<Int64> GetTotalByCursoAsync(Guid tenantId, CursoEnum curso)
        {
            Int64 result;
            try
            {
                result= await DbSet
                                .IgnoreQueryFilters()
                                .Include(c => c.Aluno)
                                .ThenInclude(c => c.Detento)
                                .Where(x => x.Tenant.Id == tenantId)
                                .Where(x => x.Aluno.Detento.IsDeleted == false
                                        ||
                                        x.Aluno.Detento.IsDeleted == true)
                                .Where(e => EF.Property<CursoEnum>(e, "Curso") == curso
                                        && e.FaseStatus == AlunoEjaFaseStatusEnum.EM_CURSO
                                        && e.IsDeleted == false)
                                .Select(x => new
                                {
                                    x.Aluno.Detento.Ipen
                                })
                                .Distinct()
                                .CountAsync();
            }
            catch { throw; }
            return result;
        }
        public async Task<Int64> GetTotalByTurnoPeriodoAsync(Guid tenantId, TurnoEnum turno)
        {
            Int64 result;
            try
            {
                result = await DbSet
                                .IgnoreQueryFilters()
                                .Include(c => c.Aluno)
                                .ThenInclude(c => c.Detento)
                                .Where(x => x.Tenant.Id == tenantId)
                                .Where(x => x.Aluno.Detento.IsDeleted == false
                                        ||
                                        x.Aluno.Detento.IsDeleted == true)
                                .Where(e => EF.Property<TurnoEnum>(e, "TurnoPeriodo") == turno
                                        && e.FaseStatus == AlunoEjaFaseStatusEnum.EM_CURSO
                                        && e.IsDeleted == false)
                                .Select(x => new
                                {
                                    x.Aluno.Detento.Ipen
                                })
                                .Distinct()
                                .CountAsync();
            }
            catch { throw; }
            return result;
        }

        #region Methos is not tenants
        public async Task<AlunoEja> GetAsync(int ipen)
        {
            var result = new AlunoEja();
            try
            {
                result = await DbSet
                                .IgnoreQueryFilters()
                                .Include(x => x.AlunoEjaDisciplinas)
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