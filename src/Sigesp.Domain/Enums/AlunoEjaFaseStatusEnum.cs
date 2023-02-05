using System.ComponentModel.DataAnnotations;

namespace Sigesp.Domain.Enums
{
    public enum AlunoEjaFaseStatusEnum
    {
        [Display(Name = "Em curso")]
        EM_CURSO = 1,

        [Display(Name = "Concluída")]
        CONCLUIDA = 2,

        [Display(Name = "Não concluída")]
        NAO_CONCLUIDA = 3,

        [Display(Name = "Concluída parcialmente")]
        CONCLUIDA_PARCIALMENTE = 4,
    }
}