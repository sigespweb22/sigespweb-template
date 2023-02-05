using System.Runtime.Serialization;
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
    public class EmpresaConvenioViewModel
    {
        public Guid? Id { get; set; }
        
        [Required(ErrorMessage = "Nome requerido")]
        [MinLength(2)]
        [MaxLength(255)]
        [DisplayName("Nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Data início requerida")]
        [DisplayName("Data início")]
        public string DataInicio { get; set; }

        [Required(ErrorMessage = "Data fim requerida")]
        [DisplayName("Data fim")]
        public string DataFim { get; set; }

        [DisplayName("Data encerramento")]
        public string DataEncerramento { get; set; }

        [MaxLength(255)]
        [DisplayName("Motivo encerramento")]
        public string MotivoEncerramento { get; set; }

        [Required(ErrorMessage = "Renovação automática requerida")]
        [DisplayName("Renovação automática")]
        public bool IsRenovacaoAutomatica { get; set; }

        [MaxLength(255)]
        [DisplayName("Termos gerais")]
        public string TermosGerais { get; set; }

        [MaxLength(255)]
        [DisplayName("Responsável")]
        public string Responsavel { get; set; }

        [DisplayName("Situação")]
        public string Situacao { get; set; }

        public bool? IsDeleted { get; set; }
        
        //Relacionamentos
        public Guid EmpresaId { get; set; }

        [MinLength(2)]
        [MaxLength(255)]
        [Required(ErrorMessage = "Empresa Razão Social requerida")]
        [DisplayName("Empresa Razão Social")]
        public string EmpresaRazaoSocial { get; set; }
    }
}