using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Text;
using System.Security.Cryptography;
using Microsoft.Extensions.Options;
using SumTotal.Sample.Connector.Models;
using Newtonsoft.Json;

namespace SumTotal.Sample.Connector.Main.Filters
{
    public class SetSecurityHeader: IActionFilter
    {
        private readonly Settings options;

        public SetSecurityHeader(IOptionsSnapshot<Settings> settings)
        {
            options = settings.Value;
        }

        /// <summary>
        /// To be invoked after the action has executed
        /// </summary>
        /// <param name="context"></param>
        public void OnActionExecuted(ActionExecutedContext context)
        {
            var httpContext = context.HttpContext;
            if (httpContext.Response.Headers.ContainsKey("X-Data-Hash"))
                httpContext.Response.Headers.Remove("X-Data-Hash");
            string content =JsonConvert.SerializeObject((context.Result as ObjectResult).Value);
            using (var hmac = new HMACSHA256())
            {
                hmac.Key = Encoding.ASCII.GetBytes(options.ConnectorSecret);
                var hashByte = hmac.ComputeHash(Encoding.ASCII.GetBytes(content));
                var contentHash = BitConverter.ToString(hashByte).Replace("-", "").ToLower();
                httpContext.Response.Headers.Add("X-Data-Hash", contentHash);
            }
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            
        }
    }
}
