using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Sigesp.Domain.Enums
{
    public enum ColaboradorSituacaoEnum
    {
        [Display(Name = "Nenhum")]
        NENHUM = 0,
        [Display(Name = "Em processo admissão")]
        EM_PROCESSO_ADMISSAO = 1,

        [Display(Name = "Admitido")]
        ADMITIDO = 2,

        [Display(Name = "Demitido")]
        DEMITIDO = 3        
    }
}