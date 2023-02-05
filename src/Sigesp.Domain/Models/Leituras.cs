using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Numerics;
using Sigesp.Domain.Enums;

namespace Sigesp.Domain.Models
{
    public class Leitura : EntityAudit
    {
        public Leitura (string titulo)
        {
            Titulo = titulo;
        }

        //Construtor vazio para o EF
        public Leitura() {}

        new public string Id { get; set; }

        public string Titulo { get; set; }

        public Aluno Aluno { get; set; }
    }
}