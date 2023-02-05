using System.Threading;
using System.Reflection.Metadata.Ecma335;
using System.Linq;
using AutoMapper;
using Sigesp.Application.ViewModels;
using Sigesp.Domain.Models;
using Sigesp.Application.Extensions;
using Sigesp.Domain.Enums;
using Sigesp.Application.ViewModels.Charts.Info;
using System.Collections.Generic;
using Sigesp.Domain.Models.DataTable;
using Sigesp.Application.ViewModels.Forms;
using Sigesp.Application.ViewModels.Relatorios;

namespace Sigesp.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<ContaUsuario, ContaUsuarioViewModel>()
                .ForMember(dst => dst.SetorId, src => src.MapFrom(x => (int) x.Setor))
                .ForMember(dst => dst.Setor, src => src.MapFrom(x => x.Setor))
                .ForMember(dst => dst.FuncaoId, src => src.MapFrom(x => (int) x.Funcao))
                .ForMember(dst => dst.Funcao, src => src.MapFrom(x => x.Funcao));
            CreateMap<ApplicationUser, ApplicationUserViewModel>()
                .ForMember(dst => dst.UserId, src => src.MapFrom(x => x.Id))
                .ForMember(dst => dst.ContaUsuarioViewModel, 
                                src => src.MapFrom(x => x.ContaUsuario));
            CreateMap<Detento, DetentoViewModel>()
                .ForMember(dst => dst.Regime,
                            src => src.ResolveUsing(x => x.Regime))
                .ForMember(dst => dst.TransferenciaDataSaida, src => src.MapFrom(x => x.TransferenciaDataSaida.ToString("yyyy-MM-dd")))
                .ForMember(dst => dst.TransferenciaDataRetornoPrevisto, src => src.MapFrom(x => x.TransferenciaDataRetornoPrevisto.ToString("yyyy-MM-dd")))
                .ForMember(dst => dst.TransferenciaDataRetornoRealizado, src => src.MapFrom(x => x.TransferenciaDataRetornoRealizado.ToString("yyyy-MM-dd")));
            CreateMap<ListaAmarela, ListaAmarelaViewModel>()
                .ForMember(dst => dst.DataPrevisaoBeneficio, src => src.MapFrom(x => x.DataPrevisaoBeneficio.ToString("yyyy-MM-dd")))
                .ForMember(dst => dst.DataProgressao, src => src.MapFrom(x => x.DataProgressao.ToString("yyyy-MM-dd")))
                .ForMember(dst => dst.DataPrisao, src => src.MapFrom(x => x.DataPrisao.ToString("yyyy-MM-dd")))
                .ForMember(dst => dst.RevisaoIpenData, src => src.MapFrom(x => x.RevisaoIpenData.ToString("yyyy-MM-dd")))
                .ForMember(dst => dst.DetentoIpen, src => src.MapFrom(x => x.Detento.Ipen.ToString()))
                .ForMember(dst => dst.DetentoNome, src => src.MapFrom(x => x.Detento.Nome))
                .ForMember(dst => dst.DetentoRegime, src => src.MapFrom(x => x.Detento.Regime))
                .ForMember(dst => dst.DetentoViewModel, src => src.MapFrom(x => x.Detento))
                .ForPath(dst => dst.DataSaidaPrevista, src => src.MapFrom(x => x.DataSaidaPrevista.ToString("yyyy-MM-dd")));
            CreateMap<Detento, DetentoForNovoViewModel>();
            CreateMap<Empresa, EmpresaViewModel>();
            CreateMap<EmpresaConvenio, EmpresaConvenioViewModel>()
                .ForMember(dst => dst.DataInicio, src => src.MapFrom(x => x.DataInicio.ToString("yyyy-MM-dd")))
                .ForMember(dst => dst.DataFim, src => src.MapFrom(x => x.DataFim.ToString("yyyy-MM-dd")))
                .ForMember(dst => dst.DataEncerramento, src => src.MapFrom(x => x.DataEncerramento.ToString("yyyy-MM-dd")));
            CreateMap<Colaborador, ColaboradorViewModel>()
                .ForMember(dst => dst.HasContaCorrente, src => src.MapFrom(x => !x.ContaCorrente.IsDeleted && x.ContaCorrente != null))
                .ForMember(dst => dst.DataInicio, src => src.MapFrom(x => x.DataInicio.ToString("yyyy-MM-dd")))
                .ForMember(dst => dst.DemissaoData, src => src.MapFrom(x => x.DemissaoData.ToString("yyyy-MM-dd")))
                .ForMember(dst => dst.Detento, src => src.MapFrom(x => x.Detento))
                .ForMember(dst => dst.EmpresaConvenio, src => src.MapFrom(x => x.EmpresaConvenio))
                .ForMember(dst => dst.ContaCorrente, src => src.MapFrom(x => x.ContaCorrente));
            CreateMap<Lancamento, LancamentoViewModel>()
                .ForMember(dst => dst.CreatedAt, src => src.MapFrom(x => x.CreatedAt.ToString("yyyy-MM-dd")))
                .ForMember(dst => dst.ColaboradorNome, src => src.MapFrom(x => x.ContaCorrente.Colaborador.Detento.Nome))
                .ForMember(dst => dst.DetentoRegime, src => src.MapFrom(x => x.ContaCorrente.Colaborador.Detento.Regime))
                .ForMember(dst => dst.DetentoIpen, src => src.MapFrom(x => x.ContaCorrente.Colaborador.Detento.Ipen))
                .ForMember(dst => dst.EmpresaRazaoSocial, src => src.MapFrom(x => x.ContaCorrente.Empresa.RazaoSocial))
                .ForMember(dst => dst.ContaCorrenteDescricao, src => src.MapFrom(x => x.ContaCorrente.Descricao))
                .ForMember(dst => dst.ContaCorrenteIsTipoCofre, src => src.MapFrom(x => x.ContaCorrente.Tipo == ContaCorrenteTipoEnum.COFRE))
                .ForMember(dst => dst.Saldo, src => 
                                    src.MapFrom(x => x.ContaCorrente.Lancamentos
                                                .Where(x => x.Tipo == LancamentoTipoEnum.CREDITO && x.Status == LancamentoStatusEnum.LIQUIDADO)
                                                .Sum(x => x.ValorLiquido)
                                                -
                                                x.ContaCorrente.Lancamentos
                                                    .Where(x => x.Tipo == LancamentoTipoEnum.DEBITO && x.Status == LancamentoStatusEnum.LIQUIDADO)
                                                    .Sum(x => x.ValorLiquido)))
                .ForMember(dst => dst.ContabilEventoEspecificacao, src => src.MapFrom(c => c.ContabilEvento.Especificacao));
            CreateMap<ContaCorrente, ContaCorrenteViewModel>()
                .ForMember(dst => dst.ColaboradorNome, src => src.MapFrom(x => x.Colaborador.Detento.Nome))
                .ForMember(dst => dst.DetentoIpen, src => src.MapFrom(x => x.Colaborador.Detento.Ipen))
                .ForMember(dst => dst.DetentoGaleria, src => src.MapFrom(x => x.Colaborador.Detento.Galeria))
                .ForMember(dst => dst.DetentoCela, src => src.MapFrom(x => x.Colaborador.Detento.Cela))
                .ForMember(dst => dst.EmpresaViewModel, src => src.MapFrom(x => x.Empresa))
                .ForMember(dst => dst.EmpresaRazaoSocial, src => src.MapFrom(x => x.Empresa.RazaoSocial))
                .ForMember(dst => dst.Saldo, src => 
                                    src.MapFrom(x => x.Lancamentos
                                                .Where(x => x.Tipo == LancamentoTipoEnum.CREDITO && x.Status == LancamentoStatusEnum.LIQUIDADO)
                                                .Sum(x => x.ValorLiquido)
                                                -
                                                x.Lancamentos
                                                    .Where(x => x.Tipo == LancamentoTipoEnum.DEBITO && x.Status == LancamentoStatusEnum.LIQUIDADO)
                                                    .Sum(x => x.ValorLiquido)));
            CreateMap<Edi, EdiViewModel>()
                .ForMember(dst => dst.CreatedAt, src => src.MapFrom(x => x.CreatedAt.ToLocalTime().ToString("dd/MM/yyyy HH:mm:ss")))
                .ForMember(dst => dst.Logs, src => src.MapFrom(x => x.EdiLogs.Count()));
            CreateMap<EdiLog, EdiLogViewModel>();
            CreateMap<ContabilEvento, ContabilEventoViewModel>();
            CreateMap<AndamentoPenal, AndamentoPenalViewModel>()
                .ForMember(dst => dst.DataEventoPrincipal, src => src.MapFrom(x => x.DataEventoPrincipal.ToString("yyyy-MM-dd")))
                .ForMember(dst => dst.EnderecoCompleto, src => src.MapFrom(x => x.EnderecoCompleto.ToUpper()))
                .ForMember(dst => dst.Telefone, src => src.MapFrom(x => x.Telefone.ToUpper()));
            CreateMap<Livro, LivroViewModel>()
                .ForMember(dst => dst.LivroAutorNome, src => src.MapFrom(x => x.LivroAutor.Nome))
                .ForMember(dst => dst.LivroGeneroNome, src => src.MapFrom(x => x.LivroGenero.Nome));
            CreateMap<LivroAutor, LivroAutorViewModel>();
            CreateMap<LivroGenero, LivroGeneroViewModel>();
            CreateMap<Professor, ProfessorViewModel>()
                .ForMember(dst => dst.ApplicationUser, src => src.MapFrom(x => x.ApplicationUser))
                .ForMember(dst => dst.ApplicationUserNome, src => src.MapFrom(x => x.ApplicationUser.ContaUsuario.Nome))
                .ForMember(dst => dst.ApplicationUserId, src => src.MapFrom(x => x.ApplicationUser.Id));
            // CreateMap<Leitor, LeitorViewModel>();
                // .ForMember(dst => dst.CejaDataMatricula, src => src.MapFrom(x => x.CejaDataMatricula.ToString("yyyy-MM-dd")))
                // .ForMember(dst => dst.DataUltimoIsDeletedOcorrencia, src => src.MapFrom(x => x.DataUltimoIsDeletedOcorrencia.ToString("yyyy-MM-dd")))
                // .ForMember(dst => dst.DataPedidoEnturmacao, src => src.MapFrom(x => x.DataPedidoEnturmacao.ToString("yyyy-MM-dd")));
            CreateMap<SequenciaOficio, SequenciaOficioViewModel>();
            CreateMap<Aluno, AlunoViewModel>()
                .ForMember(dst => dst.IsDeleted, src => src.MapFrom(x => x.IsDeleted))
                .ForMember(dst => dst.DetentoGaleria, src => src.MapFrom(x => x.Detento.Galeria))
                .ForMember(dst => dst.DetentoCela, src => src.MapFrom(x => x.Detento.Cela));
            CreateMap<AlunoLeitor, AlunoLeitorViewModel>()
                .ForMember(dst => dst.DataIngresso, src => src.MapFrom(x => x.DataIngresso.ToString("yyyy-MM-dd")))
                .ForMember(dst => dst.DataFimBloqueio, src => src.MapFrom(x => x.LockoutEndByOcorrencia.ToString("yyyy-MM-dd")))
                .ForMember(dst => dst.DataOcorrenciaDesistencia, src => src.MapFrom(x => x.DataOcorrenciaDesistencia.ToString("yyyy-MM-dd")))
                .ForMember(dst => dst.DetentoIpen, src => src.MapFrom(x => x.Aluno.Detento.Ipen))
                .ForMember(dst => dst.DetentoNome, src => src.MapFrom(x => x.Aluno.Detento.Nome))
                .ForMember(dst => dst.DetentoGaleria, src => src.MapFrom(x => x.Aluno.Detento.Galeria))
                .ForMember(dst => dst.DetentoCela, src => src.MapFrom(x => x.Aluno.Detento.Cela));
            CreateMap<AlunoLeitura, AlunoLeituraViewModel>()
                .ForMember(dst => dst.AlunoLeitorId, src => src.MapFrom(x => x.AlunoLeitor.Id))
                .ForMember(dst => dst.AlunoLeitorIpen, src => src.MapFrom(x => x.AlunoLeitor.Aluno.Detento.Ipen))
                .ForMember(dst => dst.AlunoLeitorNome, src => src.MapFrom(x => x.AlunoLeitor.Aluno.Detento.Nome))
                .ForMember(dst => dst.AlunoLeitorGaleria, src => src.MapFrom(x => x.AlunoLeitor.Aluno.Detento.Galeria))
                .ForMember(dst => dst.AlunoLeitorCela, src => src.MapFrom(x => x.AlunoLeitor.Aluno.Detento.Cela))
                .ForMember(dst => dst.AnoReferencia, src => src.MapFrom(x => x.AlunoLeituraCronograma.AnoReferencia.ToString("yyyy")))
                .ForMember(dst => dst.PeriodoReferencia, src => src.MapFrom(x => x.AlunoLeituraCronograma.PeriodoReferencia))
                .ForMember(dst => dst.LivroId, src => src.MapFrom(x => x.Livro.Id))
                .ForMember(dst => dst.LivroTitulo, src => src.MapFrom(x => x.Livro.Titulo))
                .ForMember(dst => dst.LivroLocalizacao, src => src.MapFrom(x => x.Livro.Localizacao))
                .ForMember(dst => dst.DataInicio, src => src.MapFrom(x => x.AlunoLeituraCronograma.PeriodoInicio.ToString("yyyy-MM-dd")))
                .ForMember(dst => dst.DataFim, src => src.MapFrom(x => x.AlunoLeituraCronograma.PeriodoFim.ToString("yyyy-MM-dd")))
                .ForMember(dst => dst.AlunoLeituraCronogramaNome, src => src.MapFrom(x => x.AlunoLeituraCronograma.Nome))
                .ForMember(dst => dst.OficioDataCriacao, src => src.MapFrom(x => x.OficioDataCriacao.ToString("yyyy-MM-dd")));
            CreateMap<Disciplina, DisciplinaViewModel>();
            CreateMap<AlunoEja, AlunoEjaViewModel>()
                .ForMember(dst => dst.DataIngresso, src => src.MapFrom(x => x.DataIngresso.ToString("yyyy-MM-dd")))
                .ForMember(dst => dst.DetentoIpen, src => src.MapFrom(x => x.Aluno.Detento.Ipen))
                .ForMember(dst => dst.DetentoNome, src => src.MapFrom(x => x.Aluno.Detento.Nome))
                .ForMember(dst => dst.DetentoGaleria, src => src.MapFrom(x => x.Aluno.Detento.Galeria))
                .ForMember(dst => dst.DetentoCela, src => src.MapFrom(x => x.Aluno.Detento.Cela))
                .ForMember(dst => dst.DataOcorrenciaDesistencia, src => src.MapFrom(x => x.DataOcorrenciaDesistencia.ToString("yyyy-MM-dd")));
            CreateMap<AlunoEjaDisciplina, AlunoEjaDisciplinaViewModel>();
            CreateMap<DetentoSaidaTemporaria, DetentoSaidaTemporariaViewModel>()
                .ForMember(dst => dst.SaidaPrevista, src => src.MapFrom(x => x.SaidaPrevista.ToString("dd/MM/yyyy")))
                .ForMember(dst => dst.RetornoPrevisto, src => src.MapFrom(x => x.RetornoPrevisto.ToString("dd/MM/yyyy")));
            CreateMap<AlunoLeituraCronograma, AlunoLeituraCronogramaViewModel>()
                .ForMember(dst => dst.PeriodoInicio, src => src.MapFrom(x => x.PeriodoInicio.ToString("yyyy-MM-dd")))
                .ForMember(dst => dst.PeriodoFim, src => src.MapFrom(x => x.PeriodoFim.ToString("yyyy-MM-dd")))
                .ForMember(dst => dst.AnoReferencia, src => src.MapFrom(x => x.AnoReferencia.Date.Year.ToString("yyyy")))
                .ForMember(dst => dst.DiasPeriodo, src => src.MapFrom(x => x.DiasPeriodo))
                .ForMember(dst => dst.PeriodoReferencia, src => src.MapFrom(x => x.PeriodoReferencia));
            CreateMap<AlunoLeitura, AlunoLeituraForFormModel>()
                .ForMember(dst => dst.ChaveLeitura, src => src.MapFrom(x => x.ChaveLeitura))
                .ForMember(dst => dst.Ipen, src => src.MapFrom(x => x.AlunoLeitor.Aluno.Detento.Ipen))
                .ForMember(dst => dst.Nome, src => src.MapFrom(x => x.AlunoLeitor.Aluno.Detento.Nome))
                .ForMember(dst => dst.Escolaridade, src => src.MapFrom(x => x.AlunoLeitor.Aluno.Escolaridade))
                .ForMember(dst => dst.Galeria, src => src.MapFrom(x => x.AlunoLeitor.Aluno.Detento.Galeria))
                .ForMember(dst => dst.Cela, src => src.MapFrom(x => x.AlunoLeitor.Aluno.Detento.Cela))
                .ForMember(dst => dst.LivroTitulo, src => src.MapFrom(x => x.Livro.Titulo))
                .ForMember(dst => dst.LivroAutorNome, src => src.MapFrom(x => x.Livro.LivroAutor.Nome))
                .ForMember(dst => dst.AlunoLeituraCronogramaNome, src => src.MapFrom(x => x.AlunoLeituraCronograma.Nome))
                .ForMember(dst => dst.AlunoLeituraCronogramaAnoReferencia, src => src.MapFrom(x => x.AlunoLeituraCronograma.AnoReferencia.ToString("yyyy")));
            CreateMap<AlunoLeitura, AlunoLeituraForRelatorioAvaliacao>()
                .ForMember(dst => dst.ChaveLeitura, src => src.MapFrom(x => x.ChaveLeitura))
                .ForMember(dst => dst.Ipen, src => src.MapFrom(x => x.AlunoLeitor.Aluno.Detento.Ipen))
                .ForMember(dst => dst.Nome, src => src.MapFrom(x => x.AlunoLeitor.Aluno.Detento.Nome))
                .ForMember(dst => dst.Escolaridade, src => src.MapFrom(x => x.AlunoLeitor.Aluno.Escolaridade))
                .ForMember(dst => dst.Galeria, src => src.MapFrom(x => x.AlunoLeitor.Aluno.Detento.Galeria))
                .ForMember(dst => dst.Cela, src => src.MapFrom(x => x.AlunoLeitor.Aluno.Detento.Cela))
                .ForMember(dst => dst.LivroTitulo, src => src.MapFrom(x => x.Livro.Titulo))
                .ForMember(dst => dst.LivroAutorNome, src => src.MapFrom(x => x.Livro.LivroAutor.Nome))
                .ForMember(dst => dst.AlunoLeituraCronogramaNome, src => src.MapFrom(x => x.AlunoLeituraCronograma.Nome))
                .ForMember(dst => dst.AlunoLeituraCronogramaAnoReferencia, src => src.MapFrom(x => x.AlunoLeituraCronograma.AnoReferencia.ToString("yyyy")))
                .ForMember(dst => dst.AvaliacaoCriterio1, src => src.MapFrom(x => x.AvaliacaoCriterio1))
                .ForMember(dst => dst.AvaliacaoCriterio2, src => src.MapFrom(x => x.AvaliacaoCriterio2))
                .ForMember(dst => dst.AvaliacaoCriterio3, src => src.MapFrom(x => x.AvaliacaoCriterio3))
                .ForMember(dst => dst.AvaliacaoCriterio4, src => src.MapFrom(x => x.AvaliacaoCriterio4))
                .ForMember(dst => dst.AvaliacaoCriterio5, src => src.MapFrom(x => x.AvaliacaoCriterio5))
                .ForMember(dst => dst.AvaliacaoCriterio6, src => src.MapFrom(x => x.AvaliacaoCriterio6))
                .ForMember(dst => dst.AvaliacaoCriterio7, src => src.MapFrom(x => x.AvaliacaoCriterio7))
                .ForMember(dst => dst.AvaliacaoConceito, src => src.MapFrom(x => x.AvaliacaoConceito))
                .ForMember(dst => dst.AvaliacaoConceitoJustificativa, src => src.MapFrom(x => x.AvaliacaoConceitoJustificativa))
                .ForMember(dst => dst.AvaliacaoObservacao, src => src.MapFrom(x => x.AvaliacaoObservacao))
                .ForMember(dst => dst.DataAvaliacao, src => src.MapFrom(x => x.DataAvaliacao.ToString("yyyy-MM-dd")));
            CreateMap<AlunoLeitor, AlunoLeitorESViewModel>()
                .ForMember(dst => dst.Id, src => src.MapFrom(x => x.Id))
                .ForMember(dst => dst.DetentoIpen, src => src.MapFrom(x => x.Aluno.Detento.Ipen))
                .ForMember(dst => dst.DetentoNome, src => src.MapFrom(x => x.Aluno.Detento.Nome))
                .ForMember(dst => dst.DetentoGaleria, src => src.MapFrom(x => x.Aluno.Detento.Galeria))
                .ForMember(dst => dst.DetentoCela, src => src.MapFrom(x => x.Aluno.Detento.Cela))
                .ForMember(dst => dst.DetentoRegime, src => src.MapFrom(x => x.Aluno.Detento.Regime));
            CreateMap<ServidorEstado, ServidorEstadoViewModel>()
            .ForMember(dst => dst.DataInicioGozo, src => src.MapFrom(x => x.DataInicioGozo.ToString("yyyy-MM-dd")))
            .ForMember(dst => dst.DataFimGozo, src => src.MapFrom(x => x.DataFimGozo.ToString("yyyy-MM-dd")))
                .ForMember(dst => dst.ServidorEstadoNome, src => src.MapFrom(x => x.Nome));
            CreateMap<ServidorEstadoReforco, ServidorEstadoReforcoViewModel>()
                .ForMember(dst => dst.DataPrincipalPlantao, src => src.MapFrom(x => x.DataPrevistaInicio.ToString("dd/MM/yyyy")))
                .ForMember(dst => dst.DataPrevistaInicio, src => src.MapFrom(x => x.DataPrevistaInicio.ToString("yyyy-MM-dd")))
                .ForMember(dst => dst.DataPrevistaFim, src => src.MapFrom(x => x.DataPrevistaFim.ToString("yyyy-MM-dd")));
            CreateMap<ServidorEstadoReforcoRegra, ServidorEstadoReforcoRegraViewModel>()
                .ForMember(dst => dst.Id, src => src.MapFrom(x => x.Id))
                .ForMember(dst => dst.TenantId, src => src.MapFrom(x => x.Tenant.Id))
                .ForMember(dst => dst.DataPrimeiroPlantao, src => src.MapFrom(x => x.DataPrimeiroPlantao.ToString("yyyy-MM-dd")))
                .ForMember(dst => dst.DataPrimeiraJanela, src => src.MapFrom(x => x.DataPrimeiraJanela.ToString("yyyy-MM-dd")))
                .ForMember(dst => dst.DataSegundaJanela, src => src.MapFrom(x => x.DataSegundaJanela.ToString("yyyy-MM-dd")))
                .ForMember(dst => dst.DataTerceiraJanela, src => src.MapFrom(x => x.DataTerceiraJanela.ToString("yyyy-MM-dd")));
            CreateMap<ServidorEstadoReforcoRegraVagaDia, ServidorEstadoReforcoRegraVagaDiaViewModel>();
            CreateMap<ApplicationNotification, ApplicationNotificationViewModel>()
                .ForMember(dst => dst.MessageDate, src => src.MapFrom(x => x.MessageDate.ToString("dd/MM/yyyy HH:mm")));
            CreateMap<FormularioLeituraDicaEscrita, FormularioLeituraDicaEscritaViewModel>()
                .ForMember(dst => dst.FormularioLeituraDicaEscritaDicas, src => src.MapFrom(x => x.FormularioLeituraDicaEscritaDicas));
            CreateMap<FormularioLeituraDicaEscritaDica, FormularioLeituraDicaEscritaDicaViewModel>();
        }
    }
}