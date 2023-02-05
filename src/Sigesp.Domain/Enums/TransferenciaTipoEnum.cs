using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Sigesp.Domain.Enums
{
    public enum TransferenciaTipoEnum
    {
        [Display(Name = "Nenhum")]
        NENHUM = 0,
        [Display(Name = "Audiência")]
        AUDIENCIA = 1,

        [Display(Name = "Medida Disciplinar")]
        MEDIDA_DISCIPLINAR = 2
    }
}