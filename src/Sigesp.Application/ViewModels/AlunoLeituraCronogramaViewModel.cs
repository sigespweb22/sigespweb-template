using System.Dynamic;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Sigesp.Domain.Enums;
using Sigesp.Domain.Models;
using Sigesp.Application.ViewModels;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sigesp.Application.ViewModels
{
    public class AlunoLeituraCronogramaViewModel
    {
        public AlunoLeituraCronogramaViewModel(string anoReferencia)
        {
            AnoReferencia = anoReferencia.Length == 4 ? anoReferencia + "-01-01" : 
                                anoReferencia.Length < 4 ? anoReferencia : anoReferencia.Substring(6, 4);
        }

        public Guid? Id { get; set; }

        // [Range(minimum: 4, maximum: 4, ErrorMessage = "Permitido máximo de 4 números para o ano referência.")]
        [Required(ErrorMessage = "Ano referência requerido.")]
        [StringLength(10, MinimumLength = 4, ErrorMessage = "Requerido 4 números para o ano referência.")]
        [DisplayName("Ano referência")]
        [NotMapped]
        public string AnoReferencia { get; set; }

        [Required(ErrorMessage = "Período início requerido.")]
        [DisplayName("Período início")]
        public string PeriodoInicio { get; set; }

        [Required(ErrorMessage = "Período fim requerido.")]
        [DisplayName("Período fim")]
        public string PeriodoFim { get; set; }

        [Required(ErrorMessage = "Período referência requerido.")]
        [DisplayName("Período referência")]
        public string PeriodoReferencia { get; set; }

        [Required(ErrorMessage = "Dias período requerido.")]
        [DisplayName("Dias período")]
        public string DiasPeriodo { get; set; }

        [Required(ErrorMessage = "Nome requerido.")]
        [DisplayName("Nome")]
        public string Nome { get; set; }

        [DisplayName("Cronograma nome")]
        public string AlunoLeituraCronogramaNome { get; set; }
    }
}