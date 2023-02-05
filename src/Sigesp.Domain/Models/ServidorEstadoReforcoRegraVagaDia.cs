using System;
using System.ComponentModel.DataAnnotations.Schema;
using Sigesp.Domain.Enums;

namespace Sigesp.Domain.Models
{
    public class ServidorEstadoReforcoRegraVagaDia
    {
        public ServidorEstadoReforcoRegraVagaDia(Guid id, string dia,
                                                 int totalVagas, TurnoEnum turno)
        {   
            Id = id;
            Dia = dia;
            TotalVagas = totalVagas;
            Turno = turno;
        }

        //Construtor vazio para o EF
        public ServidorEstadoReforcoRegraVagaDia() { }

        public Guid Id { get; set; }
        public string Dia { get; set; }
        public int TotalVagas { get; set; }
        public TurnoEnum Turno { get; set; }


        //Relacionamentos
        [ForeignKey("ServidorEstadoReforcoRegraId")]
        public Guid ServidorEstadoReforcoRegraId { get; set; }
        public ServidorEstadoReforcoRegra ServidorEstadoReforcoRegra { get;  set; }
    }
}