using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Sigesp.Application.ViewModels.Dashboards.Educacao;
using System;
using System.Linq;
using Sigesp.Application.Interfaces;
using Sigesp.Domain.Enums;
using Sigesp.Application.ViewModels;
using System.Threading.Tasks;

namespace Sigesp.WebUI.Controllers
{
    [Authorize(Roles = "Master, Dashboard_Laboral, Dashboard_Educacao")]
    public class DashboardController : BaseController
    {
        private readonly ILivroAppService _livroManager;
        private readonly IAlunoLeitorAppService _alManager;
        private readonly IDetentoAppService _detentoManager;
        private readonly IAlunoAppService _alunoManager;
        private readonly IAlunoLeituraAppService _alunoLeituraManager;

        public DashboardController(ILivroAppService livroManager,
                                   IAlunoLeitorAppService alManager,
                                   IDetentoAppService detentoManager,
                                   IAlunoAppService alunoManager,
                                   IAlunoLeituraAppService alunoLeituraManager)
        {
            _livroManager = livroManager;
            _alManager = alManager;
            _detentoManager = detentoManager;
            _alunoManager = alunoManager;
            _alunoLeituraManager = alunoLeituraManager;
        }

        public IActionResult Todos() => View();
        public IActionResult Juridico() => View();

        [Authorize(Roles = "Master, Dashboard_Laboral")]
        public IActionResult Laboral() => View();

        [Authorize(Roles = "Master, Dashboard_Meu-Reforco")]
        public IActionResult MeuReforco() => View();
        
        [Authorize(Roles = "Master, Dashboard_Educacao")]
        public async Task<IActionResult> Educacao()
        {
            var dashboardEducacaoViewModel = new DashboardEducacaoViewModel();
            dashboardEducacaoViewModel.ChartAcervoLiterario = new ChartAcervoLiterario();
            dashboardEducacaoViewModel.ChartIndiceAdesaoProjetoLeitura = new ChartIndiceAdesaoProjetoLeitura();
            dashboardEducacaoViewModel.ChartIndiceEscolaridadeAlunos = new ChartIndiceEscolaridadeAlunos();

            #region Dados indicador ACERVO LITERÁRIO
            dashboardEducacaoViewModel.ChartAcervoLiterario.Total = _livroManager.GetTotalWithIgnoreQueryFilter();

            dashboardEducacaoViewModel.ChartAcervoLiterario.AtivosQ = _livroManager.GetTotalAtivos();
            dashboardEducacaoViewModel.ChartAcervoLiterario.AtivosP = (Math.Round(((double)dashboardEducacaoViewModel.ChartAcervoLiterario.AtivosQ / dashboardEducacaoViewModel.ChartAcervoLiterario.Total) * 100)).ToString() + "%";
            
            dashboardEducacaoViewModel.ChartAcervoLiterario.InativosQ = _livroManager.GetTotalInativos();
            dashboardEducacaoViewModel.ChartAcervoLiterario.InativosP = (Math.Round(((double)dashboardEducacaoViewModel.ChartAcervoLiterario.InativosQ / dashboardEducacaoViewModel.ChartAcervoLiterario.Total) * 100)).ToString() + "%";
            
            dashboardEducacaoViewModel.ChartAcervoLiterario.DisponiveisQ = _livroManager.GetTotalDisponiveis();
            dashboardEducacaoViewModel.ChartAcervoLiterario.DisponiveisP = (Math.Round(((double)dashboardEducacaoViewModel.ChartAcervoLiterario.DisponiveisQ / dashboardEducacaoViewModel.ChartAcervoLiterario.AtivosQ) * 100)).ToString() + "%";
            
            dashboardEducacaoViewModel.ChartAcervoLiterario.IndisponiveisQ = _livroManager.GetTotalIndisponiveis();
            dashboardEducacaoViewModel.ChartAcervoLiterario.IndisponiveisP = (Math.Round(((double)dashboardEducacaoViewModel.ChartAcervoLiterario.IndisponiveisQ / dashboardEducacaoViewModel.ChartAcervoLiterario.AtivosQ) * 100)).ToString() + "%";
            #endregion Dados indicador ACERVO LITERÁRIO
            
            #region Dados indicador ÍNDICE ADESÃO PROJETO LEITURA
            var leitoresAtivos = _alManager.GetTotalAtivos();
            var detentosAtivos = _detentoManager.GetTotalAtivosAsync();

            if (leitoresAtivos > 0 &&
                detentosAtivos.Result > 0)
            {
                var leitoresAtivosRound = Math.Round((double) leitoresAtivos);
                var detentosAtivosRound = Math.Round((double) detentosAtivos.Result);

                dashboardEducacaoViewModel.ChartIndiceAdesaoProjetoLeitura.ParticipantesQ = leitoresAtivos;
                dashboardEducacaoViewModel
                        .ChartIndiceAdesaoProjetoLeitura
                        .ParticipantesP = Math.Round(((leitoresAtivosRound / detentosAtivosRound) * 100), 0).ToString() + "%";

                dashboardEducacaoViewModel
                        .ChartIndiceAdesaoProjetoLeitura.NaoParticipantesQ = 
                            detentosAtivos.Result - leitoresAtivos;
                dashboardEducacaoViewModel
                        .ChartIndiceAdesaoProjetoLeitura
                        .NaoParticipantesP = Math.Round(((double) dashboardEducacaoViewModel
                                                .ChartIndiceAdesaoProjetoLeitura
                                                .NaoParticipantesQ / detentosAtivosRound) * 100, 0).ToString() + "%";
            }
            else
            {
                dashboardEducacaoViewModel.ChartIndiceAdesaoProjetoLeitura.ParticipantesP = "0" + "%";
                dashboardEducacaoViewModel.ChartIndiceAdesaoProjetoLeitura.NaoParticipantesP = "0"+ "%";
            }

            dashboardEducacaoViewModel.ChartIndiceAdesaoProjetoLeitura.TotalDetentos = detentosAtivos.Result;
            #endregion Dados indicador ÍNDICE ADESÃO PROJETO LEITURA

            #region Dados indicador ÍNDICE ESCOLARIDADE ALUNOS
            var alunosAtivos = _alunoManager.GetTotalAtivos();
            var alunosNI = _alunoManager.GetTotalByEscolaridade(EscolaridadeEnum.NAO_INFORMADO);
            var alunosEFI = _alunoManager.GetTotalByEscolaridade(EscolaridadeEnum.ENSINO_FUNDAMENTAL_I);
            var alunosEFII = _alunoManager.GetTotalByEscolaridade(EscolaridadeEnum.ENSINO_FUNDAMENTAL_II);
            var alunosEM = _alunoManager.GetTotalByEscolaridade(EscolaridadeEnum.ENSINO_MEDIO);
            var alunosES = _alunoManager.GetTotalByEscolaridade(EscolaridadeEnum.ENSINO_SUPERIOR);

            if (alunosNI > 0 && alunosAtivos > 0)
            {
                dashboardEducacaoViewModel.ChartIndiceEscolaridadeAlunos.NaoInformadoQ = alunosNI;
                dashboardEducacaoViewModel
                    .ChartIndiceEscolaridadeAlunos
                    .NaoInformadoP = Math.Round((((decimal)alunosNI / alunosAtivos) * 100), 0).ToString() + "%";
            }
            else
            {
                dashboardEducacaoViewModel
                    .ChartIndiceEscolaridadeAlunos
                    .NaoInformadoP = "0%";
            }
            
            if (alunosEFI > 0 && alunosAtivos > 0)
            {
                dashboardEducacaoViewModel.ChartIndiceEscolaridadeAlunos.EnsinoFundamentalIQ = alunosEFI;
                dashboardEducacaoViewModel
                    .ChartIndiceEscolaridadeAlunos
                    .EnsinoFundamentalIP = Math.Round((((decimal)alunosEFI / alunosAtivos) * 100), 0).ToString() + "%";
            }
            else
            {
                dashboardEducacaoViewModel
                    .ChartIndiceEscolaridadeAlunos
                    .EnsinoFundamentalIP = "0%";
            }
            
            if (alunosEFII > 0 && alunosAtivos > 0)
            {
                dashboardEducacaoViewModel.ChartIndiceEscolaridadeAlunos.EnsinoFundamentalIIQ = alunosEFII;
                dashboardEducacaoViewModel
                    .ChartIndiceEscolaridadeAlunos
                    .EnsinoFundamentalIIP = Math.Round((((decimal)alunosEFII / alunosAtivos) * 100), 0).ToString() + "%";
            }
            else
            {
                dashboardEducacaoViewModel
                    .ChartIndiceEscolaridadeAlunos
                    .EnsinoFundamentalIIP = "0%";
            }
            
            if (alunosEM > 0 && alunosAtivos > 0)
            {
                dashboardEducacaoViewModel.ChartIndiceEscolaridadeAlunos.EnsinoMedioQ = alunosEM;
                dashboardEducacaoViewModel
                    .ChartIndiceEscolaridadeAlunos
                    .EnsinoMedioP = Math.Round((((decimal)alunosEM / alunosAtivos) * 100), 0).ToString() + "%";
            }
            else
            {
                dashboardEducacaoViewModel
                    .ChartIndiceEscolaridadeAlunos
                    .EnsinoMedioP = "0%";
            }
            
            if (alunosES > 0 && alunosAtivos > 0)
            {
                dashboardEducacaoViewModel.ChartIndiceEscolaridadeAlunos.EnsinoSuperiorQ = alunosES;
                dashboardEducacaoViewModel
                    .ChartIndiceEscolaridadeAlunos
                    .EnsinoSuperiorP = Math.Round((((decimal)alunosES / alunosAtivos) * 100), 0).ToString() + "%";
            }
            else
            {
                dashboardEducacaoViewModel
                    .ChartIndiceEscolaridadeAlunos
                    .EnsinoSuperiorP = "0%";
            }

            dashboardEducacaoViewModel
                .ChartIndiceEscolaridadeAlunos
                .TotalAlunos = alunosNI + alunosEFI + alunosEFII + alunosEM + alunosES;
            #endregion Dados indicador ÍNDICE ESCOLARIDADE ALUNOS

            #region Dados indicador CONCEITO LEITURAS
            dashboardEducacaoViewModel.ChartIndiceAvaliacaoConceito = new ChartIndiceAvaliacaoConceito();

            Int64 totalLeituras;
            Int64 pendenteQ;
            Int64 aprovadoQ;
            Int64 insuficienteQ;
            Int64 desistenciaQ;
            Int64 naoCumprimentoQ;

            try
            {
                totalLeituras = await _alunoLeituraManager.GetTotalByLeituraTipoAsync(LeituraTipoEnum.LEITURA_REMICAO);
                pendenteQ = await _alunoLeituraManager.GetTotalByAvaliacaoConceitoAsync(AlunoLeituraAvaliacaoConceitoEnum.PENDENTE);
                aprovadoQ = await _alunoLeituraManager.GetTotalByAvaliacaoConceitoAsync(AlunoLeituraAvaliacaoConceitoEnum.APROVADO);
                insuficienteQ = await _alunoLeituraManager.GetTotalByAvaliacaoConceitoAsync(AlunoLeituraAvaliacaoConceitoEnum.INSUFICIENTE);
                desistenciaQ = await _alunoLeituraManager.GetTotalByAvaliacaoConceitoAsync(AlunoLeituraAvaliacaoConceitoEnum.DESISTENCIA);
                naoCumprimentoQ = await _alunoLeituraManager.GetTotalByAvaliacaoConceitoAsync(AlunoLeituraAvaliacaoConceitoEnum.NAO_CUMPRIMENTO);
            }
            catch (Exception ex) { return StatusCode(400, ex); }

            /// PENDENTE
            if (pendenteQ > 0 && totalLeituras > 0)
            {
                dashboardEducacaoViewModel
                    .ChartIndiceAvaliacaoConceito
                    .PendenteQ = pendenteQ;

                dashboardEducacaoViewModel
                    .ChartIndiceAvaliacaoConceito
                    .PendenteP = Math.Round((((decimal)pendenteQ / totalLeituras) * 100), 0).ToString() + "%";
            }
            else
            {
                dashboardEducacaoViewModel
                    .ChartIndiceAvaliacaoConceito
                    .PendenteP = "0%";
            }
            
            /// APROVADO
            if (aprovadoQ > 0 && totalLeituras > 0)
            {
                dashboardEducacaoViewModel
                    .ChartIndiceAvaliacaoConceito
                    .AprovadoQ = aprovadoQ;

                dashboardEducacaoViewModel
                    .ChartIndiceAvaliacaoConceito
                    .AprovadoP = Math.Round((((decimal)aprovadoQ / totalLeituras) * 100), 0).ToString() + "%";
            }
            else
            {
                dashboardEducacaoViewModel
                    .ChartIndiceAvaliacaoConceito
                    .AprovadoP = "0%";
            }

            /// INSUFICIENTE
            if (insuficienteQ > 0 && totalLeituras > 0)
            {
                dashboardEducacaoViewModel
                    .ChartIndiceAvaliacaoConceito
                    .InsuficienteQ = insuficienteQ;

                dashboardEducacaoViewModel
                    .ChartIndiceAvaliacaoConceito
                    .InsuficienteP = Math.Round((((decimal)insuficienteQ / totalLeituras) * 100), 0).ToString() + "%";
            }
            else
            {
                dashboardEducacaoViewModel
                    .ChartIndiceAvaliacaoConceito
                    .InsuficienteP = "0%";
            }

             /// DESISTÊNCIA
            if (desistenciaQ > 0 && totalLeituras > 0)
            {
                dashboardEducacaoViewModel
                    .ChartIndiceAvaliacaoConceito
                    .DesistenciaQ = desistenciaQ;

                dashboardEducacaoViewModel
                    .ChartIndiceAvaliacaoConceito
                    .DesistenciaP = Math.Round((((decimal)desistenciaQ / totalLeituras) * 100), 0).ToString() + "%";
            }
            else
            {
                dashboardEducacaoViewModel
                    .ChartIndiceAvaliacaoConceito
                    .DesistenciaP = "0%";
            }

            /// NAO_CUMPRIMENTO
            if (naoCumprimentoQ > 0 && totalLeituras > 0)
            {
                dashboardEducacaoViewModel
                    .ChartIndiceAvaliacaoConceito
                    .NaoCumprimentoQ = naoCumprimentoQ;

                dashboardEducacaoViewModel
                    .ChartIndiceAvaliacaoConceito
                    .NaoCumprimentoP = Math.Round((((decimal)naoCumprimentoQ / totalLeituras) * 100), 0).ToString() + "%";
            }
            else
            {
                dashboardEducacaoViewModel
                    .ChartIndiceAvaliacaoConceito
                    .NaoCumprimentoP = "0%";
            }
            
            dashboardEducacaoViewModel
                    .ChartIndiceAvaliacaoConceito
                    .TotalLeituras = pendenteQ + aprovadoQ + insuficienteQ + desistenciaQ + naoCumprimentoQ;
            #endregion
            
            return View(dashboardEducacaoViewModel);
        }
    }
}