using System.Dynamic;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Sigesp.Domain.Enums;
using Sigesp.Domain.Models;
using Sigesp.Application.ViewModels;
using System.Collections.Generic;

namespace Sigesp.Application.ViewModels
{
    public class ServidorEstadoReforcoRegraVagaDiaViewModel
    {
        [DisplayName("Dia")]
        public string Dia { get; set; }

        [DisplayName("TotalVagas")]
        public int TotalVagas { get; set; }

        [DisplayName("Turno")]
        public string Turno { get; set; }
    }
}