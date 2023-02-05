using System.Collections;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sigesp.Infra.Data.Context;
using Sigesp.WebUI.Extensions;
using Sigesp.Domain.Interfaces;
using Sigesp.Application.Interfaces;
using Sigesp.Application.ViewModels;
using Sigesp.WebUI.Controllers;
using Sigesp.Domain.Models.DataTable;
using Sigesp.WebUI.Helpers;
using Sigesp.Infra.Data.Extensions.DataTable;
using AutoMapper;
using Sigesp.Domain.Enums;
using Microsoft.AspNetCore.Authorization;

namespace Sigesp.WebUI.EndPoints
{
    [Authorize(Roles = "Lista-Amarela_Todos, Master")]
    [ApiController]
    [Route("api/lista-amarela")]
    public class ListaAmarelaEndPoint : ApiController
    {
        private readonly IListaAmarelaAppService _listaAmarelaAppService;
        private readonly IListaAmarelaRepository _listaAmarelaRepository;
        private readonly SigespDbContext _context;
        private readonly IMapper _mapper;
        private readonly ValidationResult _validationResult;

        public ListaAmarelaEndPoint(IListaAmarelaAppService listaAmarelaAppService,
                                    SigespDbContext context,
                                    IMapper mapper,
                                    IListaAmarelaRepository listaAmarelaRepository,
                                    ValidationResult validationResult)
        {
            _listaAmarelaAppService = listaAmarelaAppService;
            _context = context;
            _mapper = mapper;
            _listaAmarelaRepository = listaAmarelaRepository;
            _validationResult = validationResult;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult Post([FromBody]ListaAmarelaViewModel listaAmarelaViewModel)
        {
            var commandSend = _listaAmarelaAppService.Add(listaAmarelaViewModel);

            if (commandSend.ErrorMessages != null)
                foreach (var error in commandSend.ErrorMessages)
                    AddError(error);

            return CustomResponse(listaAmarelaViewModel);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult Put([FromBody]ListaAmarelaViewModel listaAmarelaViewModel)
        {
            var commandSend  = _listaAmarelaAppService.Update(listaAmarelaViewModel);

            if (commandSend.ErrorMessages != null || !commandSend.ErrorMessages.Any())
                foreach (var error in commandSend.ErrorMessages)
                    AddError(error);

            return CustomResponse(listaAmarelaViewModel);
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult Delete([FromBody]ListaAmarelaViewModel listaAmarelaViewModel)
        {
            var commandSend  = _listaAmarelaAppService.Remove((Guid)listaAmarelaViewModel.Id);
            
            if (commandSend.ErrorMessages != null || !commandSend.ErrorMessages.Any())
                foreach (var error in commandSend.ErrorMessages)
                    AddError(error);

            return CustomResponse(listaAmarelaViewModel);
        }

        [Route("enable-disable")]
        public async Task<IActionResult> PostEnableDisableById([FromBody]string id)
        {
            var commandSend  = await _listaAmarelaAppService.EnableDisableById(id);
            
            if (commandSend.ErrorMessages != null || !commandSend.ErrorMessages.Any())
                foreach (var error in commandSend.ErrorMessages)
                    AddError(error);

            return CustomResponse(id);
        }

        //Lista amarela
        [HttpPost]
        [Route("list")]
        public async Task<IActionResult> PostListAsync([FromForm]  DataTableServerSideRequest request)
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
            
            var result = await _context.ListaAmarela
                                    .IgnoreQueryFilters()
                                    .Include(x => x.Detento)
                                    .Where(x => x.Detento.IsDeleted == false || x.Detento.IsDeleted == true)
                                    .Where(x => x.IsDeleted == false)
                                    .OrderBy(x => x.CreatedAt)
                                    .GetDatatableResultAsync(request);

            //Mapper manual instrumentos prisão
            foreach (var item in result.Data)
            {
                foreach (var instrumentoPrisao in item.InstrumentosPrisao)
                {
                    var enumMapped = EnumExtensions<InstrumentoPrisaoTipoEnum>.GetNameByValue(instrumentoPrisao);
                }
            }
            
            var dataMapped = _mapper.Map<IEnumerable<ListaAmarelaViewModel>>(result.Data);

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

        [HttpPost]
        [Route("get-all-by-instrumento-prisao")]
        public IActionResult GetAllByInstrumentoPrisao()
        {
            try
            {
                var ip = InstrumentoPrisaoTipoEnum.MEDIDA_DISCIPLINAR;

                var result = _listaAmarelaRepository
                                        .GetAllByInstrumentoPrisao(ip);

                IEnumerable resultNew = new List<ListaAmarelaViewModel>();
                if (result != null)
                {
                    resultNew = _mapper
                                    .Map<IEnumerable<ListaAmarelaViewModel>>(result);
                }

                return Ok(new {
                    Data = resultNew,
                    Success = true
                });
            }
            catch { throw; } 
        }

        [Route("get-by-ipen")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetByIpen([FromBody]string ipen)
        {
            try
            {
                if(ipen.IsNullOrEmpty())
                    throw new Exception("Ipen requerido.");
                    
                    
                var getByIpen = _listaAmarelaAppService
                                                .GetByDetentoIpen(ipen);

                return Ok(new {
                    Data = getByIpen,
                    Success = true
                });
            }
            catch { throw; } 
        }

        [Route("edicao")]
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult Edicao([FromBody]ListaAmarelaViewModel laViewModel)
        {
            var commandSend  = _listaAmarelaAppService
                                        .Update(laViewModel);

            if (commandSend.ErrorMessages != null || !commandSend.ErrorMessages.Any())
                foreach (var error in commandSend.ErrorMessages)
                    AddError(error);

            return CustomResponse(laViewModel);
        }

        [Route("resgatar-inativo-by-ipen")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult ResgatarInativoByIpen([FromBody]string ipen)
        {
            try
            {
                if(ipen.IsNullOrEmpty())
                    throw new Exception("Ipen requerido.");
                    
                    
                var resgatarInativoByIpen = _listaAmarelaAppService
                                                .ResgatarInativoByIpen(Convert.ToInt32(ipen));

                return Ok(new {
                    Data = resgatarInativoByIpen,
                    Success = true
                });
            }
            catch { throw; } 
        }

        [Route("get-attipos")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetAttTipo()
        {
            try
            {
                return CustomResponse(true, null, EnumExtensions<DetentoAguardandoTransferenciaTipoEnum>.GetNames().ToList());
            }
            catch { throw; } 
        }
    }
}