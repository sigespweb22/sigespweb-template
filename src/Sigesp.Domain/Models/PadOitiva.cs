using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;

namespace Sigesp.Domain.Models
{
    public class PadOitiva : EntityAudit
    {
        public PadOitiva (DateTime dataRealizacao,
                          string local, DateTime dataIntimacaoDefesa,
                          bool isDefesaIntimada) 
        {
            DataRealizacao = dataRealizacao;
            Local = local;
            DataIntimacaoDefesa = dataIntimacaoDefesa;
            IsDefesaIntimada = isDefesaIntimada;
        }

        // Constructo empty to EFCore
        public PadOitiva() {}

        public DateTime DataRealizacao { get; set; }
        public string Local { get; set; }
        public DateTime DataIntimacaoDefesa { get; set; }
        public bool IsDefesaIntimada { get; set; }
        
        // Relationships
        [ForeignKey("PadId")]
        public Guid PadId { get; set; }
        public Pad Pad { get; set; }

        public ICollection<PadOitivaDeclarante> PadOitivaDeclarantes { get; set; }
    } 
}