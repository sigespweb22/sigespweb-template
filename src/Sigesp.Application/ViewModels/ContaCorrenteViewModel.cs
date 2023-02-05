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
    public class ContaCorrenteViewModel
    {
        public Guid? Id { get; set; }
        public int? Numero { get; set; }
        public DateTime? DataUltimoStatus { get; set; }
        public string Status { get; set; }
        public decimal? Saldo { get; set; }
        public string Descricao { get; set; }
        public string Tipo { get; set; }
        

        //Relatiocnamentos
        public Guid? ColaboradorId { get; set; }
        public Guid? EmpresaId { get; set; }
        
        [DisplayName("Colaborador nome")]
        public string ColaboradorNome { get; set; }
        public string DetentoIpen { get; set; }
        public string DetentoGaleria { get; set; }
        public string DetentoCela { get; set; }
        public string EmpresaRazaoSocial { get; set; }
        public string LancamentoId { get; set; }
        public bool IsTipoCofre { get; set; }
        
        public List<Lancamento> Lancamentos { get; set; }
        public ColaboradorViewModel Colaborador { get; set; }
        public EmpresaViewModel EmpresaViewModel { get; set; }
    }
}