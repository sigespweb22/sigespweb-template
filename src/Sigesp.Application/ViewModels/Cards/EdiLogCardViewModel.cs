using System.Collections;
using System;
using System.Collections.Generic;
using Sigesp.Domain.Models;
using Sigesp.Domain.Enums;
using Sigesp.Application.ViewModels.Selects;

namespace Sigesp.Application.ViewModels.Cards
{
    public class EdiLogCardViewModel
    {
        public int Intervencoes { get; set; }
        public int Mudancas { get; set; }
        public int Ativacoes { get; set; }
        public int Desativacoes { get; set; }
        public int Exclusoes { get; set; }
        public int Inclusoes { get; set; }
    }
}
