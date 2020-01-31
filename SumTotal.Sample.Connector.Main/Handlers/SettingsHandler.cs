using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SumTotal.Sample.Connector.Models;
using System;
using System.IO;
using System.Linq;

namespace SumTotal.Sample.Connector.Main.Handlers
{
    /// <summary>
    /// Handler for settings
    /// </summary>
    public class SettingsHandler
    {
        /// <summary>
        /// Get settings by vendor id
        /// </summary>
        /// <param name="vendorId"></param>
        /// <returns></returns>
        public string GetSettings(string vendorId, Settings _setting)
        {
            Vendors vendor = _setting.Vendors.Where(x => x.VendorId.ToLower() == vendorId.ToLower()).FirstOrDefault();
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
        /// <param name="settings"></param>
        /// <returns></returns>
        public string UpdateSettings(Vendors settings, IHostingEnvironment _hostingEnvironment, Settings _setting)
        {
            try
            {
                if (settings != null)
                {
                    string contentRootPath = _hostingEnvironment.ContentRootPath;
                    string filepath = contentRootPath + "/appsettings.json";

                    string result = string.Empty;
                    using (StreamReader r = new StreamReader(filepath))
                    {
                        var json = r.ReadToEnd();
                        var jobj = JObject.Parse(json);
                        var appSettings = (JArray)jobj["Settings"]["Vendors"];

                        foreach (var providor in appSettings.Where(obj => obj["VendorId"].Value<string>() == settings.VendorId))
                        {
                            providor["VendorOAuthSettings"] = JObject.Parse(JsonConvert.SerializeObject(settings.VendorOAuthSettings));
                        }

                        result = jobj.ToString();

                    }
                    System.IO.File.WriteAllText(filepath, result);
                   Vendors vendor = _setting.Vendors.Where(x => x.VendorId == settings.VendorId).FirstOrDefault();
                    if (vendor != null)
                    {
                        _setting.Vendors.Where(x => x.VendorId == settings.VendorId).FirstOrDefault().VendorOAuthSettings = settings.VendorOAuthSettings;
                    }
                }
            }
            catch (Exception ex)
            {

            }
            var serialized = JsonConvert.SerializeObject(_setting.Vendors[0].VendorOAuthSettings);
            return serialized;
        }

    }
}
