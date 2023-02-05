using System;
using Sigesp.Domain.Models;

namespace Sigesp.Domain.Interfaces
{
    public interface IColaboradorPontoRepository : IRepository<ColaboradorPonto> 
    {
        bool IsAlreadyDataInicioDataFimEmpresaConvenio(DateTime dataInicio,
                                                                  DateTime dataFim,
                                                                  Guid empresaConvenioId);
    }
}