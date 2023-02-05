using System.ComponentModel.DataAnnotations;

namespace Sigesp.Domain.Enums
{
    public enum FaseEnum
    {
        [Display(Name = "Não informado")]
        NAO_INFORMADO = 0,

        [Display(Name = "Fase 1")]
        FASE_1 = 1,

        [Display(Name = "Fase 2")]
        FASE_2 = 2,

        [Display(Name = "Fase 3")]
        FASE_3 = 3,

        [Display(Name = "Fase 4")]
        FASE_4 = 4,

        [Display(Name = "Fase 5")]
        FASE_5 = 5
    }
}