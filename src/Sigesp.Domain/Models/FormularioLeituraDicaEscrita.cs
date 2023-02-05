using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sigesp.Domain.Models
{
    public class FormularioLeituraDicaEscrita : EntityAudit
    {
        public FormularioLeituraDicaEscrita(string nome)
        {
            Nome = nome;
        }

        public FormularioLeituraDicaEscrita() {}

        public string Nome { get; set; }

        // Relationships
        [ForeignKey("TenantId")]
        public Guid TenantId { get; set; }
        public Tenant Tenant { get; set; }

        public ICollection<FormularioLeituraDicaEscritaDica> FormularioLeituraDicaEscritaDicas { get; set; }
    }
}