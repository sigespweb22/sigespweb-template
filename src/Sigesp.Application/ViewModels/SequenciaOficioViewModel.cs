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
    public class SequenciaOficioViewModel
    {
        public int? Sequencia { get; set; }
        public string UsuarioNomeUltimaSequencia   { get; set; }
        public string UltimaSequencia { get; set; }
        public string SequenciaGerada { get; set; }
        public string CreatedAt { get; set; }
        public string UserSetor { get; set; }
        public string TenantNomeExibicao { get; set; }
        public List<SequenciaOficioViewModel> MinhasSequencias { get; set;}
    }
}