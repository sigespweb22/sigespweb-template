using System.Data;
using System;
using System.Collections.Generic;
using Sigesp.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sigesp.Domain.Models
{
    public class EmpresaConvenio : EntityAudit
    {
        public EmpresaConvenio(string nome, DateTime dataInicio, DateTime dataFim, DateTime dataEncerramento, string motivoEncerramento, bool isRenovacaoAutomatica, 
                        string termosGerais, string responsavel)
        {
            Nome = nome;
            DataInicio = dataInicio;
            DataFim = dataFim;
            DataEncerramento = dataEncerramento;
            MotivoEncerramento = motivoEncerramento;
            IsRenovacaoAutomatica = isRenovacaoAutomatica;
            TermosGerais = termosGerais;
            Responsavel = responsavel;
        }

        // Construtor vazio para o EF
        public EmpresaConvenio() { }

        public string Nome { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public DateTime DataEncerramento { get; set; }
        public string MotivoEncerramento { get; set; }
        public bool IsRenovacaoAutomatica { get; set; }   
        public string TermosGerais { get; set; }
        public string Responsavel { get; set; }
        public ConvenioSituacaoEnum Situacao { get; set; }

        //Relacionamentos
        public Guid EmpresaId { get; set; }
        
        [ForeignKey("EmpresaId")]
        public Empresa Empresa { get;  set; }
        public ICollection<Colaborador> Colaboradores { get; set; }

        public ICollection<ColaboradorPonto> ColaboradoresPonto { get; set; }
    }
}