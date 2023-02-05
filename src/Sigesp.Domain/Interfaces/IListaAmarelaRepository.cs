using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Sigesp.Domain.Enums;
using Sigesp.Domain.Models;
using Sigesp.Domain.Models.DataTable;

namespace Sigesp.Domain.Interfaces
{
    public interface IListaAmarelaRepository : IRepository<ListaAmarela>
    {
        Task<DataTableServerSideResult<ListaAmarela>> GetWithDataTableResultAsync(DataTableServerSideRequest request);
        ListaAmarela GetByDetentoNome(string nome);
        ListaAmarela GetByDetentoIpen(int ipen);
        Task<IEnumerable<ListaAmarela>> GetAllOnlyIsDeletedTrue();      
        ListaAmarela GetByIdWithIgnoreFilter(Guid id);
        IEnumerable<ListaAmarela> GetAllWithIgnoreFilter();
        IEnumerable<ListaAmarela> GetAllWithInclude();
        Guid GetIdByDetentoIpen(int ipen);
        ListaAmarela GetByIdWithInclude(Guid id);
        IEnumerable<ListaAmarela> GetAllByRegimeDataPrevisaoBeneficio(DetentoRegimeEnum regime, 
                                                                        DateTime dataInicio, 
                                                                        DateTime dataFim);
        IEnumerable<ListaAmarela> GetAllByRegimeDataIngresso(DetentoRegimeEnum regime, 
                                                             DateTime dataInicio, 
                                                             DateTime dataFim);
        IEnumerable<ListaAmarela> GetAllByRegime(DetentoRegimeEnum regime);
        IEnumerable<ListaAmarela> GetAllByRegimeToDataIngresso(DetentoRegimeEnum regime);
        IEnumerable<ListaAmarela> GetAllByDataPrevisaoBeneficio(DateTime dataInicio, DateTime dataFim);
        IEnumerable<ListaAmarela> GetAllByDataIngresso(DateTime dataInicio, DateTime dataFim);
        IEnumerable<ListaAmarela> GetAllByRegimeAll();
        IEnumerable<ListaAmarela> GetAllByRegimeAllToDataIngresso();
        IEnumerable<ListaAmarela> GetAllByRegimeAlimentosPrisaoTemporariaDataSaidaPrevista(DetentoRegimeEnum regime, 
                                                                                                    DateTime dataInicio,
                                                                                                    DateTime dataFim);
        IEnumerable<ListaAmarela> GetAllByRegimeAlimentosPrisaoTemporaria(DetentoRegimeEnum regime);
        IEnumerable<ListaAmarela> GetAllAguardandoTransferencia();
        
        IEnumerable<ListaAmarela> TotalizadorByCondenacaoTipo();
        ListaAmarela GetInativoForUpdateByDetentoIpen(int ipen);
        ListaAmarela GetInativoByDetentoIpen(int ipen);
        ListaAmarela GetInativoByIdWithInclude(Guid id);
        ListaAmarela GetAtivoInativoByIdWithInclude(Guid id);
        ListaAmarela ResgatarInativoByIpen(int ipen);
        bool AlreadyAtivoByDetentoIpen(int ipen);
        IEnumerable<ListaAmarela> GetAllByInstrumentoPrisao(InstrumentoPrisaoTipoEnum instrumentoPrisao);
    }
}