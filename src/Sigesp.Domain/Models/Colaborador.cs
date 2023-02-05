using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Sigesp.Domain.Enums;

namespace Sigesp.Domain.Models
{
    public class Colaborador : EntityAudit
    {
        public Colaborador(ColaboradorSituacaoEnum situacao, 
                            DateTime dataUltimaSituacao, string localTrabalho,
                            bool isTrabalhoInterno, bool isRemunerado, decimal remuneracao,
                            string familiarAutorizadoRetirada, decimal desconto, decimal descontoOutro,
                            int diaPagamento, TipoPagamentoEnum tipoPagamento,
                            string jornadaInicio, string jornadaFim, int bancoNumero,
                            string bancoAgencia, string bancoConta, TipoContaEnum tipoConta,
                            string observacao, DateTime dataInicio, string folga, DateTime demissaoData)
        {
            Situacao = situacao;
            DataUltimaSituacao = dataUltimaSituacao;
            LocalTrabalho = localTrabalho;
            IsTrabalhoInterno = isTrabalhoInterno;
            IsRemunerado = isRemunerado;
            Remuneracao = remuneracao;
            FamiliarAutorizadoRetirada = familiarAutorizadoRetirada;
            Desconto = desconto;
            DescontoOutro = descontoOutro;
            DiaPagamento = diaPagamento;
            TipoPagamento = tipoPagamento;
            JornadaInicio = jornadaInicio;
            JornadaFim = jornadaFim;
            BancoNumero = bancoNumero;
            BancoAgencia = bancoAgencia;
            BancoConta = bancoConta;
            TipoConta = tipoConta;
            Observacao = observacao;
            DataInicio = dataInicio;
            Folga = folga;
            DemissaoData = demissaoData;
        }

        // Construtor vazio para o EF
        public Colaborador() { }

        public ColaboradorSituacaoEnum Situacao { get; set; }
        public DateTime DataUltimaSituacao {get; set; }
        public string LocalTrabalho {get; set; }
        public bool IsTrabalhoInterno { get; set; }
        public bool IsRemunerado {get; set; }
        public decimal Remuneracao {get; set; }
        public string FamiliarAutorizadoRetirada { get; set; }
        public decimal Desconto { get; set; }
        public decimal DescontoOutro { get; set; }
        public int? DiaPagamento { get; set; }
        public TipoPagamentoEnum TipoPagamento { get; set; }
        public string JornadaInicio { get; set; }
        public string JornadaFim { get; set; }
        public int? BancoNumero { get; set; }
        public string BancoAgencia { get; set; }
        public string BancoConta { get; set; }
        public TipoContaEnum TipoConta { get; set; }
        public string Observacao { get; set; }
        public DateTime DataInicio { get; set; }
        public string Folga { get; set; }

        //Últimos campos implementados em 12/01/2022
        public ColaboradorDemissaoOcorrenciaEnum DemissaoOcorrencia { get; set; }
        public string DemissaoObservacao { get; set; }
        public DateTime DemissaoData { get; set; }

        //Último campos adicionados em 27/01/2022
        public ColaboradorFuncaoEnum Funcao { get; set; }



        //Relacionamentos
        [ForeignKey("EmpresaConvenioId")]
        public Guid EmpresaConvenioId { get; set; }
        public EmpresaConvenio EmpresaConvenio { get;  set; }
        
        [ForeignKey("DetentoId")]
        public Guid DetentoId { get; set; }
        public Detento Detento { get;  set; }

        public ContaCorrente ContaCorrente { get;  set; }

        public ICollection<ColaboradorPonto> Pontos { get; set; }
    }
}