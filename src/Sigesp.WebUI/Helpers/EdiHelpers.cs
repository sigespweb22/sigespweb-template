using System;
using Sigesp.Domain.Enums;

namespace Sigesp.WebUI.Helpers
{
    public static class EdiHelpers
    {
        public static DetentoRegimeEnum GetDetentoRegimeEnumByRegime(string regime)
        {
            switch (regime)
            {
                case "RECOLHIDO - RECEBENDO VISITAÇÃO - PROVISÓRIO":
                    return DetentoRegimeEnum.PROVISORIO;
                case "RECOLHIDO(A) - FECHADO (INCIDENTE DISCIPLINAR)":
                    return DetentoRegimeEnum.RECOLHIDO_FECHADO;
                case "RECOLHIDO(A) - FECHADO":
                    return DetentoRegimeEnum.RECOLHIDO_FECHADO;
                case "RECOLHIDO(A) - PRISÃO TEMPORÁRIA":
                    return DetentoRegimeEnum.PRISAO_TEMPORARIA;
                case "RECOLHIDO(A) - PROVISÓRIO (EXECUÇÃO SUSPENSA)":
                    return DetentoRegimeEnum.PROVISORIO_EXECUCAO_SUSPENSA;
                case "RECOLHIDO(A) - PROVISÓRIO":
                    return DetentoRegimeEnum.PROVISORIO;
                case "RECOLHIDO(A) - SEMIABERTO (INCIDENTE DISCIPLINAR)":
                    return DetentoRegimeEnum.RECOLHIDO_SEMIABERTO;
                case "RECOLHIDO(A) - SEMIABERTO":
                    return DetentoRegimeEnum.RECOLHIDO_SEMIABERTO;
                case "SAÍDA TEMPORÁRIA - SEMIABERTO":
                    return DetentoRegimeEnum.SAIDA_TEMPORARIA;
                case "SAÍDA TEMPORÁRIA - FECHADO":
                    return DetentoRegimeEnum.SAIDA_TEMPORARIA;
                case "TRABALHO EXTERNO - SEMIABERTO":
                    return DetentoRegimeEnum.RECOLHIDO_SEMIABERTO;
                case "TRABALHO INTERNO - FECHADO":
                    return DetentoRegimeEnum.RECOLHIDO_FECHADO;
                case "TRABALHO INTERNO - FECHADO (INCIDENTE DISCIPLINAR)":
                    return DetentoRegimeEnum.RECOLHIDO_FECHADO;
                case "TRABALHO INTERNO - PROVISÓRIO (EXECUÇÃO SUSPENSA)":
                    return DetentoRegimeEnum.PROVISORIO_EXECUCAO_SUSPENSA;
                case "TRABALHO INTERNO - PROVISÓRIO":
                    return DetentoRegimeEnum.PROVISORIO;
                case "TRABALHO INTERNO - RECEBENDO VISITAÇÃO - SEMIABERTO":
                    return DetentoRegimeEnum.RECOLHIDO_SEMIABERTO;
                case "TRABALHO INTERNO - SEMIABERTO":
                    return DetentoRegimeEnum.RECOLHIDO_SEMIABERTO;
                case "VIDEOAUDIÊNCIA INTERNA - PROVISÓRIO":
                    return DetentoRegimeEnum.PROVISORIO;
                case "VIDEOAUDIÊNCIA INTERNA - SEMIABERTO":
                    return DetentoRegimeEnum.RECOLHIDO_SEMIABERTO;
                case "VIDEOCONFERÊNCIA - PROVISÓRIO (EXECUÇÃO SUSPENSA)":
                    return DetentoRegimeEnum.PROVISORIO_EXECUCAO_SUSPENSA;
                case "RECOLHIDO - RECEBENDO VISITAÇÃO - FECHADO":
                    return DetentoRegimeEnum.RECOLHIDO_FECHADO;
                case "RECOLHIDO - RECEBENDO VISITAÇÃO - SEMIABERTO":
                    return DetentoRegimeEnum.RECOLHIDO_SEMIABERTO;
                case "SAÍDA PARA PERÍCIA MÉDICA - FECHADO":
                    return DetentoRegimeEnum.RECOLHIDO_FECHADO;
                case "INTERNAÇÃO HOSPITALAR - FECHADO (INCIDENTE DISCIPLINAR)":
                    return DetentoRegimeEnum.RECOLHIDO_FECHADO;
                case "EXAME EXTERNO - FECHADO":
                    return DetentoRegimeEnum.RECOLHIDO_FECHADO;
                case "PRESTAÇÃO DE DEPOIMENTO - PROVISÓRIO":
                    return DetentoRegimeEnum.PROVISORIO;
                case "RECOLHIDO - RECEBENDO VISITAÇÃO - PROVISÓRIO (EXECUÇÃO SUSPENSA)":
                    return DetentoRegimeEnum.PROVISORIO_EXECUCAO_SUSPENSA;
                case "ATENDIMENTO PSICOLÓGICO/CTC - SEMIABERTO":
                    return DetentoRegimeEnum.RECOLHIDO_SEMIABERTO;
                default:
                    if (regime.Contains("FECHADO")) return DetentoRegimeEnum.RECOLHIDO_FECHADO;
                    if (regime.Contains("PROVISÓRIO")) return DetentoRegimeEnum.PROVISORIO;
                    if (regime.Contains("SEMIABERTO")) return DetentoRegimeEnum.RECOLHIDO_SEMIABERTO;
                    if (regime.Contains("TEMPORÁRIA")) return DetentoRegimeEnum.PRISAO_TEMPORARIA;
                    if (regime.Contains("ALIMENTOS")) return DetentoRegimeEnum.ALIMENTOS;

                    return DetentoRegimeEnum.PROVISORIO;
            }
        }

        
    }
}