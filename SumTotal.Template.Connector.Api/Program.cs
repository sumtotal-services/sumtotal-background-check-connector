using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Serilog;

namespace SumTotal.Template.Connector.Api
{
    /// <summary>
    /// Program class used create a host for the web application
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Main method contains the code for creating the host
        /// </summary>
        /// <param name="args">args</param>
        public static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();
            Log.Logger = new LoggerConfiguration()
            .ReadFrom.Configuration(config)
           .CreateLogger();
            try
            {
                Log.Information("Starting connector service...");
                CreateWebHostBuilder(args, config).Build().Run();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Connector service terminated unexpectedly");
            }
        }

        /// <summary>
        /// Create and return the web host builder object
        /// </summary>
        /// <param name="args">args</param>
        /// <param name="config">config</param>
        /// <returns> Webhostbuilder object</returns>
        public static IWebHostBuilder CreateWebHostBuilder(string[] args, IConfiguration config) =>
                     WebHost.CreateDefaultBuilder(args)
              .UseIISIntegration()
              .UseConfiguration(config)
              .UseContentRoot(Directory.GetCurrentDirectory())
              .UseSerilog()
              .UseStartup<Startup>();
    }
}
