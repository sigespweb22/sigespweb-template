using System;
using System.Collections.Generic;

namespace Sigesp.Domain.Models
{
    public class Empresa : EntityAudit
    {
        public Empresa(string razaoSocial, string nomeFantasia, string cnpj, int cep, string cidade, 
                        string estado, string logradouro, string numero, string bairro, string responsavel,
                        string email, string telefoneFixo, string telefoneCelular, string whatsApp)
        {
            RazaoSocial = razaoSocial;
            NomeFantasia = nomeFantasia;
            Cnpj = cnpj;
            Cep = cep;
            Cidade = cidade;
            Estado = estado;
            Logradouro = logradouro;
            Numero = numero;
            Bairro = bairro;
            Responsavel = responsavel;
            Email = email;
            TelefoneFixo = telefoneFixo;
            TelefoneCelular = telefoneCelular;
            WhatsApp = whatsApp;
        }

        // Construtor vazio para o EF
        public Empresa() { }

        public string RazaoSocial { get; set; }
        public string NomeFantasia { get; set; }
        public string Cnpj { get; set; }
        public int Cep { get; set; }   
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Bairro { get; set; }
        public string Responsavel { get; set; }
        public string Email { get; set; }
        public string TelefoneFixo { get; set; }
        public string TelefoneCelular { get; set; }
        public string WhatsApp { get; set; }

        //Relacionamentos
        public ICollection<EmpresaConvenio> EmpresaConvenios { get; set; }
        public ICollection<ContaCorrente> ContasCorrentes { get; set; }
    }
}