using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Numerics;
using Sigesp.Domain.Enums;

namespace Sigesp.Domain.Models
{
    public class AlunoEja : EntityAudit
    {
        public AlunoEja(DateTime dataIngresso,
                        CursoEnum curso,
                        TurnoEnum turnoPeriodo,
                        FaseEnum fase,
                        AlunoEjaDisciplinaEnum[] disciplinas,
                        AlunoLeitorOcorrenciaDesistenciaEnum ejaOcorrenciaDesistencia,
                        DateTime dataOcorrenciaDesistencia,
                        AlunoEjaFaseStatusEnum faseStatus)
        {
            DataIngresso = dataIngresso;
            Curso = curso;
            TurnoPeriodo = turnoPeriodo;
            Fase = fase;
            Disciplinas = disciplinas;
            EjaOcorrenciaDesistencia = ejaOcorrenciaDesistencia;
            DataOcorrenciaDesistencia = dataOcorrenciaDesistencia;
            FaseStatus = faseStatus;
        }

        //Construtor vazio para o EF
        public AlunoEja() {}

        public DateTime DataIngresso { get; set; }
        public CursoEnum Curso { get; set; }
        public TurnoEnum TurnoPeriodo { get; set; }
        public FaseEnum Fase { get; set; }
        public AlunoEjaDisciplinaEnum[] Disciplinas { get; set; }
        public AlunoLeitorOcorrenciaDesistenciaEnum EjaOcorrenciaDesistencia { get; set; }
        public DateTime DataOcorrenciaDesistencia { get; set; }
        public AlunoEjaFaseStatusEnum FaseStatus { get; set; }

        
        //Relacionamentos
        
        //Aluno
        [ForeignKey("AlunoId")]
        public Guid AlunoId { get; set; }
        public Aluno Aluno { get; set; }

        //Tenant
        [ForeignKey("TenantId")]
        public Guid TenantId { get; set; }
        public Tenant Tenant { get; set; }

        public ICollection<AlunoEjaDisciplina> AlunoEjaDisciplinas { get; set; }

        //Médio	3 fases (blocos) - Cada fase corresponde, respectivamente, a um ano do Ensino Médio.
        //Fundamental II - 4 fases - Cada fase corresponde a um bimestre letivo. 
        //Fundamental I	- 5 fases	- Cada fase corresponde a um semeste letivo.
    }
}
