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
    public class EmpresaViewModel
    {
        public Guid? Id { get; set; }

        [Required(ErrorMessage = "Razão social requerida")]
        [MinLength(2)]
        [MaxLength(255)]
        [DisplayName("Razão social")]
        public string RazaoSocial { get; set; }

        [MinLength(2)]
        [MaxLength(255)]
        [DisplayName("Nome fantasia")]
        public string NomeFantasia { get; set; }

        [MinLength(14)]
        [MaxLength(14)]
        [DisplayName("CNPJ")]
        public string Cnpj { get; set; }

        [DisplayName("CEP")]
        public int? Cep { get; set; }
        
        // public string CepFormatado { get {
        //     if(CEP != null)
        //         return Convert.ToUInt64(CEP).ToString(@"00000\-000");
        //         return string.Empty;
        //     }
        // }

        [MaxLength(50)]
        [DisplayName("Cidade")]
        public string Cidade { get; set; }

        [MinLength(2)]
        [MaxLength(50)]
        [DisplayName("Estado")]
        public string Estado { get; set; }

        [MaxLength(150)]
        [DisplayName("Logradouro")]
        public string Logradouro { get; set; }

        [DisplayName("Número")]
        public string Numero { get; set; }

        [MaxLength(50)]
        [DisplayName("Bairro")]
        public string Bairro { get; set; }

        [MaxLength(255)]
        [DisplayName("Responsável")]
        public string Responsavel { get; set; }

        [MaxLength(100)]
        [DisplayName("Email")]
        public string Email { get; set; }

        [MaxLength(14)]
        [DisplayName("Telefone fixo")]
        public string TelefoneFixo { get; set; }

        [MaxLength(14)]
        [DisplayName("Telefone celular")]
        public string TelefoneCelular { get; set; }

        [MaxLength(14)]
        [DisplayName("WhatsApp")]
        public string WhatsApp { get; set; }

        public bool? IsDeleted { get; set; }

        public ICollection<string> EmpresaConvenios { get; set; }
    }
}