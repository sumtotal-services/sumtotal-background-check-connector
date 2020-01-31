using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace SumTotal.Sample.Connector.Models.Checkr
{
    [DataContract]
    public class CheckrInviteRequest
    {
        /// <summary>
        /// The Package property gets/sets the value of the Package.
        /// </summary>
        /// <value>The unique identifier for the package name the candidate will be screened against</value>
        [DataMember(Name = "package")]
        public string Package{ get; set; }

        /// <summary>
        /// The CandidateId property gets/sets the value of the CandidateId.
        /// </summary>
        /// <value>The unique identifier of the candidate to be screened</value>
        [DataMember(Name = "candidate_id")]
        public string CandidateId { get; set; }
    }
}
