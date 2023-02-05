using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Sigesp.Domain.Models;
using Sigesp.Domain.Enums;

namespace Sigesp.Domain.Interfaces
{
    public interface IContaCorrenteRepository : IRepository<ContaCorrente>
    {
        Task<IEnumerable<ContaCorrente>> GetAllWithIncludeAsync();
        decimal GetSaldoByColaboradorId(Guid colaboradorId);
        decimal GetSaldoByColaboradorNome(string colaboradorNome);
        decimal GetSaldoByEmpresaRazaoSocialAndTipo(string empresaRazaoSocial, bool isTipoCofre);
        ContaCorrente GetByColaboradorNomeIgnoreFilter(string colaboradorNome);
        ContaCorrente GetByColaboradorNome(string colaboradorNome);
        ContaCorrente GetByColaboradorNomeWithInclude(string colaboradorNome);
        ContaCorrente GetByEmpresaRazaoSocialAndTipo(string empresaRazaoSocial, bool isTipoCofre);
        IEnumerable<ContaCorrente> GetAllForFC();
        bool NumeroAlready(int numero);
        bool ContaCorrenteEmpresaAlreadyByTipoAndEmpresaIdAndDiffId(Guid id, Guid empresaId, ContaCorrenteTipoEnum tipo);
        bool ContaCorrenteColaboradorAlreadyByTipoAndColaboradorIdAndDiffId(Guid id, Guid colaboradorId, ContaCorrenteTipoEnum tipo);
        IEnumerable<ContaCorrente> GetAllByEmpresaId(Guid empresaId);
        IEnumerable<ContaCorrente> GetAllByColaboradorId(Guid empresaId);
        ContaCorrente GetByIdWithIncludeOne(Guid id, string property);
        ContaCorrente GetByIdWithColaborador(Guid id);
        IEnumerable<ContaCorrente> GetAllByTipos(List<ContaCorrenteTipoEnum> tipos);
        decimal GetSaldoSemLCTOByColaboradorNome(Guid id, string colaboradorNome);
        decimal GetSaldoSemLCTOByEmpresaRazaoSocialAndTipo(Guid id, string empresaRazaoSocial, bool isTipoCofre);
    }
}