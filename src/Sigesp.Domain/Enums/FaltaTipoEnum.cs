using System.ComponentModel.DataAnnotations;

namespace Sigesp.Domain.Enums
{
    public enum FaltaTipoEnum
    {
        [Display(Name = "Não informada")]
        NAO_INFORMADA = 0,

        [Display(Name = "Leve")]
        LEVE = 1,

        [Display(Name = "Média")]
        MEDIA = 2,

        [Display(Name = "Grave")]
        GRAVE = 3
    }
}