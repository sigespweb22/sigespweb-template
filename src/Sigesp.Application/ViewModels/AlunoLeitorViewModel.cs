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
    public class AlunoLeitorViewModel
    {
        public Guid? Id { get; set; }

        [Required(ErrorMessage = "Data ingresso requerida.")]
        [DisplayName("Data ingresso")]
        public string DataIngresso { get; set; }

        [DisplayName("Ocorrência desistência")]
        public string OcorrenciaDesistencia { get; set; }

        [DisplayName("Data ocorrência desistência")]
        public string DataOcorrenciaDesistencia { get; set; }

        public bool IsDeleted { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid CreatedBy { get; set; }

        [DisplayName("Data final do bloqueio")]
        public string DataFimBloqueio { get; set; }
        

        //Relacionamentos
        [Required(ErrorMessage = "Aluno (Ipen) requerido.")]
        public string DetentoIpen { get; set; }
        
        public string DetentoNome { get; set; }
        public string DetentoGaleria { get; set; }
        public string DetentoCela { get; set; }

        public Guid AlunoId { get; set; }
        public Aluno Aluno { get; set; }


        public Guid? ProfessorId { get; set; }
        public Professor Professor { get; set; }

        [Required(ErrorMessage = "Professor requerido.")]
        public string ProfessorNome { get; set; }


        public Guid LivroGeneroId { get; set; }

        [Required(ErrorMessage = "Genêro leitura requerido.")]
        public string LivroGeneroNome { get; set; }
        
        public LivroGenero LivroGenero { get; set; }
    }
}