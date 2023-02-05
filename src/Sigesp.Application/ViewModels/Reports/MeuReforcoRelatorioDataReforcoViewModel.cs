using System.Collections.Generic;
using Sigesp.Domain.Models;

namespace Sigesp.Application.ViewModels.Reports
{
    public class MeuReforcoRelatorioDataReforcoViewModel
    {
        public List<ServidorEstadoReforco> Reforcos { get; set; }
        public int TotalRegistros { get; set; }
        public string DataReforcoPeriodo { get; set; }
    }
}