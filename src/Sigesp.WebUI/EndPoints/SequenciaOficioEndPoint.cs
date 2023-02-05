using System.Net;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sigesp.Infra.Data.Context;
using Sigesp.WebUI.Extensions;
using Sigesp.Domain.Models;
using Sigesp.Domain.Interfaces;
using Sigesp.Application.Services;
using Sigesp.Application.Interfaces;
using Sigesp.Application.ViewModels;
using Sigesp.WebUI.Controllers;
using Sigesp.Infra.CrossCutting.Identity.Services;
using Sigesp.Infra.Data.Extensions;

namespace Sigesp.WebUI.EndPoints
{
    [ApiController]
    [Route("api/sequencias-oficios")]
    public class SequenciaOficioEndPoint : ApiController
    {
        private readonly SigespDbContext _context;
        private readonly UserResolverService _userResolverService;
        private readonly IContaUsuarioRepository _contaUsuarioRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITenantRepository _tenantRepository;

        public SequenciaOficioEndPoint(SigespDbContext context,
                                        UserResolverService userResolverService,
                                        IContaUsuarioRepository contaUsuarioRepository,
                                        IUnitOfWork unitOfWork,
                                        ITenantRepository tenantRepository)
        {
            _context = context;
            _userResolverService = userResolverService;
            _contaUsuarioRepository = contaUsuarioRepository;
            _unitOfWork = unitOfWork;
            _tenantRepository = tenantRepository;
        }

        [HttpPost]
        [Route("gerar")]
        public async Task<IActionResult> PostGerar()
        {
            #region Tenancy resolve
            Guid tenantId;
            try
            {
                tenantId = (Guid) StringHelpers.ExtractTenantId(await _tenantRepository.GetTenantIdAsync());
            }
            catch (Exception ex) { return StatusCode(500, ex); }
            #endregion

            #region Get current user id
            Guid currenteUserId;
            try
            {
                currenteUserId = _userResolverService.GetUserId();
            }
            catch (Exception ex) { return StatusCode(500, ex); }
            #endregion

            #region Get account user and user data
            var accountUser = new ContaUsuario();
            try
            {
                accountUser = _contaUsuarioRepository.GetByUserId(currenteUserId.ToString());
            }
            catch (Exception ex) { return StatusCode(500, ex); }
            #endregion

            #region Get all sequencies to tenancy and user sector
            IEnumerable<int> sequencias = new List<int>();
            try
            {
                sequencias = _context
                                .SequenciasOficios
                                .Where(x => x.Tenant.Id == tenantId &&
                                       x.Setor == accountUser.Setor)
                                .Select(x => x.Sequencia);

                if (sequencias == null)
                    throw new Exception("Problemas ao obter as sequências. Tente novamente mais tarde.");
            }
            catch (Exception ex) { return StatusCode(500, ex); }
            #endregion

            #region Generate new sequence
            var novaSequencia = new SequenciaOficio();
            try
            {
                novaSequencia.Setor = accountUser.Setor;
                novaSequencia.TenantId = tenantId;
                novaSequencia.Sequencia = sequencias.Count() <= 0 ? 1 : sequencias.Max() + 1;
                novaSequencia.UsuarioNomeUltimaSequencia = accountUser.Nome;
            }
            catch (Exception ex) { return StatusCode(500, ex); }
            #endregion

            #region Persistance and commit
            _context.SequenciasOficios.Add(novaSequencia);
            _unitOfWork.Commit();
            #endregion

            return CustomResponse(true, "OK", novaSequencia.Sequencia.ToString());
        }
    }
}