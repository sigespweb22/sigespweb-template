using System.Collections;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;
using Sigesp.Domain.Enums;

namespace Sigesp.Domain.Models
{
    public class PadDespacho : EntityAudit
    {
        public PadDespacho (DespachoTipoEnum despachoTipo) 
        {
            DespachoTipo = despachoTipo;
        }

        // Constructo empty to EFCore
        public PadDespacho() {}

        public DespachoTipoEnum DespachoTipo { get; set; }
        
        
        // Relationships
        [ForeignKey("PadId")]
        public Guid PadId { get; set; }
        public Pad Pad { get; set; }

        public ICollection<PadDespachoTrocaConselheiro> PadDespachoTrocaConselheiros { get; set; }
        public ICollection<PadConselheiro> PadConselheiros { get; set; }
    } 
}