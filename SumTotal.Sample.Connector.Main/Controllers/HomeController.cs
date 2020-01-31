using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Logging;
using System.IO;
using System.Collections.Generic;
using SumTotal.Sample.Connector.Models;
using Microsoft.AspNetCore.Authorization;

namespace SumTotal.Sample.Connector.Main.Controllers
{
    public class HomeController : Controller
    {
        private readonly Settings setting;
        private readonly HttpClient client;
        private readonly ILogger<HomeController> _logger;
        private readonly IOptions<SumTotal.Sample.Connector.Models.Serilog> _arguments;
        private const string AUTHENTICATIONSCHEME = "HmacConnect";

        public HomeController(IOptionsSnapshot<Settings> settings, IHttpClientFactory httpClient,
                              ILogger<HomeController> logger, IOptions<SumTotal.Sample.Connector.Models.Serilog> arguments)
        {
            setting = settings.Value;
            client = httpClient.CreateClient();
            this._logger = logger;
            this._arguments = arguments;
        }

        public IActionResult Index()
        {
            _logger.LogInformation("Test logger message");
            return Ok("Connector is running !");
        }

        /// <summary>
        /// fetch the logs for the data provided
        /// </summary>
        /// <returns>Log file</returns>
        [Authorize(AuthenticationSchemes = AUTHENTICATIONSCHEME)]
        public async Task<IActionResult> RetrieveLogFile()
        {
            // If no date value is provided set the log date to current date

             var  logDate = DateTime.Now;

            // Fetch the serilog configuration from appsettings.json
            var value = _arguments.Value;

            // Set the path of the file according to serilog configuration setting
            var path = value.WriteTo[0].Args.PathFormat.Split('.')[0].Replace("{Date}", Convert.ToDateTime(logDate).ToString("yyyyMMdd"));

            // Copy the log file that needs to be downloaded
            System.IO.File.Copy(path + ".txt", path + "_1.txt", true);
            var memory = new MemoryStream();

            // Copy the log file and download it to the client browser
            using (var stream = new FileStream(path + "_1.txt", FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;
            return File(memory, GetContentType(path + "_1.txt"), Path.GetFileName(path + "_1.txt"));
        }

        /// <summary>
        /// Get the file type
        /// </summary>
        /// <param name="path">Path of the file</param>
        /// <returns>File type</returns>
        private string GetContentType(string path)
        {
            var types = GetMimeTypes();
            var ext = Path.GetExtension(path).ToLowerInvariant();
            return types[ext];
        }

        /// <summary>
        /// Get mime types for the file
        /// </summary>
        /// <returns>Set of Mime types </returns>
        private Dictionary<string, string> GetMimeTypes()
        {
            return new Dictionary<string, string>
            {
                {".txt", "text/plain"},
                {".pdf", "application/pdf"},
                {".doc", "application/vnd.ms-word"},
                {".docx", "application/vnd.ms-word"},
                {".xls", "application/vnd.ms-excel"},
                {".xlsx", "application/vnd.openxmlformatsofficedocument.spreadsheetml.sheet"},  
                {".png", "image/png"},
                {".jpg", "image/jpeg"},
                {".jpeg", "image/jpeg"},
                {".gif", "image/gif"},
                {".csv", "text/csv"}
            };
        }

    }
}
