using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Sigesp.Domain.Enums
{
    public enum ColaboradorFuncaoEnum
    {
        [Display(Name = "Nenhuma")]
        NENHUMA = 0,

        [Display(Name = "Auxiliar de cozinha")]
        AUXILIAR_COZINHA = 1,

        [Display(Name = "Auxiliar de produção")]
        AUXILIAR_PRODUCAO = 2,

        [Display(Name = "Serviços gerais")]
        SERVICOS_GERAIS = 3,

        [Display(Name = "Manutenção predial")]
        MANUTENCAO_PREDIAL = 4,

        [Display(Name = "Cozinheiro (a)")]
        COZINHEIRO = 5,

        [Display(Name = "Regalia galeria")]
        REGALIA_GALERIA = 6,

        [Display(Name = "Estoquista")]
        ESTOQUISTA = 7,

        [Display(Name = "Enfermeiro")]
        ENFERMEIRO = 8,

        [Display(Name = "Jardineiro")]
        JARDINEIRO = 9,

        [Display(Name = "Assistente administrativo")]
        ASSISTENTE_ADMINISTRATIVO = 10,

        [Display(Name = "Lavador automotivo")]
        LAVADOR_AUTOMOTIVO = 11
    }
}