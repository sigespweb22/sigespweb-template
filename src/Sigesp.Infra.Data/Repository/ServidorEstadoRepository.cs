using System;
using System.Data;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Sigesp.Domain.Interfaces;
using Sigesp.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Sigesp.Domain.Models;

namespace Sigesp.Infra.Data.Repository
{
    public class ServidorEstadoRepository : Repository<ServidorEstado>, IServidorEstadoRepository
    {
        public ServidorEstadoRepository(SigespDbContext context)
            : base(context)
        {
        }

        #region Not tenants
        public async Task<ServidorEstado> GetAsync(string userId)
        {
            var result = new ServidorEstado();
            try
            {
                result = await DbSet
                                .Include(x => x.ServidoresEstadoReforcos)
                                .FirstOrDefaultAsync(x => x.ApplicationUser.Id == userId);
            }
            catch (Exception ex) { throw ex; }
            return result;
        }
        #endregion
    }
}