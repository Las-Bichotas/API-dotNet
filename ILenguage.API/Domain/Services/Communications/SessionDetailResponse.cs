using ILenguage.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ILenguage.API.Domain.Services.Communications
{
    public class SessionDetailResponse : BaseResponse<SessionDetails>
    {
        public SessionDetailResponse(SessionDetails resource) : base(resource)
        {
        }

        public SessionDetailResponse(string message) : base(message)
        {
        }
    }
}
