using System.ComponentModel.DataAnnotations;

namespace Sigesp.Domain.Enums
{
    public enum AlunoEjaDisciplinaEnum
    {
        [Display(Name = "Língua portuguesa")]
        LINGUA_PORTUGUESA = 1,

        [Display(Name = "Matemática")]
        MATEMATICA = 2,

        [Display(Name = "Geografia")]
        GEOGRAFIA = 3,

        [Display(Name = "História")]
        HISTORIA = 4,
        
        [Display(Name = "Educação física")]
        EDUC_FISICA = 5,

        [Display(Name = "Inglês")]
        INGLES = 6,

        [Display(Name = "Espanhol")]
        ESPANHOL = 7,

        [Display(Name = "Ciências")]
        CIENCIAS = 8,

        [Display(Name = "Artes")]
        ARTES = 9,

        [Display(Name = "CCTT - LP")]
        CCTT_LP = 10,

        [Display(Name = "CCTT - MAT")]
        CCTT_MAT = 11,

        [Display(Name = "CCTT - GEO")]
        CCTT_GEO = 12,

        [Display(Name = "CCTT - HIS")]
        CCTT_HIS = 13,

        [Display(Name = "CCTT - EF")]
        CCTT_EF = 14,

        [Display(Name = "CCTT - LEI")]
        CCTT_LEI = 15,

        [Display(Name = "CCTT - LEE")]
        CCTT_LEE = 16,

        [Display(Name = "CCTT - CIE")]
        CCTT_CIE = 17,

        [Display(Name = "CCTT - ART")]
        CCTT_ART = 18,

        [Display(Name = "CCTT - LPL")]
        CCTT_LPL = 19,

        [Display(Name = "CCTT - BIO")]
        CCTT_BIO = 20,

        [Display(Name = "Biologia")]
        BIOLOGIA = 21,

        [Display(Name = "Literatura")]
        LITERATURA = 22,

        [Display(Name = "Sociologia")]
        SOCIOLOGIA = 23,

        [Display(Name = "Física")]
        FISICA = 24,

        [Display(Name = "Química")]
        QUIMICA = 25,

        [Display(Name = "Filosofia")]
        FILOSOFIA = 26,

        [Display(Name = "Linguagem e Ciências Humanas")]
        LINGUAGEM_CIENCIAS_HUMANAS = 27,

        [Display(Name = "Matemática e Ciências da Natureza")]
        MATEMATICA_CIENCIAS_NATUREZA = 28
    }
}