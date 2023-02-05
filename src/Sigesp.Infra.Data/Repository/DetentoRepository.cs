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
using Sigesp.Domain.Models.DataTable;
using Sigesp.Infra.Data.Extensions;
using Sigesp.Infra.Data.Extensions.DataTable;

namespace Sigesp.Infra.Data.Repository
{
    public class DetentoRepository : Repository<Detento>, IDetentoRepository
    {
        private readonly ITenantRepository _tenantRepository;

        public DetentoRepository(SigespDbContext context,
                                 ITenantRepository tenantRepository)
            : base(context)
        {
            _tenantRepository = tenantRepository;
        }

        #region Métodos multitenants
        public new IEnumerable<Detento> GetAll()
        {
            var tenantId = StringHelpers.ExtractTenantId(_tenantRepository.GetTenantId());
            var result = new List<Detento>();

            if (tenantId != null && tenantId != Guid.Empty)
            {
                result =  DbSet
                            .AsNoTracking()
                            .Where(x => x.Tenant.Id == tenantId)
                            .ToList();
            }
            return result;
        }
        public new async Task<IEnumerable<Detento>> GetAllAsync()
        {
            var tenantId = StringHelpers.ExtractTenantId(await _tenantRepository.GetTenantIdAsync());
            var result = new List<Detento>();

            if (tenantId != null && tenantId != Guid.Empty)
            {
                result =  await DbSet
                                .AsNoTracking()
                                .Where(x => x.Tenant.Id == tenantId)
                                .ToListAsync();
            }
            return result;
        }
        public Detento GetByNome(string nome)
        {
            var tenantId = StringHelpers.ExtractTenantId(_tenantRepository.GetTenantId());
            var result = new Detento();

            if (tenantId != null && tenantId != Guid.Empty)
            {
                result =  DbSet
                            .AsNoTracking()
                            .IgnoreQueryFilters()
                            .Include(x => x.Tenant)
                            .Where(x => x.Tenant.Id == tenantId &&
                                    x.Nome == nome)
                            .Where(d => d.IsDeleted == true || d.IsDeleted == false)
                            .FirstOrDefault();
            }
            return result;
        }
        public async Task<Detento> GetByNomeAsync(string nome)
        {
            var tenantId = StringHelpers.ExtractTenantId(await _tenantRepository.GetTenantIdAsync());
            var result = new Detento();

            if (tenantId != null && tenantId != Guid.Empty)
            {
                result = await DbSet
                                .AsNoTracking()
                                .IgnoreQueryFilters()
                                .Include(x => x.Tenant)
                                .Where(x => x.Tenant.Id == tenantId &&
                                        x.Nome == nome)
                                .Where(d => d.IsDeleted == true || d.IsDeleted == false)
                                .FirstOrDefaultAsync();
            }
            return result;
        }
        public async Task<IEnumerable<Detento>> GetAllByNomeAsync(string nome)
        {
            var tenantId = StringHelpers.ExtractTenantId(await _tenantRepository.GetTenantIdAsync());
            var result = new List<Detento>();

            if (tenantId != null && tenantId != Guid.Empty)
            {
                result = await DbSet
                                .Include(x => x.Tenant)
                                .Where(x => x.Tenant.Id == tenantId &&
                                       x.Nome == nome)
                                .ToListAsync();
            }
            return result;
        }
        public async Task<DetentoRegimeEnum> GetRegimeByNomeAsync(string nome)
        {
            var tenantId = StringHelpers.ExtractTenantId(await _tenantRepository.GetTenantIdAsync());
            var result = DetentoRegimeEnum.NENHUM;

            if (tenantId != null && tenantId != Guid.Empty)
            {
                result = await DbSet
                                .IgnoreQueryFilters()
                                .AsNoTracking()
                                .Include(x => x.Tenant)
                                .Where(x => x.Tenant.Id == tenantId &&
                                       x.Nome == nome)
                                .Where(d => d.IsDeleted == true || d.IsDeleted == false)
                                .Select(x => x.Regime)
                                .FirstOrDefaultAsync();
            }
            return result;
        }
        public async Task<Int64> GetIpenByNomeAsync(string nome)
        {
            var tenantId = StringHelpers.ExtractTenantId(await _tenantRepository.GetTenantIdAsync());
            Int64 result = 0;

            if (tenantId != null && tenantId != Guid.Empty)
            {
                result = await DbSet
                                .IgnoreQueryFilters()
                                .AsNoTracking()
                                .Include(x => x.Tenant)
                                .Where(x => x.Tenant.Id == tenantId &&
                                        x.Nome == nome)
                                .Where(d => d.IsDeleted == true || d.IsDeleted == false)
                                .Select(x => x.Ipen)
                                .FirstOrDefaultAsync();
            }
            return result;
        }
        public async Task<Detento> GetIpenAndGaleriaByNomeAsync(string detentoNome)
        {
            var tenantId = StringHelpers.ExtractTenantId(await _tenantRepository.GetTenantIdAsync());
            var result = new Detento();

            if (tenantId != null && tenantId != Guid.Empty)
            {
                result = await DbSet
                                .IgnoreQueryFilters()
                                .AsNoTracking()
                                .Include(x => x.Tenant)
                                .Where(x => x.Tenant.Id == tenantId &&
                                        x.Nome.Contains(detentoNome))
                                .Where(d => d.IsDeleted == true || d.IsDeleted == false)
                                .Select(x => new Detento {
                                    Ipen = x.Ipen,
                                    Galeria = x.Galeria
                                })
                                .FirstOrDefaultAsync();
            }
            return result;
        }
        public async Task<int> GetIpenByIdAsync(string id)
        {
            var tenantId = StringHelpers.ExtractTenantId(await _tenantRepository.GetTenantIdAsync());
            Int32 result = 0;
            Guid idParsed;
            Guid.TryParse(id, out idParsed);

            if (tenantId != null && tenantId != Guid.Empty)
            {
                result = await DbSet
                                .IgnoreQueryFilters()
                                .AsNoTracking()
                                .Include(x => x.Tenant)
                                .Where(x => x.Tenant.Id == tenantId &&
                                       x.Id == idParsed)
                                .Where(d => d.IsDeleted == true || d.IsDeleted == false)
                                .Select(x => x.Ipen)
                                .FirstOrDefaultAsync();
            }
            return result;
        }
        public async Task<Detento> GetIpenAndRegimeByNomeAsync(string detentoNome)
        {
            var tenantId = StringHelpers.ExtractTenantId(await _tenantRepository.GetTenantIdAsync());
            var result = new Detento();

            if (tenantId != null && tenantId != Guid.Empty)
            {
                result = await DbSet
                                .IgnoreQueryFilters()
                                .AsNoTracking()
                                .Include(x => x.Tenant)
                                .Where(x => x.Tenant.Id == tenantId &&
                                       x.Nome == detentoNome)
                                .Where(d => d.IsDeleted == true || d.IsDeleted == false)
                                .Select(x => new Detento {
                                    Ipen = x.Ipen,
                                    Regime = x.Regime
                                })
                                .FirstOrDefaultAsync();
            }
            return result;
        }
        public async Task<Detento> GetIdAndNomeByIpenOrNomeAsync(string property, string arg)
        {
            var tenantId = StringHelpers.ExtractTenantId(await _tenantRepository.GetTenantIdAsync());
            var result = new Detento();

            if (tenantId != null && tenantId != Guid.Empty)
            {
                if (property == "Ipen")
                {
                    result = await DbSet
                                    .IgnoreQueryFilters()
                                    .AsNoTracking()
                                    .Include(x => x.Tenant)
                                    .Where(x => x.Tenant.Id == tenantId)
                                    .Where(d => d.IsDeleted == true || d.IsDeleted == false)
                                    .Where(x => EF.Functions.Like(x.Ipen.ToString(), 
                                            "%" + arg + "%"))
                                    .Select(x => new Detento {
                                        Id = x.Id,
                                        Nome = x.Nome
                                    })
                                    .FirstOrDefaultAsync();
                }
                else
                {
                    result = await DbSet
                                    .IgnoreQueryFilters()
                                    .AsNoTracking()
                                    .Include(x => x.Tenant)
                                    .Where(x => x.Tenant.Id == tenantId)
                                    .Where(d => d.IsDeleted == true || d.IsDeleted == false)
                                    .Where(x => x.Nome.Contains(arg))
                                    .Select(x => new Detento {
                                        Id = x.Id,
                                        Nome = x.Nome
                                    })
                                    .FirstOrDefaultAsync();
                }
            }
            return result;
        }
        public async Task<IEnumerable<Detento>> GetAllOnlyIsDeletedTrueAsync()
        {
            var tenantId = StringHelpers.ExtractTenantId(await _tenantRepository.GetTenantIdAsync());
            var result = new List<Detento>();

            if (tenantId != null && tenantId != Guid.Empty)
            {
                result = await DbSet
                                .IgnoreQueryFilters()
                                .Include(x => x.Tenant)
                                .Where(x => x.Tenant.Id == tenantId)
                                .Where(x => x.IsDeleted == true)
                                .ToListAsync();
            }
            return result;
        }
        public IEnumerable<Detento> GetAllDeletedTrueAndFalseWithoutInclude()
        {
            var tenantId = StringHelpers.ExtractTenantId(_tenantRepository.GetTenantId());
            var result = new List<Detento>();

            if (tenantId != null && tenantId != Guid.Empty)
            {
                result = DbSet  
                            .IgnoreQueryFilters()
                            .Include(x => x.Tenant)
                            .Where(x => x.Tenant.Id == tenantId)
                            .Where(x => x.IsDeleted == false || x.IsDeleted == true)
                            .OrderByDescending(x => x.CreatedAt)
                            .ToList();
            }
            return result;
        }
        public async Task<int> TotalMDAsync()
        {
            var tenantId = StringHelpers.ExtractTenantId(await _tenantRepository.GetTenantIdAsync());
            Int32 result = 0;

            if (tenantId != null && tenantId != Guid.Empty)
            {
                result = await DbSet
                                .IgnoreQueryFilters()
                                .Include(x => x.Tenant)
                                .Where(x => x.Tenant.Id == tenantId)
                                .CountAsync(x => x.Regime == DetentoRegimeEnum.TRANSFERIDO &&
                                            x.TransferenciaTipo == TransferenciaTipoEnum.MEDIDA_DISCIPLINAR);
            }
            return result;
        }
        public async Task<int> TotalEmAudienciaAsync()
        {
            var tenantId = StringHelpers.ExtractTenantId(await _tenantRepository.GetTenantIdAsync());
            Int32 result = 0;

            if (tenantId != null && tenantId != Guid.Empty)
            {
                result = await DbSet
                                .IgnoreQueryFilters()
                                .Include(x => x.Tenant)
                                .Where(x => x.Tenant.Id == tenantId)
                                .CountAsync(x => x.Regime == DetentoRegimeEnum.TRANSFERIDO && 
                                            x.TransferenciaTipo == TransferenciaTipoEnum.AUDIENCIA);
            }
            return result;
        }
        public IEnumerable<Detento> GetAllByTransferenciaTipoDataSaida(TransferenciaTipoEnum transferenciaTipo,
                                                                        DateTime dataInicio, DateTime dataFim) 
        {
            var tenantId = StringHelpers.ExtractTenantId(_tenantRepository.GetTenantId());
            var result = new List<Detento>();

            if (tenantId != null && tenantId != Guid.Empty)
            {
                result = DbSet
                            .IgnoreQueryFilters()
                            .Include(x => x.Tenant)
                            .Where(x => x.Tenant.Id == tenantId)
                            .Where(x => x.Regime == DetentoRegimeEnum.TRANSFERIDO
                                        && x.TransferenciaTipo == transferenciaTipo
                                        && x.TransferenciaDataSaida.Date.Date >= dataInicio.Date
                                        && x.TransferenciaDataSaida.Date <= dataFim.Date)
                            .ToList();
            }
            return result;
        }
        public IEnumerable<Detento> GetAllByTransferenciaTipo(TransferenciaTipoEnum transferenciaTipo) 
        {
            var tenantId = StringHelpers.ExtractTenantId(_tenantRepository.GetTenantId());
            var result = new List<Detento>();

            if (tenantId != null && tenantId != Guid.Empty)
            {
                result = DbSet
                            .IgnoreQueryFilters()
                            .Include(x => x.Tenant)
                            .Where(x => x.Tenant.Id == tenantId)
                            .Where(x => x.Regime == DetentoRegimeEnum.TRANSFERIDO && 
                                    x.TransferenciaTipo == transferenciaTipo)
                            .ToList();
            }
            return result;
        }
        public IEnumerable<Detento> GetAllByTransferenciaTipoDataRetornoPrevisto(TransferenciaTipoEnum transferenciaTipo,
                                                                                 DateTime dataInicio, DateTime dataFim) 
        {
            var tenantId = StringHelpers.ExtractTenantId(_tenantRepository.GetTenantId());
            var result = new List<Detento>();

            if (tenantId != null && tenantId != Guid.Empty)
            {
                result = DbSet
                            .IgnoreQueryFilters()
                            .Include(x => x.Tenant)
                            .Where(x => x.Tenant.Id == tenantId)
                            .Where(x => x.Regime == DetentoRegimeEnum.TRANSFERIDO
                                        && x.TransferenciaTipo == transferenciaTipo
                                        && x.TransferenciaDataRetornoPrevisto.Date.Date >= dataInicio.Date
                                        && x.TransferenciaDataRetornoPrevisto.Date <= dataFim.Date)
                            .ToList();
            }
            return result;
        }
        public IEnumerable<Detento> GetAllByDataSaida(DateTime dataInicio, DateTime dataFim) 
        {
            var tenantId = StringHelpers.ExtractTenantId(_tenantRepository.GetTenantId());
            var result = new List<Detento>();

            if (tenantId != null && tenantId != Guid.Empty)
            {
                result = DbSet
                            .IgnoreQueryFilters()
                            .Include(x => x.Tenant)
                            .Where(x => x.Tenant.Id == tenantId)
                            .Where(x => x.Regime == DetentoRegimeEnum.TRANSFERIDO
                                        && x.TransferenciaDataSaida.Date >= dataInicio.Date
                                        && x.TransferenciaDataSaida.Date <= dataFim.Date)
                            .ToList();
            }
            return result;
        }
        public IEnumerable<Detento> GetAllByDataRetornoPrevisto(DateTime dataInicio, DateTime dataFim) 
        {
            var tenantId = StringHelpers.ExtractTenantId(_tenantRepository.GetTenantId());
            var result = new List<Detento>();

            if (tenantId != null && tenantId != Guid.Empty)
            {
                result = DbSet
                            .IgnoreQueryFilters()
                            .Include(x => x.Tenant)
                            .Where(x => x.Tenant.Id == tenantId)
                            .Where(x => x.Regime == DetentoRegimeEnum.TRANSFERIDO
                                        && x.TransferenciaDataRetornoPrevisto.Date >= dataInicio.Date
                                        && x.TransferenciaDataRetornoPrevisto.Date <= dataFim.Date)
                            .ToList();
            }
            return result;
        }
        public IEnumerable<Detento> GetAllTransferidos() 
        {
            var tenantId = StringHelpers.ExtractTenantId(_tenantRepository.GetTenantId());
            var result = new List<Detento>();

            if (tenantId != null && tenantId != Guid.Empty)
            {
                result = DbSet
                            .IgnoreQueryFilters()
                            .Include(x => x.Tenant)
                            .Where(x => x.Tenant.Id == tenantId)
                            .Where(x => x.Regime == DetentoRegimeEnum.TRANSFERIDO)
                            .ToList();
            }
            return result;
        }
        public async Task<IEnumerable<Detento>> GetAllByRegimeAsync(DetentoRegimeEnum? regime)
        {
            var tenantId = StringHelpers.ExtractTenantId(await _tenantRepository.GetTenantIdAsync());
            var result = new List<Detento>();

            if (tenantId != null && tenantId != Guid.Empty)
            {
                if (regime != 0)
                {
                    result = await DbSet
                                    .Include(x => x.Tenant)
                                    .Where(x => x.Tenant.Id == tenantId &&
                                           x.Regime == regime)
                                    .ToListAsync();
                }
                else
                {
                    result = await DbSet
                                    .Include(x => x.Tenant)
                                    .Where(x => x.Tenant.Id == tenantId)
                                    .ToListAsync();
                }
            }
            return result.OrderBy(x => x.Galeria);
        }
        public IEnumerable<Detento> GetAllByRegime(DetentoRegimeEnum? regime)
        {
            var tenantId = StringHelpers.ExtractTenantId(_tenantRepository.GetTenantId());
            var result = new List<Detento>();

            if (tenantId != null && tenantId != Guid.Empty)
            {
                if (regime != 0)
                {
                    result = DbSet
                                .Include(x => x.Tenant)
                                .Where(x => x.Tenant.Id == tenantId &&
                                        x.Regime == regime)
                                .ToList();
                }
                else
                {
                    result = DbSet
                                .Include(x => x.Tenant)
                                .Where(x => x.Tenant.Id == tenantId)
                                .ToList();
                }
            }
            return result.OrderBy(x => x.Galeria);
        }
        public async Task<Detento> GetByIpenAsync(int ipen)
        {
            var tenantId = StringHelpers.ExtractTenantId(await _tenantRepository.GetTenantIdAsync());
            var result = new Detento();

            if (tenantId != null && tenantId != Guid.Empty)
            {
                result = await DbSet
                                .Include(x => x.Tenant)
                                .Where(x => x.Tenant.Id == tenantId)
                                .FirstOrDefaultAsync(x => x.Ipen == ipen);
            }
            return result;
        }
        public Detento GetByIpen(int ipen)
        {
            var result = new Detento();
            try
            {
                result = DbSet
                            .FirstOrDefault(x => x.Ipen == ipen);
            }
            catch { throw; }
            return result;
        }
        public Detento GetInativoByIpen(int ipen)
        {
            var result = new Detento();
            try
            {
                result = DbSet
                            .IgnoreQueryFilters()
                            .Where(x => x.IsDeleted)
                            .FirstOrDefault(x => x.Ipen == ipen);
            }
            catch { throw; }
            return result;
        }
        public async Task<Detento> GetByIpenIgnoreQueryFiltersAsync(int ipen)
        {
            var tenantId = StringHelpers.ExtractTenantId(await _tenantRepository.GetTenantIdAsync());
            var result = new Detento();

            if (tenantId != null && tenantId != Guid.Empty)
            {
                result = await DbSet
                                .IgnoreQueryFilters()
                                .Include(x => x.Tenant)
                                .Where(x => x.Tenant.Id == tenantId)
                                .FirstOrDefaultAsync(x => x.Ipen == ipen);
            }
            return result;
        }
        public async Task<Detento> GetIpenRegimeByNomeAsync(string nome)
        {
            var tenantId = StringHelpers.ExtractTenantId(await _tenantRepository.GetTenantIdAsync());
            var result = new Detento();

            if (tenantId != null && tenantId != Guid.Empty)
            {
                result  = await DbSet
                                    .Include(x => x.Tenant)
                                    .Where(x => x.Tenant.Id == tenantId &&
                                            x.Nome == nome)
                                    .FirstOrDefaultAsync();
            }
            return result;
        }
        public async Task<IEnumerable<Detento>> GetAllWithInactiveAsync()
        {
            var tenantId = StringHelpers.ExtractTenantId(await _tenantRepository.GetTenantIdAsync());
            var result = new List<Detento>();

            if (tenantId != null && tenantId != Guid.Empty)
            {
                result = await DbSet
                                .IgnoreQueryFilters()
                                .Include(x => x.Tenant)
                                .Where(x => x.Tenant.Id == tenantId)
                                .ToListAsync();
            }
            return result;
        }
        public async Task<Detento> GetForEditByIpenAsync(int ipen)
        {
            var tenantId = StringHelpers.ExtractTenantId(await _tenantRepository.GetTenantIdAsync());
            var result = new Detento();

            if (tenantId != null && tenantId != Guid.Empty)
            {
                result = await DbSet
                                .IgnoreQueryFilters()
                                .Include(x => x.Tenant)
                                .Where(x => x.Tenant.Id == tenantId &&
                                        x.Ipen == ipen)
                                .FirstOrDefaultAsync();
            }
            return result;
        }
        public Guid? GetIdByIpen(int ipen)
        {
            var tenantId = StringHelpers.ExtractTenantId(_tenantRepository.GetTenantId());
            Guid result = new Guid();

            if (tenantId != null && tenantId != Guid.Empty)
            {
                var tmp = DbSet
                            .Include(x => x.Tenant)
                            .Where(x => x.Tenant.Id == tenantId &&
                                    x.Ipen == ipen)
                            .Select(c => new { c.Id, c.Ipen })
                            .FirstOrDefault();
                
                if (tmp != null && tmp.Id != Guid.Empty)
                    result = tmp.Id;
            }
            return result;
        }
        public Detento GetForUpdateByIpen(int ipen)
        {
            var tenantId = StringHelpers.ExtractTenantId(_tenantRepository.GetTenantId());
            var result = new Detento();

            if (tenantId != null && tenantId != Guid.Empty)
            {
                result = DbSet
                            .AsNoTracking()
                            .Include(x => x.Tenant)
                            .Where(x => x.Tenant.Id == tenantId &&
                                    x.Ipen == ipen)
                            .FirstOrDefault();
            }
            return result;
        }
        public async Task<long> GetTotalAtivosAsync()
        {
            var tenantId = StringHelpers.ExtractTenantId(await _tenantRepository.GetTenantIdAsync());
            Int64 result = 0;

            if (tenantId != null && tenantId != Guid.Empty)
            {
                result = await DbSet
                                .Include(x => x.Tenant)
                                .Where(x => x.Tenant.Id == tenantId)
                                .CountAsync(x => x.IsDeleted == false);
            }
            return result;
        }
        public async Task<DataTableServerSideResult<Detento>> GetWithDataTableResultAsync(DataTableServerSideRequest request)
        {
            var tenantId = StringHelpers.ExtractTenantId(await _tenantRepository.GetTenantIdAsync());
            var result = new DataTableServerSideResult<Detento>();

            if (tenantId != null && tenantId != Guid.Empty)
            {
                result = await DbSet
                                .AsNoTracking()
                                .Include(x => x.Tenant)
                                .OrderBy(x => x.CreatedAt)
                                .Where(x => x.Tenant.Id == tenantId)
                                .GetDatatableResultAsync(request);
            }
            return result;
        }
        #endregion Métodos tenants

        #region Métodos is not multitenants
        public async Task<IEnumerable<Detento>> GetAIFullAsync()
        {
            var result =  await DbSet
                                    .AsNoTracking()
                                    .IgnoreQueryFilters()
                                    .Where(x => x.IsDeleted ||
                                          !x.IsDeleted)
                                    .ToListAsync();
            return result;
        }
        public bool IsAlreadyByIpen(int ipen, Guid tenantId)
        {
            var result = DbSet
                            .Any(x => x.Tenant.Id == tenantId &&
                                 x.Ipen == ipen);
            return result;
        }
        public bool IsAlreadyByIpen(int ipen)
        {
            var result = DbSet
                            .Any(x => x.Ipen == ipen);
            return result;
        }
        public async Task<Detento> GetInativoAsync(int ipen)
        {
            var result = await DbSet
                                .IgnoreQueryFilters()
                                .Where(x => x.IsDeleted == true)
                                .FirstOrDefaultAsync(x => x.Ipen == ipen);
            return result;
        }
        public async Task<bool> CheckAlreadyTenancyDiff(int ipen, Guid tenantId)
        {
            bool result;
            try
            {
                result = await DbSet
                                    .AnyAsync(x => x.Ipen == ipen &&
                                              x.Tenant.Id != tenantId);
            }
            catch (Exception ex) { throw ex; }
            return result;
        }
        #endregion

        #region Métodos pendentes para implementar tenancy
        public Detento GetIpenAndRegimeByColaboradorId(string colaboradorId)
        {
            Guid idParsed;
            Guid.TryParse(colaboradorId, out idParsed);

            var result = DbSet
                            .AsNoTracking()
                            .IgnoreQueryFilters()
                            .Include(x => x.Colaboradores.Where(x => x.Id == idParsed))
                            .Where(d => d.IsDeleted == true || d.IsDeleted == false)
                            .Select(x => new Detento {
                                Ipen = x.Ipen,
                                Regime = x.Regime
                            })
                            .FirstOrDefault();
                            
            return result;
        }
        public int TotalInstrumentoPrisaoMD()
        {
            var detentos = DbSet
                    .IgnoreQueryFilters()
                    .Include(x => x.ListaAmarela)
                    .Where(x => x.ListaAmarela.IsDeleted == false)
                    .ToList();

            var dtFiltered = new List<Detento>();

            foreach (var detento in detentos.ToList())
            {
                foreach (var ip in detento.ListaAmarela.InstrumentosPrisao.ToList())
                {
                    if (ip == InstrumentoPrisaoTipoEnum.MEDIDA_DISCIPLINAR)
                    {
                        dtFiltered.Add(detento);
                        continue;
                    }
                }
            }

            return dtFiltered.Count();
        }
        public IEnumerable<Detento> GetByIpenAtivoInativo(int ipen)
        {
            var result = DbSet
                            .IgnoreQueryFilters()
                            .Include(x => x.Colaboradores)
                            .Include(x => x.AndamentoPenal)
                            .Include(x => x.ListaAmarela)
                            .Include(x => x.Aluno);

            return result.Where(x => x.Ipen == ipen).ToList();
        }
        #endregion Métodos pendentes para implementar tenancy
    }
}