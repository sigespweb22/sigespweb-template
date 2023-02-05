using System.ComponentModel.DataAnnotations;

namespace Sigesp.Domain.Enums
{
    public enum EdiStatusEnum
    {
        [Display(Name = "Não informado")]
        NAO_INFORMADO = 0,

        [Display(Name = "Processando")]
        PROCESSANDO = 1,

        [Display(Name = "Concluído")]
        CONCLUIDO = 2,

        [Display(Name = "Não processado")]
        NAO_PROCESSADO = 3
    }
}