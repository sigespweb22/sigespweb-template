using System.Collections;
using System;
using System.Collections.Generic;
using Sigesp.Domain.Models;
using Sigesp.Domain.Enums;
using Sigesp.Application.ViewModels.Selects;

namespace Sigesp.Application.ViewModels.Cards
{
    public class LivroCardViewModel
    {
        public Int64 Ativos { get; set; }
        public Int64 Inativos { get; set; }
        public Int64 Disponiveis { get; set; }
        public Int64 Indisponiveis { get; set; }

        public List<string> Autores { get; set; }
        public List<string> Generos { get; set; }
    }
}