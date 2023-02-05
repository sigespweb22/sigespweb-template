using System.Collections;
using System;
using System.Collections.Generic;
using Sigesp.Domain.Models;
using Sigesp.Domain.Enums;
using Sigesp.Application.ViewModels.Selects;

namespace Sigesp.Application.ViewModels.Reports
{
    public class TotalizadorCondenacaoTipoViewModel
    {
        public List<Condenacao> CondenacoesTipo {get; set; }
        public int TotalRegistros { get; set; }
    }

    public class Condenacao
    {
        public string Tipo { get; set; }
        public int Total { get; set; }
    }
}