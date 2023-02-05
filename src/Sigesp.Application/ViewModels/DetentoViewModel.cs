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
    public class DetentoViewModel
    {
        public Guid? Id { get; set; }

        [Required(ErrorMessage = "Ipen requerido")]
        [MinLength(6, ErrorMessage="Ipen deve conter no mínimo 6 caracteres")]
        [MaxLength(6, ErrorMessage="Ipen deve conter no mínimo 6 caracteres")]
        [DisplayName("Ipen")]
        public string Ipen { get; set; }

        [Required(ErrorMessage = "Nome requerido")]
        [MinLength(1, ErrorMessage="Nome deve conter no mínimo 2 caracteres")]
        [MaxLength(100, ErrorMessage="Nome deve conter no máximo 100 caracteres")]
        [DisplayName("Nome")]
        public string Nome { get; set; }

        [MinLength(1)]
        [MaxLength(2)]
        [DisplayName("Galeria")]
        public string Galeria { get; set; }

        [MinLength(1, ErrorMessage="Cela deve conter no mínimo 1 caracter numérico")]
        [MaxLength(2, ErrorMessage="Cela deve conter no máximo 2 caracteres numéricos")]
        [DisplayName("Cela")]
        public string Cela { get; set; }

        [DisplayName("Provisório")]
        public bool IsProvisorio { get; set; }

        [DisplayName("Saída temporária")]
        public bool IsSaidaTemporaria { get; set; }

        public string Regime { get; set; }
        
        //Dados familiar
        [DisplayName("Matrícula familiar")]
        public string MatriculaFamiliar { get; set; }

        [MaxLength(100)]
        [DisplayName("Nome familiar")]
        public string NomeFamiliar { get; set; }

        [DisplayName("Banco número familiar")]
        public int BancoNumeroFamiliar { get; set; }

        [MaxLength(25)]
        [DisplayName("Banco agência familiar")]
        public string BancoAgenciaFamiliar  { get; set; }

        [MaxLength(25)]
        [DisplayName("Banco conta familiar")]
        public string BancoContaFamiliar   { get; set; }

        [DisplayName("Tipo conta familiar")]
        public string TipoContaFamiliar   { get; set; }

        [DisplayName("Local transferência")]
        public string TransferenciaLocal { get; set; }

        [DisplayName("Tipo transferência")]
        public string TransferenciaTipo { get; set; }

        [DisplayName("Data saída transferência")]
        public string TransferenciaDataSaida { get; set; }

        [DisplayName("Data retorno previsto transferência")]
        public string TransferenciaDataRetornoPrevisto { get; set; }
        
        [DisplayName("Data retorno realizado transferencia")]
        public string TransferenciaDataRetornoRealizado { get; set; }

        [DisplayName("Tenant")]
        public Guid? TenantId { get; set; }

        [DisplayName("É ativo?")]
        public bool IsDeleted { get; set; }

        //Campos novos criados em 31/01/2022
        public ICollection<DetentoSaidaTemporaria> SaidasTemporaria { get; set; }
        public List<string> SaidaTemporariaSaidaPrevista { get; set; }        
        public List<string> SaidaTemporariaRetornoPrevisto { get; set; }

        public ColaboradorViewModel ColaboradorViewModel { get; set; }
    }
}