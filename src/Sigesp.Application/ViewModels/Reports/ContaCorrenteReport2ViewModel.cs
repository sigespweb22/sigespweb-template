using System.Collections;
using System;
using System.Collections.Generic;
using Sigesp.Domain.Models;
using Sigesp.Domain.Enums;
using Sigesp.Application.ViewModels.Selects;

namespace Sigesp.Application.ViewModels.Reports
{
    public class ContaCorrenteReport2ViewModel
    {
        public List<RegistroReport2ViewModel> RegistrosReport2ViewModel { get; set; }
        public string PeriodoInicio { get; set; }
        public string PeriodoFim { get; set; }
        public string Status { get; set; }
        public string Colaboradores { get; set; }

        //Dados 
        public string CategoriaNome1 { get; set; }
        public string CategoriaNome2 { get; set; }
        public decimal TotalDeposito { get; set; }
        
        public class RegistroReport2ViewModel
        {
            public Int64 Id { get; set; }
            public string Ipen { get; set; }
            public string ColaboradorNome { get; set; }
            public string VisitanteMatricula { get; set; }
            public string VisitanteNome { get; set; }
            public string Agencia { get; set; }
            public string ContaCorrenteNumero { get; set; }
            public string ContaCorrenteTipo { get; set; }
            public string Status { get; set; }
            public decimal ValorDeposito { get; set; }
        }
    }
}