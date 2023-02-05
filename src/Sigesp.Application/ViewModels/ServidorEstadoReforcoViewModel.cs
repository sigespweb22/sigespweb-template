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
    public class ServidorEstadoReforcoViewModel
    {
        public Guid? Id { get; set; }

        [DisplayName("Data principal plantão")]
        public string DataPrincipalPlantao { get; set; }

        [Required(ErrorMessage = "Data prevista inicío requerida.")]
        [DisplayName("Data prevista início")]
        public string DataPrevistaInicio { get; set; }

        [DisplayName("Data prevista fim")]
        public string DataPrevistaFim { get; set; }
        
        [DisplayName("Dia da semana")]
        public string DiaSemana { get; set; }

        [DisplayName("Horário início")]
        public string HorarioInicio { get; set; }

        [DisplayName("Horário fim")]
        public string HorarioFim { get; set; }

        [DisplayName("Mês extenso")]
        public string MesExtenso { get; set; }

        [DisplayName("Mês numeral")]
        public string MesNumeral { get; set; }

        [DisplayName("Reforço situação")]
        public string ReforcoSituacao { get; set; }

        [DisplayName("Servido estado Id")]
        public string ServidorEstadoId { get; set; }

        [DisplayName("Servidor estado Nome")]
        public string ServidorEstadoNome { get; set; }

        [DisplayName("É expediente?")]
        public bool IsExpediente { get; set; }

        // Campos para component de tela que irá mostrar os reforços como eventos de um calendário
        public string Title { get; set; }
        // Formato de retorno - 'YYYY-MM+03T00:00:00'
        public string Start { get; set; }
        // Formato de retorno - 'YYYY-MM+03T23:59:00'
        public string End { get; set; }
        // Formatos aceitos: bg-danger border-danger text-white
        public string ClassName { get; set; }

        [DisplayName("Usuário Id")]
        public string UserId { get; set; }

        public ServidorEstado ServidorEstado { get;  set; }
    }
}