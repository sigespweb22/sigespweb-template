using System.Dynamic;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Sigesp.Domain.Enums;
using Sigesp.Domain.Models;
using Sigesp.Application.ViewModels;
using System.Collections.Generic;

namespace Sigesp.Application.ViewModels.Requests
{
    public class AlunoLeituraFormsLeiturasRequestModel
    {
        [DisplayName("Cronograma Id")]
        public string CronogramaId { get; set; }

        [DisplayName("Galeria")]
        public string Galeria { get; set; }

        [DisplayName("Celas")]
        public List<string> Celas { get; set; }

        [DisplayName("Leituras Ids")]
        public List<string> LeiturasIds { get; set;}

        [Required(ErrorMessage = "Dica de escrita requerida.")]
        [DisplayName("Dica de escrita Id")]
        public string DicaEscritaId { get; set;}

        [Required(ErrorMessage = "Grupo pergunta requerido.")]
        [DisplayName("Pergunta grupo id")]
        public string PerguntaGrupoId { get; set;}
    }
}