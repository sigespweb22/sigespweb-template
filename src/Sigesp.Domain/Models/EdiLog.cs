using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Sigesp.Domain.Enums;

namespace Sigesp.Domain.Models
{
    public class EdiLog : EntityAudit
    {
        public EdiLog (string entityName, string entityProperty, 
                        string entityPropertyOldValue, string entityPropertyNewValue,
                        EdiLogTipoEnum tipo)
        {
            EntityName = entityName;
            EntityProperty = entityProperty;
            EntityPropertyOldValue = entityPropertyOldValue;
            EntityPropertyNewValue = entityPropertyNewValue;
            Tipo = tipo;
        }

        public EdiLog() {}

        public string EntityName { get; set; }
        public string EntityProperty { get; set; }
        public string EntityPropertyOldValue { get; set; }
        public string EntityPropertyNewValue { get; set; }
        public EdiLogTipoEnum Tipo { get; set; }


        //Relacionamentos
        [ForeignKey("EdiId")]
        public Guid EdiId { get; set; }
        public virtual Edi Edi { get; set; } 

        //Tenant
        [ForeignKey("TenantId")]
        public Guid TenantId { get; set; }
        public Tenant Tenant { get; set; }
    }
}