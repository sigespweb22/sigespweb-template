using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Sigesp.Application.ViewModels;
using Sigesp.Application.ViewModels.Detentos;
using Sigesp.Application.ViewModels.Reports;
using Sigesp.Application.ViewModels.Selects;
using Sigesp.Domain.Models;

namespace Sigesp.Application.Interfaces
{
    public interface IDetentoSaidaTemporariaAppService : IDisposable
    {
        IEnumerable<DetentoSaidaTemporariaViewModel> GetAllByFilterReportSaidasPrevistas(ListaAmarelaFilterReportSaidasPrevistasViewModel listaAmarelaFilterReportSaidasPrevistasViewModel);
    }
}