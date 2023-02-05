using System.Collections;
using System;
using System.Collections.Generic;
using Sigesp.Domain.Models;
using Sigesp.Domain.Enums;
using Sigesp.Application.ViewModels.Selects;

namespace Sigesp.Application.ViewModels.Reports
{
    public class ListaAmarelaReportDataIngressoViewModel
    {
        public List<ListaAmarelaViewModel> ListasAmarela { get; set; }
        public int TotalRegistros { get; set; }
        public string DataIngressoPeriodo { get; set; }
        public string CategoriaNome1 { get; set; }
        public string CategoriaNome2 { get; set; }
    }
}