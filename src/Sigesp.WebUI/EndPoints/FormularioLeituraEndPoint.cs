using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sigesp.Application.ViewModels;
using Sigesp.WebUI.Controllers;
using Microsoft.AspNetCore.Authorization;
using AutoMapper;
using Sigesp.Infra.Data.Context;
using Sigesp.Domain.Models.DataTable;
using Sigesp.Infra.Data.Extensions;
using Sigesp.Domain.Interfaces;
using Sigesp.Domain.Models;
using Sigesp.Infra.Data.Extensions.DataTable;

namespace Sigesp.WebUI.EndPoints
{
    [AllowAnonymous]
    [ApiController]
    [Route("api/formularios-leituras")]
    public class FormularioLeituraEndPoint : ApiController
    {
        private IMapper _mapper;
        private SigespDbContext _context;
        private readonly ITenantRepository _tenantRepository;
        private readonly IUnitOfWork _unitOfWork;

        public FormularioLeituraEndPoint(IMapper mapper, 
                                         SigespDbContext context,
                                         ITenantRepository tenantRepository,
                                         IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _context = context;
            _tenantRepository = tenantRepository;
            _unitOfWork = unitOfWork;
        }

        #region Métodos Dicas de Escrita Grupos
        [Route("dicas-escrita/lista-to-select")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DicaEscritaListaToSelect2Async()
        {
            #region Tenant resolve
            Guid tenantId;
            try
            {
                tenantId = (Guid) StringHelpers.ExtractTenantId(await _tenantRepository.GetTenantIdAsync());
            }
            catch (Exception ex) { AddError(ex.Message); return CustomResponsePassCode(500); }

            if (tenantId == Guid.Empty)
            {
                AddError("Unidade Prisional não encontrada.");
                return CustomResponsePassCode(404);
            }
            #endregion

            #region Get data
            IEnumerable<FormularioLeituraDicaEscrita> flDE = new List<FormularioLeituraDicaEscrita>();
            try
            {
                flDE = await  _context
                                        .FormularioLeituraDicasEscrita
                                        .Include(x => x.FormularioLeituraDicaEscritaDicas)
                                        .Where(x => x.TenantId == tenantId)
                                        .ToListAsync();
            }
            catch (Exception ex) { AddError(ex.Message); return CustomResponsePassCode(500); }

            if (flDE == null || flDE.Count() == 0)
            {
                AddError("Nenhuma registro encontrado.");
                return CustomResponsePassCode(404);
            }
            #endregion

            #region Map
            IEnumerable<FormularioLeituraDicaEscritaViewModel> flDEMap = new List<FormularioLeituraDicaEscritaViewModel>();
            try
            {
                flDEMap = _mapper.Map<IEnumerable<FormularioLeituraDicaEscritaViewModel>>(flDE);
            }
            catch (Exception ex) { AddError(ex.Message); return CustomResponsePassCode(500); }
            #endregion

            return CustomResponse(flDE);
        }

        [Route("dicas-escrita/lista")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ListaAsync([FromForm] DataTableServerSideRequest request)
        {
            #region Tenant resolve
            Guid tenantId;
            try
            {
                tenantId = (Guid) StringHelpers.ExtractTenantId(await _tenantRepository.GetTenantIdAsync());
            }
            catch (Exception ex) { AddError(ex.Message); return CustomResponsePassCode(500); }

            if (tenantId == Guid.Empty)
            {
                AddError("Unidade Prisional não encontrada.");
                return CustomResponsePassCode(404);
            }
            #endregion

            var result = await _context.FormularioLeituraDicasEscrita
                                            .IgnoreQueryFilters()
                                            .Include(x => x.FormularioLeituraDicaEscritaDicas)
                                            .Where(x => x.TenantId == tenantId)
                                            .OrderByDescending(x => x.CreatedAt)
                                            .GetDatatableResultAsync(request);

            var dataMapped = _mapper
                                .Map<IEnumerable<FormularioLeituraDicaEscritaViewModel>>(result.Data);
            
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

        [Route("dicas-escrita/novo")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DicaEscritaNovoAsync([FromBody] FormularioLeituraDicaEscritaViewModel flDE)
        {
            #region Tenant resolve
            Guid tenantId;
            try
            {
                tenantId = (Guid) StringHelpers.ExtractTenantId(await _tenantRepository.GetTenantIdAsync());
            }
            catch (Exception ex) { AddError(ex.Message); return CustomResponsePassCode(500); }

            if (tenantId == Guid.Empty)
            {
                AddError("Unidade Prisional não encontrada.");
                return CustomResponsePassCode(404);
            }
            #endregion

            #region Map
            var flDEMap = new FormularioLeituraDicaEscrita();
            try
            {
                flDEMap = _mapper.Map<FormularioLeituraDicaEscrita>(flDE);
                flDEMap.TenantId = tenantId;
            }
            catch (Exception ex) { AddError(ex.Message); return CustomResponsePassCode(500); }
            #endregion

            #region Persistance
            await _context.FormularioLeituraDicasEscrita.AddAsync(flDEMap);
            _unitOfWork.Commit();
            #endregion

            return CustomResponsePassCode(201);
        }

        [Route("dicas-escrita/edicao")]
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DicaEscritaEdicaoAsync([FromBody] FormularioLeituraDicaEscritaViewModel flDE)
        {
            #region Required validations
            if (flDE.Id == Guid.Empty)
            {
                AddError("Id requerido.");
                return CustomResponsePassCode(400);
            }
            #endregion

            #region Tenant resolve
            Guid tenantId;
            try
            {
                tenantId = (Guid) StringHelpers.ExtractTenantId(await _tenantRepository.GetTenantIdAsync());
            }
            catch (Exception ex) { AddError(ex.Message); return CustomResponsePassCode(500); }

            if (tenantId == Guid.Empty)
            {
                AddError("Unidade Prisional não encontrada.");
                return CustomResponsePassCode(404);
            }
            #endregion

            #region Get data
            var flDEDM = new FormularioLeituraDicaEscrita();
            try
            {
                flDEDM = await _context
                                    .FormularioLeituraDicasEscrita
                                    .AsNoTracking()
                                    .FirstOrDefaultAsync(x => x.Id == flDE.Id);
            }
            catch (Exception ex) { AddError(ex.Message); return CustomResponsePassCode(500); }

            if (flDEDM == null)
            {
                AddError("Nenhum registro encontrado.");
                return CustomResponsePassCode(404);
            }
            #endregion

            #region Map
            try
            {
                flDEDM = _mapper
                            .Map<FormularioLeituraDicaEscritaViewModel,
                                 FormularioLeituraDicaEscrita>(flDE, flDEDM);
            }
            catch (Exception ex) { AddError(ex.Message); return CustomResponsePassCode(500); }
            #endregion

            #region Persistance and commit
            _context.FormularioLeituraDicasEscrita.Update(flDEDM);
            _unitOfWork.Commit();
            #endregion

            return CustomResponsePassCode(204);
        }

        [Route("dicas-escrita/ativar/{dicaEscritaId}")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DicaEscritaAtivarAsync([FromRoute] Guid dicaEscritaId)
        {
            #region Required validations
            if (dicaEscritaId == Guid.Empty)
            {
                AddError("Id requerido.");
                return CustomResponsePassCode(400);
            }
            #endregion

            #region Tenant resolve
            Guid tenantId;
            try
            {
                tenantId = (Guid) StringHelpers.ExtractTenantId(await _tenantRepository.GetTenantIdAsync());
            }
            catch (Exception ex) { AddError(ex.Message); return CustomResponsePassCode(500); }

            if (tenantId == Guid.Empty)
            {
                AddError("Unidade Prisional não encontrada.");
                return CustomResponsePassCode(404);
            }
            #endregion

            #region Get data
            var flDEDM = new FormularioLeituraDicaEscrita();
            try
            {
                flDEDM = await _context
                                    .FormularioLeituraDicasEscrita
                                    .IgnoreQueryFilters()
                                    .FirstOrDefaultAsync(x => x.Id == dicaEscritaId);
            }
            catch (Exception ex) { AddError(ex.Message); return CustomResponsePassCode(500); }

            if (flDEDM == null)
            {
                AddError("Nenhum registro encontrado.");
                return CustomResponsePassCode(404);
            }
            #endregion

            #region Map and Persistance
            flDEDM.IsDeleted = false;
            _context.FormularioLeituraDicasEscrita.Update(flDEDM);
            _unitOfWork.Commit();
            #endregion
            
            return CustomResponsePassCode(204);
        }

        [Route("dicas-escrita/inativar/{dicaEscritaId}")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DicaEscritaInativarAsync([FromRoute] Guid dicaEscritaId)
        {
            #region Required validations
            if (dicaEscritaId == Guid.Empty)
            {
                AddError("Id requerido.");
                return CustomResponsePassCode(400);
            }
            #endregion

            #region Tenant resolve
            Guid tenantId;
            try
            {
                tenantId = (Guid) StringHelpers.ExtractTenantId(await _tenantRepository.GetTenantIdAsync());
            }
            catch (Exception ex) { AddError(ex.Message); return CustomResponsePassCode(500); }

            if (tenantId == Guid.Empty)
            {
                AddError("Unidade Prisional não encontrada.");
                return CustomResponsePassCode(404);
            }
            #endregion

            #region Get data
            var flDEDM = new FormularioLeituraDicaEscrita();
            try
            {
                flDEDM = await _context
                                    .FormularioLeituraDicasEscrita
                                    .FirstOrDefaultAsync(x => x.Id == dicaEscritaId);
            }
            catch (Exception ex) { AddError(ex.Message); return CustomResponsePassCode(500); }

            if (flDEDM == null)
            {
                AddError("Nenhum registro encontrado.");
                return CustomResponsePassCode(404);
            }
            #endregion

            #region Map and Persistance
            flDEDM.IsDeleted = true;
            _context.FormularioLeituraDicasEscrita.Update(flDEDM);
            _unitOfWork.Commit();
            #endregion
            
            return CustomResponsePassCode(204);
        }
        #endregion

        #region Métodos Dicas de Escrita Dicas
        [Route("dicas-escrita/dicas/lista")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DicaEscritaDicaListaAsync()
        {
            #region Tenant resolve
            Guid tenantId;
            try
            {
                tenantId = (Guid) StringHelpers.ExtractTenantId(await _tenantRepository.GetTenantIdAsync());
            }
            catch (Exception ex) { AddError(ex.Message); return CustomResponsePassCode(500); }

            if (tenantId == Guid.Empty)
            {
                AddError("Unidade Prisional não encontrada.");
                return CustomResponsePassCode(404);
            }
            #endregion

            #region Get data
            IEnumerable<FormularioLeituraDicaEscritaDica> flDED = new List<FormularioLeituraDicaEscritaDica>();
            try
            {
                flDED = await  _context
                                        .FormularioLeituraDicasEscritaDicas
                                        .Include(x => x.FormularioLeituraDicaEscrita)
                                        // .Where(x => x.FormularioLeituraDicaEscrita.TenantId == tenantId)
                                        .ToListAsync();
            }
            catch (Exception ex) { AddError(ex.Message); return CustomResponsePassCode(500); }

            if (flDED == null || flDED.Count() == 0)
            {
                AddError("Nenhuma registro encontrado.");
                return CustomResponsePassCode(404);
            }
            #endregion

            return CustomResponse(flDED);
        }

        [Route("dicas-escrita/dicas/novo")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DicaEscritaDicaNovoAsync([FromBody] FormularioLeituraDicaEscritaDicaViewModel flDED)
        {
            #region Tenant resolve
            Guid tenantId;
            try
            {
                tenantId = (Guid) StringHelpers.ExtractTenantId(await _tenantRepository.GetTenantIdAsync());
            }
            catch (Exception ex) { AddError(ex.Message); return CustomResponsePassCode(500); }

            if (tenantId == Guid.Empty)
            {
                AddError("Unidade Prisional não encontrada.");
                return CustomResponsePassCode(404);
            }
            #endregion

            #region Map
            var flDEDMap = new FormularioLeituraDicaEscritaDica();
            try
            {
                flDEDMap = _mapper.Map<FormularioLeituraDicaEscritaDica>(flDED);
            }
            catch (Exception ex) { AddError(ex.Message); return CustomResponsePassCode(500); }
            #endregion

            #region Persistance
            await _context.FormularioLeituraDicasEscritaDicas.AddAsync(flDEDMap);
            try
            {
                _unitOfWork.Commit();
            }
            catch { throw; }
            #endregion

            return CustomResponsePassCode(201);
        }
        
        [Route("dicas-escrita/dicas/edicao")]
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DicaEscritaDicaEdicaoAsync([FromBody] FormularioLeituraDicaEscritaDicaViewModelWithoutValidations flDEDVM)
        {
            #region Required validations
            if (flDEDVM.Id == Guid.Empty)
            {
                AddError("Id requerido");
                return CustomResponsePassCode(400);
            }

            if (string.IsNullOrEmpty(flDEDVM.Dica) && flDEDVM.Ordem == 0)
            {
                AddError("Dica ou Ordem é requerida.");
                return CustomResponsePassCode(400);
            }
            #endregion

            #region Get data to update
            var flDEDDM = new FormularioLeituraDicaEscritaDica();
            try
            {
                flDEDDM = await _context
                                    .FormularioLeituraDicasEscritaDicas
                                    .FindAsync(flDEDVM.Id);    
            }
            catch (Exception ex) { AddError(ex.Message); return CustomResponsePassCode(500); }
            
            if (flDEDDM == null)
            {
                AddError("Nenhuma dica escrita dica encontrada.");
                return CustomResponsePassCode(404);
            }
            #endregion

            #region Map
            try
            {
                if (flDEDVM.Ordem == 0)
                {
                    flDEDVM.Ordem = flDEDDM.Ordem;
                } else if (string.IsNullOrEmpty(flDEDVM.Dica))
                {
                    flDEDVM.Dica = flDEDDM.Dica;
                }

                flDEDVM.FormularioLeituraDicaEscritaId = flDEDDM.FormularioLeituraDicaEscritaId.ToString();
                flDEDDM = _mapper
                        .Map<FormularioLeituraDicaEscritaDicaViewModelWithoutValidations, FormularioLeituraDicaEscritaDica>(flDEDVM, flDEDDM);
            }
            catch (Exception ex) { AddError(ex.Message); return CustomResponsePassCode(500); }
            
            #endregion

            #region Persistance and commit
            try
            {
                _context.FormularioLeituraDicasEscritaDicas.Update(flDEDDM);
                _unitOfWork.Commit();
            }
            catch (Exception ex) { AddError(ex.Message); return CustomResponsePassCode(500); }
            #endregion

            return CustomResponsePassCode(204);
        }

        [Route("dicas-escrita/dicas/delete/{id}")]
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DicaEscritaDicaEdicaoAsync([FromRoute] string id)
        {
            #region Required validations
            if (string.IsNullOrEmpty(id))
            {
                AddError("Id requerido");
                return CustomResponsePassCode(400);
            }
            #endregion

            #region Get data to delete
            var flDEDDM = new FormularioLeituraDicaEscritaDica();
            try
            {
                flDEDDM = await _context
                                    .FormularioLeituraDicasEscritaDicas
                                    .FindAsync(Guid.Parse(id));    
            }
            catch (Exception ex) { AddError(ex.Message); return CustomResponsePassCode(500); }
            
            if (flDEDDM == null)
            {
                AddError("Nenhuma dica escrita dica encontrada.");
                return CustomResponsePassCode(404);
            }
            #endregion

            #region Delete without sofdelete | permanently delete
            try
            {
                _context.FormularioLeituraDicasEscritaDicas.Remove(flDEDDM);
            }
            catch (Exception ex) { AddError(ex.Message); return CustomResponsePassCode(500); }
            #endregion

            #region Commit
            try
            {
                _unitOfWork.CommitWithoutSoftDeletion();
            }
            catch (Exception ex) { AddError(ex.Message); return CustomResponsePassCode(500); }
            #endregion

            return CustomResponsePassCode(204);
        }
        #endregion

        #region Métodos Grupo Perguntas
        [Authorize(Roles = "Master, Formulario-Leitura-Grupo-Perguntas_Lista")]
        [Route("grupos-perguntas/lista")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GrupoPerguntaGetAllAsync()
        {
            #region Tenant resolve
            Guid tenantId;
            try
            {
                tenantId = (Guid) StringHelpers.ExtractTenantId(await _tenantRepository.GetTenantIdAsync());
            }
            catch (Exception ex) { AddError(ex.Message); return CustomResponsePassCode(500); }

            if (tenantId == Guid.Empty)
            {
                AddError("Unidade Prisional não encontrada.");
                return CustomResponsePassCode(404);
            }
            #endregion
            
            #region Get data
            IEnumerable<FormularioLeituraPerguntaGrupo> flPG = new List<FormularioLeituraPerguntaGrupo>();
            try
            {
                flPG = await _context
                                .FormularioLeituraPerguntasGrupos
                                // .Where(x => x.TenantId == tenantId)
                                .ToListAsync();
            }
            catch (Exception ex) { AddError(ex.Message); return CustomResponsePassCode(500); }

            if (flPG == null || flPG.Count() == 0)
            {
                AddError("Nenhum registro encontrado.");
                return CustomResponsePassCode(404);
            }
            #endregion

            return Ok(flPG);
        }
        #endregion
    }
}