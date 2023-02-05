using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Numerics;
using Sigesp.Domain.Enums;

namespace Sigesp.Domain.Models
{
    public class AlunoEnem : EntityAudit
    {
        public AlunoEnem(DateTime dataProva,
                         string inscricaoNumero,
                         LinguaEstrangeiraEnum linguaEstrangeira,
                         decimal notaCN,
                         decimal notaCH,
                         decimal notaLC,
                         decimal notaMT,
                         decimal notaRedacao,
                         decimal media,
                         bool hasMediaMinima)
        {
            DataProva = dataProva;
            LinguaEstrangeira = linguaEstrangeira;
            NotaCN = notaCN;
            NotaCH = notaCH;
            NotaLC = notaLC;
            NotaMT = notaMT;
            NotaRedacao = notaRedacao;
            Media = media;
            HasMediaMinima = hasMediaMinima;
        }


        //Construtor vazio para o EF
        public AlunoEnem() {}


        public DateTime? DataProva { get; set; }
        public string InscricaoNumero { get; set; }
        public LinguaEstrangeiraEnum LinguaEstrangeira { get; set; }
        

        /// <summary>
            ///Ciências da Natureza e suas Tecnologias.
        /// </summary>
        public decimal? NotaCN { get; set; }

        /// <summary>
            ///Ciências Humanas e suas Tecnologias.
        /// </summary>
        public decimal? NotaCH { get; set; }

        /// <summary>
            ///Linguagens, Códigos e suas Tecnologias.
        /// </summary>
        public decimal? NotaLC { get; set; }

        /// <summary>
            ///Matemática e suas Tecnologias.
        /// </summary>
        public decimal? NotaMT { get; set; }

        //Redação
        public decimal? NotaRedacao { get; set; }
        public decimal? Media { get; set; }
        public bool HasMediaMinima { get; set; }
        

        //Relacionamentos
                
        //Aluno
        [ForeignKey("AlunoId")]
        public Guid AlunoId { get; set; }
        public Aluno Aluno { get; set; }

    }
}