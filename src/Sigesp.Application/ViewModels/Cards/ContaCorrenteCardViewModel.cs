using System.Collections;
using System;
using System.Collections.Generic;
using Sigesp.Domain.Models;
using Sigesp.Domain.Enums;
using Sigesp.Application.ViewModels.Selects;

namespace Sigesp.Application.ViewModels.Cards
{
    public class ContaCorrenteCardViewModel
    {
        public int Ativas { get; set; }
        public int Encerradas { get; set; }
        public int Bloqueadas { get; set; }
        public decimal Saldos { get; set; }

        public List<string> Colaboradores { get; set; }
        public List<string> Empresas { get; set; }
        public List<string> Status { get; set; }
        public List<string> Tipos { get; set; }
    }
}