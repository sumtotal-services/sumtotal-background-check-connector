using System;
using System.Collections.Generic;
using System.Text;

namespace SumTotal.Template.Connector.Models
{
    /// <summary>
    /// Candidate Name model class
    /// </summary>
    public class CandidateName
    {
        /// <summary>
        /// The FirstName property gets/sets the value of the candidate First Name.
        /// </summary>
        /// <value>First Name of the candidate</value>
        public string FirstName { get; set; }

        /// <summary>
        /// The LastName property gets/sets the value of the candidate Last Name.
        /// </summary>
        /// <value>LastName of the candidate</value>
        public string LastName { get; set; }

        /// <summary>
        /// The MiddleName property gets/sets the value of the candidate Middle Name.
        /// </summary>
        /// <value>MiddleName of the candidate</value>
        public string MiddleName { get; set; }

        /// <summary>
        /// The Suffix property gets/sets the value of the Suffix.
        /// </summary>
        /// <value>Suffix of candidate</value>
        public string Suffix { get; set; }

        /// <summary>
        /// The Type property gets/sets the value of the Type.
        /// </summary>
        /// <value>Type of the name(to know alias name or not)</value>
        public string Type { get; set; }


    }
}
