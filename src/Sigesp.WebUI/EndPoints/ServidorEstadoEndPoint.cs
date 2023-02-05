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
using Sigesp.Domain.Interfaces;
using Sigesp.Domain.Models;
using System;
using System.Security.Claims;

namespace Sigesp.WebUI.EndPoints
{
    [Authorize(Roles = "Master, Servidor-Estado_Todos, "+
                       "Servidor-Estado_Lista"+
                       "Servidor-Estado_Novo"+
                       "Servidor-Estado_Edicao"+
                       "Servidor-Estado_Delete")]
    [ApiController]
    [Route("api/servidores-estado")]
    public class ServidorEstadoEndPoint : ApiController
    {
        private readonly SigespDbContext _context;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITenantRepository _tenantRepository;

        public ServidorEstadoEndPoint(SigespDbContext context,
                                      IMapper mapper,
                                      IUnitOfWork unitOfWork,
                                      ITenantRepository tenantRepository)
        {
            _context = context;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _tenantRepository = tenantRepository;
        }

        
        [Authorize(Roles = "Master, Servidor-Estado_Todos, Servidor-Estado_Novo")]
        [Route("novo")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> NovoAsync([FromBody]ServidorEstadoViewModel seVM)
        {
            #region Generals validation
            bool alreadySameMatricula;
            try
            {
                alreadySameMatricula = _context.ServidoresEstado.Any(x => x.Matricula == seVM.Matricula);
            }
            catch (Exception ex) { return StatusCode(500, ex.Message); }
            if (alreadySameMatricula) {
                AddError("Já existe um servidor cadastrado e ativo com a mesma matrícula."); 
                return CustomResponse();
            }
            #endregion

            #region User resolve
            String userId;
            try
            {
                if (HttpContext.User == null) throw new Exception("Problemas ao obter usuário logado. Saia e entre no sistema novamente, persistindo o problema informe a equipe técnica.");
                userId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            }
            catch (Exception ex) { return StatusCode(500, ex.Message); }

            if (string.IsNullOrEmpty(userId)) return StatusCode(404, "Usuário não encontrado.");
            #endregion

            #region Tenant resolve
            Guid tenantId;
            try
            {
                tenantId = (Guid) StringHelpers.ExtractTenantId(await _tenantRepository.GetTenantIdAsync());
            }
            catch (Exception ex) { return StatusCode(500, ex.Message); }

            if (tenantId == Guid.Empty) return StatusCode(404, "Unidade Prisional não encontrada.");
            #endregion

            #region Map
            var se = new ServidorEstado();
            try
            {
                se = _mapper.Map<ServidorEstado>(seVM);
                se.TenantId = tenantId;
            }
            catch (Exception ex) { AddError(ex.Message); return StatusCode(500); }
            #endregion

            #region Persistance and commit
            try
            {
                await _context.ServidoresEstado.AddAsync(se);
                _unitOfWork.Commit();
            }
            catch (Exception ex) { AddError(ex.Message); return StatusCode(500); }
            #endregion

            return StatusCode(201);
        }

        [Authorize(Roles = "Master, Servidor-Estado_Todos, Servidor-Estado_Edicao")]
        [Route("edicao")]
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> EdicaoAsync([FromBody]ServidorEstadoViewModel seVM)
        {
            #region Generals validation
            bool alreadySameMatricula;
            try
            {
                alreadySameMatricula = _context.ServidoresEstado
                                        .Any(x => x.Matricula == seVM.Matricula &&
                                             x.Id != seVM.Id);
            }
            catch (Exception ex) { AddError(ex.Message); return CustomResponsePassCode(400); }
            
            if (alreadySameMatricula) 
            {
                AddError("Já existe um servidor cadastrado e ativo com a mesma matrícula."); 
                return CustomResponse();
            }
            #endregion

            #region User resolve
            String userId;
            try
            {
                if (HttpContext.User == null) throw new Exception("Problemas ao obter usuário logado. Saia e entre no sistema novamente, persistindo o problema informe a equipe técnica.");
                userId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            }
            catch (Exception ex) { AddError(ex.Message); return CustomResponsePassCode(400); }

            if (string.IsNullOrEmpty(userId))
            {
                AddError("Usuário não encontrado.");
                return CustomResponsePassCode(404);
            }
            #endregion

            #region Tenant resolve
            Guid tenantId;
            try
            {
                tenantId = (Guid) StringHelpers.ExtractTenantId(await _tenantRepository.GetTenantIdAsync());
            }
            catch (Exception ex) { return StatusCode(500, ex.Message); }

            if (tenantId == Guid.Empty)
            {
                AddError("Unidade Prisional não encontrada.");
                return CustomResponsePassCode(404);
            }
            #endregion

            #region Get Data
            var seDM = new ServidorEstado();
            try
            {
                seDM = await _context
                                .ServidoresEstado
                                .FirstOrDefaultAsync(x => x.Id == seVM.Id);
            }
            catch (Exception ex) { AddError(ex.Message); return CustomResponsePassCode(400); }

            if (seDM == null)
            {
                AddError("Servidor não encontrado");
                return CustomResponsePassCode(404);
            }
            #endregion

            #region Map
            try
            {
                seDM = _mapper.Map<ServidorEstadoViewModel, ServidorEstado>(seVM, seDM);
            }
            catch (Exception ex) { AddError(ex.Message); return CustomResponsePassCode(400); }
            #endregion

            #region Persistance and commit
            try
            {
                _context.ServidoresEstado.Update(seDM);
                await _unitOfWork.CommitAsync();
            }
            catch (Exception ex) { AddError(ex.Message); return CustomResponsePassCode(400); }
            #endregion

            return StatusCode(204);
        }

        [Authorize(Roles = "Master, Servidor-Estado_Todos, Servidor-Estado_Delete")]
        [Route("delete")]
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteAsync([FromBody]ServidorEstadoViewModel seVM)
        {
            #region Required validation
            if (seVM.Id == Guid.Empty) return StatusCode(404, "Id requerido.");
            #endregion

            #region Get data
            var se = new ServidorEstado();
            try
            {
                se = await _context.ServidoresEstado.FindAsync(seVM.Id);
            }
            catch (Exception ex) { AddError(ex.Message); return StatusCode(500); }

            if (se == null)
            {
                AddError("Servidor Estado não encontrado.");
                return CustomResponsePassCode(404);
            }
            #endregion

            #region Remove and commit
            _context.ServidoresEstado.Remove(se);
            _unitOfWork.Commit();
            #endregion

            return StatusCode(204);
        }

        [Authorize(Roles = "Master, Servidor-Estado_Todos, Servidor-Estado_Ativar")]
        [Route("ativar/{id}")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AtivarAsync([FromRoute]string id)
        {
            #region Required validation
            if (string.IsNullOrEmpty(id)) return StatusCode(404, "Id requerido.");
            #endregion

            #region Get data
            var se = new ServidorEstado();
            try
            {
                se = await _context
                            .ServidoresEstado
                            .IgnoreQueryFilters()
                            .FirstOrDefaultAsync(x => x.IsDeleted == true && x.Id == Guid.Parse(id));
            }
            catch (Exception ex) { AddError(ex.Message); return StatusCode(500); }

            if (se == null)
            {
                AddError("Servidor Estado não encontrado.");
                return CustomResponsePassCode(404);
            }
            #endregion

            #region Map
            se.IsDeleted = false;
            #endregion

            #region Remove and commit
            _context.ServidoresEstado.Update(se);
            _unitOfWork.Commit();
            #endregion

            return StatusCode(204);
        }

        [Authorize(Roles = "Master, Servidor-Estado_Todos, Servidor-Estado_Lista")]
        [Route("lista")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ListaAsync([FromForm] DataTableServerSideRequest request)
        {
            var result = await _context.ServidoresEstado
                                    .IgnoreQueryFilters()
                                    .Include(x => x.ApplicationUser)
                                    .ThenInclude(x => x.ContaUsuario)
                                    .OrderByDescending(x => x.CreatedAt)
                                    .GetDatatableResultAsync(request);

            var dataMapped = _mapper
                                .Map<IEnumerable<ServidorEstadoViewModel>>(result.Data);
            
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
    }
}