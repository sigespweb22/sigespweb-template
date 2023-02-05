using System.ComponentModel.DataAnnotations.Schema;
using System;
using Sigesp.Domain.Enums;

namespace Sigesp.Domain.Models
{
    public class PadConselheiro : EntityAudit
    {
        public PadConselheiro (ConselhoDisciplinarFuncaoEnum funcao)
        {
            Funcao = funcao;
        }

        // Constructo empty to EFCore
        public PadConselheiro() {}


        public ConselhoDisciplinarFuncaoEnum Funcao { get; set; }


        [ForeignKey("PadDespachoId")]
        public Guid PadDespachoId { get; set; }
        public PadDespacho PadDespacho { get; set; }

        [ForeignKey("PadId")]
        public Guid PadId { get; set; }
        public Pad Pad { get; set; }

        [ForeignKey("UserId")]
        public string UserId { get; set; } 
        public ApplicationUser ApplicationUser { get; set; }
    } 
}