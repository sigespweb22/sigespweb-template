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
    public class DisciplinaRepository : Repository<Disciplina>, IDisciplinaRepository
    {
        public DisciplinaRepository(SigespDbContext context)
            : base(context)
        {
        }

        public IEnumerable<Disciplina> GetAllWithIncludes()
        {
             var disciplinas = DbSet
                                .Include(x => x.Professor)
                                .ToList();
                            
            return disciplinas;
        }

        public Int64 GetTotalAtivos()
        {
            var ativos = DbSet
                            .Count();
            return ativos;
        }

        public Int64 GetTotalInativos()
        {
            var inativos = DbSet
                            .IgnoreQueryFilters()
                            .Where(x => x.IsDeleted == true)
                            .Count();
            return inativos;
        }

        public Int64 GetTotalWithIgnoreQueryFilter()
        {
            var total = DbSet
                            .IgnoreQueryFilters()
                            .Count();
            return total;
        }
    }
}