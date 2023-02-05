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
using Sigesp.WebUI.Helpers.DataTable;
using Sigesp.WebUI.Helpers;
using Sigesp.WebUI.Extensions;
using Sigesp.Application.ViewModels.Selects;
using Sigesp.Domain.Enums;
using Sigesp.Domain.Models;
using Sigesp.Domain.Interfaces;

namespace Sigesp.WebUI.EndPoints
{
    [Authorize(Roles = "Master, Alunos-Eja_Novo,"+
                       "Alunos-Eja_Edicao, Alunos-Eja_Delete, Alunos-Eja_Lista")]
    [ApiController]
    [Route("api/alunos-eja")]
    public class AlunoEjaEndPoint : ApiController
    {
        private readonly IAlunoEjaAppService _alunoEjaManager;
        private readonly SigespDbContext _context;
        private readonly IMapper _mapper;
        private readonly IAlunoEjaDisciplinaRepository _alunoEjaDisciplinaRepository;
        private readonly ITenantRepository _tenantRepository;

        public AlunoEjaEndPoint(IAlunoEjaAppService alunoEjaManager,
                                SigespDbContext context,
                                IMapper mapper, 
                                IAlunoEjaDisciplinaRepository alunoEjaDisciplinaRepository,
                                ITenantRepository tenantRepository)
        {
            _alunoEjaManager = alunoEjaManager;
            _context = context;
            _mapper = mapper;
            _alunoEjaDisciplinaRepository = alunoEjaDisciplinaRepository;
            _tenantRepository = tenantRepository;
        }

        #region Métodos CRUD
        [Authorize(Roles = "Master, Alunos-Eja_Novo")]
        [Route("novo")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> NovoAsync([FromBody]AlunoEjaViewModel alunoEjaViewModel)
        {
            var commandSend = new ValidationResult();
            try
            {
                commandSend  = await _alunoEjaManager.AddAsync(alunoEjaViewModel);
            }
            catch { throw; }

            if (commandSend.ErrorMessages != null || !commandSend.ErrorMessages.Any())
                foreach (var error in commandSend.ErrorMessages)
                    AddError(error);

            return CustomResponse(commandSend);
        }

        [Authorize(Roles = "Master, Alunos-Eja_Edicao")]
        [Route("edicao")]
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult Edicao([FromBody]AlunoEjaViewModel alunoEjaViewModel)
        {
            var commandSend  = _alunoEjaManager.Update(alunoEjaViewModel);

            if (commandSend.ErrorMessages != null || !commandSend.ErrorMessages.Any())
                foreach (var error in commandSend.ErrorMessages)
                    AddError(error);

            return CustomResponse(commandSend);
        }

        [Authorize(Roles = "Master, Alunos-Eja_Delete")]
        [Route("delete")]
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult Delete([FromBody]AlunoEjaViewModel alunoEjaViewModel)
        {
            var commandSend  = _alunoEjaManager.Remove((Guid)alunoEjaViewModel.Id);
            
            if (commandSend.ErrorMessages != null || !commandSend.ErrorMessages.Any())
                foreach (var error in commandSend.ErrorMessages)
                    AddError(error);

            return CustomResponse(commandSend);
        }

        [Authorize(Roles = "Master, Alunos-Eja_Lista")]
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

            #region Tenancy resolve
            var tenantId = StringHelpers.ExtractTenantId(await _tenantRepository.GetTenantIdAsync());
            #endregion

            var result = await _context
                                    .AlunosEja
                                        .IgnoreQueryFilters()
                                        .Include(c => c.Aluno)
                                        .ThenInclude(c => c.Detento)
                                        .Where(x => x.Tenant.Id == tenantId)
                                        .GetDatatableResultAsync(request);

            var dataMapped = _mapper.Map<IEnumerable<AlunoEjaViewModel>>(result.Data);
            
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

        [Route("get-enum-disciplinas-and-conceito")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetEnumDisciplinasAndConceitos()
        {
            var result = new AlunoEjaDisciplinaAndConceitoSelect2ViewModel();
            try
            {
                result.Disciplinas = EnumExtensions<AlunoEjaDisciplinaEnum>.GetNames().ToSafeList();
                result.Conceitos = EnumExtensions<AlunoEjaDisciplinaConceitoEnum>.GetNames().ToSafeList();
            }
            catch { throw; }
            return CustomResponse(result);
        }
        #endregion

        #region Métodos AlunoEjaDisciplina
        [Route("get-all-disciplinas-and-conceito")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllDisciplinasAndConceitoAsync([FromBody] Guid id)
        {
            if (id == null || id == Guid.Empty)
                throw new ArgumentException("Id requerido.");

            IEnumerable<AlunoEjaDisciplina> result = new List<AlunoEjaDisciplina>();
            try
            {
                result = await _alunoEjaDisciplinaRepository    
                                            .GetAllAsync(id);
            }
            catch { throw; }

            IEnumerable<AlunoEjaDisciplinaViewModel> resultMapped = new List<AlunoEjaDisciplinaViewModel>();
            try
            {
                resultMapped = _mapper.Map<IEnumerable<AlunoEjaDisciplinaViewModel>>(result);
            }
            catch { throw; }
            return CustomResponse(resultMapped);
        }
        #endregion
    }
}