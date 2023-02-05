using System.Collections;
using System;
using System.Collections.Generic;
using Sigesp.Domain.Models;
using Sigesp.Domain.Enums;
using Sigesp.Application.ViewModels.Selects;
using System.ComponentModel.DataAnnotations;

namespace Sigesp.Application.ViewModels.Reports
{
    public class ListaAmarelaFilterReportTransferidosViewModel
    {
        public string TransferenciaTipo { get;set; }

        public string DataSaidaPeriodoInicioReportTransferidos { get;set; }
        public string DataSaidaPeriodoFimReportTransferidos { get;set; }
        public string DataRetornoPrevistoPeriodoInicioReportTransferidos { get;set; }
        public string DataRetornoPrevistoPeriodoFimReportTransferidos { get;set; }
    }
}