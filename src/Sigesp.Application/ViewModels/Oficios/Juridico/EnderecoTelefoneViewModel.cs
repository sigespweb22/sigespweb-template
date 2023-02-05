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
    public class EnderecoTelefoneViewModel
    {
        public string OficioNumero { get; set; }
        public string OficioData { get; set; }
        public string DetentoNome { get; set; }
        public string DetentoIpen { get; set; }
        public string Pec { get; set; }
        public string EnderecoCompleto { get; set; }
        public string Telefone { get; set; }
    }
}