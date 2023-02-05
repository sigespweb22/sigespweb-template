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
    public class DetentoSaidaTemporariaViewModel
    {
        public Guid? Id { get; set; }

        public string SaidaPrevista { get; set; }
        public string RetornoPrevisto { get; set; }

        public Detento Detento { get; set; }
    }
}