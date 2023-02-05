using System.Xml;
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
    public class LeitorViewModel
    {
        public Guid? Id { get; set; }

        [Required(ErrorMessage = "Escolaridade requerida.")]
        [DisplayName("Escolaridade")]
        public string Escolaridade { get; set; }

        [DisplayName("Id registro Ceja")]
        public string CejaId { get; set; }

        [DisplayName("Ceja matrícula")]
        public string CejaMatricula { get; set; }

        [DisplayName("Ceja data matrícula")]
        public string CejaDataMatricula { get; set; }

        [DisplayName("Ocorrência de desativação")]
        public string OcorrenciaIsDeleted { get; set; }

        [DisplayName("Ocorrência data")]
        public string DataUltimoIsDeletedOcorrencia { get; set; }

        [DisplayName("Enturmado")]
        public bool IsEnturmado { get; set; }

        [DisplayName("Data pedido enturmação")]
        public string DataPedidoEnturmacao { get; set; }

    

        //Relacionamentos

        public string ProfessorId { get; set; }

        [Required(ErrorMessage = "Professor requerido.")]
        public string ProfessorNome { get; set; }


        public string LivroGeneroId { get; set; }

        [Required(ErrorMessage = "Gênero requerido.")]
        public string LivroGeneroNome { get; set; }

        
        public string AlunoId { get; set; }

        [Required(ErrorMessage = "Ipen requerido.")]
        public string DetentoIpen { get; set; }

        public string DetentoNome { get; set; }
        public string DetentoGaleria { get; set; }

        public string DetentoCela { get; set; }

        public ProfessorViewModel ProfessorViewModel { get; set; }
        public LivroGenero LivroGenero { get; set; }
        public Aluno Aluno { get; set; }
    }
}