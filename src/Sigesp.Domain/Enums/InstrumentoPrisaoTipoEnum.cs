using System.ComponentModel.DataAnnotations;

namespace Sigesp.Domain.Enums
{
    public enum InstrumentoPrisaoTipoEnum
    {
        [Display(Name = "Nenhum")]
        NENHUM = 0,

        [Display(Name = "Nota de culpa")]
        NOTA_CULPA = 1,

        [Display(Name = "Mandado de prisão")]
        MANDADO_PRISAO = 2,

        [Display(Name = "Transferência")]
        TRANSFERENCIA = 3,

        [Display(Name = "Recaptura")]
        RECAPTURA = 4,
        
        [Display(Name = "Medida disciplinar")]
        MEDIDA_DISCIPLINAR = 5
    }
}