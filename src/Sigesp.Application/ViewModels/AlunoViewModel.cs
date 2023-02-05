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
    public class AlunoViewModel
    {
        public Guid? Id { get; set; }

        [DisplayName("Escolaridade")]
        public string Escolaridade { get; set; }

        // [Range(minimum: 1, maximum: Int32.MaxValue, ErrorMessage = "Permitido máximo de 4 atividades educacionais.")]
        // [Required, MinLength(1, ErrorMessage = "Ao menos uma atividade educacional é requerida.")]
        [DisplayName("Atividades educacionais")]
        public List<string> AtividadesEducacionais { get; set; }

        [DisplayName("Ceja id")]
        public string CejaId { get; set; }

        [DisplayName("Ceja matrícula")]
        public string CejaMatricula { get; set; }

        [DisplayName("Ceja data matrícula")]
        public string CejaDataMatricula { get; set; }

        [DisplayName("Turma número")]
        public string TurmaNumero { get; set; }

        [DisplayName("Turma sala")]
        public string TurmaSala { get; set; }

        [DisplayName("Enturmado?")]
        public bool IsEnturmado { get; set; }

        [DisplayName("Data pedido enturmação")]
        public string DataPedidoEnturmacao { get; set; }

        public bool IsDeleted { get; set; }
        public Guid? TenantId { get; set; }



        //Relacionamentos
        [Required(ErrorMessage = "Nome reeducando requerido.")]
        public Guid DetentoId { get; set; }
        public Detento Detento { get; set; }
        public string DetentoIpen { get; set; }
        public string DetentoNome { get; set; }
        public string DetentoGaleria { get; set; }
        public string DetentoCela { get; set; }

    }
}