using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace SumTotal.Sample.Connector.Models.Checkr
{
    [DataContract]
    public class CheckrInviteResponse
    {

        /// <summary>
        ///The Invitation's ID.
        /// </summary>
        [DataMember(Name = "id")]
        public string ID { get; set; }

        /// <summary>
        /// Value:"invitation"
        /// </summary>
        public string Object { get; set; }

        /// <summary>
        /// URI of the resource
        /// </summary>
        public string Uri { get; set; }

        /// <summary>
        /// URL for the Invitation.
        /// </summary>
        public string InvitationUrl { get; set; }

        /// <summary>
        /// Status of the Invitation.
        /// </summary>
        public string status { get; set; }

        /// <summary>
        /// Time at which the Invitation was created
        /// </summary>
        public string CreatedAt { get; set; }

        /// <summary>
        /// Time at which the Invitation will expire.
        /// </summary>
        public string ExpiresAt { get; set; }

        /// <summary>
        /// Time at which the Invitation was completed by the candidate.
        /// </summary>
        public string CompletedAt { get; set; }

        /// <summary>
        /// Time at which the Invitation was deleted.
        /// </summary>
        public string DeletedAt { get; set; }

        /// <summary>
        /// Package associated with the Invitation.
        /// </summary>
        public string Package { get; set; }

        /// <summary>
        /// ID of the candidate to whom the invitation was issued.
        /// </summary>
        [DataMember(Name = "candidate_id")]
        public string CandidateId { get; set; }

        /// <summary>
        /// Id of the report created
        /// </summary>
        [DataMember(Name = "report_id")]
        public string ReportId { get; set; }
    }
}
