using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Sigesp.Application.ViewModels;
using Sigesp.Domain.Models;

namespace Sigesp.Application.Interfaces
{
    public interface IEmpresaConvenioAppService : IDisposable
    {
        void Add(EmpresaConvenioViewModel empresaConvenioViewModel);
        void Update(EmpresaConvenioViewModel empresaConvenioViewModel);
        Task<IEnumerable<EmpresaConvenioViewModel>> GetAllAsync();
        IEnumerable<EmpresaConvenioViewModel> GetAll();
        IEnumerable<EmpresaConvenioViewModel> GetAllSoftDeleted();
        void Remove(Guid id);
        EmpresaConvenioViewModel GetByEmpresaCnpj(string cnpj);
    }
}