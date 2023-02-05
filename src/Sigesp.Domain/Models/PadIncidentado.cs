using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace Sigesp.Domain.Models
{
    public class PadIncidentado
    {
        [ForeignKey("PadId")]
        public Guid PadId { get; set; }
        public Pad Pad { get; set; }

        [ForeignKey("DetentoId")]
        public Guid DetentoId { get; set; }
        public Detento Detento { get; set; }
    } 
}