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
    public class AlunoLeitorESViewModel
    {
        public Guid? Id { get; set; }
        public string DetentoIpen { get; set; }
        public string DetentoNome { get; set; }
        public string DetentoGaleria { get; set; }
        public string DetentoCela { get; set; }
        public string DetentoRegime { get; set; }
    }
}