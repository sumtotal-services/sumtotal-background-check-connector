using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SumTotal.Template.Connector.Api.Handlers
{
    /// <summary>
    /// Mapper class for mapping model and dto classes
    /// </summary>
    public class DefaultMapper : Profile
    {
        public DefaultMapper() : base()
        {
            // sample mapping for sterling

            /* Mapping of vendor package details object to Sumtotal package details object
            "SterlingPackageDetails" can be replaced with different vendor package details class for different vendors

            CreateMap<SterlingPackageDetails, BackgroundCheckPackage>()
           .ForMember(d => d.PackageName, s => s.MapFrom(a => a.Title))
           .ForMember(d => d.PackageId, s => s.MapFrom(a => a.Id))
           .ForMember(d => d.PackageStatus, s => s.MapFrom(a => a.Active))
           .ForMember(d => d.PackageRequiredFields, s => s.MapFrom(a => a.RequiredFields))
           .ForMember(d => d.PackageSubcomponents, s => s.MapFrom(a => a.Components)).AfterMap((model, dto) =>
           {
               dto.Vendor = "Sterling";
           });

            Mapping of Sumtotal background check invite object to vendor invite request object
            "SterlingInviteRequest" can be replaced with different vendor invite request class for different vendors

           CreateMap<BackGroundCheckInviteRequest, SterlingInviteRequest>()
           .ForMember(d => d.PackageId, s => s.MapFrom(a => a.PackageId))
           .ForMember(d => d.CandidateId, s => s.MapFrom(a => a.Candidate.CandidateId)); */
        }
    }
}
