using System.ComponentModel.DataAnnotations;

namespace Sigesp.Domain.Enums
{
    public enum AlunoLeitorOcorrenciaDesistenciaEnum
    {
        [Display(Name = "Nenhuma")]
        NENHUMA = 0,

        [Display(Name = "Egresso")]
        EGRESSO = 1,

        [Display(Name = "Perdeu interesse")]
        PERDEU_INTERESSE = 2,
        
        [Display(Name = "Informou possível progressão de regime")]
        INFO_PROGRESSAO_REGIME = 3,

        [Display(Name = "Inativo sistema antigo")]
        INATIVO_SISTEMA_ANTIGO = 4,

        [Display(Name = "Bloqueado automaticamento por 3 não cumprimentos")]
        BLOQUEIO_AUTOMATICO_NAO_CUMPRIMENTO = 5,

        [Display(Name = "Fim ano letivo")]
        FIM_ANO_LETIVO = 6
    }
}