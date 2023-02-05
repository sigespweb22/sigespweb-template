using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Sigesp.WebUI.Models;
using Sigesp.WebUI.StartupExtensions;
using Sigesp.Infra.CrossCutting.IoC;
using Microsoft.Extensions.Logging;
using System;
using System.Data;
using Dapper;
using Sigesp.WebUI.Helpers;
using Microsoft.EntityFrameworkCore;
using Sigesp.Domain.Hubs;

namespace Sigesp.WebUI
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            _env = env;
        }

        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;

        }
        private IConfiguration Configuration { get; }
        private readonly IWebHostEnvironment _env;

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<SmartSettings>(Configuration.GetSection(SmartSettings.SectionName));

            // Note: This line is for demonstration purposes only, I would not recommend using this as a shorthand approach for accessing settings
            // While having to type '.Value' everywhere is driving me nuts (>_<), using this method means reloaded appSettings.json from disk will not work
            services.AddSingleton(s => s.GetRequiredService<IOptions<SmartSettings>>().Value);

            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                // Este lambda determina se o consentimento do usuário para cookies não essenciais é necessário para uma determinada solicitação.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            // ----- Database -----
            services.AddCustomizedDatabase(Configuration, _env);

            // ----- Auth -----
            services.AddCustomizedAuth(Configuration);

            // ----- AutoMapper -----
            services.AddAutoMapperSetup();

            services.AddTransient<IEmailSender, EmailSender>();

            services.AddControllers().AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );

            services.AddControllersWithViews();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            //In-Memory
            services.AddDistributedMemoryCache();
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(5);
            });

            services.AddRazorPages();

            services.AddLogging(loggingBuilder =>
            {
                loggingBuilder.AddConsole()
                    .AddFilter(DbLoggerCategory.Database.Command.Name, LogLevel.Information);
                loggingBuilder.AddDebug();
            });

            services.AddCors(options => {
                options.AddDefaultPolicy(
                    options => 
                    { 
                        options.WithOrigins("http://localhost:5000",
                                            "http://localhost:5000/",
                                            "http://localhost:80",
                                            "http://localhost:80/",
                                            "http://localhost",
                                            "http://10.40.126.228:80",
                                            "http://10.40.126.228:80/",
                                            "http://10.40.126.228:5000",
                                            "http://10.40.126.228:5000/")
                                                    .AllowAnyMethod() 
                                                    .AllowAnyHeader();
                    });
            });

            // ----- Http -----
            services.AddCustomizedHttp(Configuration);

            // .NET Native DI Abstraction
            RegisterServices(services);

            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/Identity/Account/Login";
                options.LogoutPath = "/Identity/Account/Logout";
                options.AccessDeniedPath = "/Identity/Account/AccessDenied";
            });

            services.AddSignalR();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseExceptionHandler(err => err.UseCustomErrors(env));
            }
            else
            {
                app.UseExceptionHandler("/error");
                app.UseHsts();
            }

            var supportedCultures = new[] { "pt-BR" };
            var localizationOptions = new RequestLocalizationOptions()
                                            .SetDefaultCulture(supportedCultures[0])
                                            .AddSupportedCultures(supportedCultures)
                                            .AddSupportedUICultures(supportedCultures);

            app.UseRequestLocalization(localizationOptions);
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();

            // ----- Auth -----
            app.UseCustomizedAuth();

            app.UseCors(
                options => options.WithOrigins("https://localhost:5001").AllowAnyMethod()
            );

            app.UseSession();

            app.UseTenant();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    "default",
                    "{controller=Home}/{action=Index}");
                endpoints.MapRazorPages();
                endpoints.MapHub<NotificationHub>("/notificacaoHub");
            });
        }

        private class GuidTypeHandler : SqlMapper.TypeHandler<Guid>
        {
            public override void SetValue(IDbDataParameter parameter, Guid value) => parameter.Value = value;

            public override Guid Parse(object value) => Guid.Parse((string)value);
        }

        private static void RegisterServices(IServiceCollection services)
        {
            // Adding dependencies from another layers (isolated from Presentation)
            NativeInjectorBootStrapper.RegisterServices(services);
        }
    }
}