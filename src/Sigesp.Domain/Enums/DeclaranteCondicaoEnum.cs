using System.ComponentModel.DataAnnotations;

namespace Sigesp.Domain.Enums
{
    public enum DeclaranteCondicaoEnum
    {
        [Display(Name = "Não informado")]
        NAO_INFORMADO = 0,

        [Display(Name = "Vítima")]
        VITIMA = 1,

        [Display(Name = "Réu")]
        REU = 2,

        [Display(Name = "Testemunha")]
        TESTEMUNHA = 3
    }
}