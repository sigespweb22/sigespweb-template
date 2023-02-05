using System.Collections;
using System;
using System.Collections.Generic;
using Sigesp.Domain.Models;
using Sigesp.Domain.Enums;
using Sigesp.Application.ViewModels.Selects;
using System.ComponentModel.DataAnnotations;

namespace Sigesp.Application.ViewModels.Reports
{
    public class ListaAmarelaFilterReportPrevisaoBeneficioViewModel
    {
        public string Regime { get;set; }

        public string DataPrevisaoBeneficioInicio { get;set; }
        public string DataPrevisaoBeneficioFim { get;set; }
        public string DataPrevisaoBeneficioPeriodo { get; set; }
        public string DataSaidaPrevistaInicio { get; set; }
        public string DataSaidaPrevistaFim { get; set; }
    }
}