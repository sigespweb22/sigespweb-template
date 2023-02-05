using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Numerics;
using Sigesp.Domain.Enums;

namespace Sigesp.Domain.Models
{
    public class AlunoEncceja : EntityAudit
    {
        public AlunoEncceja(CursoEnum curso,
                            DateTime dataProva,
                            string inscricaoNumero,
                            decimal notaAreaI,
                            decimal notaAreaII,
                            decimal notaAreaIII,
                            decimal notaAreaIV,
                            decimal notaRedacao,
                            decimal media,
                            bool hasCertificado,
                            bool isAprovado)
        {
            Curso = curso;
            DataProva = dataProva;
            InscricaoNumero = inscricaoNumero;
            NotaAreaI = notaAreaI;
            NotaAreaII = notaAreaII;
            NotaAreaIII = notaAreaIII;
            NotaAreaIV = notaAreaIV;
            NotaRedacao = notaRedacao;
            Media = media;
            HasCertificado = hasCertificado;
            IsAprovado = isAprovado;
        }

        //Construtor vazio para o EF
        public AlunoEncceja() {}


        public CursoEnum Curso { get; set; }
        public DateTime? DataProva { get; set; }
        public string InscricaoNumero { get; set; }
        
        /// <summary>
            ///Ensino Médio
            ///Linguages, Códigos e suas tecnologias - Língua portuguesa, Lingua Estrangeira Moderna - Arte, Educação Física
            ///Ensino Fundamental
            ///Língua portuguesa, Lingua Estrangeira Moderna - Arte, Educação Física
        /// </summary>
        public decimal? NotaAreaI { get; set; }

        /// <summary>
            ///Ensino Médio
            ///Matemática e suas tecnologias
            ///Ensino Fundamental
            ///Matemática
        /// </summary>
        public decimal? NotaAreaII { get; set; }
        
        /// <summary>
            ///Ensino Médio
            ///Ciências Humanas e suas tecnologias - História, Geografia, Filosofia, Sociologia
            ///Ensino Fundamental
            ///História, Geografia
        /// </summary>
        public decimal? NotaAreaIII { get; set; }
        
        /// <summary>
            ///Ensino Médio
            ///Ciências da Natureza e suas tecnologias - Física, Química, Biologia
            ///Ensino Fundamental
            ///Ciências Naturais
        /// </summary>
        public decimal? NotaAreaIV { get; set; }

        //Redação
        public decimal? NotaRedacao { get; set; }


        public decimal? Media { get; set; }
        public bool HasCertificado { get; set; }
        public bool IsAprovado { get; set; }
        
        
        
        //Relacionamentos
                
        //Aluno
        [ForeignKey("AlunoId")]
        public Guid AlunoId { get; set; }
        public Aluno Aluno { get; set; }

    }
}