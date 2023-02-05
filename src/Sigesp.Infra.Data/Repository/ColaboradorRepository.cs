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
using Sigesp.Domain.Enums;
using Sigesp.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Sigesp.Infra.Data.Repository
{
    public class ColaboradorRepository : Repository<Colaborador>, IColaboradorRepository
    {
        public ColaboradorRepository(SigespDbContext context)
            : base(context)
        {
        }

        public new IEnumerable<Colaborador> GetAll()
        {
            var colaboradores = DbSet
                                    .IgnoreQueryFilters()
                                    .Include(x => x.Detento)
                                    .Where(x => x.Detento.IsDeleted == false || x.Detento.IsDeleted == true)
                                    .Where(x => x.IsDeleted == false);

            return colaboradores;
        }
        public Colaborador GetByIdWithInclude(Guid id)
        {
            var colaborador = DbSet
                                .AsNoTracking()
                                .IgnoreQueryFilters()
                                .Include(x => x.Detento)
                                .Include(x => x.EmpresaConvenio)
                                .Include(x => x.ContaCorrente)
                                .Where(d => d.Detento.IsDeleted == true || d.Detento.IsDeleted == false)
                                .Where(x => x.IsDeleted == false)
                                .FirstOrDefault(x => x.Id == id);
            return colaborador;
        }
        public Guid GetIdByDetentoId(Guid detentoId)
        {
            return DbSet
                        .Where(x => x.DetentoId == detentoId)
                        .Select(x => x.Id)
                        .FirstOrDefault();
        }
        public Guid GetIdByDetentoNome(string nomeDetento)
        {
            return DbSet
                        .Where(x => x.Detento.Nome == nomeDetento)
                        .Select(x => x.Id)
                        .FirstOrDefault();
        }
        public Colaborador GetByDetentoNome(string nomeDetento)
        {
            var colaboradorByDetentoNome = DbSet
                                            .IgnoreQueryFilters()
                                            .Include(x => x.Detento)
                                            .Where(x => x.Detento.IsDeleted == false || x.Detento.IsDeleted == true)
                                            .Include(x => x.ContaCorrente)
                                            .Where(x => x.IsDeleted == false || x.IsDeleted == true)
                                            .Where(x => x.Detento.Nome == nomeDetento)
                                            .FirstOrDefault();
            return colaboradorByDetentoNome;
        }
        public async Task<IEnumerable<Colaborador>> GetAllOnlyIsDeletedTrue()
        {
            var colaboradores = await DbSet
                                    .Include(x => x.EmpresaConvenio)
                                    .Include(xt => xt.Detento)
                                    .ToListAsync();

            return colaboradores.Where(x => x.IsDeleted == false);
        }
        public async Task<IEnumerable<Colaborador>> GetAllColaboradorPorConvenioSituacaoAdmitido()
        {
            var colaboradores = await DbSet
                                    .IgnoreQueryFilters()
                                    .Include(x => x.EmpresaConvenio)
                                    .Include(x => x.Detento)
                                    .Include(x => x.ContaCorrente)
                                    .Where(d => d.Detento.IsDeleted == true || d.Detento.IsDeleted == false)
                                    .Where(x => x.IsDeleted == false && x.Situacao == ColaboradorSituacaoEnum.ADMITIDO)
                                    .ToListAsync();

            return colaboradores;
        }
        public IEnumerable<Colaborador> GetAllDeletedTrueAndFalseWithInclude()
        {
            var detentos = DbSet  
                                    .IgnoreQueryFilters()
                                    .Include(x => x.Detento)
                                    .Include(x => x.ContaCorrente)
                                    .Where(x => x.ContaCorrente != null)
                                    .Where(d => d.Detento.IsDeleted == true || d.Detento.IsDeleted == false)
                                    .Where(x => x.IsDeleted == false)
                                    .OrderByDescending(x => x.CreatedAt)
                                    .ToList();

            return detentos;
        }
        public async Task<IEnumerable<Colaborador>> GetAllWithIncludeAsync()
        {
            var colaboradores = await DbSet
                                    .IgnoreQueryFilters()
                                    .Include(x => x.EmpresaConvenio)
                                    .Include(x => x.Detento)
                                    .Include(x => x.ContaCorrente)
                                    .Where(d => d.Detento.IsDeleted == true || d.Detento.IsDeleted == false)
                                    .Where(x => x.IsDeleted == false)
                                    .ToListAsync();

            return colaboradores;
        }
        public IEnumerable<Colaborador> GetAllWithInclude()
        {
            var colaboradores = DbSet
                                    .IgnoreQueryFilters()
                                    .Include(x => x.EmpresaConvenio)
                                    .Include(x => x.Detento)
                                    .Include(x => x.ContaCorrente)
                                    .Where(d => d.Detento.IsDeleted == true || d.Detento.IsDeleted == false)
                                    .Where(x => x.IsDeleted == false)
                                    .ToList();

            return colaboradores;
        }
         public new IEnumerable<Colaborador> GetAllSoftDeleted()
        {
            return DbSet.IgnoreQueryFilters()
                        .Where(x => x.IsDeleted == true)
                        .Include(x => x.EmpresaConvenio)
                        .Include(x => x.Detento)
                        .ToList();
        }
        public Colaborador GetByDetentoIpenOrDetentoNome(string property, string arg)
        {
            var colaboradorIpenAndNome = new Colaborador();

            if (property == "Ipen")
            {
                int ipen = Convert.ToInt32(arg);

                colaboradorIpenAndNome = DbSet
                                        .AsNoTracking()
                                        .IgnoreQueryFilters()
                                        .Include(x => x.Detento)
                                        .Where(x => EF.Functions.Like(x.Detento.Ipen.ToString(), 
                                                "%" + arg + "%"))
                                        .Select(x => new Colaborador {
                                            Id = x.Id,
                                            Detento = new Detento {
                                                Nome = x.Detento.Nome
                                            }
                                        })
                                        .Where(d => d.Detento.IsDeleted == true || d.Detento.IsDeleted == false)
                                        .Where(x => x.IsDeleted == false)
                                        .FirstOrDefault();
            }
            else
            {
                colaboradorIpenAndNome = DbSet
                            .AsNoTracking()
                            .Where(x => x.Detento.Nome.Contains(arg))
                            .Select(x => new Colaborador {
                                            Id = x.Id,
                                            Detento = new Detento {
                                                Nome = x.Detento.Nome
                                            }
                                        })
                            .FirstOrDefault();
            }

            return colaboradorIpenAndNome;
        }
        public bool AlreadyColaborador(Guid detentoId)
        {
            var alreadyColaborador = DbSet
                                        .IgnoreQueryFilters()
                                        .Any(x => x.Detento.Id == detentoId);
            return alreadyColaborador;
        }
        public IEnumerable<Colaborador> GetAllByDetentoNome(string detentoNome)
        {
            var colaboradores = DbSet
                                    .Where(x => x.Detento.Nome == detentoNome)
                                    .ToList();

            return colaboradores;
        }
        public IEnumerable<Colaborador> AsNoTrackingWithInclude()
        {
            var colaboradores = DbSet
                                    .AsNoTracking()
                                    .IgnoreQueryFilters()
                                    .Include(x => x.EmpresaConvenio)
                                    .Include(x => x.Detento)
                                    .Include(x => x.ContaCorrente)
                                    .Where(d => d.Detento.IsDeleted == true || d.Detento.IsDeleted == false)
                                    .Where(x => x.IsDeleted == false)
                                    .ToList();

            return colaboradores;
        }
        public Colaborador GetByDetentoIpenAndEmpresaConvenioId(int ipen, Guid ecId)
        {
            var colaborador = DbSet
                                .Include(x => x.Detento)
                                .Include(x => x.EmpresaConvenio)
                                .FirstOrDefault(x => x.Detento.Ipen == ipen
                                                && x.EmpresaConvenioId == ecId);
            
            return colaborador;
        }

        #region Methos is not tenants
        public async Task<Colaborador> GetAsync(int ipen)
        {
            var result = new Colaborador();
            try
            {
                result = await DbSet
                                .IgnoreQueryFilters()
                                .Include(x => x.Detento)
                                .Where(x => x.IsDeleted == false)
                                .FirstOrDefaultAsync(x => x.Detento.Ipen == ipen);
            }
            catch { throw; }
            return result;
        }
        #endregion
    }
}