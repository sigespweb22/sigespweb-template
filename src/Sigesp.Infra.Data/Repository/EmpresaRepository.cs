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
    public class EmpresaRepository : Repository<Empresa>, IEmpresaRepository
    {
        public EmpresaRepository(SigespDbContext context)
            : base(context)
        {
        }
        public async Task<Empresa> GetByIdAsync(int id)
        {
            return await DbSet.FindAsync(id);
        }

        public Empresa GetByRazaoSocial(string razaoSocial)
        {
            var empresa = DbSet
                            .FirstOrDefault(x => x.RazaoSocial == razaoSocial);
            return empresa;
        }
    }
}