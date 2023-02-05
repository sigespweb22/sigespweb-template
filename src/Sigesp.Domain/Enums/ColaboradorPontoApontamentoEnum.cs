using System.ComponentModel.DataAnnotations;

namespace Sigesp.Domain.Enums
{
    public enum ColaboradorPontoApontamentoEnum
    {
        [Display(Name = "Nenhum")]
        NENHUM = 0,

        [Display(Name = "Presença")]
        P = 1,

        [Display(Name = "Falta")]
        F = 2,

        [Display(Name = "Saída temporária")]
        ST = 3,

        [Display(Name = "Descanso semanal")]
        DS = 4,

        [Display(Name = "Desligamento/Demissão")]
        DM = 5,

        [Display(Name = "Hora extra")]
        HE = 6
    }
}