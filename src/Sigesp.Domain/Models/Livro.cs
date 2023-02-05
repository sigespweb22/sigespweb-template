using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Numerics;
using Sigesp.Domain.Enums;

namespace Sigesp.Domain.Models
{
    public class Livro : EntityAudit
    {
        public Livro (string titulo, Int64 localizacao, 
                        string propriedade)
        {
            Titulo = titulo;
            Localizacao = localizacao;
            Propriedade = propriedade;
        }

        //Construtor vazio para o EF
        public Livro() {}

        public string Titulo { get; set; }
        public Int64 Localizacao { get; set; }
        public string Propriedade { get; set; }
        public bool IsDisponivel { get; set; }

        //Relacionamentos

        //Tenancy        
        [ForeignKey("TenantId")]
        public Guid TenantId { get; set; }
        public Tenant Tenant { get; set; }

        //Autor
        [ForeignKey("LivroAutorId")]
        public Guid LivroAutorId { get; set; }
        public LivroAutor LivroAutor { get; set; }
        
        //Gênero
        [ForeignKey("LivroGeneroId")]
        public Guid LivroGeneroId { get; set; }
        public LivroGenero LivroGenero { get; set; }

        public ICollection<AlunoLeitura> AlunoLeituras { get; set; }
    }
}