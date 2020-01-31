using System;
using System.Collections.Generic;
using System.Text;

namespace SumTotal.Sample.Connector.Models
{
    /// <summary>
    /// Write to class
    /// </summary>
    public class SerilogWriteTo
    {
        /// <summary>
        /// The Name property gets/sets the Name of the file.
        /// </summary>
        /// <value>Name of the target object(Console/RollingFile) for logging</value>
        public string Name { get; set; }

        /// <summary>
        /// The Args property gets/sets the value of the configuration arguments for logs.
        /// </summary>
        /// <value>Arguments for logging</value>
        public SerilogArgs Args { get; set; }

    }
}
