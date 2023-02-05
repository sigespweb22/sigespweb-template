using System.ComponentModel.DataAnnotations;

namespace Sigesp.Domain.Enums
{
    public enum SexoEnum
    {
        [Display(Name = "Não informado")]
        NAO_INFORMADO = 0,

        [Display(Name = "Masculino")]
        MASCULINO = 1,

        [Display(Name = "Feminino")]
        FEMININO = 2
    }
}