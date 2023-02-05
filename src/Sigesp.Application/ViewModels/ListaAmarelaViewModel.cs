using System.Dynamic;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Sigesp.Domain.Enums;
using Sigesp.Domain.Models;
using Sigesp.Application.ViewModels;
using System.Collections.Generic;

namespace Sigesp.Application.ViewModels
{
    public class ListaAmarelaViewModel
    {
        public Guid? Id { get; set; }
        public string RevisaoIpenData   { get; set; }
        public string RevisaoIpenObservacao   { get; set; }
        public string DataPrisao   { get; set; }
        public string Artigos   { get; set; }
        public string Comarca   { get; set; }
        public string PenaAno   { get; set; }
        public string PenaMes   { get; set; }
        public string PenaDia   { get; set; }
        public List<string> InstrumentosPrisao   { get; set; }
        public string CondenacaoTipo   { get; set; }
        public Int64? DiasMedidaDisciplinar   { get; set; }
        public string AcaoPenal { get; set; }
        public string DataPrevisaoBeneficio { get; set; }
        public string DataProgressao { get; set; }
        public string PrevisaoBeneficioObservacao { get; set; }
        public bool? IsDeleted { get; set; }
        public string DataSaidaPrevista { get; set; }

        //Campos novos adicionados em 09/02/2022
        public bool AguardandoTransferencia { get; set; }
        public string AguardandoTransferenciaTipo   { get; set; }

        

        public Guid? DetentoId {get; set; }
        public string DetentoNome {get; set; }
        public string DetentoIpen {get; set; }
        public string DetentoRegime {get; set; }
        public DetentoViewModel DetentoViewModel { get; set; }
    }
}