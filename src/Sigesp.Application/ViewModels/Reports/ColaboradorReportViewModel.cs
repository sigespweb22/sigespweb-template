using System.Collections;
using System;
using System.Collections.Generic;
using Sigesp.Domain.Models;
using Sigesp.Domain.Enums;
using Sigesp.Application.ViewModels.Selects;

namespace Sigesp.Application.ViewModels.Reports
{
    public class ColaboradorReportViewModel
    {
        public List<ColaboradorReportViewModelBase> ColaboradoresReportViewModel { get; set; }

        public string CategoriaNome1 { get; set; }
        public string CategoriaNome2 { get; set; }
        public decimal Total { get; set; }
        public class ColaboradorReportViewModelBase
        {
            public Int64 Id { get; set; }
            public string EmpresaConvenioNome { get; set; }
            public string Ipen { get; set; }
            public string Nome { get; set; }
            public string Galeria { get; set; }
            public string Cela { get; set; }
            public string LocalTrabalho { get; set; }
            public string JornadaInicio { get; set; }
            public string JornadaFim { get; set; }
            public decimal Saldo { get; set; }
            public string Ativo { get; set; }
        }
    }
}