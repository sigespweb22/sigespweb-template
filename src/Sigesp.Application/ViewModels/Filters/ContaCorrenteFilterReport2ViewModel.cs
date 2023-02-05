using System.Collections;
using System;
using System.Collections.Generic;
using Sigesp.Domain.Models;
using Sigesp.Domain.Enums;
using Sigesp.Application.ViewModels.Selects;
using System.ComponentModel.DataAnnotations;

namespace Sigesp.Application.ViewModels.Reports
{
    public class ContaCorrenteFilterReport2ViewModel
    {
        public List<string> ColaboradoresNomes { get;set; }

        [Required]
        public DateTime PeriodoInicioRel2 { get;set; }
        public DateTime PeriodoFimRel2 { get;set; }

        [Required]
        public bool Ativa { get;set; }
    }
}