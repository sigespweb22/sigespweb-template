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
    public interface ILivroGeneroAppService : IDisposable
    {
        Task<LivroGeneroViewModel> GetByIdAsync(int id);
        Task<LivroGeneroViewModel> GetByIdAsyncIncludes(int id);
        LivroGeneroViewModel GetByIdIncludes(string id);
        Task<IEnumerable<LivroGeneroViewModel>> GetAllAsync();
        Task<IEnumerable<LivroGeneroViewModel>> GetAllAsyncIncludes();
        IEnumerable<LivroGeneroViewModel> GetAll();
        ValidationResult Add(LivroGeneroViewModel livroGeneroViewModel);
        ValidationResult Remove(Guid id);
        ValidationResult Update(LivroGeneroViewModel livroGeneroViewModel);
        Int64 GetTotalAtivos();
        Int64 GetTotalInativos();
        Int64 GetTotalWithIgnoreQueryFilter();
    }
}