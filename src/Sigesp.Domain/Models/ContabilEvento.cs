using System.Collections.Generic;

namespace Sigesp.Domain.Models
{
    public class ContabilEvento : EntityAudit
    {
        public ContabilEvento(string codigo, 
                                string especificacao)
        {
            Especificacao = especificacao;
            Codigo = codigo;
        }

        //Construtor vazio para o EF
        public ContabilEvento() {}

        public string Codigo { get; set; }
        public string Especificacao { get; set; }

        public ICollection<Lancamento> Lancamentos { get; set; }
    }
}