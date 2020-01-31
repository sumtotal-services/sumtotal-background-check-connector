using System;
using System.Collections.Generic;
using System.Text;

namespace SumTotal.Template.Connector.Models
{
    /// <summary>
    /// BackgroundCheckPackageSubComponent model class
    /// </summary>
    public class BackgroundCheckPackageSubComponent
    {
        /// <summary>
        /// The Name property gets/sets the value of the subcomponent Name.
        /// </summary>
        /// <value>Name of the package component</value>
        public string Name { get; set; }

        /// <summary>
        /// The Type property gets/sets the value of the component Type.
        /// </summary>
        /// <value>Type of the package component</value>
        public string Type { get; set; }

        /// <summary>
        /// The Subtype property gets/sets the value of the Package Subtype.
        /// </summary>
        /// <value>Subtype of the package component</value>
        public string Subtype { get; set; }

    }
}
