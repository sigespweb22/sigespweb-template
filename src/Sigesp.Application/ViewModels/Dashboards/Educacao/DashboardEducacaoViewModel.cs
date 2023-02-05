using System.Collections;
using System;
using System.Collections.Generic;
using Sigesp.Domain.Models;
using Sigesp.Domain.Enums;
using Sigesp.Application.ViewModels.Selects;

namespace Sigesp.Application.ViewModels.Dashboards.Educacao
{
    public class DashboardEducacaoViewModel
    {
        public ChartAcervoLiterario ChartAcervoLiterario { get; set; }
        public ChartIndiceAdesaoProjetoLeitura ChartIndiceAdesaoProjetoLeitura { get; set; }
        public ChartIndiceEscolaridadeAlunos ChartIndiceEscolaridadeAlunos { get; set; }
        public ChartIndiceAvaliacaoConceito ChartIndiceAvaliacaoConceito { get; set; }
    }

    public class ChartAcervoLiterario
    {
        public Int64 AtivosQ { get; set; }
        public string AtivosP { get; set; }
        public Int64 InativosQ { get; set; }
        public string InativosP { get; set; }
        public Int64 DisponiveisQ { get; set; }
        public string DisponiveisP { get; set; }
        public Int64 IndisponiveisQ { get; set; }
        public string IndisponiveisP { get; set; }
        public Int64 Total { get; set; }
    }

    public class ChartIndiceAdesaoProjetoLeitura
    {
        public Int64 TotalDetentos { get; set; }
        public Int64 ParticipantesQ { get; set; }
        public string ParticipantesP { get; set; }
        public Int64 NaoParticipantesQ { get; set; }
        public string NaoParticipantesP { get; set; }
    }

    public class ChartIndiceEscolaridadeAlunos
    {
        public Int64 TotalAlunos { get; set; }
        public Int64 NaoInformadoQ { get; set; }
        public string NaoInformadoP { get; set; }
        public Int64 EnsinoFundamentalIQ { get; set; }
        public string EnsinoFundamentalIP { get; set; }
        public Int64 EnsinoFundamentalIIQ { get; set; }
        public string EnsinoFundamentalIIP { get; set; }
        public Int64 EnsinoMedioQ { get; set; }
        public string EnsinoMedioP { get; set; }
        public Int64 EnsinoSuperiorQ { get; set; }
        public string EnsinoSuperiorP { get; set; }
    }

    public class ChartIndiceAvaliacaoConceito
    {
        public Int64 TotalLeituras { get; set; }
        public Int64 PendenteQ { get; set; }
        public string PendenteP { get; set; }
        public Int64 AprovadoQ { get; set; }
        public string AprovadoP { get; set; }
        public Int64 InsuficienteQ { get; set; }
        public string InsuficienteP { get; set; }
        public Int64 DesistenciaQ { get; set; }
        public string DesistenciaP { get; set; }
        public Int64 NaoCumprimentoQ { get; set; }
        public string NaoCumprimentoP { get; set; }
    }
}