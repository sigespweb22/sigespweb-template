using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Sigesp.Domain.Enums;

namespace Sigesp.Domain.Models
{
    public class Detento : EntityAudit
    {
        public Detento(int ipen, string nome, string galeria, int cela, 
                        string cpf, string rg, DateTime nascimento, string pec, 
                        bool isProvisorio, bool isSaidaTemporaria, DetentoRegimeEnum regime, 
                        string matriculaFamiliar, string nomeFamiliar, string transferenciaLocal,
                        TransferenciaTipoEnum transferenciaTipo,
                        DateTime transferenciaDataSaida, DateTime transferenciaDataRetornoPrevisto,
                        DateTime transferenciaDataRetornoRealizado, SexoEnum sexo,
                        string telefone)
        {
            Ipen = ipen;
            Nome = nome;
            Galeria = galeria;
            Cela = cela;
            Cpf = cpf;
            Rg = rg;    
            Nascimento = nascimento;
            Pec = pec;
            IsProvisorio = isProvisorio;
            IsSaidaTemporaria = isSaidaTemporaria;
            Regime = regime;
            MatriculaFamiliar = matriculaFamiliar;
            NomeFamiliar = nomeFamiliar;
            TransferenciaLocal = transferenciaLocal;
            TransferenciaTipo = transferenciaTipo;
            TransferenciaDataSaida = transferenciaDataSaida;
            TransferenciaDataRetornoPrevisto = transferenciaDataRetornoPrevisto;
            TransferenciaDataRetornoRealizado = transferenciaDataRetornoRealizado;
            Sexo = sexo;
            Telefone = telefone;
        }

        // Construtor vazio para o EF
        public Detento() { }

        public int Ipen { get; set; }
        public string Nome { get; set; }
        public string Galeria { get; set; }
        public int Cela { get; set; }
        public string Cpf { get; set; }
        public string Rg { get; set; }
        public DateTime Nascimento { get; set; }
        public string Pec { get; set; }
        public bool IsProvisorio { get; set; }
        public bool IsSaidaTemporaria { get; set; }
        public DetentoRegimeEnum Regime { get; set; }
        public string MatriculaFamiliar { get; set; }
        public string NomeFamiliar { get; set; }
        public string TransferenciaLocal { get; set; }
        public TransferenciaTipoEnum TransferenciaTipo { get; set; }
        public DateTime TransferenciaDataSaida { get; set; }
        public DateTime TransferenciaDataRetornoPrevisto { get; set; }
        public DateTime TransferenciaDataRetornoRealizado { get; set; }
        public SexoEnum Sexo { get; set; }

        //Colunas novas - Demanda surgiu a partir da criação da entidade AlunoRedaçãoDPU - São dados requeridos na inscrição da redaçãop
        public string Telefone { get; set; }
        public int Cep { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Logradouro { get; set; }
        public string Complemento { get; set; }
        public string Numero { get; set; }
        public string Bairro { get; set; }
        public string Idade { get; set; }


        //Relacionamentos

        //Tenant
        [ForeignKey("TenantId")]
        public Guid TenantId { get; set; }
        public Tenant Tenant { get; set; }

        public ICollection<DetentoSaidaTemporaria> SaidasTemporaria { get; set; }
        public ICollection<Colaborador> Colaboradores { get; set; }
        public ListaAmarela ListaAmarela { get; set; }
        public AndamentoPenal AndamentoPenal { get; set; }
        public Aluno Aluno { get; set; }
    }
}