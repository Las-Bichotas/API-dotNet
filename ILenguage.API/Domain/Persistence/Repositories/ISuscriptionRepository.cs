using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using ILenguage.API.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace ILenguage.API.Domain.Persistence.Repositories
{
    public interface ISuscriptionRepository
    {
        Task<IEnumerable<Subscription>> ListAsync();
        Task AddAsync(Subscription subscription);
        Task<Subscription> FindById(int id);
        Task<Subscription> FindByName(string name);
        Task<Subscription> FindByDuration(int duration);
        void Update(Subscription subscription);
        void Remove(Subscription subscription);
        
        
    }
}