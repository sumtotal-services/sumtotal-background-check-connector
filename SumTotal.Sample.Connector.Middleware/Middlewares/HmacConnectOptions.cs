using Microsoft.AspNetCore.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SumTotal.Sample.Connector.Middleware
{
    public class HmacConnectOptions : AuthenticationSchemeOptions
    {
        /// <summary>
        /// Gets or sets the connector id.
        /// </summary>
        public string AuthenticationScheme { get; set; } = "HmacConnect";

        /// <summary>
        /// Gets or sets the connector id.
        /// </summary>
        public string ConnectorId { get; set; }

        /// <summary>
        /// Gets or sets the connector secret.
        /// </summary>
        public string ConnectorSecret { get; set; }

        /// <summary>
        /// Check that the options are valid.  Should throw an exception if things are not ok.
        /// </summary>
        public override void Validate()
        {
            if (string.IsNullOrEmpty(ConnectorId))
            {
                throw new ArgumentException("Options.ConnectorId must be provided", nameof(ConnectorId));
            }

            if (string.IsNullOrEmpty(ConnectorSecret))
            {
                throw new ArgumentException("Options.ConnectorSecret must be provided", nameof(ConnectorSecret));
            }
        }
    }
}
