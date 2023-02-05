using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Sigesp.Application.Interfaces;
using Sigesp.Domain.Enums;
using Sigesp.Application.ViewModels.Cards;
using Microsoft.AspNetCore.Authorization;
using System.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Sigesp.WebUI.Controllers
{
    [Authorize(Roles = "Master,"+
                       "Alunos-Leituras_Todas,"+
                       "Alunos-Leituras_Novo,"+
                       "Alunos-Leituras_Edicao,"+
                       "Alunos-Leituras_Delete,"+
                       "Alunos-Leituras-Cronogramas_Todos")]
    public class AlunoLeituraController : BaseController
    {
        private readonly IAlunoLeitorAppService _alunoLeitorManager;
        private readonly IAlunoLeituraAppService _alunoLeituraManager;
        private readonly IAlunoLeituraCronogramaAppService _alunoLeituraCronogramaManager;
        private readonly ILivroAppService _livroManager;
        private readonly IAlunoLeituraCronogramaAppService _alcManager;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IHttpContextAccessor _httpContextAccessor;
        
        public AlunoLeituraController(IAlunoLeitorAppService alunoLeitorManager,
                                      IAlunoLeituraAppService alunoLeituraManager,
                                      IAlunoLeituraCronogramaAppService alunoLeituraCronogramaManager,
                                      ILivroAppService livroManager,
                                      IAlunoLeituraCronogramaAppService alcManager,
                                      IWebHostEnvironment webHostEnvironment,
                                      IHttpContextAccessor httpContextAccessor)
                                    
        {
            _alunoLeitorManager = alunoLeitorManager;
            _alunoLeituraManager = alunoLeituraManager;
            _alunoLeituraCronogramaManager = alunoLeituraCronogramaManager;
            _livroManager = livroManager;
            _alcManager = alcManager;
            _webHostEnvironment = webHostEnvironment;
            _httpContextAccessor = httpContextAccessor;
        }

        [Authorize(Roles = "Master, Alunos-Leituras_Todas")]
        public async Task<IActionResult> Todas()
        {
            // var total = _alunoLeituraManager
            //                 .GetTotalAtivos();
            var leituras = await _alunoLeituraManager
                                        .GetAllAsync();

            //Dados cards
            var alunoLeituraCardViewModel = new AlunoLeituraCardViewModel()
            {
                Total = leituras.Count(),
                LeituraLivroTipoSocial = leituras.Count(x => x.LeituraTipo == LeituraTipoEnum.LEITURA_SOCIAL.ToString()),
                LeituraLivroTipoRemissao = leituras.Count(x => x.LeituraTipo == LeituraTipoEnum.LEITURA_REMICAO.ToString()),
                AlunoLeituraTipos = EnumExtensions<LeituraTipoEnum>.GetNames().ToList(),
                AvaliacaoCriterios = EnumExtensions<AlunoLeituraAvaliacaoCriterioEnum>.GetNames().ToList(),
                AvaliacaoConceitos = EnumExtensions<AlunoLeituraAvaliacaoConceitoEnum>.GetNames().ToList()
            };

            return View(alunoLeituraCardViewModel);
        }

        [Authorize(Roles = "Master, Alunos-Leituras_Novo")]
        public IActionResult Novo()
        {
            return View();
        }

        [Authorize(Roles = "Master, Alunos-Leituras_Edicao")]
        public IActionResult Edicao()
        {
            return View();
        }

        [Authorize(Roles = "Master, Alunos-Leituras_Delete")]
        public IActionResult Delete()
        {
            return View();
        }

        [Authorize(Roles = "Master, Alunos-Leituras-Cronogramas_Todos")]
        public async Task<IActionResult> Cronogramas()
        {
            var total = await _alunoLeituraCronogramaManager.GetTotalWithIgnoreQueryFilterAsync();
            var ativos = await _alunoLeituraCronogramaManager.GetTotalAtivosAsync();
            var inativos = await _alunoLeituraCronogramaManager.GetTotalInativosAsync();

            //Dados cards
            var alunoLeituraCronogramaCardViewModel = new AlunoLeituraCronogramaCardViewModel()
            {
                Total = total,
                Ativos = ativos,
                Inativos = inativos,
            };

            return View(alunoLeituraCronogramaCardViewModel);
        }
    }
}