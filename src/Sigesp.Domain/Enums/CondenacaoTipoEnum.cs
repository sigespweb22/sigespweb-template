using System.ComponentModel.DataAnnotations;

namespace Sigesp.Domain.Enums
{
    public enum CondenacaoTipoEnum
    {
        [Display(Name = "Nenhum")]
        NENHUM = 0,

        [Display(Name = "Primário sem antecedente")]
        PRIMARIO_SEM_ANTECEDENTES = 1,

        [Display(Name = "Primário com antecedente")]
        PRIMARIO_COM_ANTECEDENTE = 2,

        [Display(Name = "Alimentos")]
        ALIMENTOS = 3,

        // [Display(Name = "Provisório")]
        // PROVISORIO = 4,

        [Display(Name = "Reincidente")]
        REINCIDENTE = 5,

        [Display(Name = "Reincidente específico")]
        REINCIDENTE_ESPECIFICO = 6,
        
        [Display(Name = "Prisão temporária")]
        PRISAO_TEMPORARIA = 7
    }
}