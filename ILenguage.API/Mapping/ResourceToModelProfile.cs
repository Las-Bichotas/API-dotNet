using AutoMapper;
using ILenguage.API.Domain.Models;
using ILenguage.API.Resources;

namespace ILenguage.API.Mapping
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<SaveSuscriptionResource, Suscription>();
            CreateMap<SaveScheduleResource, Schedule>();
            CreateMap<SaveUserResource,User>();
        }
    }
}