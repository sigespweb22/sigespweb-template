using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sigesp.Domain.Models
{
    public class FormularioLeituraDicaEscritaDica : EntityAudit
    {
        public FormularioLeituraDicaEscritaDica(string dica, int ordem)
        {
            Dica = dica;
            Ordem = ordem;
        }

        public FormularioLeituraDicaEscritaDica() {}

        public string Dica { get; set; }
        public int Ordem { get; set; }

        [ForeignKey("FormularioLeituraDicaEscritaId")]
        public Guid FormularioLeituraDicaEscritaId { get; set; }
        public FormularioLeituraDicaEscrita FormularioLeituraDicaEscrita { get; set; }
    }
}