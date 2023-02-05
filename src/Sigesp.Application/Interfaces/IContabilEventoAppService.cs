using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Sigesp.Application.ViewModels;
using Sigesp.Domain.Models.DataTable;

namespace Sigesp.Application.Interfaces
{
    public interface IContabilEventoAppService : IDisposable
    {
        Task<ValidationResult> Add(ContabilEventoViewModel contabilEventoViewModel);
        Task<ValidationResult> Update(ContabilEventoViewModel contabilEventoViewModel);
        IEnumerable<ContabilEventoViewModel> GetAll();
        int GetTotalActiveRecords();
        Task<IEnumerable<ContabilEventoViewModel>> GetAllAsync();
        Task<ValidationResult> Remove(Guid id);

        Task<DataTableServerSideResultViewModel<ContabilEventoViewModel>> GetAllWithDataTableResultAsync(DataTableServerSideRequest request);
    }
}