using System;
using Sigesp.Domain.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Polly;
using Refit;

namespace Sigesp.WebUI.StartupExtensions
{
    public static class HttpExtension
    {
        public static IServiceCollection AddCustomizedHttp(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddHttpClient("IBGE_ESTADOS_API", c =>
                {
                    c.BaseAddress = new Uri(configuration.GetValue<string>("HttpClients:IBGE_ESTADOS_API"));
                })
                .AddTransientHttpErrorPolicy(p => p.WaitAndRetryAsync(5, _ => TimeSpan.FromMilliseconds(500)))
                .AddTypedClient(c => Refit.RestService.For<IIBGEServices>(c));
            
            services
                .AddHttpClient("ESTADOS_API", c =>
                {
                    c.BaseAddress = new Uri(configuration.GetValue<string>("HttpClients:ESTADOS_API"));
                })
                .AddTransientHttpErrorPolicy(p => p.WaitAndRetryAsync(5, _ => TimeSpan.FromMilliseconds(500)))
                .AddTypedClient(c => Refit.RestService.For<IGeoNamesEstadosServices>(c));

            return services;
        }
    }
}
