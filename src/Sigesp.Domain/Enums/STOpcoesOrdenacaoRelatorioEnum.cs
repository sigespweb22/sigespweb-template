using System.ComponentModel.DataAnnotations;

namespace Sigesp.Domain.Enums
{
    public enum STOpcoesOrdenacaoRelatorioEnum
    {
        [Display(Name = "Nome")]
        NOME = 1,

        [Display(Name = "Galeria")]
        GALERIA = 2,

        [Display(Name = "Cela")]
        CELA = 3
    }
}