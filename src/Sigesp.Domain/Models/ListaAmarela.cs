using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Sigesp.Domain.Enums;

namespace Sigesp.Domain.Models
{
    public class ListaAmarela : EntityAudit
    {
        public ListaAmarela(DateTime revisaoIpenData,
                            DateTime dataPrisao, string artigos, string comarca,
                            string penaAno, string penaMes, string penaDia,
                            InstrumentoPrisaoTipoEnum[] instrumentosPrisao,
                            CondenacaoTipoEnum condenacaoTipo, Int64 diasMedidaDisciplinar,
                            string acaoPenal, DateTime dataPrevisaoBeneficio,
                            DateTime dataProgressao,
                            string previsaoBeneficioObservacao,
                            DetentoAguardandoTransferenciaTipoEnum aguardandoTransferenciaTipo)
        {
            RevisaoIpenData = revisaoIpenData;
            DataPrisao = dataPrisao;
            Artigos = artigos;
            Comarca = comarca;
            PenaAno = penaAno;
            PenaMes = penaMes;
            PenaDia = penaDia;
            InstrumentosPrisao = instrumentosPrisao;
            CondenacaoTipo = condenacaoTipo;
            DiasMedidaDisciplinar = diasMedidaDisciplinar;
            AcaoPenal = acaoPenal;
            DataPrevisaoBeneficio = dataPrevisaoBeneficio;
            DataProgressao = dataProgressao;
            PrevisaoBeneficioObservacao = previsaoBeneficioObservacao;
            AguardandoTransferenciaTipo = aguardandoTransferenciaTipo;
        }

        // Construtor vazio para o EF
        public ListaAmarela() { }

        public DateTime RevisaoIpenData { get; set; }
        public DateTime DataPrisao { get; set; }
        public string Artigos { get; set; }
        public string Comarca { get; set; }
        public string PenaAno { get; set; }
        public string PenaMes { get; set; }
        public string PenaDia { get; set; }
        public InstrumentoPrisaoTipoEnum[] InstrumentosPrisao { get; set; }
        public CondenacaoTipoEnum CondenacaoTipo { get; set; }
        public Int64? DiasMedidaDisciplinar { get; set; }
        public string AcaoPenal { get; set; }
        public DateTime DataPrevisaoBeneficio { get; set; }
        public DateTime DataProgressao { get; set; }
        public string PrevisaoBeneficioObservacao { get; set; }
        public DateTime DataSaidaPrevista { get; set; }
        public bool AguardandoTransferencia { get; set; }
        public DetentoAguardandoTransferenciaTipoEnum AguardandoTransferenciaTipo { get; set; }
        
        //Criar totalizador de detentos por dia
        //Criar totalizador de detentos por regime
        //Criar record de detentos

        //Relacionamentos
        public Guid DetentoId { get; set; }

        [ForeignKey("DetentoId")]
        public virtual Detento Detento { get; set; }
    }
}