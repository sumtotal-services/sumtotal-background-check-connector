using IdentityModel.Client;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SumTotal.Template.Connector.Api.Contracts;
using SumTotal.Template.Connector.Api.Filters;
using SumTotal.Template.Connector.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace SumTotal.Template.Connector.Api.Controllers
{
    /// <summary>
    /// BackGroundCheckController class. This class contains the connector basic functionalities.
    /// </summary>
    public class BackGroundCheckController : Controller, IBackGroundCheckApi
    {

        private readonly Settings _setting;
        private readonly HttpClient _client;
        private readonly ILogger<BackGroundCheckController> _logger;
        private readonly IOptions<SumTotal.Template.Connector.Models.Serilog> _arguments;
        private const string AUTHENTICATIONSCHEME = "HmacConnect";
        private readonly string vendorId = "{VendorId}";//replace the VendorId placeholder with VendorId Value which is configured in appsetting.json

        /// <summary>
        /// Contructor of the BackGroundCheckController class
        /// </summary>
        /// <param name="settings">settings</param>
        /// <param name="httpClient">httpClient</param>
        /// <param name="logger">logger</param>
        /// <param name="arguments">arguments</param>
        public BackGroundCheckController(IOptionsSnapshot<Settings> settings, IHttpClientFactory httpClient, ILogger<BackGroundCheckController> logger, IOptions<SumTotal.Template.Connector.Models.Serilog> arguments)
        {
            _setting = settings.Value;
            _client = httpClient.CreateClient();
            _logger = logger;
            _arguments = arguments;
        }

        /// <summary>
        ///  This method is used to get all the background check package details for different vendors
        /// </summary>
        /// <returns>List of background check packages and their details</returns>
        [Authorize(AuthenticationSchemes = AUTHENTICATIONSCHEME)]
        [HttpGet]
        [ServiceFilter(typeof(SetSecurityHeader))]
        public ActionResult<IList<BackgroundCheckPackage>> GetPackages()
        {
            // sample code using background check provider sterling

            /* _logger.LogInformation("Get Packages for sterling is started");
             
            Vendors vendor = _setting.Vendors.Where(x => x.VendorId == vendorId).FirstOrDefault();
            if (vendor != null)
            {
                var sterlingEndPoint = vendor.VendorOAuthSettings.BaseUrl;
                // "sterlingEndPoint" can be replaced with diferent vendors endpoints to get the package details from that vendor
                var data = _client.GetAsync(sterlingEndPoint + "GetPackages").Result.Content.ReadAsStringAsync().Result;
                _logger.LogInformation("Get Packages for Sterling is completed");
                IList<SterlingPackageDetails> packageDetails = JsonConvert.DeserializeObject<List<SterlingPackageDetails>>(data);
                List<BackgroundCheckPackage> packages = _mapper.Map<List<BackgroundCheckPackage>>(packageDetails);
                return Ok(packageDetails);
            }
            else
            {
                _logger.LogInformation("Vendor details are not configured in config");
                return null;
            } */
            return null;
        }

        /// <summary>
        ///  This method is used to register/initiate background check for a candidate
        /// </summary>
        /// <returns>OrderId/ApplicantId for the initiated background check</returns>
        [Authorize(AuthenticationSchemes = AUTHENTICATIONSCHEME)]
        [HttpPost]
        [ServiceFilter(typeof(SetSecurityHeader))]
        public ActionResult<BackGroundCheckInviteResponse> InitiateCheck()
        {
            // sample code using background check provider sterling

            /* _logger.LogInformation("Invite candidate for sterling is started");
                reqObject = JsonConvert.DeserializeObject<BackGroundCheckInviteRequest>(HttpContext.Items["Data"] as string);
                BackGroundCheckInviteResponse inviteResponse = new BackGroundCheckInviteResponse();
                Vendors vendor = _setting.Vendors.Where(x => x.VendorId == vendorId).FirstOrDefault();
                if (vendor != null)
                {
                    var sterlingEndPoint = vendor.VendorOAuthSettings.BaseUrl;
                    SterlingInviteRequest inviteReqObject = _mapper.Map<BackGroundCheckInviteRequest, SterlingInviteRequest>(reqObject);

                    if (string.IsNullOrEmpty(reqObject.CandidateId) && reqObject.Candidate!=null)
                    {
                        SterlingCandidateRequest candidateReqObj = _mapper.Map<Candidate, SterlingCandidateRequest>(reqObject.Candidate);

                        if (this.Validate(candidateReqObj))
                        {
                            inviteReqObject.CandidateId = this.CreateCandidate(candidateReqObj);
                        }
                        else
                        {
                            _logger.LogError("Required Fields Validation Failed");
                            inviteResponse.HttpStatusCode = HttpStatusCode.BadRequest;
                            return BadRequest(inviteResponse);
                        }
                    }
                    if (!string.IsNullOrEmpty(inviteReqObject.CandidateId) && !string.IsNullOrEmpty(inviteReqObject.PackageId))
                    {
                        var data = _client.PostAsJsonAsync(sterlingEndPoint + "screenings", inviteReqObject).Result;
                        var response = data.Content.ReadAsStringAsync().Result;
                      
                        if (data.StatusCode == HttpStatusCode.Created)
                        {
                            var responseObject = JObject.Parse(response);
                            var screeningId = Convert.ToString(responseObject["id"]);
                        
                            inviteResponse.OrderId = screeningId;
                            inviteResponse.CandidateId = inviteReqObject.CandidateId;
                            inviteResponse.HttpStatusCode = HttpStatusCode.OK;
                        }
                        else
                        {
                            throw new Exception(data.ReasonPhrase);
                        }

                        _logger.LogInformation("invite candidate for Sterling is successfully completed");

                        return Ok(inviteResponse);
                    }
                    else
                    {
                        _logger.LogError("Required Fields Validation Failed");
                        inviteResponse.HttpStatusCode = HttpStatusCode.BadRequest;
                        return BadRequest(inviteResponse);
                    }
                }
                else
                {
                    _logger.LogInformation("Vendor details are not configured in config");
                    return null;
                } */
            return null;
        }

        /// <summary>
        ///  This method is used to Create new candidate at vendor
        /// </summary>
        /// <param name="candidate">Candidate object</param>
        ///  <returns>candidate id</returns>
        public string CreateCandidate()

        {
            // sample code using background check provider sterling

            /* _logger.LogInformation("Create candidate for sterling is started");
            Vendors vendor = _setting.Vendors.Where(x => x.VendorId == vendorId).FirstOrDefault();
            if (vendor != null)
            {
            // "sterlingEndPoint" can be replaced with diferent vendors endpoints to register a candidate to that vendor
                var sterlingEndPoint = vendor.VendorOAuthSettings.BaseUrl;
                var data = _client.PostAsJsonAsync(sterlingEndPoint + "candidates", candidate).Result.Content.ReadAsStringAsync().Result;
                _logger.LogInformation("Create candidate for Sterling is completed");
                var responseObject = JObject.Parse(data);
                return Convert.ToString(responseObject["id"]);
            }
            else
            {
                _logger.LogInformation("Vendor details are not configured in config");
                return null;
            } */
            return null;
        }

        /// <summary>
        ///  callback method for updating background check status for candidates
        /// </summary>
        /// <param name="referenceId">referenceId</param>
        /// <returns>Action status</returns>
        [Authorize(AuthenticationSchemes = AUTHENTICATIONSCHEME)]
        [HttpPost]
        public async Task<ActionResult<string>> UpdateBackgroundCheck(string referenceId)
        {
            /* var result = GetAuthorizationToken().Result;
            if (result != null)
            {
                _client.DefaultRequestHeaders.Authorization = result;
            }
            // _setting.Vendors[0].VendorOAuthSettings.SumtCallBackUrl is the endpoint of the vendor used to update the background check details to the vendor
            var response = await _client.GetAsync($"{_setting.Vendors[0].VendorOAuthSettings.SumtCallBackUrl}?status=Complete&reference={referenceId}");

            if (response.IsSuccessStatusCode)
            {
                return Ok();
            }
            else
            {
                return null;
            } */
            return null;
        }

        /// <summary>
        ///  This method is used to Get access token from sumtotal for authorized oauth client
        /// </summary>
        /// <returns>Authorization token for the user</returns>
        protected virtual async Task<AuthenticationHeaderValue> GetAuthorizationToken()
        {
            var discovery = await _client.GetDiscoveryDocumentAsync(_setting.SumtOAuthSettings.Authority);
            var tokenResponse = await _client.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
            {
                Address = discovery.TokenEndpoint,
                ClientId = _setting.SumtOAuthSettings.ClientId,
                ClientSecret = _setting.SumtOAuthSettings.ClientSecret,
                Scope = _setting.SumtOAuthSettings.Scope
            });
            if (!string.IsNullOrEmpty(tokenResponse.AccessToken))
            {
                return new AuthenticationHeaderValue("Bearer", tokenResponse.AccessToken);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// This method is used to get the vendor specific settings used to connect with that vendor
        /// </summary>
        /// <returns>Vendor specific setting</returns>
        [Authorize(AuthenticationSchemes = AUTHENTICATIONSCHEME)]
        [HttpGet]
        [ServiceFilter(typeof(SetSecurityHeader))]
        public ActionResult<string> GetSettings()
        {
                /* _logger.LogInformation("Get Settings for {vendor name} is started");
                var settings = _settingHandler.GetSettings(vendorId, _setting);
                _logger.LogInformation("Get Settings for {vendor name} is completed");
                return Ok(settings); */
                return null;
        }

        /// <summary>
        ///  Validate the input fields
        /// </summary>
        /// <returns>true/false</returns>
        protected bool Validate(/*Candidaterequestobject candidate*/)
        {
            //if (string.IsNullOrEmpty(candidate.Email) || string.IsNullOrEmpty(candidate.GivenName) || string.IsNullOrEmpty(candidate.FamilyName) || string.IsNullOrEmpty(candidate.ClientReferenceId))
            //{
            //    return false;
            //}
            return true;
        }
    }
}
