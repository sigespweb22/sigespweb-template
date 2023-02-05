using System.Collections;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Sigesp.Domain.Enums;

namespace Sigesp.Domain.Models
{
    public class Pad : EntityAudit
    {
        public Pad(Int64 portaria, FaltaTipoEnum falta,
                   Int32 diasMedidaPreventiva, DateTime dataInstauracao,
                   DateTime dataOcorrencia,
                   Int64 portariaSGPE, string artigoNumero,
                   string artigoLei, string artigoDataExtenso,
                   string artigoLeiTexto, string descricaoCurtaFatos, 
                   TermoCienciaSituacaoEnum termoCienciaSituacao,
                   string parecerFinal,
                   string solucaoIncidente,
                   DateTime dataLimiteDefesaTecnica)
        {
            Portaria = portaria;
            Falta = falta;
            DiasMedidaPreventiva = diasMedidaPreventiva;
            DataInstauracao = dataInstauracao;
            DataOcorrencia = dataOcorrencia;
            PortariaSGPE = portariaSGPE;
            ArtigoNumero = artigoNumero;
            ArtigoLei = artigoLei;
            ArtigoDataExtenso = artigoDataExtenso;
            ArtigoLeiTexto = artigoLeiTexto;
            DescricaoCurtaFatos = descricaoCurtaFatos;
            TermoCienciaSituacao = termoCienciaSituacao;
            ParecerFinal = parecerFinal;
            SolucaoIncidente = solucaoIncidente;
            DataLimiteDefesaTecnica = dataLimiteDefesaTecnica;
        }

        // Contructor empty to EFCore
        public Pad() {}
        
        public Int64 Portaria { get; set;}
        public FaltaTipoEnum Falta { get; set; }
        public Int32 DiasMedidaPreventiva { get; set; }
        public DateTime DataInstauracao { get; set; }
        public DateTime DataOcorrencia { get; set; }
        public Int64 PortariaSGPE { get; set; }
        public string ArtigoNumero { get; set; }
        public string ArtigoLei { get; set; }
        public string ArtigoDataExtenso { get; set; }
        public string ArtigoLeiTexto { get; set; }
        // Este campo servirá para informar uma descrição curta do fato
        public string DescricaoCurtaFatos { get; set; }
        public TermoCienciaSituacaoEnum TermoCienciaSituacao { get; set; }
        public string ParecerFinal { get; set; }
        public string SolucaoIncidente { get; set; }
        public DateTime DataLimiteDefesaTecnica { get; set; }
        
        // Relationship
        [ForeignKey("TenantId")]
        public Guid TenantId { get; set; }
        public Tenant Tenant { get; set; }

        public ICollection<PadIncidentado> PadIncidentados { get; set; }
        public ICollection<PadConselheiro> PadConselheiros { get; set; }
        public ICollection<PadOitiva> PadOtivas { get; set; }
        public ICollection<PadDespacho> PadDespachos { get; set; }
        public ICollection<Advogado> Advogados { get; set; }
    } 
}