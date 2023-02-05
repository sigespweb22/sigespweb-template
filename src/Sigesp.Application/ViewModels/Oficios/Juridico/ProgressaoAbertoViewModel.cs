using System.Dynamic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Sigesp.Domain.Enums;
using Sigesp.Domain.Models;
using Sigesp.Application.ViewModels;

namespace Sigesp.Application.ViewModels.Oficios.Juridico
{
    public class ProgressaoAbertoViewModel
    {
        public string OficioNumero { get; set; }
        public string OficioData { get; set; }
        public string DetentoNome { get; set; }
        public string DetentoIpen { get; set; }
        public string Pec { get; set; }
    }
}