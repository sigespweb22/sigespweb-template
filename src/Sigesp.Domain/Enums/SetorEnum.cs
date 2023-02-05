using System.ComponentModel.DataAnnotations;

namespace Sigesp.Domain.Enums
{
    public enum SetorEnum
    {
        [Display(Name = "Não informado")]
        NAO_INFORMADO = 0,
        
        [Display(Name = "Jurídico")]
        JURIDICO = 1,

        [Display(Name = "Gerência")]
        GERENCIA = 2,

        [Display(Name = "Apoio Gerência")]
        APOIO_GERENCIA = 3,

        [Display(Name = "Recursos Humanos")]
        RECURSOS_HUMANOS = 4,

        [Display(Name = "Educação")]
        EDUCACAO = 5,

        [Display(Name = "Social")]
        SOCIAL = 6,

        [Display(Name = "Psicologia")]
        PSICOLOGIA = 7,

        [Display(Name = "Laboral")]
        LABORAL = 8,

        [Display(Name = "Pecúlio")]
        PECULIO = 9,

        [Display(Name = "Operacional")]
        OPERACIONAL = 10,

        [Display(Name = "Segurança")]
        SEGURANCA = 11,

        [Display(Name = "Galeria")]
        GALERIA = 12,

        [Display(Name = "Tecnologia da Informação")]
        TECNOLOGIA_INFORMACAO = 13,

        [Display(Name = "Diretoria")]
        DIRETORIA = 14,

        [Display(Name = "Escolta")]
        ESCOLTA = 15
    }
}