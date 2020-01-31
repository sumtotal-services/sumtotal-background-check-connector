using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;

namespace SumTotal.Sample.Connector.Main
{
    public class Program
    {   /// <summary>
        /// Program entry point
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
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
		/// This Builder is used to test the app
		/// </summary>
		/// <param name="args"></param>
		/// <returns></returns>
        public static IWebHostBuilder CreateWebHostBuilder(string[] args, IConfiguration config) =>
            WebHost.CreateDefaultBuilder(args)
              .UseIISIntegration()
              .UseConfiguration(config)
              .UseContentRoot(Directory.GetCurrentDirectory())
              .UseSerilog()
              .UseStartup<Startup>();


    }
}
