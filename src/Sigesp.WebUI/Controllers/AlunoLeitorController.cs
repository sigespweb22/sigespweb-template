using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Sigesp.Application.Interfaces;
using Sigesp.Domain.Enums;
using Sigesp.Application.ViewModels.Cards;
using Microsoft.AspNetCore.Authorization;
using System.Data;
using System.Threading.Tasks;

namespace Sigesp.WebUI.Controllers
{
    [Authorize(Roles = "Master, Alunos-Leitores_Todos,"+
                        "Alunos-Leitores_Novo, Alunos-Leitores_Edicao,"+
                        "Alunos-Leitores_Delete")]
    public class AlunoLeitorController : BaseController
    {
        private readonly IDetentoAppService _detentoManager;
        private readonly IAlunoAppService _alunoManager;
        private readonly IAlunoLeitorAppService _alunoLeitorManager;
        private readonly IProfessorAppService _professorManager;
        private readonly ILivroGeneroAppService _livroGeneroManager;
        
        public AlunoLeitorController(IDetentoAppService detentoManager,
                                     IAlunoAppService alunoManager,
                                     IAlunoLeitorAppService alunoLeitorManager,
                                     IProfessorAppService professorManager,
                                     ILivroGeneroAppService livroGeneroManager)
                                    
        {
            _detentoManager = detentoManager;
            _alunoManager = alunoManager;
            _alunoLeitorManager = alunoLeitorManager;
            _professorManager = professorManager;
            _livroGeneroManager = livroGeneroManager;
        }

        [Authorize(Roles = "Master, Alunos-Leitores_Todos")]
        public async Task<IActionResult> TodosAsync()
        {
            var alunos = await _alunoManager
                                    .GetAllAsync();
            
            var professores = await _professorManager
                                        .GetAllNomesAsync();

            var livroGeneros = _livroGeneroManager
                                    .GetAll()
                                    .Select(x => x.Nome)
                                    .ToList();

            var ativos = _alunoLeitorManager.GetTotalAtivos();
            var inativos = _alunoLeitorManager.GetTotalInativos();
            var total = _alunoLeitorManager.GetTotalWithIgnoreQueryFilter();     
            
            //Dados cards
            var alunoLeitorCardViewModel = new AlunoLeitorCardViewModel()
            {
                Total = total,
                Ativos = ativos,
                Inativos = inativos,
                Professores = professores.ToList(),
                LivroGeneros = livroGeneros,
                Alunos = alunos.Select(x => x.Detento.Nome).ToList(),
                OcorrenciasDesistencia = EnumExtensions<AlunoLeitorOcorrenciaDesistenciaEnum>.GetNames().ToList()
            };

            return View(alunoLeitorCardViewModel);
        }

        [Authorize(Roles = "Master, Alunos-Leitores_Novo")]
        public IActionResult Novo()
        {
            return View();
        }

        [Authorize(Roles = "Master, Alunos-Leitores_Edicao")]
        public IActionResult Edicao()
        {
            return View();
        }

        [Authorize(Roles = "Master, Alunos-Leitores_Delete")]
        public IActionResult Delete()
        {
            return View();
        }
    }
}