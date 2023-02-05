using System.Dynamic;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Sigesp.Domain.Enums;
using Sigesp.Domain.Models;
using Sigesp.Application.ViewModels;
using System.Collections.Generic;
using Sigesp.Application.ViewModels.Selects;

namespace Sigesp.Application.ViewModels.Cards
{
    public class ContabilEventoCardViewModel
    {
        public int Eventos { get; set; }
    }
}