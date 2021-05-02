using ILenguage.API.Domain.Models;
using ILenguage.API.Domain.Services.Communications;

namespace ILenguage.API.Domain.Services
{
    public class SuscriptionResponse : BaseResponse<Suscription>
    {
        public SuscriptionResponse(Suscription resource) : base(resource)
        {
        }

        public SuscriptionResponse(string message) : base(message)
        {
        }
    }
}