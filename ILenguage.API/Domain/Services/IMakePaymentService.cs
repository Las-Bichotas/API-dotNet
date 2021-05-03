using System.Threading.Tasks;

namespace ILenguage.API.Domain.Services
{
    public interface IMakePaymentService
    {
        public Task<dynamic> PayAsync();
    }
}