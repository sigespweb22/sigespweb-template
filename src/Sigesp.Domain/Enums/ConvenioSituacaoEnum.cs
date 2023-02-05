using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Sigesp.Domain.Enums
{
    public enum ConvenioSituacaoEnum
    {
        [Display(Name = "Ativo")]
        ATIVO = 1,

        [Display(Name = "Em análise")]
        EM_ANALISE = 2,

        [Display(Name = "Encerrado")]
        ENCERRADO = 3
    }
}