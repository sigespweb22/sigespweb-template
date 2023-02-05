using System.Dynamic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Sigesp.Domain.Enums;
using Sigesp.Domain.Models;
using Sigesp.Application.ViewModels;

namespace Sigesp.Application.ViewModels.Oficios.Educacao
{
    public class OficioEducacaoLeituraViewModel
    {
        public string OficioNumero { get; set; }
        public string OficioData { get; set; }
        public string DetentoNome { get; set; }
        public string DetentoIpen { get; set; }
        public string DetentoPec { get; set; }
        public string OficioRemicao { get; set; }
        public List<OficioEducacaoLeitura> Leituras { get; set; }
        public Tenant Tenant { get; set; }
    }

    public class OficioEducacaoLeitura
    {
        public Guid Id { get; set; }
        public DateTime AnoReferencia { get; set; }
        public int PeriodoReferenciaSequencia { get; set; }
        public string PeriodoReferencia { get; set; }
        public string TituloLivro { get; set; }
        public string LeituraRemicao { get; set; }
        public string Conceito { get; set; }
    }
}