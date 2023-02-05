using System.Collections;
using System;
using System.Collections.Generic;
using Sigesp.Domain.Models;
using Sigesp.Domain.Enums;
using Sigesp.Application.ViewModels.Selects;

namespace Sigesp.Application.ViewModels.Cards
{
    public class EdiCardViewModel
    {
        public int TotalImportacoes { get; set; }
        public int EmProcessamento { get; set; }
        public int Processados { get; set; }
    }
}
