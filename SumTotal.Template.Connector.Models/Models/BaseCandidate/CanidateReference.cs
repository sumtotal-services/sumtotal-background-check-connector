using System;
using System.Collections.Generic;
using System.Text;

namespace SumTotal.Template.Connector.Models
{
    /// <summary>
    /// Canidate Reference model class
    /// </summary>
    public class CanidateReference
    {
        /// <summary>
        /// The FirstName property gets/sets the value of the canidate reference First Name. 
        /// </summary>
        /// <value>FirstName of the reference</value>
        public string FirstName { get; set; }

        /// <summary>
        /// The LastName property gets/sets the value of the canidate reference Last Name.
        /// </summary>
        /// <value>LastName of the reference</value>
        public string LastName { get; set; }

        /// <summary>
        /// The ContactEmail property gets/sets the value of the Contact Email.
        /// </summary>
        /// <value>Email Id of the reference</value>
        public string ContactEmail { get; set; }

        /// <summary>
        /// The ContactPhone property gets/sets the value of the Contact Phone.
        /// </summary>
        /// <value>Phone number of the reference</value>
        public string ContactPhone { get; set; }


    }
}
