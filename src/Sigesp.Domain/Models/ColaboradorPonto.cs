using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sigesp.Domain.Models
{
    public class ColaboradorPonto : EntityAudit
    {
        public ColaboradorPonto(string periodoReferencia, 
                                DateTime periodoDataInicio,
                                DateTime periodoDataFim)
        {
            PeriodoReferencia = periodoReferencia;
            PeriodoDataInicio = periodoDataInicio;
            PeriodoDataFim = periodoDataFim;
        }

        // Construtor vazio para o EF
        public ColaboradorPonto() { }

        //Propriedades
        public string PeriodoReferencia { get; set; }
        public DateTime PeriodoDataInicio { get; set; }
        public DateTime PeriodoDataFim { get; set; }


        //Relacionamentos
        [ForeignKey("ColaboradorId")]
        public Guid ColaboradorId { get; set; }

        public Colaborador Colaborador { get; set; }

        [ForeignKey("EdiId")]
        public Guid EdiId { get; set; }

        public Edi Edi { get; set; }

        [ForeignKey("EmpresaConvenioId")]
        public Guid EmpresaConvenioId { get; set; }
        
        public EmpresaConvenio EmpresaConvenio { get; set; }

        public ICollection<ColaboradorPontoApontamento> ColaboradorPontoApontamentos { get; set; }
    }
}