using System.Dynamic;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Sigesp.Domain.Enums;
using Sigesp.Domain.Models;
using Sigesp.Application.ViewModels;
using System.Collections.Generic;

namespace Sigesp.Application.ViewModels.Requests
{
    public class OficioEducacaoLeituraRequestModel
    {
        [Required, MinLength(1, ErrorMessage = "Ao menos uma leitura é requerida.")]
        [DisplayName("Leituras Ids")]
        public List<string> LeiturasIds { get; set; }
    }
}