using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Refit;
using Sigesp.Domain.Models.Services;

namespace Sigesp.Domain.Services
{
    public interface IGeoNamesEstadosServices
    {
        [Get("/childrenJSON?geonameId=3469034")]
        Task<GeoNamesEstadosModel> GetAllEstados();
    }
}