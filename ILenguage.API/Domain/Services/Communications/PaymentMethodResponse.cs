using ILenguage.API.Domain.Models;
using ILenguage.API.Domain.Services.Communications;

namespace ILenguage.API.Domain.Services
{
    public class PaymentMethodResponse : BaseResponse<PaymentMethod>
    {
        public PaymentMethodResponse(PaymentMethod resource) : base(resource)
        {
        }

        public PaymentMethodResponse(string message) : base(message)
        {
        }
    }
}