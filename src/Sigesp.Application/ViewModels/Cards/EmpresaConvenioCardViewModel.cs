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
    public class EmpresaConvenioCardViewModel
    {
        public int Ativos { get; set; }
        
        public int EmAnalise { get; set; }

        public int RenovacaoAutomatica { get; set; }

        public int Encerrados { get; set; }

        public List<string> Empresas { get; set; }
        public List<string> Situacoes { get; set; }
    }
}