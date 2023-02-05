using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Sigesp.Domain.Enums;

namespace Sigesp.Domain.Models
{
    public class Lancamento : EntityAudit
    {
        public Lancamento(string descricao, DateTime dataLiquidacao, 
                         decimal valorLiquido, 
                         int periodoDataInicio, int periodoDataFim,
                        DateTime dataUltimoStatus, string observacao, 
                        LancamentoStatusEnum status, 
                        LancamentoPeriodoReferenciaEnum periodoReferencia,
                        LancamentoTipoEnum tipo)
        {
            Descricao = descricao;
            DataLiquidacao = dataLiquidacao;
            ValorLiquido = valorLiquido;
            PeriodoDataInicio = periodoDataInicio;
            PeriodoDataFim = periodoDataFim;
            DataUltimoStatus = dataUltimoStatus;
            Observacao = observacao;
            Status = status;
            PeriodoReferencia = periodoReferencia;
            Tipo = tipo;
        }

        // Construtor vazio para o EF
        public Lancamento() { }

        public string Descricao { get; set; }
        public DateTime DataLiquidacao { get; set; }
        public decimal ValorLiquido { get; set; }
        public int PeriodoDataInicio { get; set; }
        public int PeriodoDataFim { get; set; }
        public DateTime DataUltimoStatus { get; set; }
        public string Observacao { get; set; }
        public LancamentoStatusEnum Status { get; set; }
        public LancamentoPeriodoReferenciaEnum PeriodoReferencia { get; set; }
        public LancamentoTipoEnum Tipo { get; set; }

        //Relacionamentos
        public Guid ContaCorrenteId { get; set; }
        
        [ForeignKey("ContaCorrenteId")]
        public ContaCorrente ContaCorrente { get;  set; }

        public Guid? ContabilEventoId { get; set; }
        
        [ForeignKey("ContabilEventoId")]
        public ContabilEvento ContabilEvento { get; set; }
    }
}