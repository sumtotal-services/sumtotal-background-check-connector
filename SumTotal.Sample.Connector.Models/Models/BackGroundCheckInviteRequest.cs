using System;
using System.Collections.Generic;
using System.Text;
using SumTotal.Sample.Connector.Models;

namespace SumTotal.Sample.Connector.Models
{
    /// <summary>
    /// BackGroundCheckInviteRequest model class
    /// </summary>
    public class BackGroundCheckInviteRequest
    {
        /// <summary>
        /// The CandidateId property gets/sets the value of the Candidate Id.
        /// </summary>
        /// <value>Id of the candidate</value>
        public string CandidateId { get; set; }

        /// <summary>
        /// The Candidate property gets/sets the value of the Candidate Details.
        /// </summary>
        /// <value>Candidate details</value>
        public Candidate Candidate { get; set; }

        /// <summary>
        /// The PackageId property gets/sets the value of the Package Id.
        /// </summary>
        /// <value>The unique identifier for the package the candidate will be screened against</value>
        public string PackageId { get; set; }

        /// <summary>
        /// The PackageName property gets/sets the value of Package Name.
        /// </summary>
        /// <value>Name of the package</value>
        public string PackageName { get; set; }

        /// <summary>
        /// The Package alias Name of the Provider
        /// </summary>
        /// <value>Recruiting Package alias name.</value>
        public string PackageAlias { get; set; }

        /// <summary>
        /// The PositionApplied property gets/sets the value of the position that Candidate has applied for which should be either Internal or External Requisition Title based on the candidate.
        /// </summary>
        /// <value>The position that Candidate has applied for</value>
        public string PositionApplied { get; set; }

        /// <summary>
        /// The PositionLocations property gets/sets the location value of the position that Candidate has applied for
        /// </summary>
        /// <value>Position Locations reference.</value>
        public IList<PositionLocationDTO> PositionLocations { get; set; }

        /// <summary>
        /// The StatusNotificationUrl property gets/sets the value of the Status Notification Url.
        /// </summary>
        /// <value>The CallBack URL for the employer to view the background check</value>
        public string StatusNotificationUrl { get; set; }

        /// <summary>
        /// Quote Backs
        /// </summary>
        /// <value>Quote Backs List</value>
        public IList<PositionQuoteBacksDTO> QuoteBacks { get; set; }

        /// <summary>
        /// The Locale property gets/sets the value of Position Locale.
        /// </summary>
        /// <value>Position Locale DTO</value>
        public PackagePositionLocaleDTO Locale { get; set; }

        /// <summary>
        /// The AdditionalAttributes property gets/sets the value of the position Additional attributes
        /// </summary>
        /// <value>Additional Attributes</value>
        public PackagePositionAdditionalAttributesDTO AdditionalAttributes { get; set; }

        /// <summary>
        /// The CandidateType property gets/sets the value of Candidate Type.
        /// </summary>
        /// <value>Candidate Type</value>
        public string CandidateType { get; set; }

        /// <summary>
        /// The Documents property gets/sets the value of Documents.
        /// </summary>
        /// <value>Documents if there are any</value>
        public PackageDocumentsDTO Documents { get; set; }

        /// <summary>
        /// User Defined Fields
        /// </summary>
        /// <value>UserDefinedFields reference.</value>
        public IList<string> UserDefinedFields { get; set; }

        /// <summary>
        /// The BillingAccount property gets/sets the value of the Billing Account.
        /// </summary>
        /// <value>The Requesting Account /chargeId</value>
        public string BillingAccount { get; set; }


        /// <summary>
        /// The ClientReference property gets/sets the value of the Client Reference.
        /// </summary>
        /// <value>Client specified codes</value>
        public IList<string> ClientReference { get; set; }
    }

}
