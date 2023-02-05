using System.ComponentModel.DataAnnotations;

namespace Sigesp.Domain.Enums
{
    public enum EdiLogTipoEnum
    {
        [Display(Name = "Não informado")]
        NAO_INFORMADO = 0,
        [Display(Name = "Mudança")]
        MUDANCA = 1,
        [Display(Name = "Ativação")]
        ATIVACAO = 2,
        [Display(Name = "Desativação")]
        DESATIVACAO = 3,
        [Display(Name = "Exclusão")]
        EXCLUSAO = 4,
        [Display(Name = "Inclusão")]
        INCLUSAO = 5,

        [Display(Name = "Inconsitência")]
        INCONSISTENCIA = 6
    }
}