using System;
using System.ComponentModel.DataAnnotations.Schema;
using Sigesp.Domain.Enums;

namespace Sigesp.Domain.Models
{
    public class AlunoEjaDisciplina : EntityAudit
    {
        public AlunoEjaDisciplina(AlunoEjaDisciplinaConceitoEnum conceito,
                                  AlunoEjaDisciplinaEnum nome)
        {
            Conceito = conceito;
            Nome = nome;
        }

        // Construtor vazio para o EF
        public AlunoEjaDisciplina() { }

        public AlunoEjaDisciplinaConceitoEnum Conceito { get; set; }
        public AlunoEjaDisciplinaEnum Nome { get; set; }


        //Relacionamentos
        [ForeignKey("AlunoEjaId")]
        public Guid AlunoEjaId { get; set; }
        public AlunoEja AlunoEja { get;  set; }
    }
}