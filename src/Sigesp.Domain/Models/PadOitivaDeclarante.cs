using System.ComponentModel.DataAnnotations.Schema;
using System;
using Sigesp.Domain.Enums;

namespace Sigesp.Domain.Models
{
    public class PadOitivaDeclarante : EntityAudit
    {
        public PadOitivaDeclarante(string declaracao,
                                   DeclaranteCondicaoEnum declaranteCondicao)
        {
            Declaracao = declaracao;
            DeclaranteCondicao = declaranteCondicao;
        }

        // Constructor empty to EFCore
        public PadOitivaDeclarante() {}

        public string Declaracao { get; set; }
        public DeclaranteCondicaoEnum DeclaranteCondicao { get; set; }

        // Relationships
        [ForeignKey("PadOitivaId")]
        public Guid PadOitivaId { get; set; }
        public PadOitiva PadOitiva { get; set; }
    } 
}