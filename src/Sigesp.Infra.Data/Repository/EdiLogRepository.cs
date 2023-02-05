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

namespace Sigesp.Infra.Data.Repository
{
    public class EdiLogRepository : Repository<EdiLog>, IEdiLogRepository
    {
        public EdiLogRepository(SigespDbContext context)
            : base(context)
        {
        }

        public IEnumerable<EdiLog> GetAllByEdiId(Guid ediId)
        {
            var ediLogs = DbSet
                            .Include(x => x.Edi)
                            .Where(x => x.EdiId == ediId);

            return ediLogs;
        }
    }
}