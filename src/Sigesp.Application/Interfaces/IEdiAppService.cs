using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Sigesp.Application.ViewModels;
using Sigesp.Application.ViewModels.Cards;
using Sigesp.Application.ViewModels.Detentos;
using Sigesp.Application.ViewModels.Selects;
using Sigesp.Domain.Models;
using Sigesp.Domain.Models.DataTable;

namespace Sigesp.Application.Interfaces
{
    public interface IEdiAppService : IDisposable
    {
        Task<EdiCardViewModel> GetInfoCardsAsync();
        Task<DataTableServerSideResult<EdiViewModel>> GetWithDataTableResultAsync(DataTableServerSideRequest request);
    }
}