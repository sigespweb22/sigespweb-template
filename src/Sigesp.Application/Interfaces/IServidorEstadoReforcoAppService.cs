using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Sigesp.Application.ViewModels;

namespace Sigesp.Application.Interfaces
{
    public interface IServidorEstadoReforcoAppService : IDisposable
    {
        Task<int> CreateAsync(ServidorEstadoReforcoViewModel servidorEstadoReforcoViewModel);
        Task<List<ServidorEstadoReforcoViewModel>> DeleteOnDemandAsync(string userId, string deleteType);
    }
}