using System.Xml;
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
    public class LivroViewModel
    {
        public Guid? Id { get; set; }

        [Required(ErrorMessage = "Título requerido.")]
        [DisplayName("Título")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "Localização requerida.")]
        [DisplayName("Localização")]
        public string Localizacao { get; set; }

        [DisplayName("Última localização")]
        public string UltimaLocalizacao { get; set; }

        [Required(ErrorMessage = "Propriedade requerida.")]
        [DisplayName("Propriedade")]
        public string Propriedade { get; set; }

        [DisplayName("Disponível?")]
        public bool IsDisponivel { get; set; }

        [DisplayName("Ativo?")]
        public bool IsDeleted { get; set; }

    

        //Relacionamentos

        [Required(ErrorMessage = "Autor requerido.")]
        public string LivroAutorNome { get; set; }

        [Required(ErrorMessage = "Gênero requerido.")]
        public string LivroGeneroNome { get; set; }

        public LivroAutor LivroAutor { get; set; }
        public LivroGenero LivroGenero { get; set; }
    }
}