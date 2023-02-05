// using System.ComponentModel.DataAnnotations.Schema;
// using System.ComponentModel.DataAnnotations;
// using System.Collections;
// using System;
// using System.Linq;
// using System.Collections.Generic;
// using System.Threading.Tasks;
// using Microsoft.AspNetCore.Http;
// using Microsoft.AspNetCore.Identity;
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.EntityFrameworkCore;
// using Sigesp.Infra.Data.Context;
// using Sigesp.WebUI.Extensions;
// using Sigesp.Domain.Models;
// using Sigesp.Domain.Interfaces;
// using Sigesp.Application.Services;
// using Sigesp.Application.Interfaces;
// using Sigesp.Application.ViewModels;
// using Sigesp.WebUI.Controllers;
// using Microsoft.AspNetCore.Authorization;
// using Sigesp.Domain.Models.DataTable;
// using Sigesp.WebUI.Helpers;
// using Sigesp.Domain.Enums;
// using AutoMapper;
// using Sigesp.Infra.Data.Extensions.DataTable;
// using Sigesp.Application.ViewModels.Requests;

// namespace Sigesp.WebUI.EndPoints
// {
//     [Authorize(Roles = "Master, Leituras_Novo")]
//     [ApiController]
//     [Route("api/leituras")]
//     public class LeiturasEndPoint : ApiController
//     {
//         public LeiturasEndPoint()
//         {
//         }

//         [AllowAnonymous]
//         [Route("novo")]
//         [HttpPost]
//         [ProducesResponseType(StatusCodes.Status201Created)]
//         public IActionResult Novo([FromBody]LeituraViewModel leitura)
//         {
//             return Ok();
//         }

//         [AllowAnonymous]
//         [Route("lista")]
//         [HttpPost]
//         [ProducesResponseType(StatusCodes.Status201Created)]
//         public IActionResult Lista()
//         {
//             var leituras = new List<Leitura>();
//             var leitor = new AlunoLeitura
//             {
//                 Id = Guid.Parse("b827fbec-0708-4e66-9fca-e4d0c3411255"),
//                 // Nome = "CARLOS DANIEL"
//             };

//             var leitura = new Leitura
//             {
//                 Id = "8a0ee4db-ff99-4e02-94c4-58cae3e8fa95",
//                 Titulo = "LEITURA DO LIVRO 1",
//                 Leitor = leitor
//             };

//             leituras.Add(leitura);

//             leitor = new Leitor
//             {
//                 Id = Guid.Parse("7a2aea96-2c3e-4b5f-a128-f66dc6beaeb5"),
//                 // Nome = "EMERSON MARIA"
//             };

//             leitura = new Leitura
//             {
//                 Id = "76b2a03b-fd80-40b9-8bc3-649ed6a112a2",
//                 Titulo = "LEITURA DO LIVRO 2",
//                 Leitor = leitor
//             };

//             leituras.Add(leitura);

//             return Ok(new {
//                 Data = leituras,
//                 Success = true
//             });
//         }

//         [AllowAnonymous]
//         [Route("get-all-leitores")]
//         [HttpPost]
//         [ProducesResponseType(StatusCodes.Status200OK)]
//         public IActionResult GetAllLeitores(string term)
//         {
//             if(!string.IsNullOrEmpty(term))
//             {
//                 var leitor = new Leitor();
//                 var leitores = new List<Leitor>();

//                 leitor.Id = Guid.Parse("f8cfc981-6b45-48d5-97f9-53b0199bf45e");
//                 // leitor.Detento.Nome = "CARLOS DA SILVA";

//                 leitores.Add(leitor);

//                 leitor.Id = Guid.Parse("0c528100-cf8c-4035-95af-bc0d0f109efd");
//                 // leitor.Detento.Nome = "EMERSON MARIA";
                
//                 leitores.Add(leitor);

//                 return Ok(new {
//                     Data = leitores,
//                     Success = true
//                 });
//             }
//             else
//             {
//                 return Ok();
//             }
//         }     
//     }
// }