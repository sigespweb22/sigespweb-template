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
using Microsoft.AspNetCore.Authorization;
using Sigesp.Domain.Models.DataTable;
using Sigesp.WebUI.Helpers;
using Sigesp.Domain.Enums;
using AutoMapper;
using Sigesp.Infra.Data.Extensions.DataTable;
using Sigesp.Application.ViewModels.Requests;

namespace Sigesp.WebUI.EndPoints
{
    [Authorize(Roles = "Master, Livros_Novo, Livros_Edicao, Livros_Delete, Livros_Lista")]
    [ApiController]
    [Route("api/livros")]
    public class LivrosEndPoint : ApiController
    {
        private readonly ILivroAppService _livroManager;
        private readonly SigespDbContext _context;
        private readonly IMapper _mapper;
        private readonly ValidationResult _validationResult;

        public LivrosEndPoint(ILivroAppService livroManager,
                                SigespDbContext context,
                                IMapper mapper, ValidationResult validationResult)
        {
            _livroManager = livroManager;
            _context = context;
            _mapper = mapper;
            _validationResult = validationResult;
        }

        #region Métodos livros
        [Authorize(Roles = "Master, Livros_Novo")]
        [Route("novo")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Novo([FromBody]LivroViewModel livroViewModel)
        {
            var commandSend  = await _livroManager.AddAsync(livroViewModel);

            if (commandSend.ErrorMessages != null)
                foreach (var error in commandSend.ErrorMessages)
                    AddError(error);

            return CustomResponse(livroViewModel);
        }

        [Authorize(Roles = "Master, Livros_Edicao")]
        [Route("edicao")]
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Edicao([FromBody]LivroViewModel livroViewModel)
        {
            var commandSend  = await _livroManager.UpdateAsync(livroViewModel);

            if (commandSend.ErrorMessages != null || !commandSend.ErrorMessages.Any())
                foreach (var error in commandSend.ErrorMessages)
                    AddError(error);

            return CustomResponse(livroViewModel);
        }

        [Authorize(Roles = "Master, Livros_Delete")]
        [Route("delete")]
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult Delete([FromBody]LivroViewModel livroViewModel)
        {
            var commandSend  = _livroManager.Remove((Guid)livroViewModel.Id);
            
            if (commandSend.ErrorMessages != null || !commandSend.ErrorMessages.Any())
                foreach (var error in commandSend.ErrorMessages)
                    AddError(error);

            return CustomResponse(livroViewModel);
        }

        [Authorize(Roles = "Master, Livros_Lista")]
        [Route("lista")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Lista([FromForm] DataTableServerSideRequest request)
        {
            //Quando o método for acionado por uma busca
            //Deverá identificar qual o tipo de dado, afim de direcionar a coluna de pesquisa
            //Permitindo assim somente pesquisa de uma condicional 
            //(Localizacao/Titulo)
            if (!request.Search.Value.IsNullOrEmpty())
            {
                var valueSearch = request.Search.Value;

                if (NumericHelpers.HasNumber(valueSearch))
                {
                    //havendo numeros na string
                    //deixo ativado somente o searcheable da localizacao
                    foreach (var item in request.Columns)
                    {
                        if (item.Name != "Localizacao")
                            item.Searchable = false;
                    }
                }
                else
                {
                    //não havendo números na string
                    //deixo ativado somente o searcheable do titulo
                    foreach (var item in request.Columns)
                    {
                        if (item.Name != "Titulo")
                            item.Searchable = false;
                    }
                }
            }

            var result = await _livroManager
                                    .GetWithDataTableResultAsync(request);

            var dataMapped = _mapper.Map<IEnumerable<LivroViewModel>>(result.Data);
            
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

        [AllowAnonymous]
        [Route("get-next-localizacao")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetNextLocalizacao()
        {
            var nextLocalizacao = _livroManager.GetNextLocalizacao();

            return Ok(new {
                Data = nextLocalizacao,
                Success = true
            });
        }

        [AllowAnonymous]
        [Route("colocar-estante")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> PostColocarEstanteAsync([FromBody]ColocarEstanteRequestViewModel
                                                                 colocarEstanteRequestViewModel)
        {
            var commandSend = new ValidationResult();
            try
            {
                commandSend = await _livroManager
                                            .ColocarEstanteAsync(colocarEstanteRequestViewModel);
            }
            catch { throw; }
            
            if (commandSend.ErrorMessages != null || !commandSend.ErrorMessages.Any())
                foreach (var error in commandSend.ErrorMessages)
                    AddError(error);

            return CustomResponse(colocarEstanteRequestViewModel);
        }

        [Route("get-all-disponiveis-nao-lidos")]
        public IActionResult GetAllDisponiveisNaoLidos([FromBody] string ipen)
        {
            try
            {
                if (ipen.IsNullOrEmpty())
                {
                    _validationResult.AddErrorMessage("Ipen requerido.");
                    return CustomResponse(_validationResult);
                }

                var commandSend = _livroManager
                                        .GetAllDisponiveis(Convert.ToInt32(ipen));
                
                return CustomResponse(commandSend);
            }
            catch { throw; }            
        }

        [Route("get-localizacao")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetLocalizacao([FromBody] string id)
        {
            try
            {
                if (id.IsNullOrEmpty())
                {
                    _validationResult.AddErrorMessage("Id requerido.");
                    return CustomResponse(_validationResult);
                }

                var commandSend = _livroManager.GetLocalizacao(Guid.Parse(id));
                return CustomResponse(commandSend);
            }
            catch { throw; }            
        }

        [Route("get-all-disponiveis-nao-lidos-by-ipen-and-genero")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetAllDisponiveisNaoLidosByIpenAndGenero([FromBody] LivrosParaEdicaoRequestViewModel
                                                                                  livrosParaEdicaoRequestViewModel)
        {
            try
            {
                if (livrosParaEdicaoRequestViewModel == null)
                {
                    _validationResult.AddErrorMessage("Parâmetros requeridos.");
                    return CustomResponse(_validationResult);
                }

                if (livrosParaEdicaoRequestViewModel.AlunoLeituraId.IsNullOrEmpty() ||
                    livrosParaEdicaoRequestViewModel.Ipen.IsNullOrEmpty())
                {
                    _validationResult.AddErrorMessage("Id da leitura e Ipen requeridos.");
                    return CustomResponse(_validationResult);
                }

                var commandSend = _livroManager
                                        .GetAllDisponiveisNaoLidosByIpenAndGenero(livrosParaEdicaoRequestViewModel);

                if (commandSend.ErrorMessages != null || !commandSend.ErrorMessages.Any())
                foreach (var error in commandSend.ErrorMessages)
                    AddError(error);
                
                if (commandSend.Objects != null || !commandSend.Objects.Any())
                foreach (var obj in commandSend.Objects)
                    AddObject(obj);

                return CustomResponse(commandSend);
            }
            catch { throw; }            
        }

        [Route("get-all-with-vr")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            IEnumerable<LivroViewModel> livros = new List<LivroViewModel>();
            try
            {
                livros = await _livroManager
                                    .GetAllWithVRAsync();
            }
            catch { throw; }
            return CustomResponse(livros);
        }
    }
}