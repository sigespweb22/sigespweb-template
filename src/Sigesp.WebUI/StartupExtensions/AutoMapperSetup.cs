using System;
using Sigesp.Application.AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace Sigesp.WebUI.StartupExtensions
{
    public static class AutoMapperSetup
    {
        public static void AddAutoMapperSetup(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddAutoMapper(AutoMapperConfig.RegisterMappings());
        }
    }
}
