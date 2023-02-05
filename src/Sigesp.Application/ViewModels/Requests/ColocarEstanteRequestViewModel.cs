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
    public class ColocarEstanteRequestViewModel
    {
        public string Localizacao { get; set; }
        public bool Todos { get; set; }
    }
}