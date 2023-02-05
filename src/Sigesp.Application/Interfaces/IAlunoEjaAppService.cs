using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Sigesp.Application.ViewModels;
using Sigesp.Application.ViewModels.Reports;
using Sigesp.Domain.Enums;
using Sigesp.Domain.Models;
using Sigesp.Domain.Models.DataTable;

namespace Sigesp.Application.Interfaces
{
    public interface IAlunoEjaAppService : IDisposable
    {
        Task<ValidationResult> AddAsync(AlunoEjaViewModel alunoEjaViewModel);
        ValidationResult Update(AlunoEjaViewModel alunoEjaViewModel);
        ValidationResult UpdateWithoutCommitFromEdiDetentos(Guid id);
        ValidationResult Remove(Guid id);
        Task<Int64> GetTotalByFaseStatusAsync(AlunoEjaFaseStatusEnum faseStatus);
        Task<Int64> GetTotalInativosAsync();
        Task<Int64> GetTotalByCursoAsync(CursoEnum curso);
        Task<Int64> GetTotalByTurnoPeriodoAsync(TurnoEnum turnoPeriodo);        
    }
}