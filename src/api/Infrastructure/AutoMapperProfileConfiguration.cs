using AutoMapper;
using JobScheduler.Api.Models;

namespace JobScheduler.Api.Infrastructure
{
    public class AutoMapperProfileConfiguration : Profile
    {
        public AutoMapperProfileConfiguration() : this("MyProfile") {}
        protected AutoMapperProfileConfiguration(string profileName) : base(profileName) 
        {
            CreateMap<Classification, ClassificationDto>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id.ToString()));
        }
    }
}