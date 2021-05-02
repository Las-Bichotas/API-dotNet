using ILenguage.API.Domain.Models;

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