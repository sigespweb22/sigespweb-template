using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Configuration;
using Sigesp.Domain.Interfaces;
using Sigesp.Infra.Data.Extensions;
using Sigesp.Infra.Data.Repository;

namespace Sigesp.WebUI.Middlewares
{
    public class TenantSecurityMiddleware 
    {
        private readonly RequestDelegate next;
        
        public TenantSecurityMiddleware(RequestDelegate next) 
        {
            this.next = next;
        }
        
        public async Task Invoke(HttpContext context,
                                IConfiguration configuration,
                                IHttpContextAccessor httpContextAccessor,
                                ITenantRepository _tenantRepository)
        {
            string tenantIdentifier = context.Session.GetString("TenantId");
            if (string.IsNullOrEmpty(tenantIdentifier))
            {
                var apiKey = context.Request.Headers["X-Api-Key"].FirstOrDefault();
                if (!string.IsNullOrEmpty(apiKey)) 
                {
                    Guid apiKeyGuid;
                    if (Guid.TryParse(apiKey, out apiKeyGuid))
                    {
                        string tenantId = await _tenantRepository
                                            .GetTenantIdAsync(apiKeyGuid);
                        if (!string.IsNullOrEmpty(tenantId))
                        {
                            var tenantIdNew = StringHelpers
                                                .ExtractTenantId(tenantId);
                            context.Session.SetString("TenantId", tenantIdNew.ToString());
                        }
                    }
                }
            }
            await next.Invoke(context);
        }
    }
}