using System.Collections;
using System;
using System.Collections.Generic;
using Sigesp.Domain.Models;
using Sigesp.Domain.Enums;
using Sigesp.Application.ViewModels.Selects;

namespace Sigesp.Application.ViewModels.Reports
{
    public class ListaAmarelaReportSaidasPrevistasViewModel
    {
        public List<DetentoViewModel> Detentos { get; set; }
        public List<DetentoSaidaTemporariaViewModel> DetentosST { get; set; }
        public int TotalRegistros { get; set; }
        public string SaidaTemporariaDataSaidaPrevista { get; set; }
        public string SaidaTemporariaDataRetornoPrevisto { get; set; }
        public string SaidaTemporariaDataSaidaPeriodo { get; set; }
        public string CategoriaNome1 { get; set; }
        public string CategoriaNome2 { get; set; }
    }
}