using System.Collections;
using System;
using System.Collections.Generic;
using Sigesp.Domain.Models;
using Sigesp.Domain.Enums;
using Sigesp.Application.ViewModels.Selects;

namespace Sigesp.Application.ViewModels.Cards
{
    public class LeitorCardViewModel
    {
        public Int64 Ativos { get; set; }
        public Int64 Inativos { get; set; }
        public Int64 Total { get; set; }

        public List<string> Professores { get; set; }
        public List<string> Generos { get; set; }
        public List<string> Detentos { get; set; }
        public List<string> Escolaridades { get; set; }
        public List<string> OcorrenciasDesistencia { get; set; }
    }
}