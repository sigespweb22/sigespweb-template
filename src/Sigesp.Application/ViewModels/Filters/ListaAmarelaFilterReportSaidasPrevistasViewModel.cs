using System.Collections;
using System;
using System.Collections.Generic;
using Sigesp.Domain.Models;
using Sigesp.Domain.Enums;
using Sigesp.Application.ViewModels.Selects;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Sigesp.Application.ViewModels.Reports
{
    public class ListaAmarelaFilterReportSaidasPrevistasViewModel
    {
        public string DataSaidaPrevistaSTInicio { get; set; }
        public string DataSaidaPrevistaSTFim { get; set; }
        public string OpcaoOrdenacaoSelect2 { get; set; }
    }
}