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
    public class AlunoEjaDisciplinaViewModel
    {
        [DisplayName("Nome")]
        public string Nome { get; set; }

        [DisplayName("Conceito")]
        public string Conceito { get; set; }
    }
}