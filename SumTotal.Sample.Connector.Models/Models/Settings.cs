using System.Collections.Generic;

namespace SumTotal.Sample.Connector.Models
{
    public class Settings
    {
       public string ConnectorId { get; set; }

        public string ConnectorSecret { get; set; }

        public SumtOAuthSettings SumtOAuthSettings { get; set; }

        public IList<Vendors> Vendors { get; set; }
    }
    
    public class Vendors
    {
        public string VendorId { get; set; }
     

        public VendorOAuthSettings VendorOAuthSettings { get; set; }
    }
    public class VendorOAuthSettings
    {
        public string SumtCallBackUrl { get; set; }

        public string VendorOauth { get; set; }

        public string VendorUser { get; set; }

        public string VendorPassword { get; set; }

        public string BaseUrl { get; set; }


    }

    public class SumtOAuthSettings
    {
        public string ClientId { get; set; }

        public string ClientSecret { get; set; }

        public string Authority { get; set; }

        public string Scope { get; set; }
    }
}
