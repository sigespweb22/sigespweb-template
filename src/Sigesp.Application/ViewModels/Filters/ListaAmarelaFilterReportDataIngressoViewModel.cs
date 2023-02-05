using System.Collections;
using System;
using System.Collections.Generic;
using Sigesp.Domain.Models;
using Sigesp.Domain.Enums;
using Sigesp.Application.ViewModels.Selects;
using System.ComponentModel.DataAnnotations;

namespace Sigesp.Application.ViewModels.Reports
{
    public class ListaAmarelaFilterReportDataIngressoViewModel
    {
        public string Regime { get;set; }

        public string DataIngressoInicio { get;set; }
        public string DataIngressoFim { get;set; }
        public string DataIngressoPeriodo { get; set; }
    }
}