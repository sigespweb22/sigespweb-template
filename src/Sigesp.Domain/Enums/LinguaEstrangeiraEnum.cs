using System.ComponentModel.DataAnnotations;

namespace Sigesp.Domain.Enums
{
    public enum LinguaEstrangeiraEnum
    {

        [Display(Name = "Não informado")]
        NAO_INFORMADO = 0,

        [Display(Name = "Inglês")]
        INGLES = 1,
        
        [Display(Name = "Espanhol")]
        ESPANHOL = 2
    }
}