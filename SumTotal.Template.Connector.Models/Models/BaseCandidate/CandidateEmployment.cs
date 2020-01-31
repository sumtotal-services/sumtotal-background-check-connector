using System;
using System.Collections.Generic;
using System.Text;

namespace SumTotal.Template.Connector.Models
{
    /// <summary>
    /// Candidate Employment model
    /// </summary>
    public class CandidateEmployment
    {
        /// <summary>
        /// The CompanyName property gets/sets the value of the Company Name.
        /// </summary>
        /// <value>Employer company name.</value>
        public string CompanyName { get; set; }

        /// <summary>
        /// The Title property gets/sets the value of the Title.
        /// </summary>
        /// <value>Candidate's title</value>
        public string Title { get; set; }

        /// <summary>
        /// The StartAt property gets/sets the value of the StartAt.
        /// </summary>
        /// <value>Employment start Date</value>
        public string StartAt { get; set; }

        /// <summary>
        /// The EndAt property gets/sets the value of the EndAt.
        /// </summary>
        /// <value>Employment End Date</value>
        public string EndAt { get; set; }

        /// <summary>
        /// The StreetAddress property gets/sets the value of the Street Address.
        /// </summary>
        /// <value>The street of the Company Address</value>
        public string StreetAddress { get; set; }

        /// <summary>
        /// The State property gets/sets the value of the State.
        /// </summary>
        /// <value>The state or area of the company address</value>
        public string State { get; set; }

        /// <summary>
        ///The City property gets/sets the value of the City.
        /// </summary>
        /// <value>The city or area of the company address</value>
        public string City { get; set; }

        /// <summary>
        ///The EmployerContactEmail property gets/sets the value of the Employer Contact Email.
        /// </summary>
        /// <value>Employer contact email address</value>
        public string EmployerContactEmail { get; set; }

        /// <summary>
        /// The EmployerContactPhone property gets/sets the value of the Employer Contact Phone.
        /// </summary>
        /// <value>Employer contact email address</value>
        public string EmployerContactPhone { get; set; }

        /// <summary>
        /// The IsCurrentlyEmployed property gets/sets the value of the IsCurrentlyEmployed.
        /// </summary>
        /// <value>true/false To indicate candiate is currently empolyee of this compnay or not</value>
        public bool IsCurrentlyEmployed { get; set; }

        /// <summary>
        /// The EmployeeId property gets/sets the value of the Employee Id.
        /// </summary>
        /// <value>Employee id of the candidate</value>
        public string EmployeeId { get; set; }
    }
}
