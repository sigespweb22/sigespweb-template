using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Sigesp.Domain.Enums;

namespace Sigesp.Domain.Models
{
    public class Disciplina : EntityAudit
    {
        public Disciplina(string nome, FaseEnum fase,
                          int horaAula, int cargaHoraria, CursoEnum curso)
        {
            Nome = nome;
            Fase = fase;
            HoraAula = horaAula;
            CargaHoraria = cargaHoraria;
            Curso = curso;
        }

        // Construtor vazio para o EF
        public Disciplina() { }

        public string Nome { get; set; }
        public FaseEnum Fase { get; set; }
        public int HoraAula { get; set; }
        public int CargaHoraria { get; set; }
        public CursoEnum Curso { get; set; }


        //Relacionamentos
        [ForeignKey("ProfessorId")]
        public Guid ProfessorId { get; set; }
        public Professor Professor { get; set; }
    }
}