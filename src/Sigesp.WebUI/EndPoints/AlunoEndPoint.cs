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
using Sigesp.WebUI.Helpers.DataTable;
using Sigesp.Domain.Interfaces;

namespace Sigesp.WebUI.EndPoints
{
    [Authorize(Roles = "Master, "+
                       "Alunos_Novo, " +
                       "Alunos_Edicao,"+
                       "Alunos_Delete,"+
                       "Alunos_Lista"+
                       "Alunos_Lista_Um")]
    [ApiController]
    [Route("api/alunos")]
    public class AlunoEndPoint : ApiController
    {
        private readonly IAlunoAppService _alunoManager;
        private readonly SigespDbContext _context;
        private readonly IMapper _mapper;
        private readonly ITenantRepository _tenantRepository;

        public AlunoEndPoint(IAlunoAppService alunoManager,
                             SigespDbContext context,
                             IMapper mapper,
                            ITenantRepository tenantRepository)
        {
            _alunoManager = alunoManager;
            _context = context;
            _mapper = mapper;
            _tenantRepository = tenantRepository;
        }

        #region Métodos Genéricos
        [Authorize(Roles = "Master, Alunos_Novo")]
        [Route("novo")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult Novo([FromBody]AlunoViewModel alunoViewModel)
        {
            var commandSend  = _alunoManager.Add(alunoViewModel);

            if (commandSend.ErrorMessages != null)
                foreach (var error in commandSend.ErrorMessages)
                    AddError(error);

            return CustomResponse(alunoViewModel);
        }

        [Authorize(Roles = "Master, Alunos_Edicao")]
        [Route("edicao")]
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult Edicao([FromBody]AlunoViewModel alunoViewModel)
        {
            var commandSend  = _alunoManager.Update(alunoViewModel);

            if (commandSend.ErrorMessages != null || !commandSend.ErrorMessages.Any())
                foreach (var error in commandSend.ErrorMessages)
                    AddError(error);

            return CustomResponse(alunoViewModel);
        }

        [Authorize(Roles = "Master, Alunos_Delete")]
        [Route("delete")]
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult Delete([FromBody]AlunoViewModel alunoViewModel)
        {
            var commandSend  = _alunoManager.Remove((Guid)alunoViewModel.Id);
            
            if (commandSend.ErrorMessages != null || !commandSend.ErrorMessages.Any())
                foreach (var error in commandSend.ErrorMessages)
                    AddError(error);

            return CustomResponse(alunoViewModel);
        }

        [Authorize(Roles = "Master, Alunos_Lista")]
        [Route("lista")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
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
                        if (item.Name != "Detento.Ipen")
                            item.Searchable = false;
                    }
                }
                else
                {
                    //não havendo números na string
                    //deixo ativado somente o searcheable do nome
                    foreach (var item in request.Columns)
                    {
                        if (item.Name != "Detento.Nome")
                            item.Searchable = false;
                    }
                }
            }


            var tenantId = StringHelpers.ExtractTenantId(await _tenantRepository.GetTenantIdAsync());
            var result = await _context
                                    .Alunos
                                        .IgnoreQueryFilters()
                                        .Include(c => c.Detento)
                                        .Include(c => c.Tenant)
                                        .Where(x => x.TenantId == tenantId)
                                        .GetDatatableResultAsync(request);

            var dataMapped = _mapper.Map<IEnumerable<AlunoViewModel>>(result.Data);
            
            var data = new {
                data = dataMapped
            };
        
            return Ok(new {
                Data = data,
                Draw = result.Draw,
                RecordsFiltered  = result._iRecordsDisplay,
                RecordsTotal = result._iRecordsTotal,
                Success = true
            });
        }
        #endregion

        [Authorize(Roles = "Master, Alunos_Lista_Um")]
        [Route("get-by-detento-ipen")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult GetByDetentoIpen([FromBody]string ipen)
        {
            try
            {
                if (ipen.IsNullOrEmpty())
                    return BadRequest("Ipen requerido!");

                var result = _alunoManager
                                    .GetByDetentoIpen(Convert.ToInt32(ipen));

                if (result == null)
                {
                    AddError("Nenhum aluno encontrado com o ipen informado.");
                }

                return CustomResponse(result);
            }
            catch { throw; }
        }

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

            try
            {
                return CustomResponse(true, null, await _alunoManager.GetNomeAsync(id));
            }
            catch { throw; }
        }

        [Authorize(Roles = "Master, Aluno_Activate-Deactivate")]
        [Route("activate-or-deactivate")]
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ActivateOrDeactivateAsync ([FromBody]string id)
        {
            #region Required validations
            if (string.IsNullOrEmpty(id)) return StatusCode(400, "Id requerido.");
            #endregion
            
            bool result;
            try
            {
                result = await _alunoManager.ActivateOrDeactivateAsync(id);
            }
            catch (Exception ex) { return StatusCode(500, ex.Message); }
            if (result) return Ok(result);
            return StatusCode(404);
        }
    }
}