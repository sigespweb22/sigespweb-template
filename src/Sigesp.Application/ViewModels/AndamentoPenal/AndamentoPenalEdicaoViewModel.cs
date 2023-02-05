using System.Collections;
using System;
using System.Collections.Generic;
using Sigesp.Domain.Models;
using Sigesp.Domain.Enums;
using Sigesp.Application.ViewModels;

namespace Sigesp.Application.ViewModels.AndamentoPenal
{
    public class AndamentoPenalEdicaoViewModel
    {
        public AndamentoPenalViewModel AndamentoPenalViewModel { get; set; }
        public List<string> Statuses { get; set; }
    }
}