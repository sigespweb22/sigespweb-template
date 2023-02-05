using System.ComponentModel.DataAnnotations;

namespace Sigesp.Domain.Enums
{
    public enum LancamentoTipoEnum
    {
        [Display(Name = "Crédito")]
        CREDITO = 1,
        
        [Display(Name = "Débito")]
        DEBITO = 2
    }
}