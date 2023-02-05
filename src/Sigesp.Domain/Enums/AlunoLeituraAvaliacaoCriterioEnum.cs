using System.ComponentModel.DataAnnotations;

namespace Sigesp.Domain.Enums
{
    public enum AlunoLeituraAvaliacaoCriterioEnum
    {
        [Display(Name = "Pendente")]
        PENDENTE = 1,

        [Display(Name = "Insatisfatório")]
        INSATISFATORIO = 2,

        [Display(Name = "Regular")]
        REGULAR = 3,
        
        [Display(Name = "Bom")]
        BOM = 4,

        [Display(Name = "Ótimo")]
        OTIMO = 5
    }
}