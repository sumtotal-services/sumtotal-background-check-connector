using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using SumTotal.Template.Connector.Models;
using System;
using System.Security.Cryptography;
using System.Text;

namespace SumTotal.Template.Connector.Api.Filters
{
    /// <summary>
    /// SetSecurityHeader class to set authentication hash with the response
    /// </summary>
    public class SetSecurityHeader : IActionFilter
    {
        /// <summary>
        /// Settings object
        /// </summary>
        private readonly Settings options;

        /// <summary>
        /// Set the security header from settings value
        /// </summary>
        /// <param name="settings">settings</param>
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
            string content = JsonConvert.SerializeObject((context.Result as ObjectResult).Value);
            using (var hmac = new HMACSHA256())
            {
                hmac.Key = Encoding.ASCII.GetBytes(options.ConnectorSecret);
                var hashByte = hmac.ComputeHash(Encoding.ASCII.GetBytes(content));
                var contentHash = BitConverter.ToString(hashByte).Replace("-", "").ToLower();
                httpContext.Response.Headers.Add("X-Data-Hash", contentHash);
            }
        }

        /// <summary>
        /// To be invoked before executing an action method
        /// </summary>
        /// <param name="context">context</param>
        public void OnActionExecuting(ActionExecutingContext context)
        {
            return;
        }
    }
}
