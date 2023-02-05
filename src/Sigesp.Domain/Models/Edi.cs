using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Sigesp.Domain.Enums;

namespace Sigesp.Domain.Models
{
    public class Edi : EntityAudit
    {
        public Edi(string arquivoNome, 
                    string arquivoExtensao)
        {
            ArquivoNome = arquivoNome;
            ArquivoExtensao = arquivoExtensao;
        }

        public Edi() {}

        public string ArquivoNome { get; set; }
        public string ArquivoExtensao { get; set; }
        public EdiStatusEnum Status { get; set; }
        public string FullPath { get; set; }

        //Relacionamentos
        
        //Tenant
        [ForeignKey("TenantId")]
        public Guid TenantId { get; set; }
        public Tenant Tenant { get; set; }

        public ICollection<EdiLog> EdiLogs { get; set; }

        public ICollection<ColaboradorPonto> ColaboradoresPonto { get; set; }
    }
}