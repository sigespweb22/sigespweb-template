using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Sigesp.Domain.Enums
{
    public enum DetentoRegimeEnum
    {
        [Display(Name = "Nenhum")]
        NENHUM = 0,
        
        [Display(Name = "Recolhido Semiaberto")]
        RECOLHIDO_SEMIABERTO = 1,

        [Display(Name = "Recolhido Fechado")]
        RECOLHIDO_FECHADO = 2,

        [Display(Name = "Aberto")]
        REGIME_ABERTO = 3,

        [Display(Name = "Liberdade Condicional")]
        LIBERDADE_CONDICIONAL = 4,

        [Display(Name = "Liberdade Provisória")]
        LIBERDADE_PROVISORIA = 5,

        [Display(Name = "Transferido")]
        TRANSFERIDO = 6,
        
        [Display(Name = "Saída Temporária")]
        SAIDA_TEMPORARIA = 7,

        [Display(Name = "Provisório")]
        PROVISORIO = 8,

        [Display(Name = "Alimentos")]
        ALIMENTOS = 9,

        [Display(Name = "Egresso via Edi")]
        EGRESSO_EDI = 10,

        [Display(Name = "Recolhido via EDI")]
        RECOLHIDO_EDI = 11,

        [Display(Name = "Recolhido via Importação")]
        RECOLHIDO_IMPORTACAO = 12,
        
        [Display(Name = "Prisão Temporária")]
        PRISAO_TEMPORARIA = 13,

        [Display(Name = "Provisório Execução Suspensa")]
        PROVISORIO_EXECUCAO_SUSPENSA = 14,

        [Display(Name = "Internação Hospitalar")]
        INTERNACAO_HOSPITALAR = 15
    }
}