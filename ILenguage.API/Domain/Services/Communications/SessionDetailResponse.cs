using ILenguage.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ILenguage.API.Domain.Services.Communications
{
    public class SessionDetailResponse : BaseResponse<SessionDetail>
    {
        public SessionDetailResponse(SessionDetail resource) : base(resource)
        {
        }

        public SessionDetailResponse(string message) : base(message)
        {
        }
    }
}
