using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using SumTotal.Sample.Connector.Models;
using SumTotal.Sample.Connector.Models.Checkr;


namespace SumTotal.Sample.Connector.Main.Handlers
{
    public class DefaultMapper : Profile
    {
        private const string VENDOR_CHECKR = "Checkr";
        public DefaultMapper() : base()
        {
            #region Checkr
            ///Checkr Mapper Class for Candidate object
            CreateMap<Candidate, CheckrCandidateRequest>()
           .ForMember(d => d.FirstName, s => s.MapFrom(a => a.PersonNameDetails.FirstName))
           .ForMember(d => d.MiddleName, s => s.MapFrom(a => a.PersonNameDetails.MiddleName))
           .ForMember(d => d.LastName, s => s.MapFrom(a => a.PersonNameDetails.LastName))
           .ForMember(d => d.Email, s => s.MapFrom(a => a.Email))
           .AfterMap((model,dto) =>
           {
               dto.Dob = string.IsNullOrWhiteSpace(model.DOB) ? "" : Convert.ToDateTime(model.DOB).ToString("dd/MM/yyyy");
               dto.ConfirmedNoMiddleName = string.IsNullOrWhiteSpace(model.PersonNameDetails.MiddleName);
               if (model.PersonPhones != null)
               {
                   dto.Phone = model.PersonPhones[0].PhoneNumber;
               }
               if(model.PersonIdentities != null)
               {
                   dto.SSN = model.PersonIdentities.Where(x => x.Type == IdentityType.SSN).Select(c => c.IdNumber).ToString();
               }
               if (model.PersonLicenseDetailsList != null)
               {
                   dto.DriverLicenseState = model.PersonLicenseDetailsList[0].IssuedState;
               }
               if (model.PersonAddresses != null)
               {
                   dto.ZipCode = model.PersonAddresses[0].ZipCode;
                   if(string.IsNullOrWhiteSpace(dto.ZipCode))
                   {
                       dto.ZipCode = model.PersonAddresses[1].ZipCode;
                   }
               }
           });
          
            ///Checkr Candidate creation status mapper
            CreateMap<CheckrCandidateStatus, BackGroundCheckStatus>()
            .ForMember(d => d.CheckIssueDate, s => s.MapFrom(a => a.CreatedAt)).AfterMap((model, dto) =>
            {
                if (model.Data != null && model.Data.Object != null)
                {
                    dto.Vendor = VENDOR_CHECKR;
                    dto.CheckResult = "Started";
                    dto.VendorCandidateId = model.Data.Object.Id;
                    dto.ApplicantId = model.Data.Object.Id;
                }
            });


            ///Checkr Candidate Invite status mapper
            CreateMap<CheckrInviteStatus, BackGroundCheckStatus>()
            .ForMember(d => d.CheckIssueDate, s => s.MapFrom(a => a.CreatedAt)).AfterMap((model, dto) =>
            {
                if (model.Data != null && model.Data.Object != null)
                {
                    dto.Vendor = VENDOR_CHECKR;
                    dto.CheckResult = "Started";
                    dto.VendorCandidateId = model.Data.Object.CandidateId;
                    dto.ApplicantId = model.Data.Object.ID;
                    dto.OrderId = model.Data.Object.ReportId;
                }
            });

            ///Checkr Candidate report status mapper
            CreateMap<CheckrCheckStatus, BackGroundCheckStatus>()
            .ForMember(d => d.CheckIssueDate, s => s.MapFrom(a => a.CreatedAt)).AfterMap((model, dto) =>
            {
                if (model.Data != null && model.Data.Object != null)
                {
                    dto.Vendor = VENDOR_CHECKR;
                    string[] status = Convert.ToString(model.Type).Split('.');
                    string[] pendingStatus = { "created", "updated", "upgraded", "resumed" };
                    string[] completStatus = { "pre_adverse_action", "post_adverse_action", "assessed", "completed" };
                    if(status.Length > 1)
                    {
                        dto.CheckResult = pendingStatus.Contains(status[1]) ? "Inprogress" : (completStatus.Contains(status[1]) ? "Complete" : status[1]);
                    }
                    dto.ReportURL = "https://dashboard.checkr.com/candidates/{0}/reports/{1}";
                    dto.ReportURL= String.Format(dto.ReportURL, model.Data.Object.CandidateId, model.Data.Object.Id);
                    dto.OrderId = model.Data.Object.Id;
                    dto.VendorCandidateId = model.Data.Object.CandidateId;
                    dto.VendorPackageId = model.Data.Object.Package;
                }
            });


            ///Checkr Package Mapper Class
            CreateMap<CheckrPackageDetails, BackgroundCheckPackage>()
            .ForMember(d => d.PackageName, s => s.MapFrom(a => a.Name))
            .ForMember(d => d.PackageId, s => s.MapFrom(a => a.Id))
            .ForMember(d => d.PackageAlias, s => s.MapFrom(a => a.Slug))
            .AfterMap((model, dto) =>
            {
                dto.Vendor = VENDOR_CHECKR;
                dto.PackageStatus = String.IsNullOrWhiteSpace(model.DeletedAt) ? bool.TrueString : bool.FalseString;
                dto.PackageSubcomponents = new List<string>();
                foreach (var component in model.Screenings)
                {
                    dto.PackageSubcomponents.Add(component.Type);
                }
            });

            ///Checkr Mapper Class for Invite object
            CreateMap<BackGroundCheckInviteRequest, CheckrInviteRequest>()
            .ForMember(d => d.Package, s => s.MapFrom(a => a.PackageAlias))
            .ForMember(d => d.CandidateId, s => s.MapFrom(a => a.CandidateId));

            #endregion

            
        }

    }
}
