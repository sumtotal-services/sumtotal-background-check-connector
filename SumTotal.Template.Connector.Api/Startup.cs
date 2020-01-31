using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SumTotal.Template.Connector.Api.Filters;
using SumTotal.Template.Connector.Api.Handlers;
using SumTotal.Template.Connector.Middleware.Middlewares;
using SumTotal.Template.Connector.Models;

namespace SumTotal.Template.Connector.Api
{
    public class Startup
    {
        /// <summary>
        /// Iniatialize the configurations for the project
        /// </summary>
        /// <param name="env">env</param>
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
               .SetBasePath(env.ContentRootPath)
               .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            Configuration = builder.Build();
        }

        /// <summary>
        /// Configuration object
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        /// <param name="services">services</param>
        public void ConfigureServices(IServiceCollection services)
        {
            //In Asp.net Core, authentication is configured via servces.
            services.AddAuthentication().AddHmacConnect(options =>
            {
                options.ConnectorId = Configuration.GetValue<string>("Settings:ConnectorId");
                options.ConnectorSecret = Configuration.GetValue<string>("Settings:ConnectorSecret");
            });

            services.AddSingleton<Settings>();
            services.Configure<Settings>(Configuration.GetSection("Settings"));
            services.AddSingleton<SettingsHandler>();
            services.AddScoped<SetSecurityHeader>();
            services.AddHttpClient();
            services.AddSingleton<IMapper>(new Mapper(new MapperConfiguration(cfg => cfg.AddProfile<DefaultMapper>())));
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            // Add functionality to inject IOptions<T>
            services.AddOptions();

            // Add our Config object so it can be injected and provide the section name to be fetched from config
            services.Configure<SumTotal.Template.Connector.Models.Serilog>(Configuration.GetSection("Serilog"));
        }


        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app">app</param>
        /// <param name="env">env</param>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseAuthentication();
            app.UseStaticFiles();
            app.UseCors(builder =>
            {
                builder.AllowAnyOrigin();
                builder.AllowAnyHeader();
                builder.AllowAnyMethod();
            });

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
