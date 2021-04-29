using ILenguage.API.Domain.Models;

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