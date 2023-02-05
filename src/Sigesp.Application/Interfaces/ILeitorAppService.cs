using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Numerics;
using System.Threading.Tasks;
using Sigesp.Application.ViewModels;
using Sigesp.Application.ViewModels.Detentos;
using Sigesp.Application.ViewModels.Selects;
using Sigesp.Domain.Models;

namespace Sigesp.Application.Interfaces
{
    public interface ILeitorAppService : IDisposable
    {
        Task<LeitorViewModel> GetByIdAsync(int id);
        Task<LeitorViewModel> GetByIdAsyncIncludes(int id);
        LeitorViewModel GetByIdIncludes(string id);
        Task<IEnumerable<LeitorViewModel>> GetAllAsync();
        Task<IEnumerable<LeitorViewModel>> GetAllAsyncIncludes();
        IEnumerable<LeitorViewModel> GetAll();
        ValidationResult Add(LeitorViewModel leitorViewModel);
        ValidationResult Remove(Guid id);
        ValidationResult Update(LeitorViewModel leitorViewModel);
        Int64 GetTotalAtivos();
        Int64 GetTotalInativos();
        Int64 GetTotalWithIgnoreQueryFilter();
    }
}