using System.Collections.Generic;
using Sigesp.Domain.Models;

namespace Sigesp.WebUI.Helpers
{
    public static class ServidorEstadoReforcoHelpers  
    {
        public static bool IsDisponivelDia(int reforcosDia, ServidorEstadoReforcoRegraVagaDia vagasDia)
        {
            // Dia indisponível são todos aqueles que não possuem regra de limite de vaga
            // criado para ele, e aqueles em que o total de vagas para o seu turno,
            // é igual ao total de refoços marcados
            if (vagasDia == null) return false;

            int isVagaToDia = vagasDia.TotalVagas - reforcosDia;
            if (isVagaToDia >= 1)
            {   
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}