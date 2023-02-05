using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Sigesp.Domain.Enums;

namespace Sigesp.Domain.Models
{
    public class ServidorEstado : EntityAudit
    {
        public ServidorEstado(string nome,
                              string matricula,
                              PlantaoNomeEnum plantaoNome,
                              bool hasPrioridadeMarcacaoReforco,                     
                              bool isExpediente)
        {
            Nome = nome;
            Matricula = matricula;
            PlantaoNome = plantaoNome;
            HasPrioridadeMarcacaoReforco = hasPrioridadeMarcacaoReforco;
            IsExpediente = isExpediente;
        }

        //Construtor vazio para o EF
        public ServidorEstado() { }

        public string Nome { get; set; }
        public string Matricula { get; set; }
        public PlantaoNomeEnum PlantaoNome { get; set; }
        public GaleriaEnum Galeria { get; set; }
        /// Diretoria, Chefe de Segurança, Supervisão e Coordenação Expediente
        public bool HasPrioridadeMarcacaoReforco { get; set; }
        public bool IsExpediente { get; set; }

        public bool HasFeriasAgendadas { get; set; }
        public bool HasLicencaPremioAgendada { get; set; }

        public DateTime DataInicioGozo { get; set; }
        public DateTime DataFimGozo { get; set; }


        //Relacionamentos
        [ForeignKey("UserId")]
        public string UserId { get; set; }
        public ApplicationUser ApplicationUser { get;  set; }

        [ForeignKey("TenantId")]
        public Guid TenantId { get; set; }
        public Tenant Tenant { get;  set; }

        public ICollection<ServidorEstadoReforco> ServidoresEstadoReforcos { get; set; }
    }
}