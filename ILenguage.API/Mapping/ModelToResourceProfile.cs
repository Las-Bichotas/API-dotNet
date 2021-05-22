﻿using AutoMapper;
using ILenguage.API.Domain.Models;
using ILenguage.API.Resources;

namespace ILenguage.API.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<Subscription, SubscriptionResource>();
            CreateMap<Schedule, ScheduleResource>();
            CreateMap<User, UserResource>();
        }
    }
}