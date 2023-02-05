using System.Collections;
using System;
using System.Collections.Generic;
using Sigesp.Domain.Models;
using Sigesp.Domain.Enums;

namespace Sigesp.Application.ViewModels.Cards
{
    public class AlunoLeitorCardViewModel
    {
        public Int64 Total { get; set; }
        public Int64 Ativos { get; set; }
        public Int64 Inativos { get; set; }
        public Int64 LeituraTipoSocial { get; set; }
        public Int64 LeituraTipoRemissao { get; set; }
        
        public List<string> Alunos { get; set; }
        public List<string> Professores { get; set; }
        public List<string> LivroGeneros { get; set; }
        public List<string> OcorrenciasDesistencia { get; set; }
    }
}