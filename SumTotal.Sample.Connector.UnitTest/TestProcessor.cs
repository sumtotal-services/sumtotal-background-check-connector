using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using SumTotal.Sample.Connector.Models;
using SumTotal.Sample.Connector.Models.Checkr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace SumTotal.Sample.Connector.UnitTest
{
    public class TestProcessor
    {

        /// <summary>
        /// Test method for Unit test project
        /// </summary>
        /// <param name="val">Value</param>
        /// <returns>Value</returns>
        public string TestMethod(string val)
        {
            return val;
        }

        public IList<CheckrPackageDetails> CheckrGetPackages(string url)
        {
            HttpClient http = new HttpClient();
            var data = http.GetAsync(url).Result.Content.ReadAsStringAsync().Result;
            IList<CheckrPackageDetails> packageDetails = JsonConvert.DeserializeObject<List<CheckrPackageDetails>>(data);
            return packageDetails;
        }

        public CheckrPackageDetails CheckrGetPackageById(string url)
        {
            HttpClient http = new HttpClient();
            var data = http.GetAsync(url).Result.Content.ReadAsStringAsync().Result;
            CheckrPackageDetails packageDetail = JsonConvert.DeserializeObject<CheckrPackageDetails>(data);
            return packageDetail;
        }
       
    }
}
