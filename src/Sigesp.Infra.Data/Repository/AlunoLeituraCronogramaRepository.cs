using System.Data;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Sigesp.Domain.Interfaces;
using Sigesp.Domain.Models;
using Sigesp.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Sigesp.Infra.Data.Repository
{
    public class AlunoLeituraCronogramaRepository : Repository<AlunoLeituraCronograma>, IAlunoLeituraCronogramaRepository
    {
        public AlunoLeituraCronogramaRepository(SigespDbContext context)
            : base(context)
        {
        }
        
        #region Tenant Method
        public async Task<bool> AlreadyIdenticalPeriodoAsync(Guid tenantId, 
                                                             DateTime periodoInicio, DateTime periodoFim)
        {
            bool alreadyEquals;
            try
            {
                alreadyEquals = await DbSet.AnyAsync(x => x.Tenant.Id == tenantId &&
                                                     x.PeriodoInicio.Date.Equals(periodoInicio.Date) &&
                                                     x.PeriodoFim.Date.Equals(periodoInicio.Date));
            }
            catch { throw; }
            return alreadyEquals;
        }
        public async Task<bool> AlreadyMoreOnePeriodoReferenciaSameAnoAsync(Guid tenantId, 
                                                                            DateTime periodoInicio,
                                                                            int periodoReferencia)
        {
            bool already;
            try
            {
                already = await DbSet
                                    .AnyAsync(x => x.Tenant.Id == tenantId &&
                                              x.PeriodoInicio.Date.Year.Equals(periodoInicio.Date.Year) &&
                                              x.PeriodoReferencia.Equals(periodoReferencia));    
            }
            catch { throw; }
            return already;
        }
        public async Task<bool> AlreadyMoreTwoPeriodosInicioSameMesAnoAsync(Guid tenantId, 
                                                                            DateTime periodoInicio)
        {
            Int64 crngrms;
            try
            {
                crngrms = await DbSet
                                  .CountAsync(x => x.Tenant.Id == tenantId &&
                                              x.PeriodoInicio.Date.Month.Equals(periodoInicio.Date.Month) &&
                                              x.PeriodoInicio.Date.Year.Equals(periodoInicio.Date.Year));    
            }
            catch { throw; }
            if (crngrms >= 2)
                return true;
            return false;
        }
        public async Task<IEnumerable<AlunoLeituraCronograma>> GetAllForSelect2Async(Guid tenantId)
        {
            IEnumerable<AlunoLeituraCronograma> result = new List<AlunoLeituraCronograma>();
            try
            {
                result = await DbSet
                            .Where(x => x.Tenant.Id == tenantId)
                            .Select(x => new AlunoLeituraCronograma()
                            { 
                                Id = x.Id, 
                                Nome = x.Nome,
                                AnoReferencia = x.AnoReferencia,
                                DiasPeriodo = x.DiasPeriodo,
                                PeriodoInicio = x.PeriodoInicio,
                                PeriodoFim = x.PeriodoFim,
                                PeriodoReferencia = x.PeriodoReferencia
                            })
                            .ToListAsync();
            }
            catch { throw; }
            return result;
        }
        public async Task<Int64> GetTotalAtivosAsync(Guid tenantId)
        {
            Int64 ativos;
            try
            {
                ativos = await DbSet
                                   .CountAsync(x => x.Tenant.Id == tenantId);    
            }
            catch { throw; }
            return ativos;
        }
        public async Task<IEnumerable<AlunoLeituraCronograma>> GetAllWithIncludesAsync(Guid tenantId)
        {
            IEnumerable<AlunoLeituraCronograma> alunosLeiturasCronogramas = new List<AlunoLeituraCronograma>();
            try
            {
                alunosLeiturasCronogramas = await DbSet
                                                    .IgnoreQueryFilters()
                                                    .Where(x => x.Tenant.Id == tenantId)
                                                    .ToListAsync();    
            }
            catch { throw; }
            return alunosLeiturasCronogramas;
        }
        public async Task<Int64> GetTotalInativosAsync(Guid tenantId)
        {
            Int64 inativos;
            try
            {
                inativos = await DbSet
                                    .IgnoreQueryFilters()
                                    .CountAsync(x => x.Tenant.Id == tenantId &&
                                                x.IsDeleted == true);    
            }
            catch { throw; }
            return inativos;
        }
        public async Task<Int64> GetTotalWithIgnoreQueryFilterAsync(Guid tenantId)
        {
            Int64 total;
            try
            {
                total = await DbSet
                                .IgnoreQueryFilters()
                                .CountAsync(x => x.Tenant.Id == tenantId);
            }
            catch { throw; }
            return total;
        }
        public async Task<bool> AlreadyMoreOnePeriodoReferenciaSameAnoByIdAsync(Guid tenantId, Guid id,
                                                                                DateTime periodoInicio,
                                                                                int periodoReferencia)
        {
            bool already;
            try
            {
                already = await DbSet
                                    .AnyAsync(x => x.Tenant.Id == tenantId &&
                                              x.PeriodoInicio.Date.Year.Equals(periodoInicio.Date.Year) &&
                                              x.PeriodoReferencia.Equals(periodoReferencia) && 
                                              x.Id != id);    
            }
            catch { throw; }
            return already;
        }
        public async Task<bool> HasCronogramaByAnoAndPeriodoReferenciaAsync(Guid tenantId, int anoReferencia,
                                                                            int periodoReferencia)
        {
            bool result;
            try
            {
                result = await DbSet
                                .AnyAsync(x => x.Tenant.Id == tenantId &&
                                            x.AnoReferencia.Date.Year == anoReferencia &&
                                            x.PeriodoReferencia == periodoReferencia);
            }
            catch { throw; }
            return result;
        }
        public async Task<bool> HasCronogramaByIdAsync(Guid tenantId, Guid id)
        {
            bool result;
            try
            {
                result = await DbSet
                                .AnyAsync(x => x.Tenant.Id == tenantId &&
                                          x.Id == id);
            }
            catch { throw; }
            return result;
        }
        public async Task<AlunoLeituraCronograma> GetByAnoAndPeriodoReferenciaAsync(Guid tenantId, int anoReferencia,
                                                                                    int periodoReferencia)
        {
            var result = new AlunoLeituraCronograma();
            try
            {
                result = await DbSet
                                    .FirstOrDefaultAsync(x => x.Tenant.Id == tenantId &&
                                                 x.AnoReferencia.Date.Year == anoReferencia &&
                                                 x.PeriodoReferencia == periodoReferencia);
            }
            catch { throw; }
            return result;
        }
        public async Task<AlunoLeituraCronograma> GetByIdAsync(Guid tenantId, Guid id)
        {
            var result = new AlunoLeituraCronograma();
            try
            {
                result = await DbSet
                                .AsNoTracking()
                                .FirstOrDefaultAsync(x => x.Tenant.Id == tenantId &&
                                                     x.Id == id);
            }
            catch { throw; }
            return result;
        }
        #endregion

        #region Are is not tenants
        public AlunoLeituraCronograma GetByIdIncludes(Guid id)
        {
             var alunoLeituraCronograma = DbSet
                                .AsNoTracking()
                                .Where(x => x.Id == id)
                                .FirstOrDefault();

            return alunoLeituraCronograma;
        }
        #endregion
    }
}