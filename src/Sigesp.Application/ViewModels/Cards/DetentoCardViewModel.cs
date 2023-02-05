using System.Collections;
using System;
using System.Collections.Generic;
using Sigesp.Domain.Models;
using Sigesp.Domain.Enums;

namespace Sigesp.Application.ViewModels.Cards
{
    public class DetentoCardViewModel
    {
        public int Total { get; set; }
        public int Recolhidos { get; set; }
        
        public int Provisorios { get; set; }

        public int Condenados { get; set; }

        public int SaidaTemporaria { get; set; }
        public List<string> DetentoRegimes { get; set; }
        public List<string> TiposConta { get; set; }
        public List<string> Galerias { get; set; }
        public List<string> InstrumentosPrisao { get; set; }
        public List<string> CondenacaoTipos { get; set; }
        public List<string> TransferenciaTipos { get; set; }
    }
}