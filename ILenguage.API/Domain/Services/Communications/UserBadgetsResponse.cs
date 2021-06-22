using ILenguage.API.Domain.Models;

namespace ILenguage.API.Domain.Services.Communications
{
    public class UserBadgetsResponse : BaseResponse<UserBadgets>
    {
        public UserBadgetsResponse(UserBadgets resource) : base(resource)
        {
        }

        public UserBadgetsResponse(string message) : base(message)
        {
        }
    }
}