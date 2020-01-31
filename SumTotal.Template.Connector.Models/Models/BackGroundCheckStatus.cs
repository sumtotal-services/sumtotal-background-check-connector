using System;
using System.Collections.Generic;
using System.Text;

namespace SumTotal.Template.Connector.Models.Models
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
        /// <value>Applicant Id</value>
        public string ApplicantId { get; set; }

        /// <summary>
        /// Gets/sets the Vendor Package Id 
        /// </summary>
        ///<value>Vendor Package Id</value>
        public string VendorPackageId { get; set; }

        /// <summary>
        /// Candidate id in vendor side
        /// </summary>
        ///<value>Vendor Candidate Id</value>
        public string VendorCandidateId { get; set; }

        /// <summary>
        /// Gets/sets the Vendor name 
        /// </summary>
        ///<value>Vendor</value>
        public string Vendor { get; set; }

        /// <summary>
        /// Package issue date
        /// </summary>
        ///<value>Check Issue Date</value>
        public string CheckIssueDate { get; set; }

        /// <summary>
        /// Gets/sets the Package modified date 
        /// </summary>
        ///<value>Check Modified Date</value>
        public string CheckModifiedDate { get; set; }

        /// <summary>
        /// Gets/sets the status of the check
        /// </summary>
        /// <value>Check Result</value>
        public string CheckResult { get; set; }
    }
}
