using System;
using System.Collections.Generic;

namespace Sigesp.Domain.Models
{
    public class Tenant : EntityAudit
    {
        public Tenant(string nome, 
                      Guid apiKey, string nomeExibicao,
                      string oficioLeituraAssinaturaNome,
                      string oficioLeituraAssinaturaCargo,
                      string oficioLeituraAssinaturaMatricula,
                      string oficioLeituraVocativo1,
                      string oficioLeituraVocativo2,
                      string oficioLeituraVocativo3,
                      string enderecoLogradouro,
                      string enderecoLogradouroNumero,
                      string enderecoBairro,
                      string enderecoCEP,
                      string enderecoCidade,
                      string enderecoEstado,
                      string telefoneDDD,
                      string telefoneNumero,
                      string emailPrincipal)
        {
            ApiKey = apiKey;
            Nome = nome;
            NomeExibicao = nomeExibicao;
            OficioLeituraAssinaturaNome = oficioLeituraAssinaturaNome;
            OficioLeituraAssinaturaCargo = oficioLeituraAssinaturaCargo;
            OficioLeituraAssinaturaMatricula = oficioLeituraAssinaturaMatricula;
            OficioLeituraVocativo1 = oficioLeituraVocativo1;
            OficioLeituraVocativo2 = oficioLeituraVocativo2;
            OficioLeituraVocativo3 = oficioLeituraVocativo3;
            EnderecoLogradouro = enderecoLogradouro;
            EnderecoLogradouroNumero = enderecoLogradouroNumero;
            EnderecoBairro = enderecoBairro;
            EnderecoCEP = enderecoCEP;
            EnderecoCidade = enderecoCidade;
            EnderecoEstado = enderecoEstado;
            TelefoneDDD = telefoneDDD;
            TelefoneNumero = telefoneNumero;
            EmailPrincipal = emailPrincipal;
        }

        //Construtor vazio para o EF
        public Tenant() { }

        public Guid ApiKey { get; set; }
        public string Nome { get; set; }
        public string NomeExibicao { get; set; }
        public string OficioLeituraAssinaturaNome { get; set; }
        public string OficioLeituraAssinaturaCargo { get; set; }
        public string OficioLeituraAssinaturaMatricula { get; set; }
        public string OficioLeituraVocativo1 { get; set; }
        public string OficioLeituraVocativo2 { get; set; }
        public string OficioLeituraVocativo3 { get; set; }
        public string EnderecoLogradouro { get; set; }
        public string EnderecoLogradouroNumero { get; set; }
        public string EnderecoBairro { get; set; }
        public string EnderecoCEP { get; set; }
        public string EnderecoCidade { get; set; }
        public string EnderecoEstado { get; set; }
        public string TelefoneDDD { get; set; }
        public string TelefoneNumero { get; set; }
        public string EmailPrincipal { get; set; }

        public ICollection<Detento> Detentos { get; set; }
        public ICollection<Livro> Livros { get; set; }
        public ICollection<Aluno> Alunos { get; set; }
        public ICollection<AlunoEja> AlunosEja { get; set; }
        public ICollection<AlunoLeitor> AlunosLeitores { get; set; }
        public ICollection<AlunoLeitura> AlunosLeituras { get; set; }
        public ICollection<AlunoLeituraCronograma> AlunosLeiturasCronogramas { get; set; }
        public ICollection<Professor> Professores { get; set; }
        public ICollection<ApplicationUser> ApplicationUsers { get; set; }
        public ICollection<Edi> Edis { get; set; }
        public ICollection<EdiLog> EdisLogs { get; set; }
        public ICollection<ServidorEstado> ServidoresEstado { get; set; }
        public ICollection<ServidorEstadoReforcoRegra> ServidoEstadoReforcoRegras { get; set; }
        public ICollection<ApplicationNotification> ApplicationNotifications { get; set; }
        public ICollection<FormularioLeituraDicaEscrita> FormularioLeituraDicasEscrita { get; set; }
        public ICollection<FormularioLeituraPerguntaGrupo> FormularioLeituraPerguntaGrupos { get; set; }
    }
}