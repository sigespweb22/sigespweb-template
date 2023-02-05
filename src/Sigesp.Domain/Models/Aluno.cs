using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Sigesp.Domain.Enums;

namespace Sigesp.Domain.Models
{
    public class Aluno : EntityAudit
    {
        public Aluno(EscolaridadeEnum escolaridade,
                     AtividadeEducacionalTipoEnum[] atividadesEducacionais,
                     string turmaNumero,
                     string turmaSala,                     
                     bool isEnturmado,
                     DateTime dataPedidoEnturmacao,
                     string cejaId, 
                     string cejaMatricula,
                     DateTime cejaDataMatricula)
        {
            Escolaridade = escolaridade;
            AtividadesEducacionais = atividadesEducacionais;
            TurmaNumero = turmaNumero;
            TurmaSala = turmaSala;
            IsEnturmado = isEnturmado;
            DataPedidoEnturmacao = dataPedidoEnturmacao;
            CejaId = cejaId;
            CejaMatricula = cejaMatricula;
            CejaDataMatricula = cejaDataMatricula;
        }

        //Construtor vazio para o EF
        public Aluno() { }


        public EscolaridadeEnum Escolaridade { get; set; }
        public AtividadeEducacionalTipoEnum[] AtividadesEducacionais { get; set; }
        

        //Begin - Campos válidos para atividades educacionais (Leitura/EJA)
        public string CejaId { get; set; }
        public string CejaMatricula { get; set; }
        public DateTime? CejaDataMatricula { get; set; }
        public string TurmaNumero { get; set; }
        public string TurmaSala { get; set; }
        public bool IsEnturmado { get; set; }
        public DateTime? DataPedidoEnturmacao { get; set; }
        //End - Campos válidos para atividades educacionais (Leitura/EJA)


        //Relacionamentos
        
        //Tenancy        
        [ForeignKey("TenantId")]
        public Guid TenantId { get; set; }
        public Tenant Tenant { get; set; }


        [ForeignKey("DetentoId")]
        public Guid DetentoId { get; set; }
        public Detento Detento { get;  set; }

        public ICollection<AlunoEja> AlunosEja { get; set; }
        public ICollection<AlunoEncceja> AlunosEncceja { get; set; }
        public ICollection<AlunoEnem> AlunosEnem { get; set; }
        public ICollection<AlunoLeitor> AlunosLeitores { get; set; }
        public ICollection<AlunoRedacaoDPU> AlunosRedacaoDPU { get; set; }
    }
}