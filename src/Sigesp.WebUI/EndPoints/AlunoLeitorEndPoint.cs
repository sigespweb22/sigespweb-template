using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sigesp.Application.Interfaces;
using Sigesp.Application.ViewModels;
using Sigesp.WebUI.Controllers;
using Microsoft.AspNetCore.Authorization;
using AutoMapper;
using Sigesp.Infra.Data.Context;
using Sigesp.WebUI.Helpers;
using Sigesp.WebUI.Extensions;
using Sigesp.Domain.Models.DataTable;
using Sigesp.Domain.Interfaces;
using Sigesp.Domain.Models;
using Sigesp.Domain.Enums;

namespace Sigesp.WebUI.EndPoints
{
    [Authorize(Roles = "Master, Alunos-Leitores_Novo,"+
                       "Alunos-Leitores_Edicao, Alunos-Leitores_Delete, Alunos-Leitores_Lista")]
    [ApiController]
    [Route("api/alunos-leitores")]
    public class AlunoLeitorEndPoint : ApiController
    {
        private readonly IAlunoLeitorAppService _alunoLeitorManager;
        private readonly IAlunoLeitorRepository _alunoLeitorRepository;
        private readonly SigespDbContext _context;
        private readonly IMapper _mapper;
        private readonly ITenantRepository _tenantRepository;
        private readonly IUnitOfWork _unitOfWork;

        public AlunoLeitorEndPoint(IAlunoLeitorAppService alunoLeitorManager,
                                    SigespDbContext context,
                                    IMapper mapper,
                                    IAlunoLeitorRepository alunoLeitorRepository,
                                    ITenantRepository tenantRepository,
                                    IUnitOfWork unitOfWork)
        {
            _alunoLeitorManager = alunoLeitorManager;
            _alunoLeitorRepository = alunoLeitorRepository;
            _context = context;
            _mapper = mapper;
            _tenantRepository = tenantRepository;
            _unitOfWork = unitOfWork;
        }

        #region Methods CRUD
        [Authorize(Roles = "Master, Alunos-Leitores_Novo")]
        [Route("novo")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> NovoAsync([FromBody]AlunoLeitorViewModel alunoLeituraViewModel)
        {
            var commandSend  = await _alunoLeitorManager.AddAsync(alunoLeituraViewModel);
            if (commandSend.ErrorMessages != null || !commandSend.ErrorMessages.Any())
                foreach (var error in commandSend.ErrorMessages)
                    AddError(error);

            return CustomResponse(commandSend);
        }

        [Authorize(Roles = "Master, Alunos-Leitores_Edicao")]
        [Route("edicao")]
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> EdicaoAsync([FromBody]AlunoLeitorViewModel alunoLeitorViewModel)
        {
            var commandSend  = await _alunoLeitorManager.UpdateAsync(alunoLeitorViewModel);

            if (commandSend.ErrorMessages != null || !commandSend.ErrorMessages.Any())
                foreach (var error in commandSend.ErrorMessages)
                    AddError(error);

            return CustomResponse(alunoLeitorViewModel);
        }

        [Authorize(Roles = "Master, Alunos-Leitores_Delete")]
        [Route("delete")]
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult Delete([FromBody]AlunoLeitorViewModel alunoLeitorViewModel)
        {
            var commandSend  = _alunoLeitorManager.Remove((Guid)alunoLeitorViewModel.Id);
            
            if (commandSend.ErrorMessages != null || !commandSend.ErrorMessages.Any())
                foreach (var error in commandSend.ErrorMessages)
                    AddError(error);

            return CustomResponse(alunoLeitorViewModel);
        }

        [Authorize(Roles = "Master, Alunos-Leitores_Lista")]
        [Route("lista")]
        [HttpPost]
        public async Task<IActionResult> Lista([FromForm] DataTableServerSideRequest request)
        {
            //Quando o método for acionado por uma busca
            //Deverá identificar qual o tipo de dado, afim de direcionar a coluna de pesquisa
            //Permitindo assim somente pesquisa de uma condicional (Ipen/Nome)
            if (!request.Search.Value.IsNullOrEmpty())
            {
                var valueSearch = request.Search.Value;

                if (NumericHelpers.HasNumber(valueSearch))
                {
                    //havendo numeros na string
                    //deixo ativado somente o searcheable do ipen
                    foreach (var item in request.Columns)
                    {
                        if (item.Name != "Aluno.Detento.Ipen")
                            item.Searchable = false;
                    }
                }
                else
                {
                    //não havendo números na string
                    //deixo ativado somente o searcheable do nome
                    foreach (var item in request.Columns)
                    {
                        if (item.Name != "Aluno.Detento.Nome")
                            item.Searchable = false;
                    }
                }
            }

            var result = await _alunoLeitorManager
                                    .GetWithDataTableResultAsync(request);

            return Ok(new {
                Data = result.Data,
                Draw = result.Draw,
                RecordsFiltered  = result._iRecordsDisplay,
                RecordsTotal = result._iRecordsTotal,
                Success = true
            });
        }

        [Route("get-by-detento-ipen")]
        public IActionResult GetByDetentoIpen([FromBody]string ipen)
        {
            if (ipen.IsNullOrEmpty())
                return BadRequest("Ipen requerido.");

            var result = new AlunoLeitorViewModel();
            try
            {
                result = _alunoLeitorManager
                                .GetByDetentoIpen(Convert.ToInt32(ipen));
            }
            catch { throw; }
            return CustomResponse(result);
        }

        [Route("get-all-by-detento-nome")]
        public IActionResult GetAllByDetentoNome([FromBody]string nome)
        {
            try
            {
                if (nome.IsNullOrEmpty())
                    return BadRequest("Nome requerido!");

                var result = _alunoLeitorManager
                                    .GetAllByDetentoNome(nome);

                if (result == null)
                {
                    AddError("Nenhum aluno leitor encontrado com o nome informado.");
                }

                return CustomResponse(result);
            }
            catch { throw; }
        }

        [Route("get-all-for-add")]
        public async Task<IActionResult> GetAllForAddAsync()
        {
            IEnumerable<AlunoLeitorESViewModel> result = new List<AlunoLeitorESViewModel>();
            try
            {
                result = await _alunoLeitorManager
                                        .GetAllForAddAsync();
            }
            catch { throw; }
            return CustomResponse(result);
        }
        #endregion

        [Route("get-nome-by-id")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> GetNomeByIdAsync([FromBody]string id)
        {
            try
            {
                if (string.IsNullOrEmpty(id))
                    return CustomResponse(false, "Id requerido!", "");
            } catch { throw; }

            var alunoLeitor = new AlunoLeitor();
            try
            {
                alunoLeitor = await _context
                                        .AlunosLeitores
                                        .IgnoreQueryFilters()
                                        .Include(x => x.Aluno)
                                        .ThenInclude(x => x.Detento)
                                        .Where(x => x.Id == Guid.Parse(id))
                                        .FirstOrDefaultAsync();
            }
            catch { throw; }
            if (alunoLeitor == null) return StatusCode(404);
            return CustomResponse(true, null, alunoLeitor.Aluno.Detento.Nome);
        }

        /// <summary>
        /// Inativa todos os leitores ativos e informa ocorrência FIM_ANO_LETIVO",
        /// </summary>
        /// <param></param>
        /// <returns>Código 204 se operação for realizada com sucesso</returns>
        /// <response code="204">Sucesso</response>
        /// <response code="400">Problemas de validação ou dados nulos</response>
        /// <response code="404">Nenhum aluno leitor encontrado</response>
        /// <response code="500">Erro interno desconhecido</response>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        [Route("encerrar-ano-letivo")]
        [HttpPut]
        public async Task<IActionResult> EncerrarAnoLetivoAsync()
        {
            #region Resolve tenancy
            Guid tenantId;
            try
            {
                tenantId = (Guid) StringHelpers.ExtractTenantId(await _tenantRepository.GetTenantIdAsync());
            }
            catch (Exception ex) { AddError(ex.Message); return CustomResponse(500); }

            if (tenantId == Guid.Empty)
            {
                AddError("Não foi possível encontrar a sua UNIDADE. Tente novamente, persistindo o erro informe a equipe técnica do sistema");
                return CustomResponsePassCode(500);
            }
            #endregion

            #region Get data
            var alunosLeitores = new List<AlunoLeitor>();
            try
            {
                alunosLeitores = await _context
                                            .AlunosLeitores
                                            .Where(x => x.TenantId == tenantId)
                                            .ToListAsync();
            }
            catch (Exception ex) { AddError(ex.Message); return CustomResponse(500); }

            if (alunosLeitores == null)
            {
                AddError("Nenhum registro encontrado.");
                return CustomResponsePassCode(404);
            }
            #endregion

            #region Update data
            foreach (var alunoLeitor in alunosLeitores)
            {
                alunoLeitor.IsDeleted = true;
                alunoLeitor.OcorrenciaDesistencia = AlunoLeitorOcorrenciaDesistenciaEnum.FIM_ANO_LETIVO;
                alunoLeitor.DataOcorrenciaDesistencia = DateTime.Now;

                _context.AlunosLeitores.Update(alunoLeitor);
            }
            #endregion

            #region Commit
            try
            {
                _unitOfWork.Commit();
            }
            catch (Exception ex) { AddError(ex.Message); return CustomResponse(500); }
            #endregion

            return CustomResponsePassCode(204);
        }
    }
}