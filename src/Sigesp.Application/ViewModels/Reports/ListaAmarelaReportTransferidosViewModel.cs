using System.Collections;
using System;
using System.Collections.Generic;
using Sigesp.Domain.Models;
using Sigesp.Domain.Enums;
using Sigesp.Application.ViewModels.Selects;

namespace Sigesp.Application.ViewModels.Reports
{
    public class ListaAmarelaReportTransferidosViewModel
    {
        public List<DetentoViewModel> DetentosTransferidos { get; set; }
        public int TotalRegistros { get; set; }
        public string DataSaidaInicio { get; set; }
        public string DataSaidaFim { get; set; }
        public string DataSaidaPeriodo { get; set; }
        public string DataRetornoPrevistoPeriodo { get; set; }
        public string DataRetornoPrevistoInicio { get; set; }
        public string DataRetornoPrevistoFim { get; set; }
        public string CategoriaNome1 { get; set; }
        public string CategoriaNome2 { get; set; }
    }
}