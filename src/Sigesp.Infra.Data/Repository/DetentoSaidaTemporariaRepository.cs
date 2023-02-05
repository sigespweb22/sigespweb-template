using System.Runtime.InteropServices;
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

namespace Sigesp.Infra.Data.Repository
{
    public class DetentoSaidaTemporariaRepository : Repository<DetentoSaidaTemporaria>, IDetentoSaidaTemporariaRepository
    {
        public DetentoSaidaTemporariaRepository(SigespDbContext context)
            : base(context)
        {
        }

        public IEnumerable<DetentoSaidaTemporaria> GetAllByDetentoIpen (int ipen)
        {
            var detentosST = DbSet
                                .Include(x => x.Detento)
                                .Where(c => c.Detento.Ipen == ipen);
            
            return detentosST;
        }

        public void RemoveAll(IEnumerable<DetentoSaidaTemporaria> detentosST)
        {
            DbSet.RemoveRange(detentosST);
        }

        public IEnumerable<DetentoSaidaTemporaria> GetAllByFilterReportSaidasPrevistas(DateTime dataInicio,
                                                                                        DateTime dataFim,
                                                                                        string opt)
        {
            var detentosST = new List<DetentoSaidaTemporaria>();

            if (opt != null)
            {
                switch (opt)
                {
                    case "NOME":
                        detentosST = DbSet
                                                .Include(x => x.Detento)
                                                .Where(x => x.SaidaPrevista >= dataInicio.Date
                                                        && x.SaidaPrevista <= dataFim.Date)
                                                .OrderBy(x => x.Detento.Nome)
                                                .ThenBy(x => x.SaidaPrevista)
                                                .ToList();
                        break;
                    case "GALERIA":
                        detentosST = DbSet
                                                .Include(x => x.Detento)
                                                .Where(x => x.SaidaPrevista >= dataInicio.Date
                                                        && x.SaidaPrevista <= dataFim.Date)
                                                .OrderBy(x => x.Detento.Galeria)
                                                .ThenBy(x => x.Detento.Cela)
                                                .ThenBy(x => x.SaidaPrevista)
                                                .ToList();
                        break;
                    case "CELA":
                        detentosST = DbSet
                                                .Include(x => x.Detento)
                                                .Where(x => x.SaidaPrevista >= dataInicio.Date
                                                        && x.SaidaPrevista <= dataFim.Date)
                                                .OrderBy(x => x.Detento.Cela)
                                                .ThenBy(x => x.SaidaPrevista)
                                                .ToList();
                        break;
                }
            }
            else
            {
                detentosST = DbSet
                                .Include(x => x.Detento)
                                .Where(x => x.SaidaPrevista >= dataInicio.Date
                                        && x.SaidaPrevista <= dataFim.Date)
                                .OrderBy(x => x.Detento.Nome)
                                .ThenBy(x => x.Detento.Galeria)
                                .ThenBy(x => x.SaidaPrevista)
                                .ToList();
            }

            return detentosST;
        }
    }
}