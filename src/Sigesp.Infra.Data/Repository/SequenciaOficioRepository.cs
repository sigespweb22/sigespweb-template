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
using Sigesp.Domain.Enums;

namespace Sigesp.Infra.Data.Repository
{
    public class SequenciaOficioRepository : Repository<SequenciaOficio>, ISequenciaOficioRepository
    {
        public SequenciaOficioRepository(SigespDbContext context)
            : base(context)
        {
        }

        public IEnumerable<int> GetSequencias(Guid tenantId, SetorEnum setor)
        {
            IEnumerable<int> result = new List<int>();
            try
            {
                result =  DbSet
                            .Where(x => x.Tenant.Id == tenantId &&
                                x.Setor == setor)
                            .Select(x => x.Sequencia)
                            .ToList();
            }
            catch (Exception ex) { throw ex; }
            return result;
        }
    }
}