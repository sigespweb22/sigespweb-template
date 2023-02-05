using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Sigesp.Application.ViewModels;
using Sigesp.Application.ViewModels.Reports;
using Sigesp.Domain.Models;
using Sigesp.Domain.Models.DataTable;

namespace Sigesp.Application.Interfaces
{
    public interface IDisciplinaAppService : IDisposable
    {
        ValidationResult Add(DisciplinaViewModel disciplinaViewModel);
        ValidationResult Update(DisciplinaViewModel disciplinaViewModel);
        ValidationResult Remove(Guid id);
        IEnumerable<DisciplinaViewModel> GetAllWithInclude();
        IEnumerable<DisciplinaViewModel> GetAll();
        Task<DisciplinaViewModel> GetByIdAsync(string id);
        Int64 GetTotalAtivos();
        Int64 GetTotalInativos();
        Int64 GetTotalWithIgnoreQueryFilter();
    }
}