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
    public class ContaCorrenteRepository : Repository<ContaCorrente>, IContaCorrenteRepository
    {
        public ContaCorrenteRepository(SigespDbContext context)
            : base(context)
        {
            
        }

        public ContaCorrente GetByIdWithColaborador(Guid id)
        {
            var contaCorrente = DbSet
                                    .AsNoTracking()
                                    .IgnoreQueryFilters()
                                    .Include(x => x.Lancamentos)
                                    .Include(x => x.Colaborador)
                                    .ThenInclude(x => x.Detento)
                                    .Where(d => d.Colaborador.Detento.IsDeleted == true || d.Colaborador.Detento.IsDeleted == false)
                                    .Where(x => x.IsDeleted == false)
                                    .Where(x => x.Id == id)
                                    .FirstOrDefault();
            return contaCorrente;
        }
        public async Task<IEnumerable<ContaCorrente>> GetAllWithIncludeAsync()
        {
            return await DbSet
                        .IgnoreQueryFilters()
                        .Include(x => x.Lancamentos)
                        .Include(x => x.Colaborador)
                        .ThenInclude(x => x.Detento)
                        .Where(d => d.Colaborador.Detento.IsDeleted == true || d.Colaborador.Detento.IsDeleted == false)
                        .Where(x => x.IsDeleted == false)
                        .ToListAsync();
        }
        public decimal GetSaldoByColaboradorId(Guid colaboradorId)
        {
            var colaborador = DbSet
                            .Where(x => x.ColaboradorId == colaboradorId)
                            .Include(x => x.Lancamentos)
                            .FirstOrDefault();
                            
            decimal saldo = 0;

            if (colaborador != null)
            {
                saldo = colaborador
                            .Lancamentos
                                .Where(x => x.Tipo == LancamentoTipoEnum.CREDITO && x.Status == LancamentoStatusEnum.LIQUIDADO)
                                .Sum(x => x.ValorLiquido) - 
                            colaborador
                            .Lancamentos
                                .Where(x => x.Tipo == LancamentoTipoEnum.DEBITO && x.Status == LancamentoStatusEnum.LIQUIDADO)
                                .Sum(x => x.ValorLiquido);
            }

            return saldo;
        }
        public ContaCorrente GetByIdWithIncludeOne(Guid id, string property)
        {
            var contaCorrente = DbSet
                                .Include(property)
                                .Include(x => x.Lancamentos)
                                .Where(x => x.Id == id)
                                .FirstOrDefault();
            return contaCorrente;
        }
        public decimal GetSaldoByColaboradorNome(string colaboradorNome)
        {
            var colaborador = DbSet
                            .IgnoreQueryFilters()
                            .AsNoTracking()
                            .Where(d => d.Colaborador.Detento.IsDeleted == true || d.Colaborador.Detento.IsDeleted == false)
                            .Where(x => x.IsDeleted == false)
                            .Where(x => x.Colaborador.Detento.Nome == colaboradorNome)
                            .Include(x => x.Lancamentos)
                            .FirstOrDefault();

            decimal saldo = 0;

            if (colaborador != null)
            {
                var creditos = colaborador
                            .Lancamentos
                                .Where(x => x.Tipo == LancamentoTipoEnum.CREDITO && x.Status == LancamentoStatusEnum.LIQUIDADO)
                                .Sum(x => x.ValorLiquido);
            
                var debitos = colaborador
                            .Lancamentos
                                .Where(x => x.Tipo == LancamentoTipoEnum.DEBITO && x.Status == LancamentoStatusEnum.LIQUIDADO)
                                .Sum(x => x.ValorLiquido);
                
                saldo = creditos - debitos;
            }

            return saldo;
        }
        public decimal GetSaldoByEmpresaRazaoSocialAndTipo(string empresaRazaoSocial, bool isTipoCofre)
        {
            var tipo = isTipoCofre ? ContaCorrenteTipoEnum.COFRE : ContaCorrenteTipoEnum.PESSOA_JURIDICA;

            var contaCorrente = DbSet
                                .Include(x => x.Empresa)
                                .Where(x => x.Empresa.RazaoSocial == empresaRazaoSocial
                                        && x.Tipo == tipo)
                                .Include(x => x.Lancamentos)
                                .FirstOrDefault();

            decimal saldo = 0;

            if (contaCorrente != null)
            {
                var creditos = contaCorrente
                                .Lancamentos
                                    .Where(x => x.Tipo == LancamentoTipoEnum.CREDITO && x.Status == LancamentoStatusEnum.LIQUIDADO)
                                    .Sum(x => x.ValorLiquido);
            
                var debitos = contaCorrente
                                .Lancamentos
                                    .Where(x => x.Tipo == LancamentoTipoEnum.DEBITO && x.Status == LancamentoStatusEnum.LIQUIDADO)
                                    .Sum(x => x.ValorLiquido);
                
                saldo = creditos - debitos;
            }

            return saldo;
        }
        public ContaCorrente GetByColaboradorNomeIgnoreFilter(string colaboradorNome)
        {
            var contaCorrente = DbSet
                        .IgnoreQueryFilters()
                        .Include(x => x.Lancamentos)
                        .Where(d => d.Colaborador.Detento.IsDeleted == true || d.Colaborador.Detento.IsDeleted == false)
                        .Where(x => x.Colaborador.Detento.Nome == colaboradorNome)
                        .Where(x => x.IsDeleted == false || x.IsDeleted == true)
                        .FirstOrDefault();
            
            return contaCorrente;
        }
        public ContaCorrente GetByColaboradorNome(string colaboradorNome)
        {
            var contaCorrente = DbSet
                        .IgnoreQueryFilters()
                        .Include(x => x.Lancamentos)
                        .Where(d => d.Colaborador.Detento.IsDeleted == true || d.Colaborador.Detento.IsDeleted == false)
                        .Where(x => x.Colaborador.Detento.Nome == colaboradorNome)
                        .Where(x => x.IsDeleted == false)
                        .FirstOrDefault();
            
            return contaCorrente;
        }
        public ContaCorrente GetByColaboradorNomeWithInclude(string colaboradorNome)
        {
            var contaCorrente = DbSet
                        .IgnoreQueryFilters()
                        .Include(x => x.Colaborador)
                        .ThenInclude(x => x.Detento)
                        .Include(x => x.Lancamentos)
                        .Where(x => x.Colaborador.Detento.Nome == colaboradorNome)
                        .Where(d => d.Colaborador.Detento.IsDeleted == true || d.Colaborador.Detento.IsDeleted == false)
                        .Where(x => x.IsDeleted == false)
                        .FirstOrDefault();
            
            return contaCorrente;
        }
        public IEnumerable<ContaCorrente> GetAllForFC()
        {
            var contasCorrentes = DbSet
                                    .Include(x => x.Lancamentos)
                                    .Where(x => x.Tipo == ContaCorrenteTipoEnum.PESSOA_JURIDICA
                                            || x.Tipo == ContaCorrenteTipoEnum.COFRE)
                                    .ToList();
            return contasCorrentes;
        }
        public bool NumeroAlready (int numero)
        {
            var numeroAlready = DbSet
                                    .Any(x => x.Numero == numero);
            return numeroAlready;
        }
        public bool ContaCorrenteEmpresaAlreadyByTipoAndEmpresaIdAndDiffId(Guid id, Guid empresaId, ContaCorrenteTipoEnum tipo)
        {
            var already = DbSet
                            .Include(x => x.Empresa)
                            .Include(x => x.Lancamentos)
                            .Any(x => x.Id != id
                                    && x.Empresa.Id == empresaId
                                    && x.Tipo == tipo);
            return already;
        }
        public bool ContaCorrenteColaboradorAlreadyByTipoAndColaboradorIdAndDiffId(Guid id, Guid colaboradorId, ContaCorrenteTipoEnum tipo)
        {
            var already = DbSet
                            .IgnoreQueryFilters()
                            .Include(x => x.Lancamentos)
                            .Include(x => x.Colaborador)
                            .ThenInclude(x => x.Detento)
                            .Where(x => x.Colaborador.Detento.IsDeleted == false || x.Colaborador.Detento.IsDeleted == true)
                            .Where(x => x.IsDeleted == false)
                            .Any(x => x.Id != id
                                    && x.Colaborador.Id == colaboradorId
                                    && x.Tipo == tipo);
            return already;
        }
        public bool DetentoTemIgualByTipoAndDetentoId(Guid detentoId, ContaCorrenteTipoEnum tipo)
        {
            var already = DbSet
                            .Include(x => x.Colaborador)
                            .ThenInclude(x => x.Detento)
                            .Any(x => 
                                    x.Colaborador.Detento.Id == detentoId
                                    && x.Tipo == tipo);
            return already;
        }
        public IEnumerable<ContaCorrente> GetAllByEmpresaId(Guid empresaId)
        {
            var contasCorrentes = DbSet
                                    .Include(x => x.Lancamentos)
                                    .Include(x => x.Empresa)
                                    .Where(x => x.Empresa.Id == empresaId);

            return contasCorrentes;
        }
        public IEnumerable<ContaCorrente> GetAllByColaboradorId(Guid colaboradorId)
        {
            var contasCorrentes = DbSet
                                    .IgnoreQueryFilters()
                                    .Include(x => x.Lancamentos)
                                    .Include(x => x.Colaborador)
                                    .ThenInclude(x => x.Detento)
                                    .Where(x => x.Colaborador.Detento.IsDeleted == false
                                            || x.Colaborador.Detento.IsDeleted == true)
                                    .Where(x => x.IsDeleted == false)
                                    .Where(x => x.Colaborador.Id == colaboradorId);

            return contasCorrentes;
        }
        public IEnumerable<ContaCorrente> GetAllByTipos(List<ContaCorrenteTipoEnum> tipos)
        {
            var contasCorrentes = DbSet
                                    .IgnoreQueryFilters()
                                    .Include(x => x.Lancamentos)
                                    .Include(x => x.Empresa)
                                    .Include(x => x.Colaborador)
                                    .ThenInclude(x => x.Detento)
                                    .Where(x => x.Colaborador.Detento.IsDeleted == false
                                            || x.Colaborador.Detento.IsDeleted == true)
                                    .Where(x => x.IsDeleted == false).ToList();

            foreach (var tipo in tipos)
            {
                var ccSearch = contasCorrentes
                                        .Where(x => x.Tipo != tipo);

                if (ccSearch != null)
                {
                    foreach (var item in ccSearch.ToList())
                    {
                        contasCorrentes.Remove(item);
                    }
                }
            }

            return contasCorrentes;
        }
        public decimal GetSaldoSemLCTOByColaboradorNome(Guid id, string colaboradorNome)
        {
            var colaborador = DbSet
                            .IgnoreQueryFilters()
                            .AsNoTracking()
                            .Where(d => d.Colaborador.Detento.IsDeleted == true || d.Colaborador.Detento.IsDeleted == false)
                            .Where(x => x.IsDeleted == false)
                            .Where(x => x.Colaborador.Detento.Nome == colaboradorNome)
                            .Include(x => x.Lancamentos)
                            .FirstOrDefault();

            decimal saldo = 0;

            if (colaborador != null)
            {
                var creditos = colaborador
                                .Lancamentos
                                    .Where(x => x.Id != id
                                        && x.Tipo == LancamentoTipoEnum.CREDITO && x.Status == LancamentoStatusEnum.LIQUIDADO)
                                    .Sum(x => x.ValorLiquido);
            
                var debitos = colaborador
                                .Lancamentos
                                    .Where(x => x.Id != id
                                        && x.Tipo == LancamentoTipoEnum.DEBITO && x.Status == LancamentoStatusEnum.LIQUIDADO)
                                    .Sum(x => x.ValorLiquido);
                
                saldo = creditos - debitos;
            }

            return saldo;
        }

        public decimal GetSaldoSemLCTOByEmpresaRazaoSocialAndTipo(Guid id, 
                                                                    string empresaRazaoSocial,
                                                                    bool isTipoCofre)
        {
            var tipo = isTipoCofre ? ContaCorrenteTipoEnum.COFRE : ContaCorrenteTipoEnum.PESSOA_JURIDICA;

            var contaCorrente = DbSet
                                .Include(x => x.Empresa)
                                .Include(x => x.Lancamentos)
                                .FirstOrDefault(x => x.Id == id
                                                && x.Empresa.RazaoSocial == empresaRazaoSocial
                                                && x.Tipo == tipo);

            decimal saldo = 0;

            if (contaCorrente != null)
            {
                var creditos = contaCorrente
                                .Lancamentos
                                    .Where(x => x.Id != id
                                        && x.Tipo == LancamentoTipoEnum.CREDITO && x.Status == LancamentoStatusEnum.LIQUIDADO)
                                    .Sum(x => x.ValorLiquido);
            
                var debitos = contaCorrente
                                .Lancamentos
                                    .Where(x => x.Id != id
                                        && x.Tipo == LancamentoTipoEnum.DEBITO && x.Status == LancamentoStatusEnum.LIQUIDADO)
                                    .Sum(x => x.ValorLiquido);
                
                saldo = creditos - debitos;
            }

            return saldo;
        }

        public ContaCorrente GetByEmpresaRazaoSocialAndTipo(string empresaRazaoSocial, bool isTipoCofre)
        {
            var tipo = isTipoCofre ? ContaCorrenteTipoEnum.COFRE : ContaCorrenteTipoEnum.PESSOA_JURIDICA;

            var contaCorrente = DbSet
                                    .Include(x => x.Empresa)
                                    .FirstOrDefault(x => x.Empresa.RazaoSocial == empresaRazaoSocial
                                                    && x.Tipo == tipo);
            return contaCorrente;
        }
    }
}