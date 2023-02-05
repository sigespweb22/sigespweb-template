using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Sigesp.Application.ViewModels;
using Sigesp.Domain.Models;

namespace Sigesp.Application.Interfaces
{
    public interface ILancamentoAppService : IDisposable
    {
        ValidationResult Add(LancamentoViewModel lancamentoViewModel);
        ValidationResult Update(LancamentoViewModel lancamentoViewModel);
        IEnumerable<LancamentoViewModel> GetAll();
        IEnumerable<LancamentoViewModel> GetAllForFC();
        Task<IEnumerable<LancamentoViewModel>> GetAllAsync();
        Task<IEnumerable<LancamentoViewModel>> GetAllAsyncWithInclude();
        ValidationResult Remove(Guid id);
    }
}