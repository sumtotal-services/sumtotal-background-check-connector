using SumTotal.Sample.Connector.Models.Models.Checkr;
using System;
using System.Collections.Generic;
using System.Text;

namespace SumTotal.Sample.Connector.Models.Checkr
{
   public class CheckrPackageDetails
    {

        /// <summary>
        /// The Id property gets/sets the value of the package Id. 
        /// </summary>
        /// <value>PackageId</value>
        public string Id { get; set; }

        /// <summary>
        /// The Object property gets/sets the value of the package object.
        /// </summary>
        /// <value>Value:"package"</value>
        public string Object { get; set; }

        /// <summary>
        /// The Name property gets/sets the name of the package.
        /// </summary>
        /// <value>Name of the package</value>
        public string Name { get; set; }

        /// <summary>
        /// The Slug property gets/sets the value of the package unique identifier.
        /// </summary>
        /// <value>Unique key identifier of the Package.</value>
        public string Slug { get; set; }

        /// <summary>
        ///  The Price property gets/sets the price of the package.
        /// </summary>
        /// <value>Package price in USD cents.</value>
        public string Price { get; set; }

        /// <summary>
        /// The Price property gets/sets the URI of the package resource.
        /// </summary>
        /// <value>URI of the resource</value>
        public string Uri { get; set; }

        /// <summary>
        /// The Screenings property gets/sets the components of the package.
        /// </summary>
        /// <value>Components included in the package</value>
        public IList<CheckrPacakgeSubComponent> Screenings { get; set; }

        /// <summary>
        /// The CreatedAt property gets/sets the created date of the package.
        /// </summary>
        /// <value>Time at which the Package was created.</value>
        public string CreatedAt { get; set; }

        /// <summary>
        /// The DeletedAt property gets/sets the deleted date of the package.
        /// </summary>
        /// <value>Time at which the Package was deleted.</value>
        public string DeletedAt { get; set; }

    }
}
