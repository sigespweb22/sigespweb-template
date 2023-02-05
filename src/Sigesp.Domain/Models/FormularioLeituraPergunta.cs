using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sigesp.Domain.Models
{
    public class FormularioLeituraPergunta : EntityAudit
    {
        public FormularioLeituraPergunta(string pergunta, 
                                         int ordem)
        {
            Pergunta = pergunta;
            Ordem = ordem;
        }

        public FormularioLeituraPergunta() {}

        public string Pergunta { get; set; }
        public int Ordem { get; set; }

        //Formulario Leitura Pergunta Grupo
        [ForeignKey("FormularioLeituraPerguntaGrupoId")]
        public Guid FormularioLeituraPerguntaGrupoId { get; set; }
        public FormularioLeituraPerguntaGrupo FormularioLeituraPerguntaGrupo { get; set; }
    }
}