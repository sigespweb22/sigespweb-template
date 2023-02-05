using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Sigesp.Domain.Models;

namespace Sigesp.Application.ViewModels
{
    public class FormularioLeituraDicaEscritaDicaViewModel
    {
        public Guid? Id { get; set; }

        [Required(ErrorMessage = "Dica requerida.")]
        [DisplayName("Dica")]
        public string Dica { get; set; }

        [Required(ErrorMessage = "Ordem requerida.")]
        [DisplayName("Ordem")]
        public int Ordem { get; set; }

        public string FormularioLeituraDicaEscritaId { get; set; }
        public FormularioLeituraDicaEscritaViewModel FormularioLeituraDicaEscritaViewModel { get; set; }
    }
}