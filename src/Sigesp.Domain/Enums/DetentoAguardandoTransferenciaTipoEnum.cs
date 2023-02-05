using System.ComponentModel.DataAnnotations;

namespace Sigesp.Domain.Enums
{
    public enum DetentoAguardandoTransferenciaTipoEnum
    {
        [Display(Name = "Não informado")]
        NAO_INFORMADO = 0,

        [Display(Name = "Intermunicipal")]
        INTERMUNICIPAL = 1,

        [Display(Name = "Interestadual")]
        INTERESTADUAL = 2,

        [Display(Name = "Internacional")]
        INTERNACIONAL = 3,

        [Display(Name = "Término de medida disciplinar")]
        TERMINO_MD = 4
    }
}