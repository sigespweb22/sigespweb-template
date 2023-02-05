using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Sigesp.Domain.Enums
{
    public enum ContaCorrenteTipoEnum
    {
        [Display(Name = "Pessoa física")]
        PESSOA_FISICA = 1,

        [Display(Name = "Pessoa jurídica")]
        PESSOA_JURIDICA = 2,

        [Display(Name = "Cofre")]
        COFRE = 3
    }
}