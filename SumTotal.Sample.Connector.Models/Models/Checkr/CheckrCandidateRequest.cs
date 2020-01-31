using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace SumTotal.Sample.Connector.Models.Checkr
{
    [DataContract]
    public class CheckrCandidateRequest
    {
        /// <summary>
        /// The Id property gets/sets the value of the candidate Id.
        /// </summary>
        /// <value>Id</value>
        [DataMember]
        public string Id { get; set; }

        /// <summary>
        /// The FirstName property gets/sets the value of the First Name.
        /// </summary>
        /// <value>The candidate's given or "first" name, such as "Tim" in "Tim Duncan"</value>
        [DataMember(Name = "first_name")]
        public string FirstName { get; set; }

        /// <summary>
        /// The MiddleName property gets/sets the value of the MiddleName.
        /// </summary>
        /// <value>The candidate's middle name, useful for differentiating between individuals with similar names in public record searches.</value>
        [DataMember(Name = "middle_name")]
        public string MiddleName { get; set; }

        /// <summary>
        ///The ConfirmedNoMiddleName property gets/sets the value, if No Middle Name exist for the candidate.
        /// </summary>
        /// <value> true if the the candidate has no legal name. false if the candidate may have a legal middle name.</value>
        [DataMember(Name = "no_middle_name")]
        public bool ConfirmedNoMiddleName { get; set; }

        /// <summary>
        /// The LastName property gets/sets the value of the Last Name.
        /// </summary>
        /// <value>The candidate's last name, such as "Rowling" in "Joanne K Rowling".</value>
        [DataMember(Name = "last_name")]
        public string LastName { get; set; }

        /// <summary>
        /// The MotherMaidenName property gets/sets the value of the Mother Maiden Name.
        /// </summary>
        /// <value>The candidate's mother family name</value>
        [DataMember(Name = "mother_maiden_name")]
        public string MotherMaidenName { get; set; }

        /// <summary>
        /// The Dob property gets/sets the value of the Dob.
        /// </summary>
        /// <value>Date of birth, formatted as an ISO-8601 date(without the time component). For example, July 4, 1979 would be represented as "1979-07-04".</value>
        [DataMember(Name = "dob")]
        public string Dob { get; set; }

        /// <summary>
        ///  The Email property gets/sets the value of the Email.
        /// </summary>
        /// <value>The email provided by the candidate. Must be a unique, valid email.</value>
        [DataMember(Name = "email")]
        public string Email { get; set; }

        /// <summary>
        ///  The Phone property gets/sets the value of the Phone.
        /// </summary>
        /// <value>A phone number associated with the candidate, formatted as an E.164 string, such as +15555551234</value>
        [DataMember(Name = "phone")]
        public string Phone { get; set; }

        /// <summary>
        ///  The SSN property gets/sets the value of the SSN.
        /// </summary>
        /// <value>The social security number for the candidate, formatted as a series of numbers with no dashes 123551234</value>
        [DataMember(Name = "ssn")]
        public string SSN { get; set; }


        /// <summary>
        /// The ZipCode property gets/sets the value of the Zip Code.
        /// </summary>
        /// <value>ZipCode</value>
        [DataMember(Name = "zipcode")]
        public string ZipCode { get; set; }


        /// <summary>
        ///  The DriverLicenseNumber property gets/sets the value of the Driver License Number.
        /// </summary>
        /// <value>Candidate’s driver's license number.</value>
        [DataMember(Name = "driver_license_number")]
        public string DriverLicenseNumber { get; set; }

        /// <summary>
        /// The DriverLicenseState property gets/sets the value of the Driver License State.
        /// </summary>
        /// <value>Candidate’s driver's license state of issue. Format: ISO 3166-2:US.</value>
        [DataMember(Name = "driver_license_state")]
        public string DriverLicenseState { get; set; }

        /// <summary>
        /// The PreviousDriverLicenseNumber property gets/sets the value of the Previous Driver License Number.
        /// </summary>
        /// <value>Candidate’s previous driver's license number.</value>
        [DataMember(Name = "previous_driver_license_number")]
        public string PreviousDriverLicenseNumber { get; set; }

        /// <summary>
        ///  The PreviousDriverLicenseState property gets/sets the value of the Previous Driver License State.
        /// </summary>
        /// <value>Candidate’s driver's license state of issue. Format: ISO 3166-2:US.</value>
        [DataMember(Name = "previous_driver_license_state")]
        public string PreviousDriverLicenseState { get; set; }


        /// <summary>
        /// The CopyRequested property gets/sets the value of the Copy Requested.
        /// </summary>
        /// <value>If true, the candidate has asked to receive a copy of their report.</value>
        [DataMember(Name = "copy_requested")]
        public bool CopyRequested { get; set; }

        /// <summary>
        /// The GeoIds property gets/sets the value of the Geo Ids.
        /// </summary>
        /// <value>Array of Geo IDs.</value>
        [DataMember(Name = "geo_ids")]
        public string[] GeoIds { get; set; }

    }
}
