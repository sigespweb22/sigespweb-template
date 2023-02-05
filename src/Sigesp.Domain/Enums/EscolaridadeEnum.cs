using System.ComponentModel.DataAnnotations;

namespace Sigesp.Domain.Enums
{
    public enum EscolaridadeEnum
    {
        [Display(Name = "Não informado")]
        NAO_INFORMADO = 0,

        [Display(Name = "Ensino Fundamental I")]
        ENSINO_FUNDAMENTAL_I = 1,

        [Display(Name = "Ensino Fundamental II")]
        ENSINO_FUNDAMENTAL_II = 2,

        [Display(Name = "Ensino Médio")]
        ENSINO_MEDIO = 3,

        [Display(Name = "Ensino Superior")]
        ENSINO_SUPERIOR = 4
    }
}