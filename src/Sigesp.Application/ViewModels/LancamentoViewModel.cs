using System.Runtime.Serialization;
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
    public class LancamentoViewModel
    {
        public Guid? Id { get; set; }

        [DisplayName("Descrição")]
        public string Descricao { get; set; }
        
        [DisplayName("Data liquidacao")]
        public DateTime DataLiquidacao { get; set; }

        [Required(ErrorMessage = "Valor líquido requerido")]
        [DisplayName("Valor líquido")]
        public decimal ValorLiquido { get; set; }

        [DisplayName("Período data início")]
        public int? PeriodoDataInicio { get; set; }

        [DisplayName("Período data fim")]
        public int? PeriodoDataFim { get; set; }

        [DisplayName("Data último status")]
        public DateTime DataUltimoStatus { get; set; }

        [MaxLength(255)]
        [DisplayName("Observação")]
        public string Observacao { get; set; }

        [DisplayName("Status")]
        public string Status { get; set; }

        [DisplayName("Período referência")]
        public string PeriodoReferencia { get; set; }

        [DisplayName("Tipo lançamento")]
        public string Tipo { get; set; }

        [DisplayName("Saldo")]
        public decimal? Saldo { get; set; }

        [DisplayName("Evento especificação")]
        public string ContabilEventoEspecificacao { get; set; }
        
        [DisplayName("Data lançamento")]
        public string CreatedAt { get; set; }

        [DisplayName("Razão social")]
        public string EmpresaRazaoSocial { get; set; }
        
        //Relacionamentos
        public Guid ContaCorrenteId { get; set; }

        public string ContaCorrenteDescricao { get; set; }
        public bool ContaCorrenteIsTipoCofre { get; set; }
        public ContaCorrenteViewModel ContaCorrenteViewModel { get; set; }

        public ContabilEventoViewModel ContabilEventoViewModel { get; set; }


        public string ColaboradorNome { get; set; }
        public string DetentoIpen { get; set; }
        public string DetentoRegime { get; set; }

        public EmpresaViewModel EmpresaViewModel { get; set; }
        
    }
}