using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Sigesp.Domain.Enums;

namespace Sigesp.Domain.Models
{
    public class DetentoSaidaTemporaria : EntityAudit
    {
        public DetentoSaidaTemporaria(DateTime saidaPrevista,
                                      DateTime retornoPrevisto)
        {
            SaidaPrevista = saidaPrevista;
            RetornoPrevisto = retornoPrevisto;
        }

        // Construtor vazio para o EF
        public DetentoSaidaTemporaria() { }

        public DateTime SaidaPrevista { get; set; }
        public DateTime RetornoPrevisto { get; set; }


        //Relacionamentos
        [ForeignKey("DetentoId")]
        public Guid DetentoId { get; set; }
        public Detento Detento { get; set; }
    }
}