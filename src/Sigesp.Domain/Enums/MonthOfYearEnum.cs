using System.ComponentModel.DataAnnotations;

namespace Sigesp.Domain.Enums
{
    public enum MonthOfYearEnum
    {
        [Display(Name = "Janeiro")]
        JANEIRO = 1,

        [Display(Name = "Fevereiro")]
        FEVEREIRO = 2,

        [Display(Name = "Março")]
        MARCO = 3,

        [Display(Name = "Abril")]
        ABRIL = 4,

        [Display(Name = "Maio")]
        MAIO = 5,

        [Display(Name = "Junho")]
        JUNHO = 6,

        [Display(Name = "Julho")]
        JULHO = 7,

        [Display(Name = "Agosto")]
        AGOSTO = 8,

        [Display(Name = "Setembro")]
        SETEMBRO = 9,

        [Display(Name = "Outubro")]
        OUTUBRO = 10,

        [Display(Name = "Novembro")]
        NOVEMBRO = 11,

        [Display(Name = "Dezembro")]
        DEZEMBRO = 12
    }
}