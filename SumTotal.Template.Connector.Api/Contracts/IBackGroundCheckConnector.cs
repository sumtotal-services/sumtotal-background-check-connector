using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SumTotal.Template.Connector.Api.Filters;
using SumTotal.Template.Connector.Models;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace SumTotal.Template.Connector.Api.Contracts
{
    public interface IBackGroundCheckApi
    {
        /// <summary>
        ///  This method is used to get all the background check package details for different vendors
        /// </summary>
        /// <returns>List of background check packages and their details</returns>
        ActionResult<IList<BackgroundCheckPackage>> GetPackages();

        /// <summary>
        ///  This method is used to register/initiate background check for a candidate
        /// </summary>
        /// <returns>OrderId/ApplicantId for the initiated background check</returns>
        ActionResult<BackGroundCheckInviteResponse> InitiateCheck();

        /// <summary>
        ///  This method is used to Create new candidate at vendor
        /// </summary>
        ///  <returns>candidate id</returns>
        string CreateCandidate(/*SterlingCandidateRequest candidate*/);

        /// <summary>
        ///  callback method for updating background check status for candidates
        /// </summary>
        /// <param name="referenceId"></param>
        /// <returns>Action status</returns>
        Task<ActionResult<string>> UpdateBackgroundCheck(string referenceId);

        /// <summary>
        /// This method is used to get the vendor specific settings used to connect with that vendor
        /// </summary>
        /// <returns>Vendor specific setting</returns>
        ActionResult<string> GetSettings();
    }
}
