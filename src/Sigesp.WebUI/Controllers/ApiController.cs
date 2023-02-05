using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Sigesp.Application;
using Sigesp.Domain.Models.DataTable;

namespace Sigesp.WebUI.Controllers
{
    [ApiController]
    public abstract class ApiController : Controller
    {
        private readonly ICollection<string> _errors = new List<string>();
        private readonly ICollection<object> _objects = new List<object>();

        protected ActionResult CustomResponse(bool isValid, 
                                              string message,
                                              List<object> objList)
        {
            if (isValid)
            { 
                return Ok (new {
                    Success = true,
                    Message = message,
                    Data = objList
                });
            } else {
                return BadRequest (new {
                    Success = false,
                    Message = message,
                    Data = objList
                });
            }
        }

        protected ActionResult CustomResponse(bool isValid, 
                                              string message,
                                              List<string> stringList)
        {
            if (isValid)
            { 
                return Ok (new {
                    Success = true,
                    Message = message,
                    Data = stringList
                });
            } else {
                return BadRequest (new {
                    Success = false,
                    Message = message,
                    Data = stringList
                });
            }
        }

        protected ActionResult CustomResponse(bool isValid, 
                                              string message,
                                              string data)
        {
            if (isValid)
            { 
                return Ok (new {
                    Success = true,
                    Message = message,
                    Data = data
                });
            } else {
                return BadRequest (new {
                    Success = false,
                    Message = message,
                    Data = data
                });
            }
        }

        protected ActionResult CustomResponse(bool isValid, 
                                              string message,
                                              object data)
        {
            if (isValid)
            { 
                return Ok (new {
                    Success = true,
                    Message = message,
                    Data = data
                });
            } else {
                return BadRequest (new {
                    Success = false,
                    Message = message,
                    Data = data
                });
            }
        }

        protected ActionResult CustomResponse(object result = null)
        {
            if (IsOperationValid())
            {
                return Ok(result);
            }

            return BadRequest(new ValidationProblemDetails(new Dictionary<string, string[]>
            {
                { "Messages", _errors.ToArray() }
            }));
        }

        protected ActionResult CustomResponsePassCode(int statusCode = 0, object result = null)
        {
            if (IsOperationValid())
            {
                return Ok(result);
            }

            if (statusCode == 404)
            {
                return NotFound(new ValidationProblemDetails(new Dictionary<string, string[]>
                {
                    { "Messages", _errors.ToArray() }
                }));
            }

            if (statusCode == 204)
            {
                return NoContent();
            }

            return BadRequest(new ValidationProblemDetails(new Dictionary<string, string[]>
            {
                { "Messages", _errors.ToArray() }
            }));
        }

        protected ActionResult CustomResponse(ModelStateDictionary modelState)
        {
            var errors = modelState.Values.SelectMany(e => e.Errors);
            foreach (var error in errors)
            {
                AddError(error.ErrorMessage);
            }

            return CustomResponse();
        }

        protected ActionResult CustomResponse(ValidationResult validationResult)
        {
            foreach (var error in validationResult.ErrorMessages)
            {
                AddError(error);
            }

            foreach (var obj in validationResult.Objects)
            {
                AddObject(obj);                
            }

            if (validationResult.Objects.Any())
                return CustomResponse(validationResult.Objects);
            return CustomResponse();
        }

        protected bool IsOperationValid()
        {
            var errors = !_errors.Any();
            return errors;
        }

        protected void  AddError(string erro)
        {
            _errors.Add(erro);
        }

        protected void AddObject(object obj)
        {
            _objects.Add(obj);
        }

        protected void ClearErrors()
        {
            _errors.Clear();
        }
    }
}