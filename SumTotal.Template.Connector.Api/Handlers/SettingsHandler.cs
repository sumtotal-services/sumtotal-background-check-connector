using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SumTotal.Template.Connector.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace SumTotal.Template.Connector.Api.Handlers
{
    /// <summary>
    /// SettingsHandler class used to get and modify the settings for vendors
    /// </summary>
    public class SettingsHandler
    {
        /// <summary>
        /// ILogger object
        /// </summary>
        private readonly ILogger _logger;

        /// <summary>
        /// Constructor for SettingsHandler class
        /// </summary>
        /// <param name="logger"></param>
        public SettingsHandler(ILogger<SettingsHandler> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Get settings by vendor id
        /// </summary>
        /// <param name="vendorId">vendorId</param>
        /// <param name="setting">setting</param>
        /// <returns>Settings</returns>
        public string GetSettings(string vendorId, Settings setting)
        {
            Vendors vendor = setting.Vendors.Where(x => x.VendorId.ToLower() == vendorId.ToLower()).FirstOrDefault();
            if (vendor != null)
            {
                var serialized = JsonConvert.SerializeObject(vendor.VendorOAuthSettings);
                return serialized;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///  update settings 
        /// </summary>
        /// <param name="vendorSettings">vendorSettings</param>
        /// <param name="hostingEnvironment"></param>
        /// <param name="setting">setting</param>
        /// <returns>Vendor oAuth setting</returns>
        public string UpdateSettings(Vendors vendorSettings, IHostingEnvironment hostingEnvironment, Settings setting)
        {
            try
            {
                if (vendorSettings != null)
                {
                    string contentRootPath = hostingEnvironment.ContentRootPath;
                    string filepath = contentRootPath + "/appsettings.json";

                    string result = string.Empty;
                    using (StreamReader r = new StreamReader(filepath))
                    {
                        var jsonConfigurationData = r.ReadToEnd();
                        var jobjConfigurationDataObject = JObject.Parse(jsonConfigurationData);
                        var appSettings = (JArray)jobjConfigurationDataObject["Settings"]["Vendors"];

                        foreach (var providor in appSettings.Where(obj => obj["VendorId"].Value<string>() == vendorSettings.VendorId))
                        {
                            providor["VendorOAuthSettings"] = JObject.Parse(JsonConvert.SerializeObject(vendorSettings.VendorOAuthSettings));
                        }

                        result = jobjConfigurationDataObject.ToString();

                    }
                    System.IO.File.WriteAllText(filepath, result);
                    Vendors vendor = setting.Vendors.Where(x => x.VendorId == vendorSettings.VendorId).FirstOrDefault();
                    if (vendor != null)
                    {
                        setting.Vendors.Where(x => x.VendorId == vendorSettings.VendorId).FirstOrDefault().VendorOAuthSettings = vendorSettings.VendorOAuthSettings;
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            var serialized = JsonConvert.SerializeObject(setting.Vendors[0].VendorOAuthSettings);
            return serialized;
        }

    }
}
