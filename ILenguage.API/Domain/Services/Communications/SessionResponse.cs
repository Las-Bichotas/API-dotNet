﻿using ILenguage.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ILenguage.API.Domain.Services.Communications
{
    public class SessionResponse : BaseResponse<Session>
    {
        public SessionResponse(Session resource) : base(resource)
        {
        }

        public SessionResponse(string message) : base(message)
        {
        }
    }
}
