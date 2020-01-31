using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SumTotal.Template.Connector.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace SumTotal.Template.Connector.Api.Controllers
{
    /// <summary>
    /// HomeApiController class. This class Contains logs related code
    /// </summary>
    public class HomeApiController : Controller
    {
        /// <summary>
        /// Setting object used to fetch values from "appsettings.json" file
        /// </summary>
        private readonly Settings setting;

        /// <summary>
        /// HttpClient object used to hit any vendor url to get or post the data
        /// </summary>
        private readonly HttpClient client;

        /// <summary>
        /// logger object used to log any warning or error message to a text file
        /// </summary>
        private readonly ILogger<HomeApiController> _logger;

        /// <summary>
        /// This configuration object fetches the serilog logger configuration from the configuration file("appsettings.json")
        /// </summary>
        private readonly IOptions<SumTotal.Template.Connector.Models.Serilog> _arguments;

        /// <summary>
        /// Constructor of the controller
        /// </summary>
        /// <param name="settings">settings</param>
        /// <param name="httpClient">httpClient</param>
        /// <param name="logger">logger</param>
        /// <param name="arguments">arguments</param>
        public HomeApiController(IOptionsSnapshot<Settings> settings, IHttpClientFactory httpClient,
                              ILogger<HomeApiController> logger, IOptions<SumTotal.Template.Connector.Models.Serilog> arguments)
        {
            setting = settings.Value;
            client = httpClient.CreateClient();
            this._logger = logger;
            this._arguments = arguments;
        }

        /// <summary>
        /// It does not contain any functionality, It is just a sample method.
        /// Which is getting hit by default on running of this application for testing.
        /// </summary>
        /// <returns> Sample message </returns>
        public IActionResult Index()
        {
            _logger.LogInformation("Test logger message");
            return Ok("Connector is running !");
        }

        /// <summary>
        /// This method is used to fetch the connector logs for the specific date
        /// </summary>
        /// <param name="logDate"> Date for which logs will be fetched</param>
        /// <returns>Log file</returns>
        public async Task<IActionResult> RetrieveLogFile(DateTime? logDate)
        {
            return null;
        }

        /// <summary>
        /// This method returns the file type
        /// </summary>
        /// <param name="path">Path of the file</param>
        /// <returns>File type</returns>
        private string GetContentType(string path)
        {
            return null;
        }

        /// <summary>
        /// Get mime types for the file
        /// </summary>
        /// <returns>Set of Mime types </returns>
        private Dictionary<string, string> GetMimeTypes()
        {
            return null;
        }

    }
}
