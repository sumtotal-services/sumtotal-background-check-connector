using System;
using System.Collections.Generic;
using System.Text;

namespace SumTotal.Template.Connector.Models
{
    /// <summary>
    /// BackGroundCheck Invite Response from vendor
    /// </summary>
    public class BackGroundCheckInviteResponse
    {
        /// <summary>
        /// Gets or sets the Id
        /// </summary>
        /// <value>Id</value>
        public int Id { get; set; }

        /// <summary>
        /// The unique identifier of the candidate 
        /// </summary>
        /// <value>Candidate Id</value>
        public string CandidateId { get; set; }

        /// <summary>
        /// The unique id for each screening
        /// </summary>
        /// <value>Order Id</value>
        public string OrderId { get; set; }

        /// <summary>
        /// The unique id for each candidate invitation
        /// </summary>
        /// <value>Applicant Id</value>
        public string ApplicantId { get; set; }

        /// <summary>
        /// Response status
        /// </summary>
        /// <value>Http Status</value>
        public System.Net.HttpStatusCode HttpStatusCode { get; set; }
    }
}
