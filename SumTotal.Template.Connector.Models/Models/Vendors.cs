using System;
using System.Collections.Generic;
using System.Text;

namespace SumTotal.Template.Connector.Models
{
    /// <summary>
    /// Vendors model
    /// </summary>
    public class Vendors
    {
        /// <summary>
        /// The VendorId property gets/sets the value of the Vendor Id.
        /// </summary>
        /// <value>Vendor Id of the vendor</value>
        public string VendorId { get; set; }

        /// <summary>
        /// The VendorOAuthSettings property gets/sets the value of the Vendor OAuth Settings.
        /// </summary>
        /// <value>OAuth Settings of the vendor</value>
        public VendorOAuthSettings VendorOAuthSettings { get; set; }
    }
}
