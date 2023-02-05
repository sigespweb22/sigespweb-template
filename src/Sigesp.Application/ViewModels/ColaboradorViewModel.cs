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
    public class ColaboradorViewModel
    {
        public Guid? Id { get; set; }

        [DisplayName("Tem conta corrente?")]
        public bool HasContaCorrente { get; set; }

        [DisplayName("Situacao")]
        public string Situacao { get; set; }
        
        [DisplayName("Data última situação")]
        public DateTime DataUltimaSituacao { get; set; }

        [MaxLength(255)]
        [DisplayName("Local trabalho")]
        public string LocalTrabalho { get; set; }

        [DisplayName("Trabalho interno")]
        public bool IsTrabalhoInterno { get; set; }

        [DisplayName("Remunerado")]
        public bool IsRemunerado { get; set; }

        [DisplayName("Remuneração")]
        public decimal? Remuneracao { get; set; }

        [MaxLength(255)]
        [DisplayName("Familiar autorizado retirada")]
        public string FamiliarAutorizadoRetirada { get; set; }

        [DisplayName("Desconto")]
        public decimal? Desconto { get; set; }

        [DisplayName("DescontoOutro")]
        public decimal? DescontoOutro { get; set; }

        [MaxLength(255)]
        [DisplayName("Observação")]
        public string Observacao { get; set; }

        [DisplayName("Dia para pagamento")]
        public int? DiaPagamento { get; set; }

        [DisplayName("Tipo pagamento")]
        public string TipoPagamento { get; set; }

        [MaxLength(5)]
        [DisplayName("Jornada início")]
        public string JornadaInicio { get; set; }

        [MaxLength(5)]
        [DisplayName("Jornada fim")]
        public string JornadaFim { get; set; }
        
        [DisplayName("Banco número")]
        public int? BancoNumero { get; set; }

        [MaxLength(25)]
        [DisplayName("Banco agência")]
        public string BancoAgencia  { get; set; }

        [MaxLength(25)]
        [DisplayName("Banco conta")]
        public string BancoConta   { get; set; }

        [DisplayName("Tipo conta")]
        public string TipoConta   { get; set; }
        
        public bool? IsDeleted { get; set; }

        [DisplayName("Data início")]
        public string DataInicio { get; set; }

        [DisplayName("Folga")]
        public string Folga { get; set; }

        //Campos novos implementandos em 12/01/2022
        [DisplayName("Demissão ocorrência")]
        public string DemissaoOcorrencia { get; set; }

        [DisplayName("Demissão observação")]
        public string DemissaoObservacao { get; set; }

        [DisplayName("Data demissão")]
        public string DemissaoData { get; set; }

        //Campos novos implementandos em 27/01/2022
        [DisplayName("Função")]
        public string Funcao { get; set; }




        //Relacionamentos
        public EmpresaConvenio EmpresaConvenio { get; set; }
        public Guid EmpresaConvenioId { get; set; }

        [Required(ErrorMessage = "Nome convênio requerido")]
        [MinLength(2)]
        [MaxLength(255)]
        [DisplayName("Nome convênio")]
        public string EmpresaConvenioNome { get; set; }

        public Detento Detento { get; set; }
        public Guid DetentoId { get; set; }
        
        [Required(ErrorMessage = "Nome reeducando requerido")]
        [MinLength(2)]
        [MaxLength(255)]
        [DisplayName("Nome reeducando")]
        public string DetentoNome { get; set; }

        [DisplayName("Ipen reeducando")]
        public string DetentoIpen { get; set; }

        [DisplayName("Galeria reeducando")]
        public string DetentoGaleria { get; set; }

        [DisplayName("Cela reeducando")]
        public string DetentoCela { get; set; }

        public ContaCorrente ContaCorrente { get; set; }
    }
}