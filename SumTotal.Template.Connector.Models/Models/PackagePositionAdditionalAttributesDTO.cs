using System;
using System.Collections.Generic;
using System.Text;

namespace SumTotal.Template.Connector.Models
{
    /// <summary>
    /// PackagePositionAdditionalAttributesDTO
    /// </summary>
    /// <value>The Additional attributes of PackagePosition</value>
    public class PackagePositionAdditionalAttributesDTO
    {
        /// <summary>
        /// Ordering Account details
        /// </summary>
        /// <value>OrderAs</value>
        public PackageOrderAsDTO OrderAs { get; set; }

        /// <summary>
        /// System where order is to be created
        /// </summary>
        /// <value>System</value>
        public string System { get; set; }
    }
}
