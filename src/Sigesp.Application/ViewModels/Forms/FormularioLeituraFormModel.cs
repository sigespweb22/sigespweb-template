using System;
using System.Collections.Generic;
using Sigesp.Domain.Models;

namespace Sigesp.Application.ViewModels.Forms
{
    public class FormularioLeituraFormModel
    {
        public ICollection<AlunoLeituraForFormModel> DadosLeituras { get; set;}
        public FormularioLeituraDicaEscrita FormularioLeituraDicaEscrita { get; set; }
        public FormularioLeituraPerguntaGrupo FormularioLeituraPerguntaGrupo { get; set; }
        public Tenant DadosUnidadePrisional { get; set; }
    }

    public class AlunoLeituraForFormModel
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
    }
}