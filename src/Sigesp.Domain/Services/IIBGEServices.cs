using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Refit;
using Sigesp.Domain.Models;

namespace Sigesp.Domain.Services
{
    public interface IIBGEServices
    {
        [Get("/")]
        Task<IEnumerable<IBGEEstado>> GetAllEstados();
    }
}