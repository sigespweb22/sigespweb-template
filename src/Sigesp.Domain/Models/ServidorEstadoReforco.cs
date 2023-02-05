using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Sigesp.Domain.Enums;

namespace Sigesp.Domain.Models
{
    public class ServidorEstadoReforco : EntityAudit
    {
        public ServidorEstadoReforco(DateTime dataPrevistaInicio,
                                     DateTime dataPrevistaFim,
                                     string diaSemana,
                                     TimeSpan horarioInicio,
                                     TimeSpan horarioFim,
                                     string mesExtenso,
                                     int mesNumeral,
                                     ReforcoSituacaoEnum reforcoSituacao)
        {   
            DataPrevistaInicio = dataPrevistaInicio;
            DataPrevistaFim = dataPrevistaFim;
            DiaSemana = diaSemana;
            MesExtenso = mesExtenso;
            MesNumeral = MesNumeral;
            ReforcoSituacao = reforcoSituacao;
        }

        //Construtor vazio para o EF
        public ServidorEstadoReforco() { }

        public DateTime DataPrevistaInicio { get; set; }
        public DateTime DataPrevistaFim { get; set; }
        public string DiaSemana { get; set; }
        public string MesExtenso { get; set; }
        public int MesNumeral { get; set; }
        public ReforcoSituacaoEnum ReforcoSituacao { get; set; }
        public bool IsExpediente { get; set; }



        //Relacionamentos
        [ForeignKey("ServidorEstadoId")]
        public Guid ServidorEstadoId { get; set; }
        public ServidorEstado ServidorEstado { get;  set; }
    }
}