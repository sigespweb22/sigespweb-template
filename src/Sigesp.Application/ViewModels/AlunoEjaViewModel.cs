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
    public class AlunoEjaViewModel
    {
        public Guid? Id { get; set; }

        [Required(ErrorMessage = "Data ingresso requerida.")]
        [DisplayName("Data ingresso")]
        public string DataIngresso { get; set; }

        [DisplayName("Ocorrência desistência")]
        public string EjaOcorrenciaDesistencia { get; set; }

        [DisplayName("Data ocorrência desistência")]
        public string DataOcorrenciaDesistencia { get; set; }

        [Required(ErrorMessage = "Curso requerido.")]
        [DisplayName("Curso")]
        public string Curso { get; set; }

        [Required(ErrorMessage = "Turno período requerido.")]
        [DisplayName("Turno período")]
        public string TurnoPeriodo { get; set; }

        [Required(ErrorMessage = "Fase requerida.")]
        [DisplayName("Fase")]
        public string Fase { get; set; }

        [DisplayName("Disciplinas")]
        public List<string> Disciplinas   { get; set; }

        [Required, MinLength(1, ErrorMessage = "Ao menos uma disciplina é requerida.")]
        [DisplayName("Alunos Eja Disciplinas")]
        public List<AlunoEjaDisciplina> AlunoEjaDisciplinas   { get; set; }

        [Required(ErrorMessage = "Fase status requerida.")]
        [DisplayName("Fase status")]
        public string FaseStatus { get; set; }
        
        [DisplayName("Inativo?")]
        public bool IsDeleted { get; set; }


        //Relacionamentos
        [Required(ErrorMessage = "Aluno (Ipen) requerido.")]
        public string DetentoIpen { get; set; }
        
        public string DetentoNome { get; set; }
        public string DetentoGaleria { get; set; }
        public string DetentoCela { get; set; }


        public Guid AlunoId { get; set; }
        public Aluno Aluno { get; set; }
    }
}