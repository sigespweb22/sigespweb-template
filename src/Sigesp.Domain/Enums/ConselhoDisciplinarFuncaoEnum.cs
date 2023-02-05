using System.ComponentModel.DataAnnotations;

namespace Sigesp.Domain.Enums
{
    public enum ConselhoDisciplinarFuncaoEnum
    {
        [Display(Name = "Membro do Conselho Disciplinar")]
        MEMBRO_CONSELHO_DISCIPLINAR = 0,

        [Display(Name = "Presidente do Conselho Disciplinar")]
        PRESIDENTE_CONSELHO_DISCIPLINAR = 1,

        [Display(Name = "Secretária(o) do Conselho Disciplinar")]
        SECRETARIO_CONSELHO_DISCIPLINAR = 2
    }
}