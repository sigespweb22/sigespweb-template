using System.ComponentModel.DataAnnotations;

namespace Sigesp.Domain.Enums
{
    public enum FuncaoEnum
    {
        [Display(Name = "Não informado")]
        NAO_INFORMADO = 0,

        [Display(Name = "Coordenador Pecúlio")]
        COORDENADOR_PECULIO = 1,

        [Display(Name = "Coordenador Educação")]
        COORDENADOR_EDUCACAO = 2,

        [Display(Name = "Coordenador Jurídico")]
        COORDENADOR_JURIDICO = 3,

        [Display(Name = "Analista de Sistemas")]
        ANALISTA_SISTEMAS = 4,

        [Display(Name = "Arquiteto de Software")]
        ARQUITETO_SOFTWARE = 5,

        [Display(Name = "Coordenador Laboral")]
        COORDENADOR_LABORAL = 6,

        [Display(Name = "Digitador")]
        DIGITADOR = 7,

        [Display(Name = "Professor")]
        PROFESSOR = 8,

        [Display(Name = "Diretor")]
        DIRETOR = 9,

        [Display(Name = "Analista Técnico Administrativo")]
        ANALISTA_TECNICO_ADM = 10,

        [Display(Name = "Técnico em Atividade Administrativa")]
        TECNICO_ATIVIDADE_ADM = 11,

        [Display(Name = "Dentista")]
        DENTISTA = 12,

        [Display(Name = "Enfermeiro")]
        ENFERMEIRO = 13,

        [Display(Name = "Instrutor de Artes")]
        INSTRUTOR_ARTES = 14,

        [Display(Name = "Instrutor de Horta e Jardinagem")]
        INSTRUTOR_HORTA_JARDINAGEM = 15,

        [Display(Name = "Instrutor de Informática")]
        INSTRUTOR_INFORMATICA = 16,

        [Display(Name = "Instrutor de Panificação")]
        INSTRUTOR_PANIFICACAO = 17,

        [Display(Name = "Instrutor de Marcenaria")]
        INSTRUTOR_MARCENARIA = 18,

        [Display(Name = "Médico")]
        MEDICO = 19,

        [Display(Name = "Pedagogo")]
        PEDAGOGO = 20,

        [Display(Name = "Farmacêutico")]
        FARMACEUTICO = 21,

        [Display(Name = "Nutricionista")]
        NUTRICIONISTA = 22,

        [Display(Name = "Assistente Social")]
        ASSISTENTE_SOCIAL = 23,

        [Display(Name = "Técnico em Enfermagem")]
        TECNICO_ENFERMAGEM = 24,

        [Display(Name = "Técnico em Saúde Bucal")]
        TECNICO_SAUDE_BUCAL = 25,

        [Display(Name = "Coordenador Saúde")]
        COORDENADOR_SAUDE = 26,

        [Display(Name = "Psicólogo (a)")]
        PSICOLOGO_A = 27,

        [Display(Name = "Orientador (a) Leitura")]
        ORIENTADORA_LEITURA = 28
    }
}