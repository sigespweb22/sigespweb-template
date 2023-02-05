using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Sigesp.Application.ViewModels;
using Sigesp.Application.ViewModels.Detentos;
using Sigesp.Application.ViewModels.Reports;
using Sigesp.Application.ViewModels.Selects;
using Sigesp.Domain.Models;
using Sigesp.Domain.Models.DataTable;

namespace Sigesp.Application.Interfaces
{
    public interface IDetentoAppService : IDisposable
    {
        Task<IEnumerable<DetentoViewModel>> GetAIFullAsync();
        DetentoViewModel GetByNome(string nome);
        Task<DetentoViewModel> GetByNomeAsync(string nome);
        Task<IEnumerable<DetentoViewModel>> GetAllByNomeAsync(string nome);
        Task<DetentoForNovoViewModel> GetDetentoDataByIdAsync(string id);
        Task<ValidationResult> AddAsync(DetentoViewModel detentoViewModel);
        ValidationResult Update(DetentoViewModel detentoViewModel);
        string GetDetentoRegimeByNome(string nome);
        Task<string> GetIpenByNomeAsync(string nome);
        Task<DetentoViewModel> GetIpenAndGaleriaByNomeAsync(string detentoNome);
        Task<string> GetIpenByIdAsync(string id);
        DetentoViewModel GetIpenAndRegimeByColaboradorId(string colaboradorId);
        Task<DetentoViewModel> GetIpenAndRegimeByNomeAsync(string detentoNome);
        Task<Generic2Select2ViewModel> GetByIpenOrNomeAsync(string property, string arg);
        Task<IEnumerable<DetentoViewModel>> GetAllOnlyIsDeletedTrueAsync();
        Task<IEnumerable<DetentoViewModel>> GetAllAsync();
        Task<IEnumerable<DetentoViewModel>> GetAllWithInactiveAsync();
        Task<int> TotalMDAsync();
        Task<int> TotalEmAudienciaAsync();
        int TotalInstrumentoPrisaoMD();
        void Remove(Guid id);
        Task<DetentoViewModel> GetForModalTransferenciaAsync(string ipen);
        Task<DetentoViewModel> TransferByIpenAsync(DetentoViewModel detentoViewModel);
        IEnumerable<DetentoViewModel> GetAllByFilterReportTransferidos(ListaAmarelaFilterReportTransferidosViewModel listaAmarelaFilterReportTransferidosViewModel);
        IEnumerable<DetentoViewModel> GetAllByRegime(string regime);
        bool IsAlreadyByIpen(int ipen);
        Task<DetentoViewModel> GetByIpenAsync(int ipen);
        Task<DetentoViewModel> GetIpenRegimeByNomeAsync(string nome);
        Task<DetentoViewModel> GetForEditByIpenAsync(string ipen);
        Task<Int64> GetTotalAtivosAsync();
        IEnumerable<DetentoViewModel> GetAll();
        Task<DataTableServerSideResult<DetentoViewModel>> GetWithDataTableResultAsync(DataTableServerSideRequest request);
        Task<int> ChangeTenancyAsync(string ipen);
    }
}