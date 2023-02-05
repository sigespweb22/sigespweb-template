using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Sigesp.Domain.Enums
{
    public enum TipoContaEnum
    {
        [Display(Name = "Nenhum")]
        NENHUM = 0,

        [Display(Name = "Conta Corrente")]
        CONTA_CORRENTE = 1,

        [Display(Name = "Conta Poupança")]
        CONTA_POUPANCA = 2,

        [Display(Name = "Conta Digital")]
        CONTA_DIGITAL = 3
    }
}