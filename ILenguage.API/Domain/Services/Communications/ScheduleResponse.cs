using ILenguage.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ILenguage.API.Domain.Services.Communications
{
    public class ScheduleResponse : BaseResponse<Schedule>
    {
        public ScheduleResponse(Schedule resource) : base(resource)
        {
        }

        public ScheduleResponse(string message) : base(message)
        {
        }

    }
}
