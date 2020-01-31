using System;
using System.Collections.Generic;
using System.Text;

namespace SumTotal.Template.Connector.Models
{
    /// <summary>
    /// Package Position Locale DTO
    /// </summary> 
    /// <value>The string property gets the PersonFK</value>
    public class PackagePositionLocaleDTO
    {
        /// <summary>
        /// Language Code
        /// </summary>
        /// <value>Language Code</value>
        public string LanguageCode { get; set; }

        /// <summary>
        /// CountryCode
        /// </summary>
        /// <value>CountryCode of the Position</value>
        public string CountryCode { get; set; }
    }
}
