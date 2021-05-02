using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using ILenguage.API.Domain.Models;

namespace ILenguage.API.Domain.Services
{
    public interface IPaymentMethodService
    {
        Task<IEnumerable<PaymentMethod>> ListByUserId(int userId);
        Task<PaymentMethodResponse> SaveAsync(PaymentMethod paymentMethod);
        Task<PaymentMethodResponse> UpdateAsync(int id, PaymentMethod paymentMethod);
        Task<PaymentMethodResponse> Delete(int id);
    }
}