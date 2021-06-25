using ILenguage.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ILenguage.API.Domain.Services.Communications
{
    public class UserSessionResponse : BaseResponse<UserSession>
    {
        public UserSessionResponse(UserSession resource) : base(resource)
        {
        }

        public UserSessionResponse(string message) : base(message)
        {
        }
    }
}
