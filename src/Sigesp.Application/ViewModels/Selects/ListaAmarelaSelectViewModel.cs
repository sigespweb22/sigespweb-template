using System.Collections;
using System;
using System.Collections.Generic;
using Sigesp.Domain.Models;
using Sigesp.Domain.Enums;
using Sigesp.Application.ViewModels.Selects;

namespace Sigesp.Application.ViewModels.Selects
{
    public class ListaAmarelaSelectViewModel
    {
        public List<string> TransferenciaTipos { get; set; }
        public List<string> Regimes { get; set; }
        public List<string> SaidaTemporariaOpcoesOrdenacaoRelatorio { get; set; }
    }
}
