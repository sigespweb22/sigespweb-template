using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Numerics;
using System.Threading.Tasks;
using Sigesp.Application.ViewModels;
using Sigesp.Application.ViewModels.Cards;
using Sigesp.Application.ViewModels.Detentos;
using Sigesp.Application.ViewModels.Selects;
using Sigesp.Domain.Models;
using Sigesp.Domain.Models.DataTable;

namespace Sigesp.Application.Interfaces
{
    public interface IServidorEstadoReforcoRegraAppService : IDisposable
    {
        Task<int> CreateAsync(ServidorEstadoReforcoRegraViewModel servidorEstadoReforcoRegraViewModel);
        Task<int> UpdateAsync(ServidorEstadoReforcoRegraViewModel servidorEstadoReforcoRegraViewModel);
        Task<int> DeleteAsync(Guid id);
        Task<DataTableServerSideResult<ServidorEstadoReforcoRegraViewModel>> GetWithDataTableResultAsync(DataTableServerSideRequest request);
    }
}