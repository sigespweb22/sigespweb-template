using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Numerics;
using Sigesp.Domain.Enums;

namespace Sigesp.Domain.Models
{
    public class Professor : EntityAudit
    {
        public Professor (string nome, 
                          GaleriaEnum galeria)
        {
            Nome = nome;
            Galeria = galeria;
        }

        //Construtor vazio para o EF
        public Professor() {}

        public string Nome { get; set; }
        public GaleriaEnum Galeria { get; set; }
        public string Cpf { get; set; }

        //Relacionamentos

        //Tenant
        [ForeignKey("TenantId")]
        public Guid TenantId { get; set; }
        public Tenant Tenant { get; set; }


        [ForeignKey("ApplicationUserId")]
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }


        public ICollection<AlunoLeitor> AlunosLeitores { get; set; }
        public ICollection<Disciplina> Disciplinas { get; set; }
        public ICollection<AlunoRedacaoDPU> AlunosRedacaoDPU { get; set; }
    }
}