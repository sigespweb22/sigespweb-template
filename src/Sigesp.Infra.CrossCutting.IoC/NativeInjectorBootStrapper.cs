using Microsoft.Extensions.DependencyInjection;
using Sigesp.Infra.Data.UoW;
using Sigesp.Domain.Interfaces;
using Sigesp.Infra.Data.Repository;
using Sigesp.Application.Services;
using Sigesp.Application.Interfaces;
using Sigesp.Infra.CrossCutting.Identity.Services;
using Sigesp.Application.Helpers;
using Sigesp.Domain.Hubs;

namespace Sigesp.Infra.CrossCutting.IoC
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // Infra - Data
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IContaUsuarioRepository, ContaUsuarioRepository>();
            services.AddScoped<IDetentoRepository, DetentoRepository>();
            services.AddScoped<IEmpresaRepository, EmpresaRepository>();
            services.AddScoped<IEmpresaConvenioRepository, EmpresaConvenioRepository>();
            services.AddScoped<IColaboradorRepository, ColaboradorRepository>();
            services.AddScoped<ILancamentoRepository, LancamentoRepository>();
            services.AddScoped<IContaCorrenteRepository, ContaCorrenteRepository>();
            services.AddScoped<IListaAmarelaRepository, ListaAmarelaRepository>();
            services.AddScoped<IEdiRepository, EdiRepository>();
            services.AddScoped<IEdiLogRepository, EdiLogRepository>();
            services.AddScoped<IColaboradorPontoRepository, ColaboradorPontoRepository>();
            services.AddScoped<IColaboradorPontoApontamentoRepository, ColaboradorPontoApontamentoRepository>();
            services.AddScoped<IContabilEventoRepository, ContabilEventoRepository>();
            services.AddScoped<ILivroRepository, LivroRepository>();
            services.AddScoped<ILivroAutorRepository, LivroAutorRepository>();
            services.AddScoped<ILivroGeneroRepository, LivroGeneroRepository>();
            services.AddScoped<IProfessorRepository, ProfessorRepository>();            
            services.AddScoped<IAndamentoPenalRepository, AndamentoPenalRepository>();
            services.AddScoped<ISequenciaOficioRepository, SequenciaOficioRepository>();
            services.AddScoped<IAlunoRepository, AlunoRepository>();
            services.AddScoped<IAlunoLeitorRepository, AlunoLeitorRepository>();
            services.AddScoped<IAlunoLeituraRepository, AlunoLeituraRepository>();
            services.AddScoped<IAlunoLeituraCronogramaRepository, AlunoLeituraCronogramaRepository>();
            services.AddScoped<IDisciplinaRepository, DisciplinaRepository>();
            services.AddScoped<IAlunoEjaRepository, AlunoEjaRepository>();
            services.AddScoped<IAlunoEjaDisciplinaRepository, AlunoEjaDisciplinaRepository>();
            services.AddScoped<IDetentoSaidaTemporariaRepository, DetentoSaidaTemporariaRepository>();
            services.AddScoped<ITenantRepository, TenantRepository>();
            services.AddScoped<IFormularioLeituraDicaEscritaRepository, FormularioLeituraDicaEscritaRepository>();
            services.AddScoped<IFormularioLeituraPerguntaGrupoRepository, FormularioLeituraPerguntaGrupoRepository>();
            services.AddScoped<IServidorEstadoRepository, ServidorEstadoRepository>();
            services.AddScoped<IServidorEstadoReforcoRepository, ServidorEstadoReforcoRepository>();
            services.AddScoped<IServidorEstadoReforcoRegraRepository, ServidorEstadoReforcoRegraRepository>();

            // Application
            services.AddScoped<IContaUsuarioAppService, ContaUsuarioAppService>();
            services.AddScoped<IDetentoAppService, DetentoAppService>();
            services.AddScoped<IEmpresaAppService, EmpresaAppService>();
            services.AddScoped<IEmpresaConvenioAppService, EmpresaConvenioAppService>();
            services.AddScoped<IColaboradorAppService, ColaboradorAppService>();
            services.AddScoped<ILancamentoAppService, LancamentoAppService>();
            services.AddScoped<IContaCorrenteAppService, ContaCorrenteAppService>();
            services.AddScoped<IListaAmarelaAppService, ListaAmarelaAppService>();
            services.AddScoped<IEdiAppService, EdiAppService>();
            services.AddScoped<IEdiLogAppService, EdiLogAppService>();
            services.AddScoped<IContabilEventoAppService, ContabilEventoAppService>();
            services.AddScoped<ILivroAppService, LivroAppService>();
            services.AddScoped<ILivroAutorAppService, LivroAutorAppService>();
            services.AddScoped<ILivroGeneroAppService, LivroGeneroAppService>();
            services.AddScoped<IProfessorAppService, ProfessorAppService>();
            services.AddScoped<IAndamentoPenalAppService, AndamentoPenalAppService>();
            services.AddScoped<ISequenciaOficioAppService, SequenciaOficioAppService>();
            services.AddScoped<IAlunoAppService, AlunoAppService>();
            services.AddScoped<IAlunoLeitorAppService, AlunoLeitorAppService>();
            services.AddScoped<IAlunoLeituraAppService, AlunoLeituraAppService>();
            services.AddScoped<IAlunoLeituraCronogramaAppService, AlunoLeituraCronogramaAppService>();
            services.AddScoped<IDisciplinaAppService, DisciplinaAppService>();
            services.AddScoped<IAlunoEjaAppService, AlunoEjaAppService>();
            services.AddScoped<IDetentoSaidaTemporariaAppService, DetentoSaidaTemporariaAppService>();
            services.AddScoped<IServidorEstadoAppService, ServidorEstadoAppService>();
            services.AddScoped<IServidorEstadoReforcoAppService, ServidorEstadoReforcoAppService>();
            services.AddScoped<IServidorEstadoReforcoRegraAppService, ServidorEstadoReforcoRegraAppService>();

            services.AddScoped<UserResolverService>();
            services.AddScoped<ValidationResult>();
            services.AddScoped<AlunoLeituraChaveGenerator>();
        }
    }
}