using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Sigesp.Domain.Models;
using System.Numerics;
using Sigesp.Domain.Enums;
using Sigesp.Domain.Models.DataTable;

namespace Sigesp.Domain.Interfaces
{
    public interface IFormularioLeituraDicaEscritaRepository : IRepository<FormularioLeituraDicaEscrita>
    {
        Task<FormularioLeituraDicaEscrita> GetAsync(Guid id);
    }
}