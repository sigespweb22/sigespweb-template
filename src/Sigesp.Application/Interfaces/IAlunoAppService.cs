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
    public interface IAlunoAppService : IDisposable
    {
        Task<string> GetNomeAsync(string id);
        Task<IEnumerable<AlunoViewModel>> GetAllAsync();
        ValidationResult Add(AlunoViewModel alunoViewModel);
        ValidationResult Update(AlunoViewModel alunoViewModel);
        ValidationResult Remove(Guid id);
        AlunoViewModel GetByDetentoIpen(int ipen);
        Int64 GetTotalAtivos();
        Int64 GetTotalByEscolaridade(EscolaridadeEnum escolaridade);
        Task<bool> ActivateOrDeactivateAsync (string id);
    }
}