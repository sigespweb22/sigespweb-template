using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Numerics;
using System.Threading.Tasks;
using Sigesp.Application.ViewModels;
using Sigesp.Application.ViewModels.Detentos;
using Sigesp.Application.ViewModels.Requests;
using Sigesp.Application.ViewModels.Selects;
using Sigesp.Domain.Models;
using Sigesp.Domain.Models.DataTable;

namespace Sigesp.Application.Interfaces
{
    public interface ILivroAppService : IDisposable
    {
        Task<IEnumerable<LivroViewModel>> GetAllWithVRAsync();
        Task<ValidationResult> AddAsync(LivroViewModel livroViewModel);
        ValidationResult Remove(Guid id);
        Task<ValidationResult> UpdateAsync(LivroViewModel livroViewModel);
        string GetNextLocalizacao();
        Task<DataTableServerSideResult<LivroViewModel>> GetWithDataTableResultAsync(DataTableServerSideRequest request);
        Int64 GetTotalAtivos();
        Int64 GetTotalInativos();
        Int64 GetTotalDisponiveis();
        Int64 GetTotalIndisponiveis();
        Task<ValidationResult> ColocarEstanteAsync(ColocarEstanteRequestViewModel 
                                                colocarEstanteRequestViewModel);
        Int64 GetTotalWithIgnoreQueryFilter();
        IEnumerable<LivroViewModel> GetAllDisponiveis(int ipen);
        Int64 GetLocalizacao(Guid id);
        ValidationResult GetAllDisponiveisNaoLidosByIpenAndGenero(LivrosParaEdicaoRequestViewModel
                                                                    livrosParaEdicaoRequestViewModel);
    }
}