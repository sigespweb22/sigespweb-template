using System;
using System.ComponentModel.DataAnnotations.Schema;
using Sigesp.Domain.Enums;

namespace Sigesp.Domain.Models
{
    public class AlunoLeitura : EntityAudit
    {
        public AlunoLeitura(LeituraTipoEnum leituraTipo,
                            DateTime dataInicio,
                            DateTime dataFim,
                            AlunoLeituraAvaliacaoCriterioEnum avaliacaoCriterio1,
                            AlunoLeituraAvaliacaoCriterioEnum avaliacaoCriterio2,
                            AlunoLeituraAvaliacaoCriterioEnum avaliacaoCriterio3,
                            AlunoLeituraAvaliacaoCriterioEnum avaliacaoCriterio4,
                            AlunoLeituraAvaliacaoCriterioEnum avaliacaoCriterio5,
                            AlunoLeituraAvaliacaoCriterioEnum avaliacaoCriterio6,
                            AlunoLeituraAvaliacaoCriterioEnum avaliacaoCriterio7,
                            AlunoLeituraAvaliacaoConceitoEnum avaliacaoConceito,
                            string avaliacaoConceitoJustificativa,
                            string avaliacaoObservacao,
                            Int64 chaveLeitura,
                            bool isAvaliado,
                            bool hasOficio,
                            int oficioNumero,
                            DateTime oficioDataCriacao)
        {
            LeituraTipo = leituraTipo;
            DataInicio = dataInicio;
            DataFim = dataFim;
            AvaliacaoCriterio1 = avaliacaoCriterio1;
            AvaliacaoCriterio2 = avaliacaoCriterio2;
            AvaliacaoCriterio3 = avaliacaoCriterio3;
            AvaliacaoCriterio4 = avaliacaoCriterio4;
            AvaliacaoCriterio5 = avaliacaoCriterio5;
            AvaliacaoCriterio6 = avaliacaoCriterio6;
            AvaliacaoCriterio7 = avaliacaoCriterio7;
            AvaliacaoConceito = avaliacaoConceito;
            AvaliacaoConceitoJustificativa = avaliacaoConceitoJustificativa;
            AvaliacaoObservacao = avaliacaoObservacao;
            ChaveLeitura = chaveLeitura;
            IsAvaliado = isAvaliado;
            HasOficio  = hasOficio;
            OficioNumero = oficioNumero;
            OficioDataCriacao = oficioDataCriacao;
        }
        
        //Construtor vazio para o EF
        public AlunoLeitura() {}

        public LeituraTipoEnum LeituraTipo { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public AlunoLeituraAvaliacaoCriterioEnum AvaliacaoCriterio1 { get; set; }
        public AlunoLeituraAvaliacaoCriterioEnum AvaliacaoCriterio2 { get; set; }
        public AlunoLeituraAvaliacaoCriterioEnum AvaliacaoCriterio3 { get; set; }
        public AlunoLeituraAvaliacaoCriterioEnum AvaliacaoCriterio4 { get; set; }
        public AlunoLeituraAvaliacaoCriterioEnum AvaliacaoCriterio5 { get; set; }
        public AlunoLeituraAvaliacaoCriterioEnum AvaliacaoCriterio6 { get; set; }
        public AlunoLeituraAvaliacaoCriterioEnum AvaliacaoCriterio7 { get; set; }
        public AlunoLeituraAvaliacaoConceitoEnum AvaliacaoConceito { get; set; }
        public string AvaliacaoConceitoJustificativa { get; set; }
        public string AvaliacaoObservacao { get; set; }
        public Int64 ChaveLeitura { get; set; }
        public DateTime DataAvaliacao { get; set; }
        public bool IsAvaliado { get; set; }
        public bool HasOficio { get; set; }
        public int OficioNumero { get; set; }
        public DateTime OficioDataCriacao { get; set; }

        
        //Relacionamentos
        
        //Aluno leitura
        [ForeignKey("AlunoLeitorId")]
        public Guid AlunoLeitorId { get; set; }
        public AlunoLeitor AlunoLeitor { get; set; }

        //Livro
        [ForeignKey("LivroId")]
        public Guid LivroId { get; set; }
        public Livro Livro { get; set; }

        //Cronograma
        [ForeignKey("AlunoLeituraCronogramaId")]
        public Guid AlunoLeituraCronogramaId { get; set; }
        public AlunoLeituraCronograma AlunoLeituraCronograma { get; set; }

        //Tenant
        [ForeignKey("TenantId")]
        public Guid TenantId { get; set; }
        public Tenant Tenant { get; set; }
    }
}