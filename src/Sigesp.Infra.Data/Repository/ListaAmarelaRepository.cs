using System.Xml.Linq;
using System.ComponentModel.DataAnnotations;
using System.Net.Mime;
using System.Xml;
using System.Security.AccessControl;
using Microsoft.VisualBasic.CompilerServices;
using System.Linq.Expressions;
using System.Reflection.PortableExecutable;
using System.Data;
using System.Diagnostics;
using System.Data.Common;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Sigesp.Domain.Interfaces;
using Sigesp.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Sigesp.Domain.Enums;
using Sigesp.Domain.Models;
using Sigesp.Domain.Models.DataTable;
using Sigesp.Infra.Data.Extensions.DataTable;

namespace Sigesp.Infra.Data.Repository
{
    public class ListaAmarelaRepository : Repository<ListaAmarela>, IListaAmarelaRepository
    {
        public ListaAmarelaRepository(SigespDbContext context)
            : base(context)
        {
        }

        public ListaAmarela GetByDetentoNome(string nome)
        {
            var listaAmarela = DbSet
                                .AsNoTracking()
                                .IgnoreQueryFilters()
                                .Include(x => x.Detento)
                                .Where(d => d.Detento.IsDeleted == true || d.Detento.IsDeleted == false)
                                .Where(x => x.Detento.Nome == nome)
                                .Where(x => x.IsDeleted == false || x.IsDeleted == true)
                                .FirstOrDefault();

            return listaAmarela;
        }

        public ListaAmarela GetByDetentoIpen(int ipen)
        {
            var listaAmarela = DbSet
                                .AsNoTracking()
                                .IgnoreQueryFilters()
                                .Include(c => c.Detento)
                                .Where(x => x.IsDeleted == false
                                      || x.IsDeleted == true)
                                .FirstOrDefault(x => x.Detento.Ipen == ipen);

            return listaAmarela;
        }

        public ListaAmarela GetInativoByDetentoIpen(int ipen)
        {
            var listaAmarela = DbSet
                                .AsNoTracking()
                                .IgnoreQueryFilters()
                                .Include(x => x.Detento)
                                .Where(d => d.Detento.IsDeleted == false 
                                       || 
                                       d.Detento.IsDeleted == true)
                                .FirstOrDefault(x => x.IsDeleted == true
                                                &&
                                                x.Detento.Ipen == ipen);

            return listaAmarela;
        }

        public async Task<DataTableServerSideResult<ListaAmarela>> GetWithDataTableResultAsync(DataTableServerSideRequest request)
        {
            var listaaAmarelaForDataTable = await DbSet
                                                    .AsNoTracking()
                                                    .IgnoreQueryFilters()
                                                    .Include(x => x.Detento)
                                                    .Where(d => d.Detento.IsDeleted == true || d.Detento.IsDeleted == false)
                                                    .Where(x => x.IsDeleted == false)
                                                    .OrderBy(x => x.RevisaoIpenData)
                                                    .GetDatatableResultAsync(request);
            return listaaAmarelaForDataTable;
        }

        public async Task<IEnumerable<ListaAmarela>> GetAllOnlyIsDeletedTrue()
        {
            var listasAmarela = await DbSet
                                .IgnoreQueryFilters()
                                .Include(x => x.Detento)
                                .Where(d => d.Detento.IsDeleted == true || d.Detento.IsDeleted == false)
                                .Where(d => d.Detento.IsDeleted == true)
                                .ToListAsync();

            return listasAmarela;
        }

        public IEnumerable<ListaAmarela> GetAllWithIgnoreFilter()
        {
             var listasAmarela = DbSet
                                    .IgnoreQueryFilters()
                                    .Include(x => x.Detento)
                                    .Where(d => d.Detento.IsDeleted == true || d.Detento.IsDeleted == false)
                                    .Where(d => d.IsDeleted == false)
                                    .ToList();

            return listasAmarela;
        }

        public IEnumerable<ListaAmarela> GetAllWithInclude()
        {
             var listasAmarela = DbSet
                                    .IgnoreQueryFilters()
                                    .Include(x => x.Detento)
                                    .Where(d => d.Detento.IsDeleted == true || d.Detento.IsDeleted == false)
                                    .Where(d => d.IsDeleted == false)
                                    .ToList();

            return listasAmarela;
        }

        public ListaAmarela GetByIdWithIgnoreFilter(Guid id)
        {
            var listaAmarela = DbSet
                                .IgnoreQueryFilters()
                                .FirstOrDefault(x => x.Id == id);

            return listaAmarela;
        }

        public Guid GetIdByDetentoIpen(int ipen)
        {
            var id = DbSet
                        .IgnoreQueryFilters()
                        .Include(x => x.Detento)
                        .Where(x => x.Detento.IsDeleted == false
                               ||
                               x.Detento.IsDeleted == true)
                        .Where(x => x.IsDeleted == false
                               && x.Detento.Ipen.Equals(ipen))
                        .Select(x => x.Id)
                        .FirstOrDefault();

            return id;
        }

        public IEnumerable<ListaAmarela> GetAllByRegimeDataPrevisaoBeneficio(DetentoRegimeEnum regime,
                                                                             DateTime dataInicio, DateTime dataFim) 
        {
            var listasAmarela = DbSet
                                .Include(x => x.Detento)
                                .Include(x => x.Detento.Colaboradores)
                                .ThenInclude(x => x.EmpresaConvenio)
                                .Where(x => x.Detento.Regime == regime
                                            && x.DataPrevisaoBeneficio.Date >= dataInicio.Date
                                            && x.DataPrevisaoBeneficio.Date <= dataFim.Date)
                                .OrderByDescending(x => x.DataPrevisaoBeneficio);
            return listasAmarela;
        }

        public IEnumerable<ListaAmarela> GetAllByRegimeDataIngresso(DetentoRegimeEnum regime,
                                                                    DateTime dataInicio, DateTime dataFim) 
        {
            var listasAmarela = DbSet
                                .Include(x => x.Detento)
                                .Include(x => x.Detento.Colaboradores)
                                .ThenInclude(x => x.EmpresaConvenio)
                                .Where(x => x.Detento.Regime == regime
                                            && x.DataPrisao.Date >= dataInicio.Date
                                            && x.DataPrisao.Date <= dataFim.Date)
                                .OrderBy(x => x.DataPrisao);
            return listasAmarela;
        }

        public IEnumerable<ListaAmarela> GetAllByRegime(DetentoRegimeEnum regime) 
        {
            var listasAmarela = DbSet
                                .Include(x => x.Detento)
                                .ThenInclude(x => x.Colaboradores)
                                .ThenInclude(x => x.EmpresaConvenio)
                                .Where(x => x.Detento.Regime == regime)
                                .OrderByDescending(x => x.DataPrevisaoBeneficio);
            return listasAmarela;
        }

        public IEnumerable<ListaAmarela> GetAllByRegimeToDataIngresso(DetentoRegimeEnum regime) 
        {
            var listasAmarela = DbSet
                                .Include(x => x.Detento)
                                .ThenInclude(x => x.Colaboradores)
                                .ThenInclude(x => x.EmpresaConvenio)
                                .Where(x => x.Detento.Regime == regime)
                                .OrderBy(x => x.DataPrisao);
            return listasAmarela;
        }

        public IEnumerable<ListaAmarela> GetAllByDataPrevisaoBeneficio(DateTime dataInicio, DateTime dataFim) 
        {
            var listasAmarela = DbSet
                                .Include(x => x.Detento)
                                .ThenInclude(x => x.Colaboradores)
                                .ThenInclude(x => x.EmpresaConvenio)
                                .Where(x => x.DataPrevisaoBeneficio.Date >= dataInicio.Date
                                            && x.DataPrevisaoBeneficio.Date <= dataFim.Date)
                                .OrderByDescending(x => x.DataPrevisaoBeneficio);
            return listasAmarela;
        }

        public IEnumerable<ListaAmarela> GetAllByDataIngresso(DateTime dataInicio, DateTime dataFim) 
        {
            var listasAmarela = DbSet
                                .Include(x => x.Detento)
                                .ThenInclude(x => x.Colaboradores)
                                .ThenInclude(x => x.EmpresaConvenio)
                                .Where(x => x.DataPrisao.Date >= dataInicio.Date
                                            && x.DataPrisao.Date <= dataFim.Date)
                                .OrderBy(x => x.DataPrisao);
            return listasAmarela;
        }

        public IEnumerable<ListaAmarela> GetAllByRegimeAll() 
        {
            var listasAmarela = DbSet
                                .Include(x => x.Detento)
                                .ThenInclude(x => x.Colaboradores)
                                .ThenInclude(x => x.EmpresaConvenio)
                                .Where(x => x.Detento.Regime.Equals(DetentoRegimeEnum.ALIMENTOS)
                                            || x.Detento.Regime.Equals(DetentoRegimeEnum.PROVISORIO)
                                            || x.Detento.Regime.Equals(DetentoRegimeEnum.RECOLHIDO_EDI)
                                            || x.Detento.Regime.Equals(DetentoRegimeEnum.RECOLHIDO_FECHADO)
                                            || x.Detento.Regime.Equals(DetentoRegimeEnum.RECOLHIDO_IMPORTACAO)
                                            || x.Detento.Regime.Equals(DetentoRegimeEnum.RECOLHIDO_SEMIABERTO)
                                            || x.Detento.Regime.Equals(DetentoRegimeEnum.SAIDA_TEMPORARIA)
                                            || x.Detento.Regime.Equals(DetentoRegimeEnum.PRISAO_TEMPORARIA)
                                            || (x.Detento.Regime.Equals(DetentoRegimeEnum.TRANSFERIDO) && x.Detento.TransferenciaTipo.Equals(TransferenciaTipoEnum.MEDIDA_DISCIPLINAR))
                                            || (x.Detento.Regime.Equals(DetentoRegimeEnum.TRANSFERIDO) && x.Detento.TransferenciaTipo.Equals(TransferenciaTipoEnum.AUDIENCIA)))
                                .OrderByDescending(x => x.DataPrevisaoBeneficio);
            return listasAmarela;
        }

        public IEnumerable<ListaAmarela> GetAllByRegimeAllToDataIngresso() 
        {
            var listasAmarela = DbSet
                                .Include(x => x.Detento)
                                .ThenInclude(x => x.Colaboradores)
                                .ThenInclude(x => x.EmpresaConvenio)
                                .Where(x => x.Detento.Regime.Equals(DetentoRegimeEnum.ALIMENTOS)
                                            || x.Detento.Regime.Equals(DetentoRegimeEnum.PROVISORIO)
                                            || x.Detento.Regime.Equals(DetentoRegimeEnum.RECOLHIDO_EDI)
                                            || x.Detento.Regime.Equals(DetentoRegimeEnum.RECOLHIDO_FECHADO)
                                            || x.Detento.Regime.Equals(DetentoRegimeEnum.RECOLHIDO_IMPORTACAO)
                                            || x.Detento.Regime.Equals(DetentoRegimeEnum.RECOLHIDO_SEMIABERTO)
                                            || x.Detento.Regime.Equals(DetentoRegimeEnum.SAIDA_TEMPORARIA)
                                            || x.Detento.Regime.Equals(DetentoRegimeEnum.PRISAO_TEMPORARIA)
                                            || (x.Detento.Regime.Equals(DetentoRegimeEnum.TRANSFERIDO) && x.Detento.TransferenciaTipo.Equals(TransferenciaTipoEnum.MEDIDA_DISCIPLINAR))
                                            || (x.Detento.Regime.Equals(DetentoRegimeEnum.TRANSFERIDO) && x.Detento.TransferenciaTipo.Equals(TransferenciaTipoEnum.AUDIENCIA)))
                                .OrderBy(x => x.DataPrisao);
            return listasAmarela;
        }

        public IEnumerable<ListaAmarela> GetAllByRegimeAlimentosPrisaoTemporariaDataSaidaPrevista(DetentoRegimeEnum regime, 
                                                                                                    DateTime dataInicio,
                                                                                                    DateTime dataFim) 
        {
            var listasAmarela = DbSet
                                .Include(x => x.Detento)
                                .ThenInclude(x => x.Colaboradores)
                                .ThenInclude(x => x.EmpresaConvenio)
                                .Where(x => x.Detento.Regime == regime
                                            && x.DataSaidaPrevista.Date >= dataInicio.Date
                                            && x.DataSaidaPrevista.Date <= dataFim.Date)
                                .OrderBy(x => x.DataSaidaPrevista);
            return listasAmarela;
        }

        public IEnumerable<ListaAmarela> GetAllByRegimeAlimentosPrisaoTemporaria(DetentoRegimeEnum regime)
        {
            var listasAmarela = DbSet
                                .Include(x => x.Detento)
                                .ThenInclude(x => x.Colaboradores)
                                .ThenInclude(x => x.EmpresaConvenio)
                                .Where(x => x.Detento.Regime == regime)
                                .OrderBy(x => x.DataSaidaPrevista);
            return listasAmarela;
        }

        public ListaAmarela GetByIdWithInclude(Guid id)
        {
            var listaAmarela = DbSet
                                .IgnoreQueryFilters()
                                .Include(x => x.Detento)
                                .Where(x => x.Detento.IsDeleted == false
                                       || x.Detento.IsDeleted == true)
                                .Where(x => x.IsDeleted == false && x.Id == id)
                                .FirstOrDefault();
            
            return listaAmarela;
        }

        public ListaAmarela GetAtivoInativoByIdWithInclude(Guid id)
        {
            var listaAmarela = DbSet
                                .IgnoreQueryFilters()
                                .Include(x => x.Detento)
                                .Where(x => x.Detento.IsDeleted == false
                                       || x.Detento.IsDeleted == true)
                                .Where(x => x.IsDeleted == false 
                                       || x.IsDeleted == true)
                                .FirstOrDefault(x => x.Id == id);
            var a = DbSet
                        .AsNoTracking()
                        .IgnoreQueryFilters()
                        .Include(c => c.Detento)
                        .Where(x => x.IsDeleted == false
                                || x.IsDeleted == true)
                        .FirstOrDefault(x => x.Id == id);
            
            return listaAmarela;
        }
       
        public ListaAmarela GetInativoByIdWithInclude(Guid id)
        {
            var listaAmarela = DbSet
                                .IgnoreQueryFilters()
                                .Include(x => x.Detento)
                                .Where(x => x.Detento.IsDeleted == false
                                       || x.Detento.IsDeleted == true)
                                .Where(x => x.IsDeleted == true && x.Id == id)
                                .FirstOrDefault();
            
            return listaAmarela;
        }

        public ListaAmarela GetInativoForUpdateByDetentoIpen(int ipen)
        {
            var listaAmarela = DbSet
                                    .AsNoTracking()
                                    .IgnoreQueryFilters()
                                    .Include(x => x.Detento)
                                    .Where(x => x.Detento.IsDeleted == false 
                                           || x.Detento.IsDeleted == true)
                                    .Where(x => x.IsDeleted == true
                                          &&
                                          x.Detento.Ipen == ipen)
                                    .FirstOrDefault();
            
            return listaAmarela;
        }

        public IEnumerable<ListaAmarela> GetAllAguardandoTransferencia()
        {
            var listasAmarelas = DbSet
                                    .Include(x => x.Detento)            
                                    .Where(x => x.AguardandoTransferencia)
                                    .OrderBy(x => x.Comarca);       
            return listasAmarelas;
        }

        public IEnumerable<ListaAmarela> TotalizadorByCondenacaoTipo()
        {
            var listasAmarelas = DbSet;

            return listasAmarelas;
        }

        public ListaAmarela ResgatarInativoByIpen(int ipen)
        {
            var resgatarInativoByIpen = DbSet
                                            .IgnoreQueryFilters()
                                            .Include(x => x.Detento)
                                            .Where(x => x.Detento.IsDeleted == false
                                                  || x.Detento.IsDeleted == true)
                                            .Where(x => x.IsDeleted == true)
                                            .FirstOrDefault(x => x.Detento.Ipen == ipen);
                                        
            return resgatarInativoByIpen;
        }

        public bool AlreadyAtivoByDetentoIpen(int ipen)
        {
            var already = DbSet
                            .Include(x => x.Detento)
                            .Any(x => x.Detento.Ipen == ipen);
            return already;
        }

        public IEnumerable<ListaAmarela> GetAllByInstrumentoPrisao(InstrumentoPrisaoTipoEnum instrumentoPrisao)
        {
            var result = DbSet
                            .Include(x => x.Detento)
                            .OrderByDescending(x => x.DataPrevisaoBeneficio);
            var resultNew = new List<ListaAmarela>();

            foreach (var item in result.ToList())
            {
                if (item.InstrumentosPrisao.Contains(instrumentoPrisao))
                {
                    resultNew.Add(item);
                }
            }

            return resultNew;
        }
    }
}