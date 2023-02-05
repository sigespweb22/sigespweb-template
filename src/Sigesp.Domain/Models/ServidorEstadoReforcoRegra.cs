using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Sigesp.Domain.Enums;

namespace Sigesp.Domain.Models
{
    public class ServidorEstadoReforcoRegra : EntityAudit
    {
        public ServidorEstadoReforcoRegra(DateTime dataPrimeiroPlantao,
                                          PlantaoNomeEnum nomePrimeiroPlantao,
                                          DateTime dataPrimeiraJanela,
                                          DateTime dataSegundaJanela,
                                          DateTime dataTerceiraJanela,
                                          MonthOfYearEnum mesRegra)
        {   
            DataPrimeiroPlantao = dataPrimeiroPlantao;
            NomePrimeiroPlantao = nomePrimeiroPlantao;
            DataPrimeiraJanela = dataPrimeiraJanela;
            DataSegundaJanela = dataSegundaJanela;
            DataTerceiraJanela = dataTerceiraJanela;
            MesRegra = mesRegra;
        }

        //Construtor vazio para o EF
        public ServidorEstadoReforcoRegra() { }

        public DateTime DataPrimeiroPlantao { get; set; }
        public PlantaoNomeEnum NomePrimeiroPlantao { get; set; }
        public DateTime DataPrimeiraJanela { get; set; }
        public DateTime DataSegundaJanela { get; set; }
        public DateTime DataTerceiraJanela { get; set; }
        public MonthOfYearEnum MesRegra { get; set; }


        //Relacionamentos
        [ForeignKey("TenantId")]
        public Guid TenantId { get; set; }
        public Tenant Tenant { get;  set; }

        public ICollection<ServidorEstadoReforcoRegraVagaDia> VagasPorDia { get; set; }
    }
}