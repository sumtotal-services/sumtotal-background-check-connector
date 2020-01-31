using SumTotal.Sample.Connector.Models.Checkr;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace SumTotal.Sample.Connector.Models.Checkr
{

    /// <summary>
    /// Status update for invite candidate
    /// </summary>
    [DataContract]
    public class CheckrInviteStatus
    {
        /// <summary>
        /// Applicant Id of the candidate
        /// </summary>
        [DataMember]
        public string Id { get; set; }

        /// <summary>
        /// Object of the Type
        /// </summary>
        [DataMember]
        public string Object { get; set; }

        /// <summary>
        /// Type of event
        /// </summary>
        [DataMember]
        public string Type { get; set; }

        /// <summary>
        /// Check the status details or update it
        /// </summary>
        [DataMember(Name = "webhook_url")]
        public string WebhookUrl { get; set; }

        /// <summary>
        /// Check created date
        /// </summary>
        [DataMember(Name = "created_at")]
        public string CreatedAt { get; set; }

        /// <summary>
        /// Candidate details object
        /// </summary>
        [DataMember(Name = "data")]
        public InviteCandidate Data { get; set; }
    }

    /// <summary>
    /// Candidate object
    /// </summary>
    [DataContract]
    public class InviteCandidate
    {
        [DataMember(Name = "object")]
        public CheckrInviteResponse Object { get; set; }
    }
}
