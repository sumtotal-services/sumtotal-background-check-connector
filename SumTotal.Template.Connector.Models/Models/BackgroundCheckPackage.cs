using System.Collections.Generic;

namespace SumTotal.Template.Connector.Models
{
    /// <summary>
    /// BackgroundCheckPackagemodel class
    /// </summary>
    public class BackgroundCheckPackage
    {
        /// <summary>
        /// The PackageName property gets/sets the value of the Package Name.  
        /// </summary>
        /// <value>Package name</value>
        public string PackageName { get; set; }

        /// <summary>
        /// The PackageId property gets/sets the value of the PackageId.
        /// </summary>
        /// <value>Package Id from vendor</value>
        public string PackageId { get; set; }

        /// <summary>
        /// The PackageDescription property gets/sets the value of the Package Description.
        /// </summary>
        /// <value>Package Description </value>
        public string PackageDescription { get; set; }

        /// <summary>
        /// The Vendor property gets/sets the value of the Vendor.
        /// </summary>
        /// <value>Vendor Name</value>
        public string Vendor { get; set; }

        /// <summary>
        /// The PackageStatus property gets/sets the value of the Package Status.
        /// </summary>
        /// <value>Status of the package</value>
        public string PackageStatus { get; set; }

        /// <summary>
        /// The PackageSubcomponents property gets/sets the value of the Package Subcomponents.
        /// </summary>
        /// <value>Package Sub Component details</value>
        public List<string> PackageSubcomponents { get; set; }

        /// <summary>
        /// The PackageRequiredFields property gets/sets the value of the Package Required Fields.
        /// </summary>
        /// <value>List of Required Fields to initiate the back ground check for this package</value>
        public List<string> PackageRequiredFields { get; set; }

    }

}