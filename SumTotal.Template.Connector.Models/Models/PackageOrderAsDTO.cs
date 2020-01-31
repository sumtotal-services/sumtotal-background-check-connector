using System;
using System.Collections.Generic;
using System.Text;

namespace SumTotal.Template.Connector.Models
{
    /// <summary>
    /// Package Order As DTO
    /// </summary>
    /// <value>The string property gets the account details</value>
    public class PackageOrderAsDTO
    {
        /// <summary>
        /// AccountId
        /// </summary>
        /// <value>AccountId</value>
        public string AccountId { get; set; }

        /// <summary>
        /// UserId
        /// </summary>
        /// <value>UserId</value>
        public string UserId { get; set; }

        /// <summary>
        /// Gets/sets the Email value of the Ordered Package
        /// </summary>
        /// <value>Email</value>
        public string Email { get; set; }
    }
}
