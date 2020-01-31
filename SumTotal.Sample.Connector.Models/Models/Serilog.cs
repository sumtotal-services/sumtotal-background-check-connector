using System;
using System.Collections.Generic;
using System.Text;

namespace SumTotal.Sample.Connector.Models
{
    /// <summary>
    /// Serilog class
    /// </summary>
    public class Serilog
    {
        /// <summary>
        /// Write to Object of Serilog configuration
        /// </summary>
        public IList<SerilogWriteTo> WriteTo { get; set; }

    }


}
