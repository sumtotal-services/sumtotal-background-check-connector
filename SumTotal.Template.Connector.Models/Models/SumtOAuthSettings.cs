using System;
using System.Collections.Generic;
using System.Text;

namespace SumTotal.Template.Connector.Models
{
    /// <summary>
    /// Sumt OAuth Settings model
    /// </summary>
    public class SumtOAuthSettings
    {
        /// <summary>
        /// The ClientId property gets/sets the value of the Client Id.
        /// </summary>
        /// <value>Client Id of SumtOAuth</value>
        public string ClientId { get; set; }

        /// <summary>
        /// The ClientSecret property gets/sets the value of the ClientSecret.
        /// </summary>
        /// <value>Client Secret key of SumtOAuth</value>
        public string ClientSecret { get; set; }

        /// <summary>
        /// The Authority property gets/sets the value of the Authority.
        /// </summary>
        /// <value>Authority in SumtOAuth Settings</value>
        public string Authority { get; set; }

        /// <summary>
        /// The Scope property gets/sets the value of the Scope.
        /// </summary>
        /// <value>Scope of SumtOAuth</value>
        public string Scope { get; set; }
    }
}
