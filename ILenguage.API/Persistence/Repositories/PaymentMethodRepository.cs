using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ILenguage.API.Domain.Models;
using ILenguage.API.Domain.Persistence.Contexts;
using ILenguage.API.Domain.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ILenguage.API.Persistence.Repositories
{
    public class PaymentMethodRepository : BaseRepository, IPaymentMethodRepository
    {
        public PaymentMethodRepository(AppDbContext context) : base(context)
        {
        }

        public async Task AddAsync(PaymentMethod paymentMethod)
        {
            //? : Idk how to implement this 
            await _context.PaymentMethods.AddAsync(paymentMethod);
        }

        public async Task RemoveAsync(PaymentMethod paymentMethod)
        {
            _context.PaymentMethods.Remove(paymentMethod);
            //TODO: do i have to do this?  _context.SaveChanges()
        }

        public async Task UpdateAsync(PaymentMethod paymentMethod)
        {
            _context.Update(paymentMethod);
            //_context.SaveChanges();
        }

        public async Task<IEnumerable<PaymentMethod>> ListByUserId(int userId)
        {
            //TODO: This should be ok with UserModel
            return await _context.PaymentMethods.Where(pm => pm.UserId == userId).Include(pm => pm.User).ToListAsync();
            
            
        }

        public async Task<PaymentMethod> FindById(int id)
        {
            return await _context.PaymentMethods.FindAsync(id);
        }
    }
}