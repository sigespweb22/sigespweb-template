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
using Sigesp.Domain.Models.DataTable;
using Sigesp.Infra.Data.Extensions;
using Sigesp.Infra.Data.Extensions.DataTable;

namespace Sigesp.Infra.Data.Repository
{
    public class FormularioLeituraPerguntaGrupoRepository : Repository<FormularioLeituraPerguntaGrupo>, IFormularioLeituraPerguntaGrupoRepository
    {

        public FormularioLeituraPerguntaGrupoRepository(SigespDbContext context)
            : base(context)
        {
        }

        public async Task<FormularioLeituraPerguntaGrupo> GetAsync(Guid id)
        {
            var result = new FormularioLeituraPerguntaGrupo();
            result = await DbSet
                            .Include(x => x.FormularioLeituraPerguntas)
                            .FirstOrDefaultAsync(x => x.Id == id);
            return result;
        }
    }
}