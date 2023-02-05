using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Sigesp.Domain.Models;

namespace Sigesp.Domain.Interfaces
{
    public interface ILancamentoRepository : IRepository<Lancamento>
    {
        Task<Lancamento> GetByIdWithChildrensAsync(Guid id);
        Task<IEnumerable<Lancamento>> GetAllOnlyIsDeletedTrue();
        Task<IEnumerable<Lancamento>> GetAllWithInclude();
        IEnumerable<Lancamento> GetAllForFC();
        Lancamento GetByIdForTipoJuridicaAndCofre(Guid id);
        Lancamento GetByIdWithEmpresa(Guid id);
        Lancamento GetByIdWithColaborador(Guid id);
    }
}