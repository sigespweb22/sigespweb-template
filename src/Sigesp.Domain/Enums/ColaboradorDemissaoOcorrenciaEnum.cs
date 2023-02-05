using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Sigesp.Domain.Enums
{
    public enum ColaboradorDemissaoOcorrenciaEnum
    {
        [Display(Name = "Nenhuma")]
        NENHUMA = 0,
        [Display(Name = "Progressão regime")]
        PROGRESSAO_REGIME = 1,

        [Display(Name = "Solicitação empresa")]
        SOLICITACAO_EMPRESA = 2,

        [Display(Name = "Instauração PAD")]
        INSTAURACAO_PAD = 3,

        [Display(Name = "Afastamento por motivo médicos")]
        AFASTAMENTO_MOTIVOS_MEDICOS = 4,

        [Display(Name = "Demissao via sistema")]
        DEMISSAO_VIA_SISTEMA = 5,

        [Display(Name = "Solicitação Chefe de Segurança")]
        SOLICITACAO_CHEFE_SEGURANCA = 6,

        [Display(Name = "Troca de convênio")]
        TROCA_CONVENIO = 7,

        [Display(Name = "Afastamento por motivos disciplinares")]
        AFASTAMENTO_MOTIVOS_DISCIPLINARES = 8,

        [Display(Name = "Alvará de soltura")]
        ALVARA_SOLTURA = 9
    }
}