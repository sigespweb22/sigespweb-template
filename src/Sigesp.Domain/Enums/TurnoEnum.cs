using System.ComponentModel.DataAnnotations;

namespace Sigesp.Domain.Enums
{
    public enum TurnoEnum
    {
        [Display(Name = "Não informado")]
        NAO_INFORMADO = 0,

        [Display(Name = "Matutino")]
        MATUTINO = 1,

        [Display(Name = "Vespertino")]
        VESPERTINO = 2,

        [Display(Name = "Noturno")]
        NOTURNO = 3,

        [Display(Name = "Diurno")]
        DIURNO = 4
    }
}