using System.Collections;
using System;
using System.Collections.Generic;
using Sigesp.Domain.Models;
using Sigesp.Domain.Enums;
using Sigesp.Application.ViewModels.Selects;

namespace Sigesp.Application.ViewModels.Selects
{
    public class ColaboradorSelectViewModel
    {
        public List<string> Galerias { get; set; }
        public List<string> Situacoes { get; set; }
        public List<string> EmpresasConvenios { get; set; }
    }
}
