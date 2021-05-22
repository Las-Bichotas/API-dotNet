using AutoMapper;
using ILenguage.API.Domain.Models;
using ILenguage.API.Resources;

namespace ILenguage.API.Mapping
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<SaveSuscriptionResource, Subscription>();
            CreateMap<SaveScheduleResource, Schedule>();
            CreateMap<SaveUserResource, User>();
            CreateMap<SaveLanguageOfInterestResource, LanguageOfInterest>();
            CreateMap<SaveTopicOfInterestResource, TopicsOfInterest>();
        }
    }
}