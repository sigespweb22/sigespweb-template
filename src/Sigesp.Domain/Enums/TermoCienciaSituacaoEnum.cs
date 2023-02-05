using System.ComponentModel.DataAnnotations;

namespace Sigesp.Domain.Enums
{
    public enum TermoCienciaSituacaoEnum
    {
        [Display(Name = "Não criado")]
        NAO_CRIADO = 0,

        [Display(Name = "Criado")]
        CRIADO = 1,

        [Display(Name = "Enviado ao detento para ciência e assinatura")]
        ENVIADO_DETENTO = 2,

        [Display(Name = "Enviado ao defensor")]
        ENVIADO_DEFENSOR = 3,
    }
}