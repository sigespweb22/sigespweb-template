using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;
using Sigesp.Application.ViewModels;
using Sigesp.Domain.Models;

namespace Sigesp.Application.Interfaces
{
    public interface IEmpresaAppService : IDisposable
    {
        void Add(EmpresaViewModel empresaViewModel);
        void Update(EmpresaViewModel empresaViewModel);
        IEnumerable<EmpresaViewModel> GetAll();
        IEnumerable<EmpresaViewModel> GetAllSoftDeleted();
        Task<IEnumerable<EmpresaViewModel>> GetAllAsync();
        Task<IEnumerable<EmpresaViewModel>> GetAllAsyncDapper();
        void Remove(Guid id);
    }
}