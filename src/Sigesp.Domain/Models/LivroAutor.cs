using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Sigesp.Domain.Enums;

namespace Sigesp.Domain.Models
{
    public class LivroAutor : EntityAudit
    {
        public LivroAutor (string nome)
        {
            Nome = nome;
        }

        //Construtor vazio para o EF
        public LivroAutor() {}

        public string Nome { get; set; }


        //Relacionamentos
        public ICollection<Livro> Livros { get; set; }
    }
}