using LiteDB;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SumTotal.Sample.Connector.Main.Handlers;
using SumTotal.Sample.Connector.Models;

using SumTotal.Sample.Connector.Middleware;
using SumTotal.Sample.Connector.Main.Filters;
using AutoMapper;

namespace SumTotal.Sample.Connector.Main
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                           .SetBasePath(env.ContentRootPath)
                           .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }

        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// <summary>
        public void ConfigureServices(IServiceCollection services)
        {
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
            services.Configure<Models.Serilog>(Configuration.GetSection("Serilog"));
        }
        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// <summary>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseAuthentication();
            
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
