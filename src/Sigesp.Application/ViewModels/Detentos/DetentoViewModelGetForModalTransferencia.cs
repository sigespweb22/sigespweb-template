using System.Dynamic;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Sigesp.Domain.Enums;
using Sigesp.Domain.Models;
using Sigesp.Application.ViewModels;
using System.Collections.Generic;

namespace Sigesp.Application.ViewModels.Detentos
{
    public class DetentoViewModelGetForModalTransferencia
    {
        public string Ipen { get; set; }
        public string Nome { get; set; }
        public string Regime { get; set; }
    }
}