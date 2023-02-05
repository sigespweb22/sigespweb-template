using Microsoft.AspNetCore.Mvc;
using Sigesp.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using AutoMapper;
using System.Threading.Tasks;
using Sigesp.Application.ViewModels.Requests;
using Sigesp.Application.ViewModels.Oficios.Educacao;
using System;
using System.Linq;

namespace Sigesp.WebUI.Controllers
{
    [Authorize(Roles = "Master, Oficio-Educacao-Leitura_Criar")]
    public class OficioEducacao : Controller
    {
        public readonly IAlunoLeituraAppService _alunoLeituraManager;

        public OficioEducacao(IAlunoLeituraAppService alunoLeituraManager)
        {
            _alunoLeituraManager = alunoLeituraManager;
        }

        [Authorize(Roles = "Master, Oficio-Educacao-Leitura_Criar")]
        [HttpPost]
        public async Task<IActionResult> Leitura([FromBody] OficioEducacaoLeituraRequestModel oficioEducacaoLeituraRequestModel)
        {
            #region Get data for ofício
            var result = new OficioEducacaoLeituraViewModel();
            try
            {
                result = await _alunoLeituraManager.GetOficioLeituraAsync(oficioEducacaoLeituraRequestModel.LeiturasIds);
            }
            catch(Exception ex) { return StatusCode(500, ex.Message); }
            #endregion

            if (result == null)
                return StatusCode(404, "Nenhuma leitura encontrada com os ids informados para criação do ofício.");

            return View(result);
        }
    }
}