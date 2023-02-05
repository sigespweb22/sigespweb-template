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
    public class EmpresaConvenioRepository : Repository<EmpresaConvenio>, IEmpresaConvenioRepository
    {
        public EmpresaConvenioRepository(SigespDbContext context)
            : base(context)
        {
        }

        public async Task<EmpresaConvenio> GetByIdAsync(int id)
        {
            return await DbSet.FindAsync(id);
        }

        public async Task<EmpresaConvenio> GetByIdWithChildrensAsync(Guid id)
        {
            return await DbSet
                            .Include(x => x.Empresa)
                            .FirstOrDefaultAsync(x => x.Id == id);
        }

        public EmpresaConvenio GetByIdWithInclude(Guid id)
        {
            return DbSet
                        .Include(x => x.Empresa)
                        .FirstOrDefault(x => x.Id == id);
        }
        
        public async Task<IEnumerable<EmpresaConvenio>> GetAllWithIncludeAsync()
        {
            var empresaCovenios = await DbSet
                                    .Include(x => x.Empresa)
                                    .ToListAsync();

            return empresaCovenios;
        }

        public IEnumerable<EmpresaConvenio> GetAllWithInclude()
        {
            var empresaCovenios = DbSet
                                    .Include(x => x.Empresa)
                                    .ToList();

            return empresaCovenios;
        }

        public EmpresaConvenio GetByEmpresaCnpj(string cnpj)
        {
            var empresaConvenio = DbSet
                                    .Include(x => x.Empresa)
                                    .FirstOrDefault(x => x.Empresa.Cnpj == cnpj);
            return empresaConvenio;    
        }
    }
}