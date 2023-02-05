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
    public class AndamentoPenalCardViewModel
    {
        public Int64 Total { get; set; }
        public Int64 Normal { get; set; }
        public Int64 Provisorios { get; set; }
        
        public Int64 CTCs { get; set; }

        public Int64 PADs { get; set; }       

        public Int64 SaidasTemporarias { get; set; }

        public Int64 EvasoesFugas { get; set; }

        public Int64 PrisaoDomiciliar { get; set; }

        public List<string> Detentos { get; set; }
        public List<string> Regimes { get; set; }
        public List<string> InstrumentosPrisao { get; set; }
        public List<string> CondenacaoTipos { get; set; }
    }
}