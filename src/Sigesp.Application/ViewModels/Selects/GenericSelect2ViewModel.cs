using System.Dynamic;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Sigesp.Domain.Enums;
using Sigesp.Domain.Models;
using Sigesp.Application.ViewModels;

namespace Sigesp.Application.ViewModels.Selects
{
    public class GenericSelect2ViewModel
    {
        public int Id { get; set; }

        public string Titulo { get; set; }
    }
}