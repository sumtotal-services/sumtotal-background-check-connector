using System;
using System.Collections.Generic;
using System.Text;

namespace SumTotal.Sample.Connector.Models
{

    /// <summary>
    /// Candidate Identity model
    /// </summary>
    public class CandidateIdentity
    {
        /// <summary>
        /// The Type property gets/sets the value of the identity Type.
        /// </summary>
        /// <value>The type of GovernmentIds.Ex:SSN/PassPort</value>
        public string Type { get; set; }

        /// <summary>
        /// The IdNumber property gets/sets the value of the Id Number.
        /// </summary>
        /// <value>Id number</value>
        public string IdNumber { get; set; }

        /// <summary>
        /// The IssueDate property gets/sets the value of the Id Issue Date.
        /// </summary>
        /// <value>Id issue date. suggested format: yyyy-MM-dd.</value>
        public string IssueDate { get; set; }

        /// <summary>
        /// The ExpiryDate property gets/sets the value of the Id Expiry Date.
        /// </summary>
        /// <value>Id expiry date. suggested format: yyyy-MM-dd.</value>
        public string ExpiryDate { get; set; }

        /// <summary>
        /// The IssuedCountry property gets/sets the value of the Issued Country.
        /// </summary>
        /// <value>Id issued country.</value>
        public string IssuedCountry { get; set; }
    }

    /// <summary>
    /// identity types available
    /// </summary>
    public static class IdentityType
    {
        public const string SSN = "SSN";
        public const string PASSPORT = "PASSPORT";
        public const string GOVT = "GOVT";  

    }
}