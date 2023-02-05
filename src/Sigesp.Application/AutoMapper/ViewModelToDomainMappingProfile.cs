using System.Reflection.Metadata.Ecma335;
using System.Linq;
using AutoMapper;
using Sigesp.Application.ViewModels;
using Sigesp.Domain.Models;
using Sigesp.Application.Extensions;
using Sigesp.Application.ViewModels.Detentos;

namespace Sigesp.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<ContaUsuarioViewModel, ContaUsuario>();
            CreateMap<ApplicationUserViewModel, ApplicationUser>();
            CreateMap<DetentoViewModel, Detento>()
                .ForMember(dst => dst.Regime,
                            src => src.ResolveUsing(x => x.Regime));
            CreateMap<ListaAmarelaViewModel, ListaAmarela>();
            CreateMap<EmpresaViewModel, Empresa>();
            CreateMap<EmpresaConvenioViewModel, EmpresaConvenio>();
            CreateMap<ColaboradorViewModel, Colaborador>();               
            CreateMap<LancamentoViewModel, Lancamento>()
                .ForMember(dst => dst.PeriodoDataInicio, src => src.MapFrom(x => x.PeriodoDataInicio))
                .ForMember(dst => dst.PeriodoDataFim, src => src.MapFrom(x => x.PeriodoDataFim));
            CreateMap<ContaCorrenteViewModel, ContaCorrente>();
            CreateMap<EdiViewModel, Edi>();
            CreateMap<EdiLogViewModel, EdiLog>();
            CreateMap<ContabilEventoViewModel, ContabilEvento>();
            CreateMap<AndamentoPenalViewModel, AndamentoPenal>();
            CreateMap<SequenciaOficioViewModel, SequenciaOficio>();
            CreateMap<LivroViewModel, Livro>();
            CreateMap<LivroAutorViewModel, LivroAutor>();
            CreateMap<LivroGeneroViewModel, LivroGenero>();
            CreateMap<ProfessorViewModel, Professor>();
            CreateMap<AlunoViewModel, Aluno>();
            CreateMap<AlunoLeitorViewModel, AlunoLeitor>();
            CreateMap<AlunoLeituraViewModel, AlunoLeitura>();
            CreateMap<DisciplinaViewModel, Disciplina>();
            CreateMap<AlunoEjaViewModel, AlunoEja>();
            CreateMap<DetentoSaidaTemporariaViewModel, DetentoSaidaTemporaria>();
            CreateMap<AlunoLeituraCronogramaViewModel, AlunoLeituraCronograma>();
            CreateMap<ServidorEstadoViewModel, ServidorEstado>()
                .ForMember(dst => dst.UserId, src => src.MapFrom(x => x.UserId));
            CreateMap<ServidorEstadoReforcoViewModel, ServidorEstadoReforco>();
            CreateMap<ServidorEstadoReforcoRegraViewModel, ServidorEstadoReforcoRegra>()
                .ForMember(dst => dst.Id, src => src.MapFrom(x => x.Id))
                .ForMember(dst => dst.TenantId, src => src.MapFrom(x => x.TenantId));
            CreateMap<ServidorEstadoReforcoRegraVagaDiaViewModel, ServidorEstadoReforcoRegraVagaDia>();
            CreateMap<ApplicationNotificationViewModel, ApplicationNotification>();
            CreateMap<FormularioLeituraDicaEscritaViewModel, FormularioLeituraDicaEscrita>();
            CreateMap<FormularioLeituraDicaEscritaDicaViewModelWithoutValidations, FormularioLeituraDicaEscritaDica>()
                .ForMember(dst => dst.FormularioLeituraDicaEscritaId, src => src.MapFrom(x => x.FormularioLeituraDicaEscritaId));
            CreateMap<FormularioLeituraDicaEscritaDicaViewModel, FormularioLeituraDicaEscritaDica>()
                .ForMember(dst => dst.FormularioLeituraDicaEscrita, src => src.MapFrom(x => x.FormularioLeituraDicaEscritaViewModel))
                .ForMember(dst => dst.FormularioLeituraDicaEscritaId, src => src.MapFrom(x => x.FormularioLeituraDicaEscritaId));
        }
    }
}
