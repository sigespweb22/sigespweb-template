using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Sigesp.Domain.Enums
{
    public enum AndamentoPenalStatusEnum
    {
        [Display(Name = "Normal")]
        NORMAL = 0,

        [Display(Name = "CTC em andamento")]
        CTC_EM_ANDAMENTO = 1,

        [Display(Name = "PAD em andamento")]
        PAD_EM_ANDAMENTO = 2,

        [Display(Name = "Saida temporária")]
        SAIDA_TEMPORARIA = 3,

        [Display(Name = "Evasão/Fuga")]
        EVASAO_FUGA = 4,

        [Display(Name = "Prisão Domiciliar")]
        PRISAO_DOMICILIAR = 5
    }
}