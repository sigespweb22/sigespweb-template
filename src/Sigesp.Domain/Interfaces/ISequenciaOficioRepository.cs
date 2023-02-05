using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Sigesp.Domain.Models;
using System.Numerics;
using Sigesp.Domain.Enums;

namespace Sigesp.Domain.Interfaces
{
    public interface ISequenciaOficioRepository : IRepository<SequenciaOficio>
    {
        IEnumerable<int> GetSequencias(Guid tenantId, SetorEnum setor);
    }
}