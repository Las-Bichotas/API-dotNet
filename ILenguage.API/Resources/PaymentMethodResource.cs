using ILenguage.API.Domain.Models;

namespace ILenguage.API.Resources
{
    public class PaymentMethodResource
    {
        public string OwnerName { get; set; }
        public uint Year { get; set; }
        public uint month { get; set; }
        public EPaymentNetwork PaymentNetwork { get; set; }
    }
}