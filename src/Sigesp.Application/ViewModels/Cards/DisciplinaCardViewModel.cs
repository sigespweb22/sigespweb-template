using System.Collections;
using System;
using System.Collections.Generic;
using Sigesp.Domain.Models;
using Sigesp.Domain.Enums;

namespace Sigesp.Application.ViewModels.Cards
{
    public class DisciplinaCardViewModel
    {
        public Int64 Total { get; set; }
        public Int64 Ativas { get; set; }
        public Int64 Inativas { get; set; }

        public List<string> Fases { get; set; }
        public List<string> Cursos { get; set; }
        public List<string> Professores { get; set; }
    }
}