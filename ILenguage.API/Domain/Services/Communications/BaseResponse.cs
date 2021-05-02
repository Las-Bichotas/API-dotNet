<<<<<<< HEAD
﻿using System;

namespace ILenguage.API.Domain.Services
=======
namespace ILenguage.API.Domain.Services.Communications
>>>>>>> a8a397018832005604f3f598bfa0f93be25989d6
{
    public abstract class BaseResponse<T>
    {
        public bool Succes { get; set; }
        public string Message { get; protected set; }
        public T Resource { get; set; }
<<<<<<< HEAD
        
        
        protected BaseResponse(T resource)
        {
            Resource = resource;
            Succes = true;
            Message = String.Empty;
        }

        protected BaseResponse(string message)
        {
            Message = message;
            Succes = true;
        }
        
=======
        public BaseResponse(T resource)
        {
            Resource = resource;
            Succes = true;
            Message = string.Empty;
        }
        public BaseResponse(string message)
        {
            Succes = false;
            Message = message;
        }
>>>>>>> a8a397018832005604f3f598bfa0f93be25989d6
    }
}