using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using ILenguage.API.Domain.Models;

namespace ILenguage.API.Domain.Persistence.Repositories
{
    public interface IPaymentMethodRepository
    {
        Task AddAsync(PaymentMethod paymentMethod);
        Task RemoveAsync(PaymentMethod paymentMethod);

        Task UpdateAsync(PaymentMethod paymentMethod);
        //?Do i have to do this? 
        Task<IEnumerable<PaymentMethod>> ListByUserId(int userId);
        
    }
}