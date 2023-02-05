using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sigesp.Domain.Models
{
    public class PadDespachoTrocaConselheiro : EntityAudit
    {
        public PadDespachoTrocaConselheiro(DateTime dataTroca)
        {
            DataTroca = dataTroca;
        }

        // Constructor empty to EFCore
        public PadDespachoTrocaConselheiro() {}

        public DateTime DataTroca { get; set; }

        // Relationships
        [ForeignKey("PadDespachoId")]
        public Guid PadDespachoId { get; set; }
        public PadDespacho PadDespacho { get; set; }

        [ForeignKey("PadConselheiroId")]
        public Guid ConselheiroImpedidoId { get; set; }
        public PadConselheiro ConselheiroImpedido { get; set; }

        [ForeignKey("PadConselheiroId")]
        public Guid ConselheiroSubstitutoId { get; set; }
        public PadConselheiro ConselheiroSubstituto { get; set; }
    }
}