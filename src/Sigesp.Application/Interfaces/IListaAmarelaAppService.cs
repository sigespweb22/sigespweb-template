using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Sigesp.Application.ViewModels;
using Sigesp.Application.ViewModels.Reports;
using Sigesp.Domain.Models;
using Sigesp.Domain.Models.DataTable;

namespace Sigesp.Application.Interfaces
{
    public interface IListaAmarelaAppService : IDisposable
    {
        Task<DataTableServerSideResult<ListaAmarelaViewModel>> GetWithDataTableResultAsync(DataTableServerSideRequest request);
        ListaAmarelaViewModel GetByDetentoNome(string nome);
        ListaAmarelaViewModel GetByDetentoIpen(string ipen);
        Task<IEnumerable<ListaAmarelaViewModel>> GetAllAsync();
        IEnumerable<ListaAmarelaViewModel> GetAll();
        IEnumerable<ListaAmarelaViewModel> GetAllWithIgnoreFilter();
        IEnumerable<ListaAmarelaViewModel> GetAllWithInclude();
        ValidationResult Add(ListaAmarelaViewModel listaAmarelaViewModel);
        ValidationResult Remove(Guid id);
        ValidationResult Update(ListaAmarelaViewModel listaAmarelaViewModel);
        Task<ValidationResult> EnableDisableById(string id);
        IEnumerable<ListaAmarelaViewModel> GetAllByFilterReportPrevisaoBeneficio(ListaAmarelaFilterReportPrevisaoBeneficioViewModel  listaAmarelaFilterReportPrevisaoBeneficioViewModel);
        IEnumerable<ListaAmarelaViewModel> GetAllByFilterReportDataIngresso(ListaAmarelaFilterReportDataIngressoViewModel  listaAmarelaFilterReportDataIngressoViewModel);
        IEnumerable<ListaAmarelaViewModel> GetAllAguardandoTransferencia();
        TotalizadorCondenacaoTipoViewModel TotalizadorByCondenacaoTipo();
        ListaAmarelaViewModel ResgatarInativoByIpen(int ipen);
    }
}