using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace SumTotal.Sample.Connector.Models.Checkr
{
    /// <summary>
    /// Check object to update status
    /// </summary>
    [DataContract]
    public class CheckrCheckStatus
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
        public CheckData Data { get; set; }

    }

    /// <summary>
    /// Check data object
    /// </summary>
    /// 
    [DataContract]
    public class CheckData
    {
        [DataMember(Name = "object")]
        public CheckrReportResponse Object { get; set; }
    }

    [DataContract]
    public class CheckrReportResponse
    {
        /// <summary>
        /// ApplicantId of the candidate
        /// </summary>
        [DataMember]
        public string Id { get; set; }

        /// <summary>
        /// Type of the object
        /// </summary>
        [DataMember ( Name ="object")]
        public string ObjectType { get; set; }

        /// <summary>
        /// Call Back Url to view the reports from vendor
        /// </summary>
        [DataMember]
        public string Uri { get; set; }

        /// <summary>
        /// Created date of the check 
        /// </summary>

        [DataMember( Name = "created_at")]
        public string CreatedAt { get; set; }

        /// <summary>
        /// Received date of the check
        /// </summary>
        [DataMember(Name = "received_at")]
        public string ReceivedAt { get; set; }

        /// <summary>
        /// Status of the check
        /// </summary>
        [DataMember(Name = "status")]
        public string Status { get; set; }

        /// <summary>
        /// Package of the check
        /// </summary>
        [DataMember(Name = "package")]
        public string Package { get; set; }

        /// <summary>
        /// Id of the candidate
        /// </summary>
        [DataMember(Name = "candidate_id")]
        public string CandidateId { get; set; }

        /// <summary>
        /// SSN Trace Id of the candidate
        /// </summary>
        [DataMember(Name = "ssn_trace_id")]
        public string SSNTraceId { get; set; }
        
        /// <summary>
        /// Sex offender search Id
        /// </summary>
        [DataMember(Name = "sex_offender_search_id")]
        public string SexOffenderSearchId { get; set; }

        /// <summary>
        /// National criminal Search Id
        /// </summary>
        [DataMember(Name = "national_criminal_search_id")]
        public string NationalCriminalSearchId { get; set; }
    }
}
