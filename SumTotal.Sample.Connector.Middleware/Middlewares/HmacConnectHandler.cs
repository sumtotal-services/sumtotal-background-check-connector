using System;
using System.IO;
using System.Net.Http;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Primitives;

namespace SumTotal.Sample.Connector.Middleware
{
    public class HmacConnectHandler : AuthenticationHandler<HmacConnectOptions>
    {
        public HmacConnectHandler(
            IOptionsMonitor<HmacConnectOptions> options,
            ILoggerFactory logger,
            UrlEncoder encoder,
            ISystemClock clock) : base(options, logger, encoder, clock) { }

        protected async override Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            try
            {
                var content = string.Empty;
                var contentHash = string.Empty;

                if (Request.Method == HttpMethod.Get.ToString())
                {
                    content = Options.ConnectorId;
                }
                else
                {
                    using (StreamReader reader = new StreamReader(Request.Body, Encoding.ASCII))
                    {
                        content = await reader.ReadToEndAsync();
                    }
                }

                Request.Headers.TryGetValue("X-Data-Hash", out StringValues hash);

                if (string.IsNullOrEmpty(hash))
                    return AuthenticateResult.Fail("Unauthorized.");

                using (var hmac = new HMACSHA256())
                {
                    hmac.Key = Encoding.ASCII.GetBytes(Options.ConnectorSecret);
                    var hashByte = hmac.ComputeHash(Encoding.ASCII.GetBytes(content));
                    contentHash = BitConverter.ToString(hashByte).Replace("-", "").ToLower();
                }
                if (hash == contentHash)
                {
                    if(Request.Method == HttpMethod.Post.ToString())
                        Context.Items.Add("Data", content);
                    var claims = new[]
                    {
                        new Claim(ClaimTypes.NameIdentifier, Options.ConnectorId)
                    };
                    var principal = new ClaimsPrincipal(new ClaimsIdentity(claims, Options.AuthenticationScheme));
                    var ticket = new AuthenticationTicket(principal, new AuthenticationProperties(), Options.AuthenticationScheme);
                    return AuthenticateResult.Success(ticket);
                }
                else
                   return AuthenticateResult.Fail("Unauthorized.");
            }
            catch (Exception ex)
            {
                return AuthenticateResult.Fail("Unknown Exception");
            }
        }

    }
}