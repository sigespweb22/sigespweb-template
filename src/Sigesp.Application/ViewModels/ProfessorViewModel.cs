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
    public class ProfessorViewModel
    {
        public Guid? Id { get; set; }

        [Required(ErrorMessage = "Nome requerido.")]
        [DisplayName("Nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Galeria requerido.")]
        [DisplayName("Galeria")]
        public string Galeria { get; set; }


        [DisplayName("Cpf")]
        public string Cpf { get; set; }

        [DisplayName("Inativo?")]
        public bool IsDeleted { get; set; }

        //Relacionamentos
        [DisplayName("Tenancy")]
        public Guid? TenantId { get; set; }
        public Tenant Tenant { get; set; }


        [Required(ErrorMessage = "Usuário requerido.")]
        [DisplayName("Usuário")]
        public string ApplicationUserId {get; set; }
        public string ApplicationUserNome {get; set; }
        public ApplicationUser ApplicationUser {get; set; }


        public ICollection<AlunoLeitor> AlunosLeitores { get; set; }
    }
}