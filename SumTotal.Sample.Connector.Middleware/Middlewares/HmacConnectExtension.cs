using Microsoft.AspNetCore.Authentication;
using System;

namespace SumTotal.Sample.Connector.Middleware
{
    public static class HmacConnectExtension 
    {
        /// <summary>
        /// The default value used for AuthenticationScheme.
        /// </summary>
        public const string AuthenticationScheme = "HmacConnect";
        public static AuthenticationBuilder AddHmacConnect(this AuthenticationBuilder builder, Action<HmacConnectOptions> configureOptions)
            => builder.AddHmacConnect(AuthenticationScheme, configureOptions);

        public static AuthenticationBuilder AddHmacConnect(this AuthenticationBuilder builder, string authenticationScheme,Action<HmacConnectOptions> configureOptions)
        {
            return builder.AddScheme<HmacConnectOptions, HmacConnectHandler>(authenticationScheme, AuthenticationScheme, configureOptions);
        }
    }
}
