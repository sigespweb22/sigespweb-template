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
    public class AndamentoPenalRepository : Repository<AndamentoPenal>, IAndamentoPenalRepository
    {
        public AndamentoPenalRepository(SigespDbContext context)
            : base(context)
        {
        }

        public AndamentoPenal GetByDetentoNome(string nome)
        {
            var andamentoPenal = DbSet
                                    .IgnoreQueryFilters()
                                    .Include(x => x.Detento)
                                    .Where(d => d.Detento.IsDeleted == true || d.Detento.IsDeleted == false)
                                    .Where(x => x.Detento.Nome == nome)
                                    .Where(x => x.IsDeleted == false || x.IsDeleted == true)
                                    .FirstOrDefault();

            return andamentoPenal;
        }

        public AndamentoPenal GetByDetentoIpen(int ipen)
        {
            var andamentoPenal = DbSet
                                .IgnoreQueryFilters()
                                .Include(x => x.Detento)
                                .Where(d => d.Detento.IsDeleted == true || d.Detento.IsDeleted == false)
                                .Where(x => x.Detento.Ipen == ipen)
                                .Where(x => x.IsDeleted == false)
                                .FirstOrDefault();

            return andamentoPenal;
        }

        public AndamentoPenal GetByDetentoId(Guid id)
        {
            var andamentoPenal = DbSet
                                    .AsNoTracking()
                                    .IgnoreQueryFilters()
                                    .Include(x => x.Detento)
                                    .Where(d => d.Detento.IsDeleted == true || d.Detento.IsDeleted == false)
                                    .Where(x => x.Detento.Id == id)
                                    .Where(x => x.IsDeleted == true || x.IsDeleted == false)
                                    .FirstOrDefault();

            return andamentoPenal;
        }

        public async Task<DataTableServerSideResult<AndamentoPenal>> GetWithDataTableResultAsync(DataTableServerSideRequest request)
        {
            var andamentoPenalForDataTable = await DbSet
                                                    .AsNoTracking()
                                                    .IgnoreQueryFilters()
                                                    .Include(x => x.Detento)
                                                    .Where(d => d.Detento.IsDeleted == true || d.Detento.IsDeleted == false)
                                                    .Where(x => x.IsDeleted == false)
                                                    .OrderBy(x => x.DataEventoPrincipal)
                                                    .GetDatatableResultAsync(request);
            return andamentoPenalForDataTable;
        }

        public async Task<IEnumerable<AndamentoPenal>> GetAllOnlyIsDeletedTrue()
        {
            var andamentoPenal = await DbSet
                                .IgnoreQueryFilters()
                                .Include(x => x.Detento)
                                .Where(d => d.Detento.IsDeleted == true || d.Detento.IsDeleted == false)
                                .Where(d => d.Detento.IsDeleted == true)
                                .ToListAsync();

            return andamentoPenal;
        }

        public IEnumerable<AndamentoPenal> GetAllWithIgnoreFilter()
        {
             var andamentoPenal = DbSet
                                    .IgnoreQueryFilters()
                                    .Include(x => x.Detento)
                                    .Where(d => d.Detento.IsDeleted == true || d.Detento.IsDeleted == false)
                                    .Where(d => d.IsDeleted == false)
                                    .ToList();

            return andamentoPenal;
        }

        public IEnumerable<AndamentoPenal> GetAllWithInclude()
        {
             var andamentoPenal = DbSet
                                    .IgnoreQueryFilters()
                                    .Include(x => x.Detento)
                                    .Where(d => d.Detento.IsDeleted == true || d.Detento.IsDeleted == false)
                                    .Where(d => d.IsDeleted == false)
                                    .ToList();

            return andamentoPenal;
        }

        public AndamentoPenal GetByIdWithIgnoreFilter(Guid id)
        {
            var andamentoPenal = DbSet
                                .IgnoreQueryFilters()
                                .FirstOrDefault(x => x.Id == id);

            return andamentoPenal;
        }

        public Guid GetIdByDetentoIpen(int ipen)
        {
            var id = DbSet
                        .Where(x => x.Detento.Ipen.Equals(ipen))
                        .Select(x => x.Id)
                        .FirstOrDefault();

            return id;
        }

        public IEnumerable<AndamentoPenal> GetAllByRegimeDataPrevisaoBeneficio(DetentoRegimeEnum regime,
                                                                             DateTime dataInicio, DateTime dataFim) 
        {
            var andamentosPenal = DbSet
                                .Include(x => x.Detento)
                                .Where(x => x.Detento.Regime == regime
                                            && x.DataEventoPrincipal.Date >= dataInicio.Date
                                            && x.DataEventoPrincipal.Date <= dataFim.Date)
                                .OrderByDescending(x => x.DataEventoPrincipal);

            return andamentosPenal;
        }

        public IEnumerable<AndamentoPenal> GetAllByRegime(DetentoRegimeEnum regime) 
        {
            var andamentoPenal = DbSet
                                .Include(x => x.Detento)
                                .Where(x => x.Detento.Regime == regime)
                                .OrderByDescending(x => x.DataEventoPrincipal);
            return andamentoPenal;
        }

        public IEnumerable<AndamentoPenal> GetAllByDataPrevisaoBeneficio(DateTime dataInicio, 
                                                                            DateTime dataFim) 
        {
            var andamentoPenal = DbSet
                                .Include(x => x.Detento)
                                .Where(x => x.DataEventoPrincipal.Date >= dataInicio.Date
                                            && x.DataEventoPrincipal.Date <= dataFim.Date)
                                .OrderByDescending(x => x.DataEventoPrincipal);
            return andamentoPenal;
        }

        public IEnumerable<AndamentoPenal> GetAllByRegimeAll() 
        {
            var andamentoPenal = DbSet
                                .Include(x => x.Detento)
                                .Where(x => x.Detento.Regime.Equals(DetentoRegimeEnum.ALIMENTOS)
                                            || x.Detento.Regime.Equals(DetentoRegimeEnum.PROVISORIO)
                                            || x.Detento.Regime.Equals(DetentoRegimeEnum.RECOLHIDO_EDI)
                                            || x.Detento.Regime.Equals(DetentoRegimeEnum.RECOLHIDO_FECHADO)
                                            || x.Detento.Regime.Equals(DetentoRegimeEnum.RECOLHIDO_IMPORTACAO)
                                            || x.Detento.Regime.Equals(DetentoRegimeEnum.RECOLHIDO_SEMIABERTO)
                                            || x.Detento.Regime.Equals(DetentoRegimeEnum.SAIDA_TEMPORARIA)
                                            || x.Detento.Regime.Equals(DetentoRegimeEnum.PRISAO_TEMPORARIA)
                                            || (x.Detento.Regime.Equals(DetentoRegimeEnum.TRANSFERIDO) && x.Detento.TransferenciaTipo.Equals(TransferenciaTipoEnum.MEDIDA_DISCIPLINAR))
                                            || (x.Detento.Regime.Equals(DetentoRegimeEnum.TRANSFERIDO) && x.Detento.TransferenciaTipo.Equals(TransferenciaTipoEnum.AUDIENCIA)))
                                .OrderByDescending(x => x.DataEventoPrincipal);

            return andamentoPenal;
        }

        public IEnumerable<AndamentoPenal> GetAllByRegimeAlimentosPrisaoTemporariaDataSaidaPrevista(DetentoRegimeEnum regime, 
                                                                                                    DateTime dataInicio,
                                                                                                    DateTime dataFim) 
        {
            var andamentoPenal = DbSet
                                .Include(x => x.Detento)
                                .Where(x => x.Detento.Regime == regime
                                            && x.DataEventoPrincipal.Date >= dataInicio.Date
                                            && x.DataEventoPrincipal.Date <= dataFim.Date)
                                .OrderBy(x => x.DataEventoPrincipal);
            return andamentoPenal;
        }

        public IEnumerable<AndamentoPenal> GetAllByRegimeAlimentosPrisaoTemporaria(DetentoRegimeEnum regime)
        {
            var andamentoPenal = DbSet
                                .Include(x => x.Detento)
                                .Where(x => x.Detento.Regime == regime)
                                .OrderBy(x => x.DataEventoPrincipal);
            return andamentoPenal;
        }

        public AndamentoPenal GetByIdWithInclude(Guid id)
        {
            var andamentoPenal = DbSet
                                    .IgnoreQueryFilters()
                                    .Include(x => x.Detento)
                                    .Where(x => x.Detento.IsDeleted == false || x.Detento.IsDeleted == true)
                                    .Where(x => x.IsDeleted == false && x.Id == id)
                                    .FirstOrDefault();
            
            return andamentoPenal;

        }

        public Int64 GetTotalByStatus(AndamentoPenalStatusEnum status)
        {
            var total = DbSet
                            .Count(e => EF.Property<AndamentoPenalStatusEnum>(e, "Status") == status);
            
            return total;
        }

        public Int64 GetTotal()
        {
            var total = DbSet
                            .Count();
            return total;
        }

        public bool AlreadyAtivoByIpen(int ipen)
        {
            var alreadyAtivoByIpen = DbSet
                                        .Include(x => x.Detento)
                                        .Any(x => x.Detento.Ipen == ipen);
            return alreadyAtivoByIpen;
        }

        public AndamentoPenal RescueInactiveByIpen(int ipen)
        {
            var rescueInactiveByIpen = DbSet
                                        .AsNoTracking()
                                        .IgnoreQueryFilters()
                                        .Include(x => x.Detento)
                                        .Where(x => x.Detento.IsDeleted == false
                                              || x.Detento.IsDeleted == true)
                                        .Where(x => x.IsDeleted == true
                                                && x.Detento.Ipen == ipen)
                                        .FirstOrDefault();
                                        
            return rescueInactiveByIpen;
        }

        public AndamentoPenal GetByIdWithouIncludes(Guid id)
        {
            var result = DbSet
                            .AsNoTracking()
                            .FirstOrDefault(x => x.Id == id);
            
            return result;
        }
    }
}