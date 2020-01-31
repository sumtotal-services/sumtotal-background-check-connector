using System.Collections.Generic;

namespace SumTotal.Template.Connector.Models
{
    /// <summary>
    /// Settings model contains the configuration setting properties of the project, matching with appsettings.json file
    /// </summary>
    public class Settings
    {
        /// <summary>
        /// The ConnectorId property gets/sets the value of the Connector Id.
        /// </summary>
        /// <value>The connector Id</value>
        public string ConnectorId { get; set; }

        /// <summary>
        /// The ConnectorSecret property gets/sets the value of the Connector Secret key.
        /// </summary>
        /// <value>Connector Secret key</value>
        public string ConnectorSecret { get; set; }

        /// <summary>
        /// The SumtOAuthSettings property gets/sets the value of the Sumt OAuth Settings.
        /// </summary>
        /// <value>SumtOAuth Settings</value>
        public SumtOAuthSettings SumtOAuthSettings { get; set; }

        /// <summary>
        /// The Vendors property gets/sets the value of the Vendors.
        /// </summary>
        /// <value>Vendor list</value>
        public IList<Vendors> Vendors { get; set; }
    }
}
