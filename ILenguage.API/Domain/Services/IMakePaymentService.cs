using System.Threading.Tasks;

namespace ILenguage.API.Domain.Services
{
    public interface IMakePaymentService
    {
        public  Task<dynamic> PayAsync(string cardNumber, int month, int year, string cvc, long? value );
    }
}