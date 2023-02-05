using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Sigesp.Domain.Models;
using System.Numerics;

namespace Sigesp.Domain.Interfaces
{
    public interface IAlunoLeituraCronogramaRepository : IRepository<AlunoLeituraCronograma>
    {
        Task<IEnumerable<AlunoLeituraCronograma>> GetAllForSelect2Async(Guid tenantId);
        AlunoLeituraCronograma GetByIdIncludes(Guid id);
        Task<IEnumerable<AlunoLeituraCronograma>> GetAllWithIncludesAsync(Guid tenantId);
        Task<Int64> GetTotalAtivosAsync(Guid tenantId);
        Task<Int64> GetTotalInativosAsync(Guid tenantId);
        Task<Int64> GetTotalWithIgnoreQueryFilterAsync(Guid tenantId);
        Task<bool> AlreadyMoreTwoPeriodosInicioSameMesAnoAsync(Guid tenantId, DateTime periodoInicio);
        Task<bool> AlreadyIdenticalPeriodoAsync(Guid tenantId, DateTime periodoInicio, DateTime periodoFim);
        Task<bool> AlreadyMoreOnePeriodoReferenciaSameAnoAsync(Guid tenantId, DateTime periodoInicio,
                                                               int periodoReferencia);
        Task<bool> AlreadyMoreOnePeriodoReferenciaSameAnoByIdAsync(Guid tenantId, Guid id,
                                                                   DateTime periodoInicio,
                                                                   int periodoReferencia);
        Task<bool> HasCronogramaByAnoAndPeriodoReferenciaAsync(Guid tenantId, int anoReferencia,
                                                               int periodoReferencia);
        Task<AlunoLeituraCronograma> GetByAnoAndPeriodoReferenciaAsync(Guid tenantId, int anoReferencia,
                                                                       int periodoReferencia);
        Task<bool> HasCronogramaByIdAsync(Guid tenantId, Guid id);
        Task<AlunoLeituraCronograma> GetByIdAsync(Guid tenantId, Guid id);
    }
}