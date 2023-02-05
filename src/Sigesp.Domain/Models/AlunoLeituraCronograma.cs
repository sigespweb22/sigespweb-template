using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Numerics;
using Sigesp.Domain.Enums;

namespace Sigesp.Domain.Models
{
    public class AlunoLeituraCronograma : EntityAudit
    {
        public AlunoLeituraCronograma(DateTime anoReferencia,
                                      DateTime periodoInicio,
                                      DateTime periodoFim,
                                      int periodoReferencia,
                                      int diasPeriodo,
                                      string nome)
        {
            AnoReferencia = anoReferencia;
            PeriodoInicio = periodoInicio;
            PeriodoFim = periodoFim;
            PeriodoReferencia = periodoReferencia;
            DiasPeriodo = diasPeriodo;
            Nome = nome;
        }

        //Construtor vazio para o EF
        public AlunoLeituraCronograma() {}

        public DateTime AnoReferencia { get; set; }
        public DateTime PeriodoInicio { get; set; }
        public DateTime PeriodoFim { get; set; }
        public int PeriodoReferencia { get; set; }
        public int DiasPeriodo { get; set; }
        public string Nome { get; set; }

        //Tenant
        [ForeignKey("TenantId")]
        public Guid TenantId { get; set; }
        public Tenant Tenant { get; set; }

        public ICollection<AlunoLeitura> AlunoLeituras { get; set; }
    }
}