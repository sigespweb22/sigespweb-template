using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Numerics;
using Sigesp.Domain.Enums;

namespace Sigesp.Domain.Models
{
    public class AlunoLeitor : EntityAudit
    {
        public AlunoLeitor(DateTime dataIngresso,
                            AlunoLeitorOcorrenciaDesistenciaEnum ocorrenciaDesistencia,
                            DateTime dataOcorrenciaDesistencia)
        {
            DataIngresso = dataIngresso;
            OcorrenciaDesistencia = ocorrenciaDesistencia;
            DataOcorrenciaDesistencia = dataOcorrenciaDesistencia;
        }


        //Construtor vazio para o EF
        public AlunoLeitor() {}


        public DateTime DataIngresso { get; set; }
        public AlunoLeitorOcorrenciaDesistenciaEnum OcorrenciaDesistencia { get; set; }
        public DateTime DataOcorrenciaDesistencia { get; set; }
        public DateTime LockoutEndByOcorrencia { get; set; }
        

        
        //Relacionamentos

        //Tenancy        
        [ForeignKey("TenantId")]
        public Guid TenantId { get; set; }
        public Tenant Tenant { get; set; }
                
        //Aluno
        [ForeignKey("AlunoId")]
        public Guid AlunoId { get; set; }
        public Aluno Aluno { get; set; }

        //Professor - Orientador
        [ForeignKey("ProfessorId")]
        public Guid ProfessorId { get; set; }
        public Professor Professor { get; set; }

        //Gênero
        [ForeignKey("LivroGeneroId")]
        public Guid LivroGeneroId { get; set; }
        public LivroGenero LivroGenero { get; set; }


        public ICollection<AlunoLeitura> AlunoLeituras { get; set; }

    }
}