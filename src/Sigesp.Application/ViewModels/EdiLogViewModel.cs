using System.Dynamic;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Sigesp.Domain.Enums;
using Sigesp.Domain.Models;
using Sigesp.Application.ViewModels;
using System.Collections.Generic;

namespace Sigesp.Application.ViewModels
{
    public class EdiLogViewModel
    {
        public Guid? Id { get; set; }

        [DisplayName("Nome entidade")]
        public string EntityName { get; set; }
        
        [DisplayName("Propriedade entidade")]
        public string EntityProperty { get; set; }
        
        [DisplayName("Valor antigo propriedade entidade")]
        public string EntityPropertyOldValue { get; set; }
        
        [DisplayName("Valor novo propriedade entidade")]
        public string EntityPropertyNewValue { get; set; }
        
        [DisplayName("Tipo")]
        public string Tipo { get; set; }

        [DisplayName("Id edi")]
        public string EdiId { get; set; }

        [DisplayName("Tenant")]
        public Guid TenantId { get; set; }
    }
}