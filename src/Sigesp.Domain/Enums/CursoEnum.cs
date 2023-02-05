using System.ComponentModel.DataAnnotations;

namespace Sigesp.Domain.Enums
{
    public enum CursoEnum
    {
        [Display(Name = "Não informado")]
        NAO_INFORMADO = 0,

        [Display(Name = "Ensino fundamental I")]
        ENSINO_FUNDAMENTAL_I = 1,

        [Display(Name = "Ensino fundamental II")]
        ENSINO_FUNDAMENTAL_II = 2,

        [Display(Name = "Ensino médio")]
        ENSINO_MEDIO = 3,

        [Display(Name = "Ensino superior")]
        ENSINO_SUPERIOR = 4,

        [Display(Name = "Ensino médio novo")]
        ENSINO_MEDIO_NOVO = 5
    }
}