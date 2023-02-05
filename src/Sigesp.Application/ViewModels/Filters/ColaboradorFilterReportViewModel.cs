using System.Collections;
using System;
using System.Collections.Generic;
using Sigesp.Domain.Models;
using Sigesp.Domain.Enums;
using Sigesp.Application.ViewModels.Selects;
using System.ComponentModel.DataAnnotations;

namespace Sigesp.Application.ViewModels.Reports
{
    public class ColaboradorFilterReportViewModel
    {
        public string Galeria { get;set; }
        public List<string> Situacoes { get;set; }
        public string EmpresaConvenio { get;set; }
    }
}