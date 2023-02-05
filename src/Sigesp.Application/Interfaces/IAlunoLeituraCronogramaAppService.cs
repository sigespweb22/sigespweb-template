using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Sigesp.Application.ViewModels;
using Sigesp.Application.ViewModels.Reports;
using Sigesp.Application.ViewModels.Selects;
using Sigesp.Domain.Models;
using Sigesp.Domain.Models.DataTable;

namespace Sigesp.Application.Interfaces
{
    public interface IAlunoLeituraCronogramaAppService : IDisposable
    {
        IEnumerable<AlunoLeituraCronogramaViewModel> GetAll();
        Task<IEnumerable<AlunoLeituraCronogramaViewModel>> GetAllForSelect2Async();
        Task<AlunoLeituraCronogramaViewModel> GetByIdAsync(string id);
        AlunoLeituraCronogramaViewModel GetByIdIncludes(string id);
        Task<IEnumerable<AlunoLeituraCronogramaViewModel>> GetAllWithIncludeAsync();
        Task<ValidationResult> AddAsync(AlunoLeituraCronogramaViewModel alunoLeituraCronogramaViewModel);
        Task<ValidationResult> UpdateAsync(AlunoLeituraCronogramaViewModel alunoLeituraCronogramaViewModel);
        ValidationResult Remove(Guid id);
        Task<Int64> GetTotalAtivosAsync();
        Task<Int64> GetTotalInativosAsync();
        Task<Int64> GetTotalWithIgnoreQueryFilterAsync();
    }
}