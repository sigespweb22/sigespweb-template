using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Sigesp.Domain.Enums
{
    public enum TipoPagamentoEnum
    {
        [Display(Name = "Nenhum")]
        NENHUM = 0,
        [Display(Name = "Depósito bancário")]
        DEPOSITO_BANCARIO = 1,

        [Display(Name = "DOC bancário")]
        DOC_BANCARIO = 2,

        [Display(Name = "TEC bancária")]
        TED_BANCÁRIA = 3,

        [Display(Name = "PIX")]
        PIX = 4,

        [Display(Name = "Retirada familiar")]
        RETIRADA_FAMILIAR = 5
    }
}