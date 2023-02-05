using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Sigesp.Domain.Models;
using Sigesp.Domain.Enums;
using Sigesp.Domain.Models.DataTable;

namespace Sigesp.Domain.Interfaces
{
    public interface IDetentoRepository : IRepository<Detento>
    {
        Task<IEnumerable<Detento>> GetAIFullAsync();
        new IEnumerable<Detento> GetAll();
        new Task<IEnumerable<Detento>> GetAllAsync();
        Detento GetByNome(string nome);
        Task<Detento> GetByNomeAsync(string nome);
        Task<IEnumerable<Detento>> GetAllByNomeAsync(string nome);
        Task<DetentoRegimeEnum> GetRegimeByNomeAsync(string nome);
        Task<Detento> GetIpenAndGaleriaByNomeAsync(string detentoNome);
        Task<Int64> GetIpenByNomeAsync(string nome);
        Task<int> GetIpenByIdAsync(string id);
        Detento GetIpenAndRegimeByColaboradorId(string colaboradorId);
        Task<Detento> GetIpenAndRegimeByNomeAsync(string detentoNome);
        Task<Detento> GetIdAndNomeByIpenOrNomeAsync(string property, string arg);
        Task<IEnumerable<Detento>> GetAllOnlyIsDeletedTrueAsync();
        IEnumerable<Detento> GetAllDeletedTrueAndFalseWithoutInclude();
        Task<int> TotalMDAsync();
        int TotalInstrumentoPrisaoMD();
        Task<int> TotalEmAudienciaAsync();
        IEnumerable<Detento> GetAllByTransferenciaTipoDataSaida(TransferenciaTipoEnum transferenciaTipo, 
                                                                DateTime dataInicio, DateTime dataFim);
        IEnumerable<Detento> GetAllByTransferenciaTipo(TransferenciaTipoEnum transferenciaTipo);
        IEnumerable<Detento> GetAllByTransferenciaTipoDataRetornoPrevisto(TransferenciaTipoEnum transferenciaTipo, 
                                                                                DateTime dataInicio, DateTime dataFim);
        IEnumerable<Detento> GetAllByDataSaida(DateTime dataInicio, DateTime dataFim);
        IEnumerable<Detento> GetAllByDataRetornoPrevisto(DateTime dataInicio, DateTime dataFim);
        Task<IEnumerable<Detento>> GetAllByRegimeAsync(DetentoRegimeEnum? regime);
        IEnumerable<Detento> GetAllByRegime(DetentoRegimeEnum? regime);
        Task<Detento> GetByIpenAsync(int ipen);
        Detento GetByIpen(int ipen);
        Detento GetInativoByIpen(int ipen);
        IEnumerable<Detento> GetByIpenAtivoInativo(int ipen);
        Task<Detento> GetByIpenIgnoreQueryFiltersAsync(int ipen);
        bool IsAlreadyByIpen(int ipen);
        bool IsAlreadyByIpen(int ipen, Guid tenantId);
        Task<IEnumerable<Detento>> GetAllWithInactiveAsync();
        Task<Detento> GetIpenRegimeByNomeAsync(string nome);
        Task<Detento> GetForEditByIpenAsync(int ipen);
        Guid? GetIdByIpen(int ipen);
        Detento GetForUpdateByIpen(int ipen);
        Task<Int64> GetTotalAtivosAsync();
        Task<Detento> GetInativoAsync(int ipen);
        IEnumerable<Detento> GetAllTransferidos();
        Task<DataTableServerSideResult<Detento>> GetWithDataTableResultAsync(DataTableServerSideRequest request);
        Task<bool> CheckAlreadyTenancyDiff(int ipen, Guid tenantId);
    }
}