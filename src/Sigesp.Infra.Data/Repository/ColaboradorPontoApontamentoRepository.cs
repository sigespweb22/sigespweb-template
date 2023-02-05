using Sigesp.Domain.Interfaces;
using Sigesp.Domain.Models;
using Sigesp.Infra.Data.Context;

namespace Sigesp.Infra.Data.Repository
{
    public class ColaboradorPontoApontamentoRepository : Repository<ColaboradorPontoApontamento>, IColaboradorPontoApontamentoRepository
    {
        public ColaboradorPontoApontamentoRepository(SigespDbContext context) 
            :base(context) 
        {
        }

        
    }
}