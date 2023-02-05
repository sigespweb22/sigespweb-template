using System;
using System.Linq;
using Sigesp.Domain.Models;
using Sigesp.Domain.Interfaces;
using Sigesp.Infra.Data.Context;
using Sigesp.Domain.Models.DataTable;
using Sigesp.Infra.Data.Extensions.DataTable;
using System.Threading.Tasks;

namespace Sigesp.Infra.Data.Repository
{
    public class ContabilEventoRepository : Repository<ContabilEvento>, IContabilEventoRepository
    {
        public ContabilEventoRepository(SigespDbContext context)
            : base(context)
        {
            
        }

        public int GetTotalActiveRecords()
        {
            var total = DbSet.Count();

            return total;
        }

        public async Task<DataTableServerSideResult<ContabilEvento>> GetAllWithDataTableResultAsync(DataTableServerSideRequest request)
        {
            var contabilEventosForDataTable = await DbSet
                                                    .OrderBy(x => x.Codigo)
                                                    .GetDatatableResultAsync(request);
            return contabilEventosForDataTable;
        }

        public ContabilEvento GetByEspecificacao (string especificacao)
        {
            var contabilEvento = DbSet
                                    .Where(x => x.Especificacao == especificacao)
                                    .FirstOrDefault();
            return contabilEvento;
        }
    }
}