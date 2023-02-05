using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Sigesp.Domain.Enums;

namespace Sigesp.Domain.Models
{
    public class SequenciaOficio : EntityAudit
    {
        public SequenciaOficio(int sequencia, string usuarioNomeUltimaSequencia,
                               SetorEnum setor)
        {
            Sequencia = sequencia;
            UsuarioNomeUltimaSequencia = usuarioNomeUltimaSequencia;
            Setor = setor;
        }

        // Construtor vazio para o EF
        public SequenciaOficio() {}

        public int Sequencia { get; set; }
        public string UsuarioNomeUltimaSequencia { get; set; }
        public SetorEnum Setor { get; set; }
        

        // Relacionamentos
        [ForeignKey("TenantId")]
        public Guid TenantId { get; set; }
        public Tenant Tenant { get; set; }

        
    }
}