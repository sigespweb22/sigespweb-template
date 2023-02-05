using System;
using System.ComponentModel.DataAnnotations.Schema;
using Sigesp.Domain.Enums;

namespace Sigesp.Domain.Models
{
    public class ColaboradorPontoApontamento : EntityAudit
    {
        public ColaboradorPontoApontamento(DateTime data, 
                                            ColaboradorPontoApontamentoEnum tipo)
        {
            Data = data;
            Tipo = tipo;
        }

        //Construtor vazio para o EF
        public ColaboradorPontoApontamento() {}

        //Propriedades
        public DateTime Data { get; set; }
        public ColaboradorPontoApontamentoEnum Tipo { get; set; }


        //Relacionamentos
        [ForeignKey("ColaboradorPontoId")]
        public Guid ColaboradorPontoId { get; set; }
        public ColaboradorPonto ColaboradorPonto { get; set; }
    }
}