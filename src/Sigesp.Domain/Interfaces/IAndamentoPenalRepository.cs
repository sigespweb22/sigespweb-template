using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Sigesp.Domain.Enums;
using Sigesp.Domain.Models;
using Sigesp.Domain.Models.DataTable;

namespace Sigesp.Domain.Interfaces
{
    public interface IAndamentoPenalRepository : IRepository<AndamentoPenal>
    {
        Task<DataTableServerSideResult<AndamentoPenal>> GetWithDataTableResultAsync(DataTableServerSideRequest request);
        AndamentoPenal GetByDetentoNome(string nome);
        AndamentoPenal GetByDetentoIpen(int ipen);
        AndamentoPenal GetByDetentoId(Guid id);
        Task<IEnumerable<AndamentoPenal>> GetAllOnlyIsDeletedTrue();      
        AndamentoPenal GetByIdWithIgnoreFilter(Guid id);
        IEnumerable<AndamentoPenal> GetAllWithIgnoreFilter();
        IEnumerable<AndamentoPenal> GetAllWithInclude();
        Guid GetIdByDetentoIpen(int ipen);
        AndamentoPenal GetByIdWithInclude(Guid id);
        IEnumerable<AndamentoPenal> GetAllByRegimeDataPrevisaoBeneficio(DetentoRegimeEnum regime, 
                                                                        DateTime dataInicio, 
                                                                        DateTime dataFim);
        IEnumerable<AndamentoPenal> GetAllByRegime(DetentoRegimeEnum regime);
        IEnumerable<AndamentoPenal> GetAllByDataPrevisaoBeneficio(DateTime dataInicio, DateTime dataFim);
        IEnumerable<AndamentoPenal> GetAllByRegimeAll();
        IEnumerable<AndamentoPenal> GetAllByRegimeAlimentosPrisaoTemporariaDataSaidaPrevista(DetentoRegimeEnum regime, 
                                                                                                    DateTime dataInicio,
                                                                                                    DateTime dataFim);
        IEnumerable<AndamentoPenal> GetAllByRegimeAlimentosPrisaoTemporaria(DetentoRegimeEnum regime);
        Int64 GetTotalByStatus(AndamentoPenalStatusEnum status);
        Int64 GetTotal();
        bool AlreadyAtivoByIpen(int ipen);
        AndamentoPenal RescueInactiveByIpen(int ipen);
        AndamentoPenal GetByIdWithouIncludes(Guid id);
    }
}