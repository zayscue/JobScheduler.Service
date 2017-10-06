using AutoMapper;
using JobScheduler.Api.Models;
using MongoDB.Bson;

namespace JobScheduler.Api.Infrastructure
{
    public class AutoMapperProfileConfiguration : Profile
    {
        public AutoMapperProfileConfiguration() : this("MyProfile") {}
        protected AutoMapperProfileConfiguration(string profileName) : base(profileName) 
        {
            CreateMap<Classification, ClassificationDto>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id.ToString()));
            CreateMap<ClassificationDto, Classification>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => ObjectId.Parse(src.Id)));
            CreateMap<JobRequest, JobRequestDto>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id.ToString()));
            CreateMap<JobRequestDto, JobRequest>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => ObjectId.Parse(src.Id)));
            CreateMap<InspectionRequest, InspectionRequestDto>().ForMember(dest => dest.Classification, opt => opt.MapFrom(src => src.Classification.ToString()));
            CreateMap<InspectionRequestDto, InspectionRequest>().ForMember(dest => dest.Classification, opt => opt.MapFrom(src => ObjectId.Parse(src.Classification)));
        }
    }
}