using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Sigesp.WebUI.Helpers
{
    public class ExceptionHandlerOptions
    {
         public PathString ExceptionHandlingPath { get; set; }
        public RequestDelegate ExceptionHandler { get; set; }
    }
}