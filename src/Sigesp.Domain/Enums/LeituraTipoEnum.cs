using System.ComponentModel.DataAnnotations;

namespace Sigesp.Domain.Enums
{
    public enum LeituraTipoEnum
    {
        [Display(Name = "Leitura para remição")]
        LEITURA_REMICAO = 1,

        [Display(Name = "Leitura social")]
        LEITURA_SOCIAL = 2
    }
}