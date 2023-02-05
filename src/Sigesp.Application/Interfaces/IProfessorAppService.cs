using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Numerics;
using System.Threading.Tasks;
using Sigesp.Application.ViewModels;
using Sigesp.Application.ViewModels.Cards;
using Sigesp.Application.ViewModels.Detentos;
using Sigesp.Application.ViewModels.Selects;
using Sigesp.Domain.Models;
using Sigesp.Domain.Models.DataTable;

namespace Sigesp.Application.Interfaces
{
    public interface IProfessorAppService : IDisposable
    {
        Task<Int64> GetTotalInativosAsync();
        Task<IEnumerable<ProfessorViewModel>> GetAllAsync();
        Task<IEnumerable<string>> GetAllNomesAsync();
        Task<DataTableServerSideResult<ProfessorViewModel>> GetWithDataTableResultAsync(DataTableServerSideRequest request);
        Task<ProfessorCardViewModel> GetInfoCardsAsync();
        Task AddAsync(ProfessorViewModel professorViewModel);
        Task UpdateAsync(ProfessorViewModel professorViewModel);
        ValidationResult Remove(Guid id);
        Int64 GetTotalAtivos();
        Int64 GetTotalWithIgnoreQueryFilter();        
    }
}