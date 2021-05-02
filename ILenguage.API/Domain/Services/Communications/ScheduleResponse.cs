using ILenguage.API.Domain.Models;

namespace ILanguage.API.Domain.Services.Communication
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
