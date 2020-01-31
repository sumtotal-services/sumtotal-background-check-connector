using System;
using System.Collections.Generic;
using System.Text;

namespace SumTotal.Template.Connector.Models
{
    /// <summary>
    /// Serilog class
    /// </summary>
    public class Serilog
    {
        /// <summary>
        /// The WriteTo property gets/sets the value of the WriteTo.
        /// </summary>
        /// <value>Write to Object of Serilog configuration</value>
        public SerilogWriteTo[] WriteTo { get; set; }

    }

}
