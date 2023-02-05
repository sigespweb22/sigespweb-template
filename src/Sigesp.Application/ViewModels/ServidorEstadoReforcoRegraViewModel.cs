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
    public class ServidorEstadoReforcoRegraViewModel
    {
        [DisplayName("Id")]
        public Guid? Id { get; set; }

        [Required(ErrorMessage = "Mês da regra requerido.")]
        [DisplayName("Mês regra")]
        public string MesRegra { get; set; }

        [DisplayName("Data primeiro plantão")]
        public string DataPrimeiroPlantao { get; set; }

        [DisplayName("Nome primeiro plantão")]
        public string NomePrimeiroPlantao { get; set; }

        [Required(ErrorMessage = "Data primeira janela requerida.")]
        [DisplayName("Data primeira janela")]
        public string DataPrimeiraJanela { get; set; }

        [Required(ErrorMessage = "Data segunda janela requerida.")]
        [DisplayName("Data segunda janela")]
        public string DataSegundaJanela { get; set; }

        [Required(ErrorMessage = "Data terceira janela requerida.")]
        [DisplayName("Data terceira janela")]
        public string DataTerceiraJanela { get; set; }

        [Required, MinLength(1, ErrorMessage = "Ao menos uma informação VAGAS POR DIA é requerida.")]
        [DisplayName("Vagas por dia")]
        public List<ServidorEstadoReforcoRegraVagaDiaViewModel> VagasPorDia { get; set; }

        [DisplayName("Id unidade")]
        public string TenantId { get; set; }
    }
}