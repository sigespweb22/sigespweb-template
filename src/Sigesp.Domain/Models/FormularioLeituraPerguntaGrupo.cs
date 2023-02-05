using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sigesp.Domain.Models
{
    public class FormularioLeituraPerguntaGrupo : EntityAudit
    {
        public FormularioLeituraPerguntaGrupo(string nome)
        {
            Nome = nome;
        }

        public FormularioLeituraPerguntaGrupo() {}

        public string Nome { get; set; }

        // Relationships
        [ForeignKey("TenantId")]
        public Guid TenantId { get; set; }
        public Tenant Tenant { get; set; }

        public ICollection<FormularioLeituraPergunta> FormularioLeituraPerguntas { get; set; }
    }
}