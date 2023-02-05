using System.ComponentModel.DataAnnotations;

namespace Sigesp.Domain.Enums
{
    public enum AlunoLeituraAvaliacaoConceitoEnum
    {
        [Display(Name = "Pendente")]
        PENDENTE = 1,

        [Display(Name = "Aprovado")]
        APROVADO = 2,
        
        [Display(Name = "Insuficiente")]
        INSUFICIENTE = 3,

        [Display(Name = "Desistência")]
        DESISTENCIA = 4,

        [Display(Name = "Não cumprimento")]
        NAO_CUMPRIMENTO = 5
    }
}