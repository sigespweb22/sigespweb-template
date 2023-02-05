using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Sigesp.Application.ViewModels
{
    public class FormularioLeituraDicaEscritaViewModel
    {
        public Guid? Id { get; set; }

        [Required(ErrorMessage = "Nome requerido.")]
        [DisplayName("Nome")]
        public string Nome { get; set; }

        public bool IsDeleted { get; set; }
        
        public List<FormularioLeituraDicaEscritaDicaViewModel> FormularioLeituraDicaEscritaDicas { get; set; }
    }
}