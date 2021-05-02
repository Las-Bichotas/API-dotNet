using System;

namespace ILenguage.API.Domain.Services
{
    public abstract class BaseResponse<T>
    {
        public bool Succes { get; set; }
        public string Message { get; protected set; }
        public T Resource { get; set; }
        
        
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
        
    }
}