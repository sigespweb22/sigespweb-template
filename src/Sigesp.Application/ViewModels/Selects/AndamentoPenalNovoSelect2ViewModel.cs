using System.Collections;
using System;
using System.Collections.Generic;
using Sigesp.Domain.Models;
using Sigesp.Domain.Enums;
using Sigesp.Application.ViewModels.Selects;

namespace Sigesp.Application.ViewModels.Selects
{
    public class AndamentoPenalNovoSelect2ViewModel
    {
        public List<Generic2Select2ViewModel> Detentos { get; set; }
        public List<string> Statuses { get; set; }
    }
}