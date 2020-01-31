using System;
using System.Collections.Generic;
using System.Text;

namespace SumTotal.Template.Connector.Models
{
    /// <summary>
    /// Candidate Address model
    /// </summary>
    public class CandidateAddress
    {
        /// <summary>
        /// The City property gets/sets the value of the City.
        /// </summary>
        /// <value>The city or area of the given address</value>
        public string City { get; set; }

        /// <summary>
        /// The State property gets/sets the value of the State.
        /// </summary>
        /// <value>The state or area of the given address</value>
        public string State { get; set; }

        /// <summary>
        /// The Country property gets/sets the value of the Country.
        /// </summary>
        /// <value>The country of the residence address.</value>
        public string Country { get; set; }

        /// <summary>
        /// The ZipCode property gets/sets the value of the ZipCode.
        /// </summary>
        /// <value>The zip or postal code of the address.</value>
        public string ZipCode { get; set; }

        /// <summary>
        /// The StreetAddress property gets/sets the value of the Street Address.
        /// </summary>
        /// <value>The street of the address.</value>
        public string StreetAddress { get; set; }

        /// <summary>
        /// The StartAt property gets/sets the value of the StartAt.
        /// </summary>
        /// <value>The start date of the residence. date format: yyyy-MM-dd</value>
        public string StartAt { get; set; }

        /// <summary>
        /// The EndAt property gets/sets the value of the EndAt.
        /// </summary>
        /// <value>The end date of the residence. date format: yyyy-MM-dd</value>
        public string EndAt { get; set; }
    }
}
