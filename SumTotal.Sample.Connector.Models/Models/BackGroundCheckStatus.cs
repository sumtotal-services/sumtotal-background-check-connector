using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace SumTotal.Sample.Connector.Models
{
    /// <summary>
    /// Model to update the status of the back ground check package assigned to candidate
    /// SumT expected object
    /// </summary>
    public class BackGroundCheckStatus
    {
        /// <summary>
        /// Applicant Id of the candidate
        /// </summary>
        [JsonProperty(PropertyName = "applicantId", Order = 1)]
        public string ApplicantId { get; set; }

        /// <summary>
        /// Vendor Package Id 
        /// </summary>
        ///
        [JsonProperty(PropertyName = "vendorPackageId", Order = 2)]
        public string VendorPackageId { get; set; }

        /// <summary>
        /// Candidate id in vendor side
        /// </summary>
        ///
        [JsonProperty(PropertyName = "vendorCandidateId", Order = 3)]
        public string VendorCandidateId { get; set; }

        /// <summary>
        /// Vendor name 
        /// </summary>
        ///
        [JsonProperty(PropertyName = "vendor", Order = 4)]
        public string Vendor { get; set; }


        /// <summary>
        /// Package issue date
        /// </summary>
        ///
        [JsonProperty(PropertyName = "checkIssueDate", Order = 5)]
        public string CheckIssueDate { get; set; }

        /// <summary>
        /// Package modified date 
        /// </summary>
        ///
        [JsonProperty(PropertyName = "checkModifiedDate", Order = 7)]
        public string CheckModifiedDate { get; set; }

        /// <summary>
        /// Status of the check
        /// </summary>
        [JsonProperty(PropertyName = "checkResult", Order = 8)]
        public string CheckResult { get; set; }

        /// <summary>
        /// Order Id of the candidate
        /// </summary>
        [JsonProperty(PropertyName = "orderId", Order = 9)]
        public string OrderId { get; set; }

        /// <summary>
        /// Report URL of the check
        /// </summary>
        [JsonProperty(PropertyName = "reportURL", Order = 10)]
        public string ReportURL { get; set; }
    }
}
