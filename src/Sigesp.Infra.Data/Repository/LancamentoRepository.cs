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
using Sigesp.Domain.Enums;

namespace Sigesp.Infra.Data.Repository
{
    public class LancamentoRepository : Repository<Lancamento>, ILancamentoRepository
    {
        public LancamentoRepository(SigespDbContext context)
            : base(context)
        {
        }

        public async Task<Lancamento> GetByIdAsync(int id)
        {
            return await DbSet.FindAsync(id);
        }
        public async Task<Lancamento> GetByIdWithChildrensAsync(Guid id)
        {
            return await DbSet
                            .Include(x => x.ContaCorrente)
                            .FirstOrDefaultAsync(x => x.Id == id);
        }
        public Lancamento GetByIdWithColaborador(Guid id)
        {
            var lancamento = DbSet
                                .IgnoreQueryFilters()
                                .Include(x => x.ContaCorrente)
                                .ThenInclude(x => x.Colaborador)
                                .ThenInclude(x => x.Detento)
                                .Where(d => d.ContaCorrente.Colaborador.Detento.IsDeleted == true || d.ContaCorrente.Colaborador.Detento.IsDeleted == false)
                                .Where(x => x.IsDeleted == false)
                                .FirstOrDefault(x => x.Id == id);
            return lancamento;
        }
        public Lancamento GetByIdWithEmpresa(Guid id)
        {
            var lancamento = DbSet
                                .Include(x => x.ContaCorrente)
                                .ThenInclude(x => x.Empresa)
                                .FirstOrDefault(x => x.Id == id);
            return lancamento;
        }
        public Lancamento GetByIdForTipoJuridicaAndCofre(Guid id)
        {
            var lancamento = DbSet
                                .Include(x => x.ContaCorrente)
                                .ThenInclude(x => x.Colaborador)
                                .ThenInclude(x => x.EmpresaConvenio)
                                .ThenInclude(x => x.Empresa)
                                .FirstOrDefault(x => x.Id == id);
            return lancamento;
        }
        public async Task<IEnumerable<Lancamento>> GetAllOnlyIsDeletedTrue()
        {
            var lancamentos = await DbSet
                                    .Include(x => x.ContaCorrente)
                                    .ToListAsync();

            return lancamentos.Where(x => x.IsDeleted == false);
        }
        public async Task<IEnumerable<Lancamento>> GetAllWithInclude()
        {
            var lancamentos = await DbSet
                                    .IgnoreQueryFilters()
                                    .Include(x => x.ContaCorrente)
                                    .ThenInclude(x => x.Colaborador)
                                    .ThenInclude(x => x.Detento)
                                    .Where(d => d.ContaCorrente.Colaborador.Detento.IsDeleted == true || d.ContaCorrente.Colaborador.Detento.IsDeleted == false)
                                    .Where(x => x.IsDeleted == false)
                                    .OrderBy(x => x.CreatedAt)
                                    .ToListAsync();

            return lancamentos;
        }
        public IEnumerable<Lancamento> GetAllForFC()
        {
            var lancamentos = DbSet
                                .Include(x => x.ContaCorrente)
                                .Where(x => x.ContaCorrente.Tipo 
                                            == ContaCorrenteTipoEnum.PESSOA_JURIDICA
                                        || x.ContaCorrente.Tipo 
                                            == ContaCorrenteTipoEnum.COFRE)
                                .ToList();

            return lancamentos;
        }
    }
}