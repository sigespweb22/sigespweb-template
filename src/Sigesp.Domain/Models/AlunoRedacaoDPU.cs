using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Numerics;
using Sigesp.Domain.Enums;

namespace Sigesp.Domain.Models
{
    public class AlunoRedacaoDPU : EntityAudit
    {
        public AlunoRedacaoDPU(string inscricaoNumero,
                                DateTime dataLimiteEntregaRedacao,
                                CursoEnum etapa,
                                bool isPrivadoLiberdade,
                                string redacaoImagem,
                                decimal media,
                                decimal notaCriativade,
                                decimal notaConteudo,
                                decimal notaClareza,
                                decimal notaPertinencia,
                                string certificadoImagem,
                                int resultadoColocacao)
        {
            InscricaoNumero = inscricaoNumero;
            DataLimiteEntregaRedacao = dataLimiteEntregaRedacao;
            Etapa = etapa;
            IsPrivadoLiberdade = isPrivadoLiberdade;
            RedacaoImagem = redacaoImagem;
            Media = media;
            NotaCriatividade = notaCriativade;
            NotaConteudo = notaConteudo;
            NotaClareza = notaClareza;
            NotaPertinencia = notaPertinencia;
            CertificadoImagem = certificadoImagem;
            ResultadoColocacao = resultadoColocacao;
        }


        //Construtor vazio para o EF
        public AlunoRedacaoDPU() {}


        public string InscricaoNumero { get; set; }
        public DateTime? DataLimiteEntregaRedacao { get; set; }
        public CursoEnum Etapa { get; set; }
        public bool IsPrivadoLiberdade { get; set; }
        public string RedacaoImagem { get; set; }

        /// <summary>
            ///Média
        /// </summary>
        public decimal? Media { get; set; }

        /// <summary>
            ///Nota pela criatividade
        /// </summary>
        public decimal? NotaCriatividade { get; set; }

        /// <summary>
            ///Nota pelo conteúdo
        /// </summary>
        public decimal? NotaConteudo { get; set; }

        /// <summary>
            ///Nota pela clareza
        /// </summary>
        public decimal? NotaClareza { get; set; }

        /// <summary>
            ///Nota pela pertinência
        /// </summary>
        public decimal? NotaPertinencia { get; set; }

        public string CertificadoImagem { get; set; }
        public int ResultadoColocacao { get; set; }


        //Relacionamentos
                
        //Aluno
        [ForeignKey("AlunoId")]
        public Guid AlunoId { get; set; }
        public Aluno Aluno { get; set; }

        //Aluno
        [ForeignKey("ProfessorId")]
        public Guid ProfessorId { get; set; }
        public Professor Professor { get; set; }

        //Definição dos campos da entidade
        //Escolaridade                            - Está na entidade principal - ALUNO
        //Telefone                                - Está na entidade DETENTO, vinculada a principal - ALUNO
        //Etapa                                   - Cursos (OPÇÕES - ENSINO MÉDIO OU FUNDAMENTAL)
        //IsPrivadoLiberdade (Default TRUE)       - Entidade AlunoRedacaoDPU
        //DataNascimento                          - Está na entidade DETENTO, vinculada a principal - ALUNO
        //Professor                               - Entidade AlunoRedacaoDPU
        //CEP                                     - Está na entidade DETENTO, vinculada a principal - ALUNO
        //Cidade                                  - Está na entidade DETENTO, vinculada a principal - ALUNO
        //Estado                                  - Está na entidade DETENTO, vinculada a principal - ALUNO
        //Logradouro                              - Está na entidade DETENTO, vinculada a principal - ALUNO
        //Numero                                  - Está na entidade DETENTO, vinculada a principal - ALUNO
        //Complemento                             - Está na entidade DETENTO, vinculada a principal - ALUNO
        //Bairro                                  - Está na entidade DETENTO, vinculada a principal - ALUNO
        //ProfessorId                             - Entidade AlunoRedacaoDPU - Foreign Key
        //Imagem redação                          - Entidade AlunoRedacaoDPU  
        //Media                                   - Entidade AlunoRedacaoDPU
        //Idade                                   - Está na entidade DETENTO, vinculada a principal - ALUNO
        //NotaCriativade                          - Entidade AlunoRedacaoDPU
        //NotaConteudo                            - Entidade AlunoRedacaoDPU
        //NotaClareza                             - Entidade AlunoRedacaoDPU
        //NotaPertinencia                         - Entidade AlunoRedacaoDPU
        //Imagem Certificado                      - Entidade AlunoRedacaoDPU
        //ResultadoColocação                      - Entidade AlunoRedacaoDPU

    }
}