using ILenguage.API.Domain.Models;

namespace ILenguage.API.Domain.Services.Communications
{
    public class BadgetsResponse : BaseResponse<Badgets>
    {
        public BadgetsResponse(Badgets resource) : base(resource)
        {
        }

        public BadgetsResponse(string message) : base(message)
        {
        }
    }
}