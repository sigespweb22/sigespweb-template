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
    public class AlunoEjaDisciplinaRepository : Repository<AlunoEjaDisciplina>, IAlunoEjaDisciplinaRepository
    {
        public AlunoEjaDisciplinaRepository(SigespDbContext context)
            : base(context)
        {
        }

        public async Task<IEnumerable<AlunoEjaDisciplina>> GetAllAsync(Guid alunoEjaId)
        {
            IEnumerable<AlunoEjaDisciplina> result = new List<AlunoEjaDisciplina>();
            try
            {
                result = await DbSet
                                .Where(x => x.AlunoEjaId == alunoEjaId &&
                                       x.IsDeleted == false)
                                .ToListAsync();
            }
            catch { throw; }
            return result;
        }
    }
}