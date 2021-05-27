using ILenguage.API.Domain.Models;

namespace ILenguage.API.Domain.Services.Communications
{
    public class UserSubscriptionResponse :BaseResponse<UserSubscription>

    {
        public UserSubscriptionResponse(UserSubscription resource) : base(resource)
        {
        }

        public UserSubscriptionResponse(string message) : base(message)
        {
        }
    }
}