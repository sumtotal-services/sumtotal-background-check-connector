using System;
using System.Collections.Generic;
using System.Text;

namespace SumTotal.Sample.Connector.Models
{
    /// <summary>
    /// Package Position Locale DTO
    /// </summary> 
    /// <value>PackagePositionLocaleDTO</value>
    public class PackagePositionLocaleDTO
    {
        /// <summary>
        /// Language Code
        /// </summary>
        /// <value>Language Code</value>
        public string LanguageCode { get; set; }

        /// <summary>
        /// CountryCode of Position
        /// </summary>
        /// <value>CountryCode</value>
        public string CountryCode { get; set; }
    }
}
