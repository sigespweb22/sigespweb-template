using System.Dynamic;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Sigesp.Domain.Enums;
using Sigesp.Domain.Models;
using Sigesp.Application.ViewModels;
using System.Collections.Generic;

namespace Sigesp.Application.ViewModels.Requests
{
    public class AlunoLeituraNovosRequestViewModel
    {
        public string LeituraTipo { get; set; }
        public string Galeria { get; set; }
        public List<string> Celas { get; set; }
        public string Cronograma { get; set;}
    }
}