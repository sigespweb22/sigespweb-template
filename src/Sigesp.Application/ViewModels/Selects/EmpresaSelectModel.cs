using System.Dynamic;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Sigesp.Domain.Enums;
using Sigesp.Domain.Models;
using Sigesp.Application.ViewModels;

namespace Sigesp.Application.ViewModels.Selects
{
    public class EmpresaSelectModel
    {
        public Guid? EmpresaId { get; set; }

        public string RazaoSocial { get; set; }
    }
}