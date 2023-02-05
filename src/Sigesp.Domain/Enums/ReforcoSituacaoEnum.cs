using System.ComponentModel.DataAnnotations;

namespace Sigesp.Domain.Enums
{
    public enum ReforcoSituacaoEnum
    {
        [Display(Name = "Nenhuma")]
        NENHUMA = 0,

        [Display(Name = "Agendado")]
        AGENDADO = 1,
        
        [Display(Name = "Realizado")]
        REALIZADO = 2,

        [Display(Name = "Cancelado")]
        CANCELADO = 3
    }
}