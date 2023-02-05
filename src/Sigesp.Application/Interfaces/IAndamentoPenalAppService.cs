using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Sigesp.Application.ViewModels;
using Sigesp.Domain.Enums;
using Sigesp.Domain.Models;

namespace Sigesp.Application.Interfaces
{
    public interface IAndamentoPenalAppService : IDisposable
    {
        AndamentoPenalViewModel GetByIdWithInclude(string id);
        ValidationResult Add(AndamentoPenalViewModel andamentoPenalViewModel);
        ValidationResult Update(AndamentoPenalViewModel andamentoPenalViewModel);
        IEnumerable<AndamentoPenalViewModel> GetAll();
        Task<IEnumerable<AndamentoPenalViewModel>> GetAllAsync();
        ValidationResult Remove(Guid id);
        Int64 GetTotalByStatus(AndamentoPenalStatusEnum status);
        Int64 GetTotal();
        bool AlreadyAtivoByIpen(int ipen);
        AndamentoPenalViewModel RescueInactiveByIpen(int ipen);
    }
}