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
           
            CreateMap<SaveRoleResource, Role>();
            CreateMap<SaveUserResource, User>();
            CreateMap<SaveLanguageOfInterestResource, LanguageOfInterest>();
            CreateMap<SaveTopicOfInterestResource, TopicsOfInterest>();
            CreateMap<SaveSessionResource, Session>();
          
            CreateMap<SaveBadgetsResource, Badgets>();
            CreateMap<SaveCommentResource, Comment>();
        }
    }
}