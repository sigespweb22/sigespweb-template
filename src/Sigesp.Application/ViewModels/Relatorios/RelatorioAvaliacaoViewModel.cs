using System;
using System.Collections.Generic;
using Sigesp.Domain.Models;

namespace Sigesp.Application.ViewModels.Relatorios
{
    public class RelatorioAvaliacaoViewModel
    {
        public ICollection<AlunoLeituraForRelatorioAvaliacao> DadosLeituras { get; set;}
        public Tenant DadosUnidadePrisional { get; set; }
    }

    public class AlunoLeituraForRelatorioAvaliacao
    {
        public string ChaveLeitura { get; set; }
        public int Ipen { get; set; }
        public string Nome { get; set; }
        public string Escolaridade { get; set; }
        public string Galeria { get; set; }
        public int Cela { get; set; }
        public string LivroTitulo { get; set; }
        public string LivroAutorNome { get; set; }
        public string AlunoLeituraCronogramaNome { get; set; }
        public string AlunoLeituraCronogramaAnoReferencia { get; set; }

        /// Dados da avaliação
        public string AvaliacaoCriterio1 { get; set; }
        public string AvaliacaoCriterio2 { get; set; }
        public string AvaliacaoCriterio3 { get; set; }
        public string AvaliacaoCriterio4 { get; set; }
        public string AvaliacaoCriterio5 { get; set; }
        public string AvaliacaoCriterio6 { get; set; }
        public string AvaliacaoCriterio7 { get; set; }
        public string AvaliacaoConceito { get; set; }
        public string AvaliacaoConceitoJustificativa { get; set; }
        public string AvaliacaoObservacao { get; set; }

        public string DataAvaliacao { get; set; }
    }
}