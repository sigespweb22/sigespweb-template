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
    public interface IAlunoLeitorAppService : IDisposable
    {
        Task<IEnumerable<AlunoLeitorViewModel>> GetAllAsync();
        Task<IEnumerable<AlunoLeitorESViewModel>> GetAllForAddAsync();
        Task<ValidationResult> AddAsync(AlunoLeitorViewModel alunoLeitorViewModel);
        Task<ValidationResult> UpdateAsync(AlunoLeitorViewModel alunoLeitorViewModel);
        ValidationResult Remove(Guid id);
        IEnumerable<AlunoLeitorViewModel> GetAllWithInclude();
        Int64 GetTotalAtivos();
        Int64 GetTotalInativos();
        Int64 GetTotalWithIgnoreQueryFilter();
        AlunoLeitorViewModel GetByDetentoIpen(int ipen);
        IEnumerable<AlunoLeitorViewModel> GetAllByDetentoNome(string nome);
        Task<DataTableServerSideResult<AlunoLeitorViewModel>> GetWithDataTableResultAsync(DataTableServerSideRequest request);
    }
}