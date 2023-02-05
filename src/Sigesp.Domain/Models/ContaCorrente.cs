using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Sigesp.Domain.Enums;

namespace Sigesp.Domain.Models
{
    public class ContaCorrente : EntityAudit
    {
        public ContaCorrente(int numero, 
                            DateTime dataUltimoStatus,
                            ContaCorrenteStatusEnum status)
        {
            Numero = numero;
            DataUltimoStatus = dataUltimoStatus;
            Status = status;
        }

        // Construtor vazio para o EF
        public ContaCorrente() { }

        public int Numero { get; set; }
        public DateTime DataUltimoStatus { get; set; }
        public ContaCorrenteStatusEnum Status { get; set; }
        
        //Campos novos
        public ContaCorrenteTipoEnum Tipo { get; set; }
        public string Descricao { get; set; }

        //Relacionamentos
        public ICollection<Lancamento> Lancamentos { get;  set; }

        [ForeignKey("ColaboradorId")]
        public Guid? ColaboradorId { get; set; }
        public Colaborador Colaborador { get;  set; }

        [ForeignKey("EmpresaId")]
        public Guid? EmpresaId { get; set; }
        public Empresa Empresa { get; set; }
    }
}