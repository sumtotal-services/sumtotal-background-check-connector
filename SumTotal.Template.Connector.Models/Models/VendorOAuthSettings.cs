using System;
using System.Collections.Generic;
using System.Text;

namespace SumTotal.Template.Connector.Models
{
    /// <summary>
    /// Vendor OAuth Settings model
    /// </summary>
    public class VendorOAuthSettings
    {
        /// <summary>
        /// The SumtCallBack Url property gets/sets the value of the SumtCallBack Url.
        /// </summary>
        /// <value>Sumt CallBack Url</value>
        public string SumtCallBackUrl { get; set; }

        /// <summary>
        /// The VendorOauth property gets/sets the value of the Vendor Oauth.
        /// </summary>
        /// <value>Vendor Oauth value</value>
        public string VendorOauth { get; set; }

        /// <summary>
        /// The VendorUser property gets/sets the value of the Vendor User.
        /// </summary>
        /// <value>Vendor User/client Id</value>
        public string VendorUser { get; set; }

        /// <summary>
        /// The VendorPassword property gets/sets the value of the Vendor Password.
        /// </summary>
        /// <value>Vendor Password/client Secret</value>
        public string VendorPassword { get; set; }

        /// <summary>
        /// The BaseUrl property gets/sets the value of the Base Url.
        /// </summary>
        /// <value>Base Url of the vendor</value>
        public string BaseUrl { get; set; }


    }
}
