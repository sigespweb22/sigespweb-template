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
    public class LivroGeneroViewModel
    {
        public Guid? Id { get; set; }

        [Required(ErrorMessage = "Nome requerido.")]
        [DisplayName("Nome")]
        public string Nome { get; set; }

        public ICollection<LivroViewModel> Livros { get; set; }
    }
}