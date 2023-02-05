using System.Collections;
using System;
using System.Collections.Generic;
using Sigesp.Domain.Models;
using Sigesp.Domain.Enums;

namespace Sigesp.Application.ViewModels.Cards
{
    public class ListaAmarelaCardViewModel
    {
        public int Ativos { get; set; }
        public int Provisorios { get; set; }
        public int Condenados { get; set; }
        public int Fechados { get; set; }
        public int SemiAbertos { get; set; }
        public int SaidaTemporaria { get; set; }
        public int Alimentos { get; set; }
        public int Temporarias { get; set; }
        public int Outros { get; set; }
        public int TransferenciasMD { get; set; }
        public int MDsRecebidos { get; set; }
        public int EmAudiencia { get; set; }
        public int InternacaoHospitalar { get; set; }
        public List<string> Detentos { get; set; }
        public List<string> DetentoSituacoes { get; set; }
        public List<string> InstrumentosPrisao { get; set; }
        public List<string> CondenacaoTipos { get; set; }
        public List<string> TransferenciaTipos { get; set; }
        public List<string> Regimes { get; set; }
        public List<string> AguardandoTransferenciaTipos { get; set; }
    }
}