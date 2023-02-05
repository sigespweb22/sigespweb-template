using System.Dynamic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Sigesp.Domain.Enums;
using Sigesp.Domain.Models;
using Sigesp.Application.ViewModels;

namespace Sigesp.Application.ViewModels.Oficios
{
    public class OficioAlimentosViewModel
    {
        public string Nome { get; set; }
        public string Ipen { get; set; }
        public string Comarca { get; set; }
        public string Autos { get; set; }
        public string PrazoPrisao { get; set; }
        public string DataPrisao { get; set; }
        public string DataSaida { get; set; }
    }
}