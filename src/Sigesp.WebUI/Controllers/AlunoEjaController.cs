using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Sigesp.Application.Interfaces;
using Sigesp.Domain.Enums;
using Sigesp.Application.ViewModels.Cards;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Sigesp.WebUI.Controllers
{
    [Authorize(Roles = "Master, Alunos-Eja_Todos,"+
                        "Alunos-Eja_Novo, Alunos-Eja_Edicao,"+
                        "Alunos-Eja_Delete")]
    public class AlunoEjaController : BaseController
    {
        private readonly IAlunoAppService _alunoManager;
        private readonly IAlunoEjaAppService _alunoEjaManager;
        private readonly IDisciplinaAppService _disciplinaManager;
        
        public AlunoEjaController(IAlunoAppService alunoManager,
                                  IAlunoEjaAppService alunoEjaManager,
                                  IDisciplinaAppService disciplinaManager)
                                    
        {
            _alunoManager = alunoManager;
            _alunoEjaManager = alunoEjaManager;
            _disciplinaManager = disciplinaManager;
        }

        [Authorize(Roles = "Master, Alunos-Eja_Todos")]
        public async Task<IActionResult> TodosAsync()
        {
            var alunos = await _alunoManager
                                    .GetAllAsync();
            
            var alunosMapped = new List<string>();
            try
            {
                alunosMapped = alunos.Select(x => x.DetentoNome).ToList();
            }
            catch { throw; }
            
            var inativos = await _alunoEjaManager
                                    .GetTotalInativosAsync();
            
            var cursando = await _alunoEjaManager
                                        .GetTotalByFaseStatusAsync(AlunoEjaFaseStatusEnum.EM_CURSO);

            var concluido = await _alunoEjaManager
                                    .GetTotalByFaseStatusAsync(AlunoEjaFaseStatusEnum.CONCLUIDA);
            
            var concluidoParcialmente = await _alunoEjaManager
                                                .GetTotalByFaseStatusAsync(AlunoEjaFaseStatusEnum.CONCLUIDA_PARCIALMENTE);

            var naoConcluido = await _alunoEjaManager
                                        .GetTotalByFaseStatusAsync(AlunoEjaFaseStatusEnum.NAO_CONCLUIDA);

            var eFundamentalI = await _alunoEjaManager
                                        .GetTotalByCursoAsync(CursoEnum.ENSINO_FUNDAMENTAL_I);
                                    
            var eFundamentalII = await _alunoEjaManager
                                            .GetTotalByCursoAsync(CursoEnum.ENSINO_FUNDAMENTAL_II);

            var eMedio = await _alunoEjaManager
                                    .GetTotalByCursoAsync(CursoEnum.ENSINO_MEDIO);

            var matutinos = await _alunoEjaManager
                                    .GetTotalByTurnoPeriodoAsync(TurnoEnum.MATUTINO);

            var vespertinos = await _alunoEjaManager
                                        .GetTotalByTurnoPeriodoAsync(TurnoEnum.VESPERTINO);
                                    
            var noturnos = await _alunoEjaManager
                                    .GetTotalByTurnoPeriodoAsync(TurnoEnum.NOTURNO);
            
            //Dados cards
            var alunoEjaCardViewModel = new AlunoEjaCardViewModel()
            {
                Cursando = cursando,
                Concluido = concluido,
                ConcluidoParcialmente = concluidoParcialmente,
                NaoConcluido = naoConcluido,
                Inativos = inativos,
                Disciplinas = EnumExtensions<AlunoEjaDisciplinaEnum>.GetNames().ToList(),
                Alunos = alunosMapped,
                Cursos = EnumExtensions<CursoEnum>.GetNames().ToList(),
                Turnos = EnumExtensions<TurnoEnum>.GetNames().ToList(),
                Fases = EnumExtensions<FaseEnum>.GetNames().ToList(),
                FaseStatuses = EnumExtensions<AlunoEjaFaseStatusEnum>.GetNames().ToList(),
                OcorrenciasDesistencia = EnumExtensions<AlunoLeitorOcorrenciaDesistenciaEnum>.GetNames().ToList(),
                EFundamentalI = eFundamentalI,
                EFundamentalII = eFundamentalII,
                EMedio = eMedio,
                Matutinos = matutinos,
                Vespertinos = vespertinos,
                Noturnos = noturnos
            };

            return View(alunoEjaCardViewModel);
        }

        [Authorize(Roles = "Master, Alunos-Eja_Novo")]
        public IActionResult Novo()
        {
            return View();
        }

        [Authorize(Roles = "Master, Alunos-Eja_Edicao")]
        public IActionResult Edicao()
        {
            return View();
        }

        [Authorize(Roles = "Master, Alunos-Eja_Delete")]
        public IActionResult Delete()
        {
            return View();
        }
    }
}