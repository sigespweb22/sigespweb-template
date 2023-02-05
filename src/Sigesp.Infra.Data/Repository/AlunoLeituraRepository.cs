using System;
using System.Data;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Sigesp.Domain.Interfaces;
using Sigesp.Domain.Models;
using Sigesp.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Sigesp.Domain.Enums;
using Sigesp.Domain.Models.DataTable;
using Sigesp.Infra.Data.Extensions.DataTable;

namespace Sigesp.Infra.Data.Repository
{
    public class AlunoLeituraRepository : Repository<AlunoLeitura>, IAlunoLeituraRepository
    {
        private readonly ITenantRepository _tenantRepository;
        public AlunoLeituraRepository(SigespDbContext context,
                                      ITenantRepository tenantRepository)
            : base(context)
        {
            _tenantRepository = tenantRepository;
        }

        public async Task<Guid> GetCronogramaIdAsync(Guid alunoLeituraId)
        {
            Guid result;
            try
            {
                result = await DbSet
                                .Where(x => x.Id == alunoLeituraId)
                                .Select(x => x.AlunoLeituraCronogramaId)
                                .FirstOrDefaultAsync();
            }
            catch { throw; }
            return result;
        }
        public async Task<DataTableServerSideResult<AlunoLeitura>> GetWithDataTableResultAsync(DataTableServerSideRequest request)
        {
            var result = new DataTableServerSideResult<AlunoLeitura>();
            try
            {
                result = await DbSet
                                .IgnoreQueryFilters()
                                .AsNoTracking()
                                .Include(x => x.AlunoLeitor)
                                .ThenInclude(x => x.Aluno)
                                .ThenInclude(x => x.Detento)
                                .Include(x => x.Livro)
                                .Include(x => x.AlunoLeituraCronograma)
                                .OrderBy(x => x.CreatedAt)
                                .Where(x => x.Tenant.Id == request.TenantId)
                                .GetDatatableResultAsync(request);
            }
            catch { throw; }
            return result;
        }
        public async Task<IEnumerable<AlunoLeitura>> GetAllAsync(Guid tenantId)
        {
            IEnumerable<AlunoLeitura> result = new List<AlunoLeitura>();
            try
            {
                result = await DbSet
                                .Where(x => x.Tenant.Id == tenantId)
                                .ToListAsync();
            }
            catch { throw; }
            return result;
        }
        public async Task<IEnumerable<AlunoLeitura>> GetAllForRelAvaliacaoAsync(Guid tenantId,
                                                                                Guid cronogramaId,
                                                                                string galeria,
                                                                                DateTime periodoInicio,
                                                                                DateTime periodoFim)
        {
            IEnumerable<AlunoLeitura> result = new List<AlunoLeitura>();
            try
            {
                if (string.IsNullOrEmpty(galeria))
                {
                    result = await DbSet
                                .IgnoreQueryFilters()
                                .Where(x => x.Tenant.Id == tenantId)
                                .Include(x => x.AlunoLeitor)
                                .ThenInclude(x => x.Aluno)
                                .ThenInclude(x => x.Detento)
                                .Include(x => x.AlunoLeituraCronograma)
                                .Include(x => x.Livro)
                                .ThenInclude(x => x.LivroAutor)
                                .Where(x => x.IsAvaliado)
                                .Where(x => x.AlunoLeituraCronograma.Id == cronogramaId &&
                                       x.LeituraTipo == LeituraTipoEnum.LEITURA_REMICAO &&
                                       x.DataAvaliacao >= periodoInicio &&
                                       x.DataAvaliacao <= periodoFim)
                                .OrderBy(x => x.DataAvaliacao)
                                .ToListAsync();
                }
                else 
                {
                    result = await DbSet
                                .IgnoreQueryFilters()
                                .Where(x => x.Tenant.Id == tenantId)
                                .Include(x => x.AlunoLeitor)
                                .ThenInclude(x => x.Aluno)
                                .ThenInclude(x => x.Detento)
                                .Include(x => x.AlunoLeituraCronograma)
                                .Include(x => x.Livro)
                                .ThenInclude(x => x.LivroAutor)
                                .Where(x => x.IsAvaliado)
                                .Where(x => x.AlunoLeituraCronograma.Id == cronogramaId &&
                                       x.AlunoLeitor.Aluno.Detento.Galeria == galeria &&
                                       x.LeituraTipo == LeituraTipoEnum.LEITURA_REMICAO &&
                                       x.DataAvaliacao >= periodoInicio &&
                                       x.DataAvaliacao <= periodoFim)
                                .OrderBy(x => x.DataAvaliacao)
                                .ToListAsync();
                }
            }
            catch { throw; }
            return result;
        }
        public async Task<IEnumerable<AlunoLeitura>> GetAllForRelAvaliacaoAsync(List<string> leiturasId)
        {
            IEnumerable<AlunoLeitura> result = new List<AlunoLeitura>();
            try
            {
                string createWhereForConsult = "WHERE ";
                foreach (var leituraId in leiturasId.Select((value, i) => new { i, value }))
                {
                    if (leiturasId.Count() == leituraId.i + 1)
                    {
                        createWhereForConsult = createWhereForConsult + "\"Id\"=" + "\'" + leituraId.value + "\'" + "";
                    }
                    else
                    {
                        createWhereForConsult = createWhereForConsult + "\"Id\"=" + "\'" + leituraId.value + "\'" + " OR ";
                    }
                }
                var queryInicial = "SELECT * FROM public.\"AlunosLeituras\" ";
                var queryFinal = queryInicial + createWhereForConsult;
                result = await DbSet
                                .FromSqlRaw(queryFinal)
                                .IgnoreQueryFilters()
                                .Include(x => x.AlunoLeituraCronograma)
                                .Include(x => x.AlunoLeitor)
                                .ThenInclude(x => x.Aluno)
                                .ThenInclude(x => x.Detento)
                                .Include(x => x.Livro)
                                .ThenInclude(x => x.LivroAutor)
                                .Where(x => x.IsAvaliado)
                                .Where(x => x.LeituraTipo == LeituraTipoEnum.LEITURA_REMICAO)
                                .OrderBy(x => x.DataAvaliacao)
                                .ToListAsync();
            }
            catch { throw; }
            return result;
        }
        public async Task<IEnumerable<AlunoLeitura>> GetAllForFormsLeituraAsync(List<string> leiturasId)
        {
            IEnumerable<AlunoLeitura> result = new List<AlunoLeitura>();
            try
            {
                string createWhereForConsult = "WHERE ";
                foreach (var leituraId in leiturasId.Select((value, i) => new { i, value }))
                {
                    if (leiturasId.Count() == leituraId.i + 1)
                    {
                        createWhereForConsult = createWhereForConsult + "\"Id\"=" + "\'" + leituraId.value + "\'" + "";
                    }
                    else
                    {
                        createWhereForConsult = createWhereForConsult + "\"Id\"=" + "\'" + leituraId.value + "\'" + " OR ";
                    }
                }
                var queryInicial = "SELECT * FROM public.\"AlunosLeituras\" ";
                var queryFinal = queryInicial + createWhereForConsult;
                result = await DbSet
                                .FromSqlRaw(queryFinal)
                                .IgnoreQueryFilters()
                                .Include(x => x.AlunoLeituraCronograma)
                                .Include(x => x.AlunoLeitor)
                                .ThenInclude(x => x.Aluno)
                                .ThenInclude(x => x.Detento)
                                .Include(x => x.Livro)
                                .ThenInclude(x => x.LivroAutor)
                                .Where(x => x.LeituraTipo == LeituraTipoEnum.LEITURA_REMICAO)
                                .OrderByDescending(x => x.DataAvaliacao)
                                .ToListAsync();
            }
            catch { throw; }
            return result;
        }
        public async Task<IEnumerable<AlunoLeitura>> GetAllForFormsLeituraAsync(Guid tenantId, 
                                                                                Guid cronogramaId,
                                                                                string galeria,
                                                                                List<int> celas)
        {
            var result = new List<AlunoLeitura>();
            try
            {
                var resultTMP = await DbSet
                                        .IgnoreQueryFilters()
                                        .Include(x => x.AlunoLeitor)
                                        .ThenInclude(x => x.Aluno)
                                        .ThenInclude(x => x.Detento)
                                        .Include(x => x.AlunoLeituraCronograma)
                                        .Include(x => x.Livro)
                                        .ThenInclude(x => x.LivroAutor)
                                        .Where(x => x.Tenant.Id == tenantId &&
                                               x.AlunoLeituraCronograma.Id == cronogramaId &&
                                               x.AlunoLeitor.Aluno.Detento.Galeria == galeria &&
                                               x.LeituraTipo == LeituraTipoEnum.LEITURA_REMICAO)
                                        .ToListAsync();

                foreach (var cela in celas)
                {
                    var findValue = resultTMP.FindAll(x => x.AlunoLeitor.Aluno.Detento.Cela == cela);
                    result.AddRange(findValue);
                }
            }
            catch { throw; }
            return result;
        }
        public async Task<IEnumerable<AlunoLeitura>> GetAllForFormsLeituraAsync(Guid tenantId, 
                                                                                Guid cronogramaId,
                                                                                string galeria)
        {
            IEnumerable<AlunoLeitura> result = new List<AlunoLeitura>();
            try
            {
                result = await DbSet
                                .IgnoreQueryFilters()
                                .Where(x => x.Tenant.Id == tenantId)
                                .Include(x => x.AlunoLeitor)
                                .ThenInclude(x => x.Aluno)
                                .ThenInclude(x => x.Detento)
                                .Include(x => x.AlunoLeituraCronograma)
                                .Include(x => x.Livro)
                                .ThenInclude(x => x.LivroAutor)
                                .Where(x => x.AlunoLeituraCronograma.Id == cronogramaId &&
                                       x.AlunoLeitor.Aluno.Detento.Galeria == galeria &&
                                       x.LeituraTipo == LeituraTipoEnum.LEITURA_REMICAO)
                                .ToListAsync();
            }
            catch { throw; }
            return result;
        }
        public IEnumerable<AlunoLeitura> GetAllWithIncludes()
        {
             var alunosLeituras = DbSet
                                    .IgnoreQueryFilters()
                                    .Include(x => x.AlunoLeitor)
                                    .ThenInclude(x => x.Aluno)
                                    .ThenInclude(x => x.Detento)
                                    .Where(x => x.AlunoLeitor.Aluno.Detento.IsDeleted == true 
                                        || 
                                        x.AlunoLeitor.Aluno.Detento.IsDeleted == false)
                                    .Where(x => x.IsDeleted == false)
                                    .ToList();
                            
            return alunosLeituras;
        }
        public AlunoLeitura GetByIdIncludes(Guid id)
        {
             var alunoLeitor = DbSet
                                .AsNoTracking()
                                .IgnoreQueryFilters()
                                .Include(x => x.AlunoLeitor)
                                .ThenInclude(x => x.Aluno)
                                .ThenInclude(x => x.Detento)
                                .Include(x => x.Livro)
                                .Include(x => x.AlunoLeituraCronograma)
                                .Where(x => x.AlunoLeitor.IsDeleted == false ||
                                       x.AlunoLeitor.IsDeleted == true)
                                .Where(x => x.AlunoLeitor.Aluno.IsDeleted == false ||
                                       x.AlunoLeitor.Aluno.IsDeleted == true)
                                .Where(x => x.AlunoLeitor.Aluno.Detento.IsDeleted == false ||
                                       x.AlunoLeitor.Aluno.Detento.IsDeleted == true)
                                .Where(x => x.Id == id)
                                .FirstOrDefault();

            return alunoLeitor;
        }
        public Int64 GetTotalAtivos()
        {
            var ativos = DbSet
                            .Count();
            return ativos;
        }
        public Int64 GetTotalInativos()
        {
            var inativos = DbSet
                            .IgnoreQueryFilters()
                            .Where(x => x.IsDeleted == true)
                            .Count();
            return inativos;
        }
        public Int64 GetTotalWithIgnoreQueryFilter()
        {
            var total = DbSet
                            .IgnoreQueryFilters()
                            .Count();
            return total;
        }
        public bool AlreadyAlunoLeitorAtivoByIpen(int ipen)
        {
            var alreadyAlunoLeitorAtivoByIpen = DbSet
                                                    .Any(x => x.AlunoLeitor.Aluno.Detento.Ipen == ipen);
                                            
            return alreadyAlunoLeitorAtivoByIpen;
        }
        public AlunoLeitura GetByDetentoIpen(int ipen)
        {
            var alunoLeitor = DbSet
                                .Include(c => c.AlunoLeitor)
                                .ThenInclude(c => c.Aluno)
                                .ThenInclude(c => c.Detento)
                                .FirstOrDefault(x => x.AlunoLeitor.Aluno.Detento.Ipen == ipen);

            return alunoLeitor;
        }
        public AlunoLeitura GetInativoByDetentoIpen(int ipen)
        {
            var alunoLeitor = DbSet
                                .AsNoTracking()
                                .IgnoreQueryFilters()
                                .Include(c => c.AlunoLeitor)
                                .ThenInclude(c => c.Aluno)
                                .ThenInclude(c => c.Detento)
                                .Where(x => x.AlunoLeitor.Aluno.Detento.IsDeleted == false
                                        ||
                                       x.AlunoLeitor.Aluno.Detento.IsDeleted == true)
                                .FirstOrDefault(x => x.IsDeleted == true);

            return alunoLeitor;
        }
        public AlunoLeitura GetAtivoOrInativoByDetentoIpen(int ipen)
        {
            var alunoLeitura = DbSet
                                .AsNoTracking()
                                .IgnoreQueryFilters()
                                .Include(c => c.AlunoLeitor)
                                .ThenInclude(c => c.Aluno)
                                .ThenInclude(c => c.Detento)
                                .FirstOrDefault(x => x.AlunoLeitor.Aluno.Detento.Ipen == ipen);

            return alunoLeitura;
        }
        public IEnumerable<AlunoLeitura> GetAllByIpen(int ipen)
        {
            var leituras = DbSet
                            .Include(x => x.AlunoLeitor)
                            .ThenInclude(x => x.Aluno)
                            .ThenInclude(x => x.Detento)
                            .Include(x => x.AlunoLeitor.LivroGenero)
                            .Include(x => x.Livro)
                            .Where(x => x.AlunoLeitor.Aluno.Detento.Ipen == ipen);
                            
            return leituras;
        }
        public bool AlreadySameAnoAndPeriodoReferencia(int ipen, 
                                                       int anoReferencia,
                                                       int periodoReferencia,
                                                       LeituraTipoEnum lt)
        {
            var result = DbSet
                            .IgnoreQueryFilters()
                            .Include(x => x.AlunoLeitor)
                            .ThenInclude(x => x.Aluno)
                            .ThenInclude(x => x.Detento)
                            .Include(x => x.AlunoLeituraCronograma)
                            .Any(x => x.AlunoLeitor.Aluno.Detento.Ipen == ipen &&
                                 x.AlunoLeituraCronograma.AnoReferencia.Date.Year == anoReferencia &&
                                 x.AlunoLeituraCronograma.PeriodoReferencia == periodoReferencia &&
                                 x.LeituraTipo == lt);
            return result;
        }
        public bool AlreadySameAnoAndPeriodoReferenciaById(Guid id,
                                                           int ipen,
                                                           int anoReferencia,
                                                           int periodoReferencia,
                                                           LeituraTipoEnum lt)
        {
            var result = DbSet
                            .Include(x => x.AlunoLeitor)
                            .ThenInclude(x => x.Aluno)
                            .ThenInclude(x => x.Detento)
                            .Include(x => x.AlunoLeituraCronograma)
                            .Any(x => x.AlunoLeitor.Aluno.Detento.Ipen == ipen &&
                                 x.AlunoLeituraCronograma.AnoReferencia.Date.Year == anoReferencia &&
                                 x.AlunoLeituraCronograma.PeriodoReferencia == periodoReferencia &&
                                 x.LeituraTipo == lt &&
                                 x.Id != id);
            return result;
        }
        public bool AlreadySameTitulo(int ipen, 
                                      Guid livroId,
                                      string livroTitulo,
                                      LeituraTipoEnum lt)
        {
            var result = DbSet
                            .IgnoreQueryFilters()
                            .Include(x => x.AlunoLeitor)
                            .ThenInclude(x => x.Aluno)
                            .ThenInclude(x => x.Detento)
                            .Include(x => x.Livro)
                            .Any(x => x.AlunoLeitor.Aluno.Detento.Ipen == ipen &&
                                 x.Livro.Titulo.StartsWith(livroTitulo) &&
                                 x.LeituraTipo == lt);
            return result;
        }
        public bool AlreadySameTituloById(Guid id,
                                          int ipen,
                                          Guid livroId,
                                          LeituraTipoEnum lt)
        {
            var result = DbSet
                            .IgnoreQueryFilters()
                            .Include(x => x.AlunoLeitor)
                            .ThenInclude(x => x.Aluno)
                            .ThenInclude(x => x.Detento)
                            .Include(x => x.Livro)
                            .Any(x => x.AlunoLeitor.Aluno.Detento.Ipen == ipen &&
                                 x.Livro.Id == livroId &&
                                 x.LeituraTipo == lt &&
                                 x.Id != id);
            return result;
        }
        public bool AlreadySameTituloById(int ipen,
                                          Guid livroId,
                                          LeituraTipoEnum lt)
        {
            var result = DbSet
                            .IgnoreQueryFilters()
                            .Include(x => x.AlunoLeitor)
                            .ThenInclude(x => x.Aluno)
                            .ThenInclude(x => x.Detento)
                            .Include(x => x.Livro)
                            .Any(x => x.AlunoLeitor.Aluno.Detento.Ipen == ipen &&
                                 x.Livro.Id == livroId &&
                                 x.LeituraTipo == lt);
            return result;
        }  
        public bool AlreadySameCronograma(Guid alunoLeituraCronogramaId,
                                          int ipen)
        {
            var result = DbSet
                            .Include(x => x.AlunoLeituraCronograma)
                            .Include(x => x.AlunoLeitor)
                            .ThenInclude(x => x.Aluno)
                            .ThenInclude(x => x.Detento)
                            .Any(x => x.AlunoLeitor.Aluno.Detento.Ipen == ipen &&
                                      x.AlunoLeituraCronograma.Id == alunoLeituraCronogramaId);

            return result;
        }
        public IEnumerable<Livro> GetAllTitulosLidos(int ipen, LeituraTipoEnum lr)
        {
            var result = DbSet
                            .IgnoreQueryFilters()
                            .Include(x => x.AlunoLeitor)
                            .ThenInclude(x => x.Aluno)
                            .ThenInclude(x => x.Detento)
                            .Where(x => x.AlunoLeitor.Aluno.Detento.Ipen == ipen &&
                                        x.LeituraTipo == lr)
                            .Select(x => new {
                                Id = x.Livro.Id,
                                Titulo = x.Livro.Titulo
                            });

            var resultMapped = new List<Livro>();

            foreach (var item in result)
            {
                var tmp = new Livro {
                    Id = item.Id,
                    Titulo = item.Titulo
                };

                resultMapped.Add(tmp);
            }
            
            return resultMapped.ToList();
        }
        public Livro GetLivroLeitura(Guid idLeitura)
        {
            var livro = DbSet
                            .Include(x => x.Livro)
                            .Where(x => x.Id == idLeitura)
                            .Select(x => x.Livro)
                            .FirstOrDefault();
            return livro;
        }
        public async Task<AlunoLeitura> GetByChaveLeituraAsync(Guid tenantId, Int64 chaveLeitura)
        {
            var result = new AlunoLeitura();
            try
            {
                result = await DbSet
                                .IgnoreQueryFilters()
                                .Include(x => x.AlunoLeitor)
                                .ThenInclude(x => x.Aluno)
                                .ThenInclude(x => x.Detento)
                                .Include(x => x.Livro)
                                .Include(x => x.AlunoLeituraCronograma)
                                .Where(x => x.Tenant.Id == tenantId)
                                .Where(x => x.AlunoLeitor.IsDeleted == false || x.AlunoLeitor.IsDeleted == true &&
                                            x.AlunoLeitor.Aluno.IsDeleted == false || x.AlunoLeitor.Aluno.IsDeleted == true &&
                                            x.AlunoLeitor.Aluno.Detento.IsDeleted == false || x.AlunoLeitor.Aluno.Detento.IsDeleted == true &&
                                            x.Livro.IsDeleted == false || x.Livro.IsDeleted == true &&
                                            x.AlunoLeituraCronograma.IsDeleted == false || x.AlunoLeituraCronograma.IsDeleted == true)
                                .FirstOrDefaultAsync(x => x.ChaveLeitura == chaveLeitura);    
            }
            catch { throw; }
            return result;
        }
        public Livro GetLivroForEdicao(Guid id)
        {
            var result = DbSet
                            .IgnoreQueryFilters()
                            .Include(x => x.AlunoLeitor)
                            .ThenInclude(x => x.Aluno)
                            .ThenInclude(x => x.Detento)
                            .Include(x => x.Livro)
                            .Include(x => x.AlunoLeituraCronograma)
                            .Where(x => x.AlunoLeitor.IsDeleted == false || x.AlunoLeitor.IsDeleted == true &&
                                        x.AlunoLeitor.Aluno.IsDeleted == false || x.AlunoLeitor.Aluno.IsDeleted == true &&
                                        x.AlunoLeitor.Aluno.Detento.IsDeleted == false || x.AlunoLeitor.Aluno.Detento.IsDeleted == true &&
                                        x.Livro.IsDeleted == false || x.Livro.IsDeleted == true &&
                                        x.AlunoLeituraCronograma.IsDeleted == false || x.AlunoLeituraCronograma.IsDeleted == true)
                            .Where(x => x.Id == id)
                            .Select(x => x.Livro);
    
            return result.FirstOrDefault();
        }
        public AlunoLeitura GetByIdWithoutIncludes(Guid id)
        {
            var result = DbSet
                            .AsNoTracking()
                            .FirstOrDefault(x => x.Id == id);
            
            return result;

        }
        public async Task<Int64> GetTotalByAvaliacaoConceitoAsync(Guid tenantId, 
                                                                  AlunoLeituraAvaliacaoConceitoEnum avlC)
        {
            Int64 result;
            try
            {
                result = await DbSet
                                .CountAsync(x => x.Tenant.Id == tenantId &&
                                            x.AvaliacaoConceito == avlC);
            }
            catch { throw; }
            return result;
        }

        public async Task<Int64> GetTotalByLeituraTipoAsync(Guid tenantId, 
                                                            LeituraTipoEnum lt)
        {
            Int64 result;
            try
            {
                result = await DbSet
                                .CountAsync(x => x.Tenant.Id == tenantId &&
                                            x.LeituraTipo == lt);
            }
            catch { throw; }
            return result;
        }
        public async Task<IEnumerable<AlunoLeitura>> GetForOficioLeituraAsync(List<string> leiturasId)
        {
            IEnumerable<AlunoLeitura> result = new List<AlunoLeitura>();
            try
            {
                string createWhereForConsult = "WHERE ";
                foreach (var leituraId in leiturasId.Select((value, i) => new { i, value }))
                {
                    if (leiturasId.Count() == leituraId.i + 1)
                    {
                        createWhereForConsult = createWhereForConsult + "\"Id\"=" + "\'" + leituraId.value + "\'" + "";
                    }
                    else
                    {
                        createWhereForConsult = createWhereForConsult + "\"Id\"=" + "\'" + leituraId.value + "\'" + " OR ";
                    }
                }
                var queryInicial = "SELECT * FROM public.\"AlunosLeituras\" ";
                var queryFinal = queryInicial + createWhereForConsult;
                result = await DbSet
                                .FromSqlRaw(queryFinal)
                                .IgnoreQueryFilters()
                                .Include(x => x.Tenant)
                                .Include(x => x.AlunoLeituraCronograma)
                                .Include(x => x.AlunoLeitor)
                                .ThenInclude(x => x.Aluno)
                                .ThenInclude(x => x.Detento)
                                .Include(x => x.Livro)
                                .ThenInclude(x => x.LivroAutor)
                                .Where(x => x.LeituraTipo == LeituraTipoEnum.LEITURA_REMICAO)
                                .Select(x => new AlunoLeitura
                                {
                                    Id = x.Id,
                                    AlunoLeitor = new AlunoLeitor
                                    {
                                        Aluno = new Aluno
                                        {
                                            Detento = new Detento
                                            {
                                                Ipen = x.AlunoLeitor.Aluno.Detento.Ipen,
                                                Nome = x.AlunoLeitor.Aluno.Detento.Nome,
                                                AndamentoPenal = new AndamentoPenal
                                                {
                                                    Pec = x.AlunoLeitor.Aluno.Detento.AndamentoPenal.Pec
                                                }
                                            }
                                        }
                                    },
                                    ChaveLeitura = x.ChaveLeitura,
                                    AlunoLeituraCronograma = new AlunoLeituraCronograma 
                                    {
                                        AnoReferencia = x.AlunoLeituraCronograma.AnoReferencia,
                                        PeriodoReferencia = x.AlunoLeituraCronograma.PeriodoReferencia,
                                        PeriodoInicio = x.AlunoLeituraCronograma.PeriodoInicio,
                                        PeriodoFim = x.AlunoLeituraCronograma.PeriodoFim 
                                    },
                                    Livro = new Livro { Titulo = x.Livro.Titulo },
                                    AvaliacaoConceito = x.AvaliacaoConceito,
                                    HasOficio = x.HasOficio
                                })
                                .ToListAsync();
            }
            catch { throw; }
            return result;
        }

        public void UpdateRange(IEnumerable<AlunoLeitura> leituras)
        {
            DbSet.UpdateRange(leituras);
        }
    }
}