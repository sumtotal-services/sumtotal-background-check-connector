using System;
using System.Collections.Generic;
using System.Text;

namespace SumTotal.Sample.Connector.Models
{ 
  /// <summary>
  /// Candidate License model
  /// </summary>
    public class CandidateLicense
    {
        /// <summary>
        /// The Type property gets/sets the value of the Type.
        /// </summary>
        /// <value>The type of license.</value>
        public string Type { get; set; }

        /// <summary>
        /// The LicenseNumber property gets/sets the value of the License Number.
        /// </summary>
        /// <value>The license number</value>
        public string LicenseNumber { get; set; }

        /// <summary>
        ///  The IssueDate property gets/sets the value of the License Issue Date.
        /// </summary>
        /// <value>Id issue date. suggested format: yyyy-MM-dd.</value>
        public string IssueDate { get; set; }

        /// <summary>
        /// The ExpiryDate property gets/sets the value of the License Expiry Date.
        /// </summary>
        /// <value>Id issue date. suggested format: yyyy-MM-dd.</value>
        public string ExpiryDate { get; set; }

        /// <summary>
        /// The IssuedCountry property gets/sets the value of the License Issued Country.
        /// </summary>
        /// <value>The license issue country.</value>
        public string IssuedCountry { get; set; }

        /// <summary>
        /// The IssuedState property gets/sets the value of the Issued State.
        /// </summary>
        /// <value>The license issue state.</value>
        public string IssuedState { get; set; }
    }
}
