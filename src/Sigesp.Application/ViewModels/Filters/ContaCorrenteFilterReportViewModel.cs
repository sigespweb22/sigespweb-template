using System.Collections;
using System;
using System.Collections.Generic;
using Sigesp.Domain.Models;
using Sigesp.Domain.Enums;
using Sigesp.Application.ViewModels.Selects;
using System.ComponentModel.DataAnnotations;

namespace Sigesp.Application.ViewModels.Reports
{
    public class ContaCorrenteFilterReportViewModel
    {
        [Required]
        public string ColaboradorNome { get;set; }

        [Required]
        public DateTime PeriodoInicioRel1 { get;set; }
        public DateTime PeriodoFimRel1 { get;set; }
    }
}