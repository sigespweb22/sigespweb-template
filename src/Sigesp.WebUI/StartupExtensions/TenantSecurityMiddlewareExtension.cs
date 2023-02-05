using System;
using Sigesp.Domain.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Polly;
using Refit;
using Microsoft.AspNetCore.Builder;
using Sigesp.WebUI.Middlewares;

namespace Sigesp.WebUI.StartupExtensions
{
   public static class TenantSecurityMiddlewareExtension 
    {
        public static IApplicationBuilder UseTenant(this IApplicationBuilder app) 
        {
            app.UseMiddleware<TenantSecurityMiddleware>();
            return app;
        }
    }
}
