using System.Dynamic;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Sigesp.Domain.Enums;
using Sigesp.Domain.Models;
using Sigesp.Application.ViewModels;
using System.Collections.Generic;
using Sigesp.Application.ViewModels.Selects;

namespace Sigesp.Application.ViewModels.Cards
{
    public class LancamentoCardViewModel
    {
        public int Pendentes { get; set; }
        
        public int Liquidados { get; set; }

        public int Creditos { get; set; }

        public int Debitos { get; set; }

        public List<string> Empresas { get; set; }
        public List<string> Colaboradores { get; set; }
        public List<string> ContasCorrentes { get; set; }
        public List<string> PeriodosReferencia { get; set; }
        public List<string> Status { get; set; }
        public List<string> TiposLancamento { get; set; }
        public List<string> ContabilEventos { get; set; }
    }
}