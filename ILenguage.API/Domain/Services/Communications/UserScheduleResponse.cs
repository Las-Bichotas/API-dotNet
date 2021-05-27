using ILenguage.API.Domain.Models;

namespace ILenguage.API.Domain.Services.Communications
{
    public class UserScheduleResponse :BaseResponse<UserSchedule>

    {
        public UserScheduleResponse(UserSchedule resource) : base(resource)
        {
        }

        public UserScheduleResponse(string message) : base(message)
        {
        }
    }
}