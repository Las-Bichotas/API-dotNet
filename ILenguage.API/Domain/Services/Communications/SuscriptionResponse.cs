using ILenguage.API.Domain.Models;
using ILenguage.API.Domain.Services.Communications;

namespace ILenguage.API.Domain.Services
{
    public class SuscriptionResponse : BaseResponse<Subscription>
    {
        public SuscriptionResponse(Subscription resource) : base(resource)
        {
        }

        public SuscriptionResponse(string message) : base(message)
        {
        }
    }
}