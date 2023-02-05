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
    public class ServidorEstadoViewModel
    {
        public Guid? Id { get; set; }

        [DisplayName("Nome")]
        public string ServidorEstadoNome { get; set; }
        
        [Required(ErrorMessage = "Matrícula requerida.")]
        [DisplayName("Matrícula")]
        public string Matricula { get; set; }

        [DisplayName("Plantão nome")]
        public string PlantaoNome { get; set; }

        [DisplayName("Galeria")]
        public string Galeria { get; set; }

        [DisplayName("Tem prioridade na marcação de reforço?")]
        public bool HasPrioridadeMarcacaoReforco { get; set; }

        [DisplayName("Entrará em licença prêmio este ano?")]
        public bool HasFeriasAgendadas { get; set; }

        [DisplayName("Entrará em férias este ano?")]
        public bool HasLicencaPremioAgendada { get; set; }

        [DisplayName("Data início gozo")]
        public string DataInicioGozo { get; set; }

        [DisplayName("Data fim gozo")]
        public string DataFimGozo { get; set; }


        [DisplayName("É expediente?")]
        public bool IsExpediente { get; set; }

        [DisplayName("É ativo?")]
        public bool IsDeleted { get; set; }


        [DisplayName("Usuário Id")]
        public string UserId { get; set; }

        [DisplayName("Usuário nome")]
        public string UserNome { get; set; }

        public ApplicationUser ApplicationUser { get; set; }
    }
}