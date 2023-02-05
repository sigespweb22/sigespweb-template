using System.Dynamic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Sigesp.Domain.Enums;
using Sigesp.Domain.Models;
using Sigesp.Application.ViewModels;

namespace Sigesp.Application.ViewModels
{
    public class DetentoImp
    {
        public string Ipen { get;set; } = "";
        public string Nome { get; set; } = "";
        public string Galeria { get; set; } = "";
        public string Cela { get; set; } = "";
    }
}