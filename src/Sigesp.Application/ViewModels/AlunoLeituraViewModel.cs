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
    public class AlunoLeituraViewModel
    {
        public Guid? Id { get; set; }

        public string AnoReferencia { get; set; }
        public string PeriodoReferencia { get; set; }

        public string DataInicio { get; set; }
        public string DataFim { get; set; }
        public string LeituraTipo { get; set; }


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
        public string ChaveLeitura { get; set; }

        public string DataAvaliacao { get; set; }
        public bool IsAvaliado { get; set; }

        public bool HasOficio { get; set; }
        public int? OficioNumero { get; set; }
        public string OficioDataCriacao { get; set; }


        //Relacionamentos
        public Guid? AlunoLeituraCronogramaId { get; set; }
        public string AlunoLeituraCronogramaNome { get; set; }
        public AlunoLeituraCronograma AlunoLeituraCronograma { get; set; }
        


        public Guid? LivroId { get; set; }
        public string LivroTitulo { get; set; }
        public string LivroLocalizacao { get; set; }
        public Livro Livro { get; set; }


        public Guid? AlunoLeitorId { get; set; }
        public string AlunoLeitorIpen { get; set; }
        public string AlunoLeitorNome { get; set; }
        public string AlunoLeitorGaleria { get; set; }
        public string AlunoLeitorCela { get; set; }
        public AlunoLeitor AlunoLeitor { get; set; }
    }
}