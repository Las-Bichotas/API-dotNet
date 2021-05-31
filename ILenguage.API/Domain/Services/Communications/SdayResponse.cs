using ILenguage.API.Domain.Models;

namespace ILenguage.API.Domain.Services.Communications
{
    public class SdayResponse :BaseResponse<Sday>

    {
        public SdayResponse(Sday resource) : base(resource)
        {
        }

        public SdayResponse(string message) : base(message)
        {
        }
    }
}