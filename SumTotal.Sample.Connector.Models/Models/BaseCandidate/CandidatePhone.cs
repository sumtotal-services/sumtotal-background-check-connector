using System;
using System.Collections.Generic;
using System.Text;

namespace SumTotal.Sample.Connector.Models
{
    /// <summary>
    /// Candidate Phone model class
    /// </summary>
    public class CandidatePhone
    {
        /// <summary>
        /// Phone number for the candidate.
        /// </summary>
        /// <value>The PhoneNumber property gets/sets the value of the PhoneNumber.</value>
        public string PhoneNumber { get; set; }

        /// <summary>
        ///Specifies country code. Default is +1
        /// </summary>
        /// <value>The CountryCode property gets/sets the value of the Country Code.</value>
        public string CountryCode { get; set; }

        /// <summary>
        ///Specifies extension
        /// </summary>
        /// <value>The Extension property gets/sets the value of the Extension.</value>
        public string Extension { get; set; }

        /// <summary>
        ///Specifies the priority of phone number. Default is primary
        /// </summary>
        /// <value>The Type property gets/sets the value of the Type.</value>
        public string Type { get; set; }

    }
}
