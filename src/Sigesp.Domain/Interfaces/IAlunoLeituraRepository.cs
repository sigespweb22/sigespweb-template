using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Sigesp.Domain.Models;
using Sigesp.Domain.Enums;
using Sigesp.Domain.Models.DataTable;

namespace Sigesp.Domain.Interfaces
{
    public interface IAlunoLeituraRepository : IRepository<AlunoLeitura>
    {
        Task<Guid> GetCronogramaIdAsync(Guid alunoLeituraId);
        Task<DataTableServerSideResult<AlunoLeitura>> GetWithDataTableResultAsync(DataTableServerSideRequest request);
        Task<IEnumerable<AlunoLeitura>> GetAllAsync(Guid tenantId);
        Task<IEnumerable<AlunoLeitura>> GetAllForRelAvaliacaoAsync(Guid tenantId,
                                                                   Guid cronogramaId,
                                                                   string galeria,
                                                                   DateTime periodoInicio,
                                                                   DateTime periodoFim);
        Task<IEnumerable<AlunoLeitura>> GetAllForRelAvaliacaoAsync(List<string> leiturasIds);
        Task<IEnumerable<AlunoLeitura>> GetAllForFormsLeituraAsync(List<string> leiturasIds);
        Task<IEnumerable<AlunoLeitura>> GetAllForFormsLeituraAsync(Guid tenantId, 
                                                                   Guid cronogramaId,
                                                                   string galeria,
                                                                   List<int> celas);
        Task<IEnumerable<AlunoLeitura>> GetAllForFormsLeituraAsync(Guid tenantId, 
                                                                   Guid cronogramaId,
                                                                   string galeria);
        AlunoLeitura GetByIdIncludes(Guid id);
        IEnumerable<AlunoLeitura> GetAllWithIncludes();
        Int64 GetTotalAtivos();
        Int64 GetTotalInativos();
        Int64 GetTotalWithIgnoreQueryFilter();
        bool AlreadyAlunoLeitorAtivoByIpen(int ipen);
        AlunoLeitura GetByDetentoIpen(int ipen);
        AlunoLeitura GetInativoByDetentoIpen(int ipen);
        AlunoLeitura GetAtivoOrInativoByDetentoIpen(int ipen);
        IEnumerable<AlunoLeitura> GetAllByIpen(int ipen);
        bool AlreadySameAnoAndPeriodoReferencia(int ipen,
                                                int anoReferencia,
                                                int periodoReferencia,
                                                LeituraTipoEnum lt);
        bool AlreadySameAnoAndPeriodoReferenciaById(Guid id,
                                                    int ipen,
                                                    int anoReferencia,
                                                    int periodoReferencia,
                                                    LeituraTipoEnum lt);
        bool AlreadySameTitulo(int ipen,
                                Guid livroId,
                                string livroTitulo,
                                LeituraTipoEnum lt);
        bool AlreadySameTituloById(Guid id,
                                   int ipen,
                                   Guid livroId,
                                   LeituraTipoEnum lt);
        bool AlreadySameTituloById(int ipen,
                                          Guid livroId,
                                          LeituraTipoEnum lt);
        bool AlreadySameCronograma(Guid alunoLeituraCronogramaId, int ipen);
        IEnumerable<Livro> GetAllTitulosLidos(int ipen, LeituraTipoEnum
                                                         lr);
        Livro GetLivroLeitura(Guid idLeitura);
        Task<AlunoLeitura> GetByChaveLeituraAsync(Guid tenantId, Int64 chaveLeitura);
        Livro GetLivroForEdicao(Guid id);
        AlunoLeitura GetByIdWithoutIncludes(Guid id);
        Task<Int64> GetTotalByAvaliacaoConceitoAsync(Guid tenantId, 
                                                     AlunoLeituraAvaliacaoConceitoEnum avlC);
        Task<Int64> GetTotalByLeituraTipoAsync(Guid tenantId, 
                                               LeituraTipoEnum lt);
        Task<IEnumerable<AlunoLeitura>> GetForOficioLeituraAsync(List<string> leiturasId);                                                                                                            
        void UpdateRange(IEnumerable<AlunoLeitura> leituras);
    }
}