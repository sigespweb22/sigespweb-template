using System.Dynamic;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Sigesp.Domain.Enums;
using Sigesp.Domain.Models;
using Sigesp.Application.ViewModels;
using System.Collections.Generic;

namespace Sigesp.Application.ViewModels.Selects
{
    public class AlunoEjaDisciplinaAndConceitoSelect2ViewModel
    {
        public List<string> Disciplinas { get; set;}
        public List<string> Conceitos { get; set;}
    }
}