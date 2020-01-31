using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using IdentityModel.Client;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using SumTotal.Sample.Connector.Main.Filters;
using SumTotal.Sample.Connector.Main.Handlers;
using SumTotal.Sample.Connector.Models;
using SumTotal.Sample.Connector.Models.Checkr;


namespace SumTotal.Sample.Connector.Main.Controllers
{
    public class CheckrController : Controller 
    {

        private readonly Settings _setting;
        private readonly HttpClient _client;
        private readonly SettingsHandler _settingHandler;
        private readonly ILogger<CheckrController> _logger;
        private readonly IOptions<Models.Serilog> _arguments;
        private readonly string vendorId = "CheckrConnector";
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly IMapper _mapper;
        private const string AUTHENTICATIONSCHEME = "HmacConnect";

        public CheckrController(IOptionsSnapshot<Settings> settings, IHttpClientFactory httpClient, ILogger<CheckrController> logger, IOptions<SumTotal.Sample.Connector.Models.Serilog> arguments, SettingsHandler settingHandler, IHostingEnvironment hostingEnvironment, IMapper mapper)
        {
            _setting = settings.Value;
            _client = httpClient.CreateClient();
            _logger = logger;
            _arguments = arguments;
            _settingHandler = settingHandler;
            _hostingEnvironment = hostingEnvironment;
            _mapper = mapper;
        }


        /// <summary>
        /// Get all the packages for the Checkr Hire vendor for that account 
        /// </summary>
        /// <param name="clientId"></param>
        /// <returns></returns>
        [Authorize(AuthenticationSchemes = AUTHENTICATIONSCHEME)]
        [HttpGet]
        [ServiceFilter(typeof(SetSecurityHeader))]
        public ActionResult<IList<BackgroundCheckPackage>> GetPackages()
        {

            _logger.LogInformation("Get Packages for Checkr Hire is started");
            try
            {
                Vendors vendor = _setting.Vendors.Where(x => x.VendorId == vendorId).FirstOrDefault();
                if (vendor != null)
                {
                    var checkrEndPoint = vendor.VendorOAuthSettings.BaseUrl;
                    _client.DefaultRequestHeaders.Authorization = ResolveAuthToken(vendor);
                    var data = _client.GetAsync(checkrEndPoint + "packages").Result.Content.ReadAsStringAsync().Result;
                    _logger.LogInformation("Get Packages for Checkr Hire is completed");
                    var responseObject = JObject.Parse(data);
                    var checkrData = Convert.ToString(responseObject["data"]);
                    IList<CheckrPackageDetails> packageDetails = JsonConvert.DeserializeObject<List<CheckrPackageDetails>>(checkrData);
                    List<BackgroundCheckPackage> packages = _mapper.Map<List<BackgroundCheckPackage>>(packageDetails);
                    return Ok(packages);
                }
                else
                {
                    _logger.LogInformation("Vendor details are not configured in config");
                    return null;
                }
            }
            catch (Exception ex)
            {

                _logger.LogError(ex.Message);
                return null;
            }
        }


        /// <summary>
        ///  Creates check order for a candidate
        /// </summary>
        ///  <returns>candidate check applicant/order Id</returns>
        [Authorize(AuthenticationSchemes = AUTHENTICATIONSCHEME)]
        [HttpPost]
        [ServiceFilter(typeof(SetSecurityHeader))]
        public ActionResult<BackGroundCheckInviteResponse> InitiateCheck(BackGroundCheckInviteRequest reqObject)
        {           
            _logger.LogInformation("Invite candidate for checkr is started");
            try
            {
                reqObject = JsonConvert.DeserializeObject<BackGroundCheckInviteRequest>(HttpContext.Items["Data"] as string);
                BackGroundCheckInviteResponse inviteResponse = new BackGroundCheckInviteResponse();
                Vendors vendor = _setting.Vendors.Where(x => x.VendorId == vendorId).FirstOrDefault();
                if (vendor != null)
                {
                    var checkrEndPoint = vendor.VendorOAuthSettings.BaseUrl;
                    CheckrInviteRequest inviteReqObject = _mapper.Map<BackGroundCheckInviteRequest, CheckrInviteRequest>(reqObject);

                    if (string.IsNullOrEmpty(inviteReqObject.CandidateId)&& reqObject.Candidate!=null)
                    {
                        CheckrCandidateRequest candidateReqObj = _mapper.Map<Candidate, CheckrCandidateRequest>(reqObject.Candidate);
                        if (this.Validate(candidateReqObj))
                        {
                            inviteReqObject.CandidateId = this.CreateCandidate(candidateReqObj);
                            inviteResponse.CandidateId = inviteReqObject.CandidateId;
                        }
                        else
                        {
                            inviteResponse.HttpStatusCode = HttpStatusCode.BadRequest;
                            _logger.LogError("Required Fields Validation Failed");
                            return BadRequest("Invalid Request To Create Candidate");
                        }
                        
                    }
                    if (!string.IsNullOrEmpty(inviteReqObject.CandidateId) && !string.IsNullOrEmpty(inviteReqObject.Package))
                    {
                        _client.DefaultRequestHeaders.Authorization = ResolveAuthToken(vendor);
                        var data = _client.PostAsJsonAsync(checkrEndPoint + "invitations", inviteReqObject).Result;

                        var response = data.Content.ReadAsStringAsync().Result;

                        if (data.StatusCode == HttpStatusCode.Created)
                        {
                            var responseObject = JObject.Parse(response);
                            var screeningId = Convert.ToString(responseObject["id"]);
                           
                            inviteResponse.ApplicantId = screeningId;
                            inviteResponse.CandidateId = inviteReqObject.CandidateId;
                            inviteResponse.HttpStatusCode = HttpStatusCode.OK;
                            _logger.LogInformation("Invite candidate for checkr is completed");
                            return Ok(inviteResponse);
                        }
                        else
                        {
                           
                            throw new Exception(data.ReasonPhrase);
                        }
                    }
                    else
                    {
                        inviteResponse.HttpStatusCode = HttpStatusCode.BadRequest;
                        _logger.LogError("Required Fields Validation Failed");
                        return BadRequest("Invalid Request To Invite Candidate");
                    }

                }
                else
                {
                    _logger.LogInformation("Vendor details are not configured in config");
                    return null;
                }
            }
            catch (Exception ex)
            {

                _logger.LogError(ex.Message);
                return null;
            }

        }

        /// <summary>
        ///  Creates new candidate at vendor
        /// </summary>
        ///  <returns>candidate object</returns>
        protected string CreateCandidate(CheckrCandidateRequest candidate)
        {
            _logger.LogInformation("Create candidate for checkr is started");
            try
            {
                Vendors vendor = _setting.Vendors.Where(x => x.VendorId == vendorId).FirstOrDefault();
                if (vendor != null)
                {
                    var checkrEndPoint = vendor.VendorOAuthSettings.BaseUrl;
                    _client.DefaultRequestHeaders.Authorization = ResolveAuthToken(vendor);
                    var data = _client.PostAsJsonAsync(checkrEndPoint + "candidates", candidate).Result;
                    var response = data.Content.ReadAsStringAsync().Result;

                    if (data.StatusCode == HttpStatusCode.Created)
                    {
                        var responseObject = JObject.Parse(response);
                       _logger.LogInformation("Create candidate for checkr is completed");
                        return Convert.ToString(responseObject["id"]);
                    }
                    else
                    {
                        throw new Exception(data.ReasonPhrase);
                    }
                }
                else
                {
                    _logger.LogInformation("Vendor details are not configured in config");
                    return null;
                }
            }
            catch (Exception ex)
            {

                _logger.LogError(ex.Message);
                return null;
            }
        }

        /// <summary>
        /// Gets the Settings for vendors
        /// </summary>
        /// <returns></returns>
        [Authorize(AuthenticationSchemes = AUTHENTICATIONSCHEME)]
        [HttpGet]
        [ServiceFilter(typeof(SetSecurityHeader))]
        public ActionResult<string> GetSettings()
        {
            _logger.LogInformation("Get Settings for checkr is started");
            try
            {
                var settings = _settingHandler.GetSettings(vendorId, _setting);
                _logger.LogInformation("Get Settings for checkr is completed");
                return Ok(settings);
            }
            catch (Exception ex)
            {

                _logger.LogError(ex.Message);
                return null;
            }
        }

        /// <summary>
        ///  gets access token from client/Host
        /// </summary>
        protected async Task<AuthenticationHeaderValue> GetAuthorizationToken()
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
        /// Update the check status
        /// </summary>
        /// <returns>Action Result</returns>
        [HttpPost]
        public async Task<ActionResult<string>> UpdateBackgroundCheck()
        {
            try
            {
                BackGroundCheckStatus bgCheckStatus = new BackGroundCheckStatus();
                Vendors vendor = _setting.Vendors.Where(x => x.VendorId == vendorId).FirstOrDefault();
                AuthenticationHeaderValue Authorization = await GetAuthorizationToken();
                if (Authorization != null)
                {
                    JObject check;
                    using (StreamReader reader = new StreamReader(Request.Body, Encoding.ASCII))
                    {
                        check = JsonConvert.DeserializeObject<JObject>(await reader.ReadToEndAsync());
                    }
                    string type = check != null && Convert.ToString(check["type"]).Length > 0 ? Convert.ToString(check["type"]).Split('.')[0] : string.Empty;
                    switch (type)
                    {
                        case "candidate":
                            return Ok();
                        case "invitation":
                            bgCheckStatus = _mapper.Map<BackGroundCheckStatus>(JsonConvert.DeserializeObject<CheckrInviteStatus>(check.ToString()));
                            break;
                        case "report":
                            bgCheckStatus = bgCheckStatus = _mapper.Map<BackGroundCheckStatus>(JsonConvert.DeserializeObject<CheckrCheckStatus>(check.ToString()));
                            break;
                        default:
                            return BadRequest("Invalid Request");
                    }

                    if (bgCheckStatus != null && (bgCheckStatus.ApplicantId != null || bgCheckStatus.OrderId != null) && bgCheckStatus.CheckResult != null)
                    {
                        //Append reporturl for Test environment
                        bgCheckStatus.ReportURL += "?test=true";
                        var requestBody = JsonConvert.SerializeObject(bgCheckStatus);
                        var buffer = System.Text.Encoding.UTF8.GetBytes(requestBody);
                        var byteContent = new ByteArrayContent(buffer);
                        byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                        _client.DefaultRequestHeaders.Authorization = Authorization;
                        var requestId = bgCheckStatus.ApplicantId;
                        if(string.IsNullOrWhiteSpace(bgCheckStatus.ApplicantId))
                        {
                            requestId = bgCheckStatus.OrderId;
                        }
                        var response = await _client.PostAsync(vendor.VendorOAuthSettings.SumtCallBackUrl.Replace("{applicantId}", requestId), byteContent);
                        switch (response.StatusCode)
                        {
                            case System.Net.HttpStatusCode.OK:
                                return Ok(response.ReasonPhrase);
                            case System.Net.HttpStatusCode.BadRequest:
                                return BadRequest(response.ReasonPhrase);
                            case System.Net.HttpStatusCode.NotFound:
                                return NotFound(response.ReasonPhrase);
                            case System.Net.HttpStatusCode.Unauthorized:
                                return Unauthorized();
                            default:
                                return BadRequest();

                        }
                    }
                    else
                    {
                        return BadRequest("Invalid Request");
                    }
                }

                return Unauthorized();
            }
            catch (Exception ex)
            {

                _logger.LogError(ex.Message);
                throw ex;
            }
        }

        /// <summary>
        ///  Validate the input fields
        /// </summary>
        protected bool Validate(CheckrCandidateRequest candidate)
        {
            if (string.IsNullOrEmpty(candidate.Email) || string.IsNullOrEmpty(candidate.FirstName) || string.IsNullOrEmpty(candidate.LastName) || string.IsNullOrWhiteSpace(candidate.ZipCode) || string.IsNullOrWhiteSpace(candidate.Dob))
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// This method is used to resolve the auth token for request
        /// </summary>
        /// <param name="vendor"></param>
        /// <returns>Authentiction header</returns>
        private AuthenticationHeaderValue ResolveAuthToken(Vendors vendor)
        {
            var authToken = Encoding.ASCII.GetBytes($"{vendor.VendorOAuthSettings.VendorUser}:{""}");
            return new AuthenticationHeaderValue("Basic", Convert.ToBase64String(authToken));
        }
    }
}