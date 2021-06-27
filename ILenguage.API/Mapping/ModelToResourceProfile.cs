using AutoMapper;
using ILenguage.API.Domain.Models;
using ILenguage.API.Resources;

namespace ILenguage.API.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<Subscription, SubscriptionResource>();
         
            CreateMap<User, UserResource>();
            CreateMap<Role, RoleResource>();
            CreateMap<LanguageOfInterest, LanguageOfInterestResource>();
            CreateMap<TopicsOfInterest, TopicOfInterestResource>();
            CreateMap<Session, SessionResource>();
          
            CreateMap<Badgets, BadgetsResource>();
            CreateMap<Comment, CommentResource>();
        }
    }
}