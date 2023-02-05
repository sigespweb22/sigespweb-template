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
    public class AndamentoPenalViewModel
    {
        public Guid? Id { get; set; }

        [Required(ErrorMessage = "Data evento principal requerida.")]
        [DisplayName("Data evento principal")]
        public string DataEventoPrincipal { get; set; }
        
        [Required(ErrorMessage = "Status requerido.")]
        [DisplayName("Status")]
        public string Status { get; set; }

        [DisplayName("Histórico")]
        public string Historico { get; set; }

        [DisplayName("Observação")]
        public string Observacao { get; set; }

        [DisplayName("Endereço completo")]
        public string EnderecoCompleto { get; set; }

        [DisplayName("Telefone")]
        public string Telefone { get; set; }


        [DisplayName("Pec")]
        public string Pec { get; set; }

        [DisplayName("IsDeleted")]
        public bool? IsDeleted { get; set; }

        //Relacionamentos
        [DisplayName("Id detento")]
        public Guid? DetentoId { get; set; }

        [DisplayName("Nome detento")]
        public string DetentoNome { get; set; }
        
        [DisplayName("Galeria detento")]
        public string DetentoGaleria { get; set; }
        
        [DisplayName("Cela detento")]
        public string DetentoCela { get; set; }

        [DisplayName("Ipen detento")]
        public string DetentoIpen { get; set; }
        
        [DisplayName("Regime detento")]
        public string DetentoRegime { get; set; }

        public Detento Detento { get; set; }
    }
}