using System.Collections;
using System;
using System.Collections.Generic;
using Sigesp.Domain.Models;
using Sigesp.Domain.Enums;

namespace Sigesp.Application.ViewModels.Cards
{
    public class AlunoLeituraCronogramaCardViewModel
    {
        public Int64 Total { get; set; }
        public Int64 Ativos { get; set; }
        public Int64 Inativos { get; set; }
    }
}