using System;
using System.Collections.Generic;
using System.Text;

namespace SumTotal.Sample.Connector.Models
{
    /// <summary>
    /// Class for serilog setting arguments
    /// </summary>
    public class SerilogArgs
    {
        /// <summary>
        /// The PathFormat property gets/sets the value of the Path Format.
        /// </summary>
        /// <value>Path of the file used for writing the logs</value>
        public string PathFormat { get; set; }

        /// <summary>
        /// The Formatter property gets/sets the value of the Formatter.
        /// </summary>
        /// <value>Log format</value>
        public string Formatter { get; set; }

        /// <summary>
        /// The RestrictedToMinimumLevel property gets/sets the value of the Restricted To Minimum Level .
        /// </summary>
        /// <value>Level of Logs to be logged</value>
        public string RestrictedToMinimumLevel { get; set; }

        /// <summary>
        /// The RetainedFileCountLimit property gets/sets the value of the Retained File Count Limit.
        /// </summary>
        /// <value>Maximum files to be retained</value>
        public string RetainedFileCountLimit { get; set; }

        /// <summary>
        /// The OutputTemplate property gets/sets the value of the Output Template.
        /// </summary>
        /// <value>Template for the log</value>
        public string OutputTemplate { get; set; }

    }
}
