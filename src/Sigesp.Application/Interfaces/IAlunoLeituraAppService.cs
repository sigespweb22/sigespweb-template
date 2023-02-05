using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Sigesp.Application.ViewModels;
using Sigesp.Application.ViewModels.Forms;
using Sigesp.Application.ViewModels.Oficios.Educacao;
using Sigesp.Application.ViewModels.Relatorios;
using Sigesp.Application.ViewModels.Requests;
using Sigesp.Application.ViewModels.Responses;
using Sigesp.Domain.Enums;
using Sigesp.Domain.Models.DataTable;

namespace Sigesp.Application.Interfaces
{
    public interface IAlunoLeituraAppService : IDisposable
    {
        Task<OficioEducacaoLeituraViewModel> GetOficioLeituraAsync(List<string> leiturasIds);
        Task<Guid> GetCronogramaIdAsync(Guid alunoLeituraId);
        Task<DataTableServerSideResult<AlunoLeituraViewModel>> GetWithDataTableResultAsync(DataTableServerSideRequest request);
        Task<FormularioLeituraFormModel> GetAllForFormsLeituraAsync(AlunoLeituraFormsLeiturasRequestModel alunoLeituraFormsLeiturasRequestModel);
        Task<RelatorioAvaliacaoViewModel> GetAllForRelAvaliacaoAsync(AlunoLeituraRelAvaliacaoRequestModel alunoLeituraRelAvaliacaoRequestModel);
        Task<ValidationResult> AddAsync(AlunoLeituraViewModel alunoLeituraViewModel);
        Task<AlunoLeituraNovosResponseViewModel> AddsAsync(AlunoLeituraNovosRequestViewModel 
                                                           alunoLeituraNovosRequestViewModel);
        Task<ValidationResult> UpdateAsync(AlunoLeituraViewModel alunoLeituraViewModel);
        ValidationResult Avaliar(AlunoLeituraViewModel alunoLeituraViewModel);
        ValidationResult Remove(Guid id);
        IEnumerable<AlunoLeituraViewModel> GetAllWithInclude();
        Task<IEnumerable<AlunoLeituraViewModel>> GetAllAsync();
        Task<AlunoLeituraViewModel> GetByIdAsync(string id);
        AlunoLeituraViewModel GetByIdIncludes(string id);
        Int64 GetTotalAtivos();
        Int64 GetTotalInativos();
        Int64 GetTotalWithIgnoreQueryFilter();
        Task<AlunoLeituraViewModel> GetByChaveLeituraAsync(string chaveLeitura);
        ValidationResult GetLivroForEdicao(string alunoLeituraId);
        Task<Int64> GetTotalByAvaliacaoConceitoAsync(AlunoLeituraAvaliacaoConceitoEnum avlC);
        Task<Int64> GetTotalByLeituraTipoAsync(LeituraTipoEnum lt);
    }
}