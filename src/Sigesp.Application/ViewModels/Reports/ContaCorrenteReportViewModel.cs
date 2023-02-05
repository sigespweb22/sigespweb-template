using System.Collections;
using System;
using System.Collections.Generic;
using Sigesp.Domain.Models;
using Sigesp.Domain.Enums;
using Sigesp.Application.ViewModels.Selects;

namespace Sigesp.Application.ViewModels.Reports
{
    public class ContaCorrenteReportViewModel
    {
        public List<LancamentoReportViewModel> LancamentosReportViewModel { get; set; }

        public DateTime LancamentoDataInicio { get; set; }
        public DateTime LancamentoDataFim { get; set; }

        public string Numero { get; set; }
        public string Nome { get; set; }
        public string Ipen { get; set; }
        public string Galeria { get; set; }
        public string LocalTrabalho { get; set; }
        public string Status { get; set; }
        public string PeriodoInicio { get; set; }
        public string PeriodoFim { get; set; }

        //Dados 
        public string CategoriaNome1 { get; set; }
        public string CategoriaNome2 { get; set; }
        public decimal TotalLancamentos { get; set; }
        public decimal TotalCreditos { get; set; }
        public decimal TotalDebitos { get; set; }
        
        public class LancamentoReportViewModel
        {
            public Int64 Id { get; set; }
            public string DataLiquidacao { get; set; }
            public string Descricao { get; set; }
            public string LancamentoTipo { get; set; }
            public decimal ValorLiquido { get; set; }
            public string Saldo { get; set; }
        }
    }
}