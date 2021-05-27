using ILenguage.API.Domain.Models;
using ILenguage.API.Domain.Services.Communications;

namespace ILenguage.API.Domain.Services
{
    public class SubscriptionResponse : BaseResponse<Subscription>
    {
        public SubscriptionResponse(Subscription resource) : base(resource)
        {
        }

        public SubscriptionResponse(string message) : base(message)
        {
        }
    }
}