using System;
using System.Collections.Generic;
using System.Text;

namespace SumTotal.Template.Connector.Models
{
    /// <summary>
    /// Candidate Education model
    /// </summary>
    public class CandidateEducation
    {
        /// <summary>
        /// The InstitutionName property gets/sets the value of the Institution/School Name. 
        /// </summary>
        /// <value>School/Institution name</value>
        public string InstitutionName { get; set; }

        /// <summary>
        /// The Degree property gets/sets the value of the Degree.
        /// </summary>
        /// <value>Name of degree earned/earning from the school</value>
        public string Degree { get; set; }

        /// <summary>
        /// The DegreeType property gets/sets the value of the Degree Type.
        /// </summary> 
        /// <value>Type of degree earned/earning from the school</value>
        public string DegreeType { get; set; }

        /// <summary>
        /// The ZipCode property gets/sets the value of the ZipCode.
        /// </summary>
        /// <value>School/Institution Postal code</value>
        public string ZipCode { get; set; }

        /// <summary>
        /// The StreetAddress property gets/sets the value of the Street Address.
        /// </summary>
        /// <value>School/Institution Address</value>
        public string StreetAddress { get; set; }

        /// <summary>
        /// The State property gets/sets the value of the State.
        /// </summary>
        /// <value>School/Institution state</value>
        public string State { get; set; }

        /// <summary>
        /// The City property gets/sets the value of the City.
        /// </summary>
        /// <value>School/Institution City</value>
        public string City { get; set; }

        /// <summary>
        ///The StudyMajor property gets/sets the value of the Study Major.
        /// </summary>
        /// <value>Field of study</value>
        public string StudyMajor { get; set; }

        /// <summary>
        ///The StartYear property gets/sets the value of the Start Year.
        /// </summary>
        /// <value>Degree Start Year</value>
        public string StartYear { get; set; }

        /// <summary>
        ///The EndYear property gets/sets the value of the End Year.
        /// </summary>
        /// <value>Degree End Year</value>
        public string EndYear { get; set; }

        /// <summary>
        /// The InstitutionContactEmail property gets/sets the value of the Institution Contact Email.
        /// </summary>
        /// <value>Institution contact email address</value>
        public string InstitutionContactEmail { get; set; }

        /// <summary>
        /// The InstitutionContactPhone property gets/sets the value of the Institution Contact Phone.
        /// </summary>
        /// <value>Institution contact Phone Number</value>
        public string InstitutionContactPhone { get; set; }
    }
}
