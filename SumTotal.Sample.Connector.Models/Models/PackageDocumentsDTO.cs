using System;
using System.Collections.Generic;
using System.Text;

namespace SumTotal.Sample.Connector.Models
{
    /// <summary>
    /// Package Documents DTO
    /// </summary>
    /// <value>Package Documents DTO reference.</value>
    public class PackageDocumentsDTO
    {
        /// <summary>
        /// Gets/sets the Id value for the Package Document
        /// </summary>
        /// <value></value>
        public string DocumentId { get; set; }

        /// <summary>
        /// Type of the Package Document
        /// </summary>
        /// <value>Type of Document</value>
        public string Type { get; set; }
    }
}
