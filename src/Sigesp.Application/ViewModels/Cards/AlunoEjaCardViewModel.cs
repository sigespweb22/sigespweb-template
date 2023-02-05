using System.Collections;
using System;
using System.Collections.Generic;
using Sigesp.Domain.Models;
using Sigesp.Domain.Enums;

namespace Sigesp.Application.ViewModels.Cards
{
    public class AlunoEjaCardViewModel
    {
        public Int64 Cursando { get; set; }
        public Int64 Concluido { get; set; }
        public Int64 ConcluidoParcialmente { get; set; }
        public Int64 NaoConcluido { get; set; }
        public Int64 EFundamentalI { get; set; }
        public Int64 EFundamentalII { get; set; }
        public Int64 EMedio { get; set; }
        public Int64 Matutinos { get; set; }
        public Int64 Vespertinos { get; set; }
        public Int64 Noturnos { get; set; }
        public Int64 Inativos { get; set; }
        public List<string> Alunos { get; set; }
        public List<string> Cursos { get; set; }
        public List<string> Turnos { get; set; }
        public List<string> Fases { get; set; }
        public List<string> Disciplinas { get; set; }
        public List<string> FaseStatuses { get; set; }
        public List<string> OcorrenciasDesistencia { get; set; }
    }
}