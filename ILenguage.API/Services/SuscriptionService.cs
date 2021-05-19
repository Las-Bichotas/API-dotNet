using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ILenguage.API.Domain.Models;
using ILenguage.API.Domain.Persistence.Repositories;
using ILenguage.API.Domain.Services;

namespace ILenguage.API.Services
{
    public class SuscriptionService : ISuscriptionService
    {
        private readonly ISuscriptionRepository _suscriptionRepository;
        private readonly IUnitOfWork _unitOfWork;

        public SuscriptionService(ISuscriptionRepository suscriptionRepository, IUnitOfWork unitOfWork)
        {
            _suscriptionRepository = suscriptionRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Suscription>> ListAsync()
        {
            return await _suscriptionRepository.ListAsync();
        }

        public async Task<SuscriptionResponse> GetById(int id)
        {
            var existingSuscription = await _suscriptionRepository.FindById(id);
            if (existingSuscription == null)
                return new SuscriptionResponse("Suscription Not Found");
            return new SuscriptionResponse(existingSuscription);
        }

        public async Task<SuscriptionResponse> GetByName(string name)
        {
            var existingSuscription = await _suscriptionRepository.FindByName(name);
            if (existingSuscription == null)
                return new SuscriptionResponse("Suscription Not Found");
            return new SuscriptionResponse(existingSuscription);
            
        }

        public async Task<SuscriptionResponse> GetByDuration(int duration)
        {
            var existingSuscription = await _suscriptionRepository.FindByDuration(duration);
            if (existingSuscription == null)
                return new SuscriptionResponse("Suscription Not Found");
            return new SuscriptionResponse(existingSuscription);
        }

        public async Task<SuscriptionResponse> SaveAsync(Suscription suscription)
        {
            var existingSubscriptionByDuration = await _suscriptionRepository.FindByDuration(suscription.MonthDuration);
            var existingSubscriptionByName = await _suscriptionRepository.FindByName(suscription.Name);
            if (existingSubscriptionByDuration != null)
                return new SuscriptionResponse("There already exist a Subscription with that duration");
            if(existingSubscriptionByName != null)
                return new SuscriptionResponse("There already exist a Subscription with that name");
            
            try
            {
                await _suscriptionRepository.AddAsync(suscription);
                await _unitOfWork.CompleteAsync();
                return new SuscriptionResponse(suscription);
            }
            catch (Exception e)
            {
                return new SuscriptionResponse($"An error ocurred while saving the suscription {e.Message}");
            }
        }

        public async Task<SuscriptionResponse> UpdateAsync(int id, Suscription suscription)
        {
            var existingSuscription = await _suscriptionRepository.FindById(id);
            if (existingSuscription == null)
                return new SuscriptionResponse("Suscription Not Found");
            
            var existingSubscriptionByDuration = await _suscriptionRepository.FindByDuration(suscription.MonthDuration);
            var existingSubscriptionByName = await _suscriptionRepository.FindByName(suscription.Name);
            if (existingSubscriptionByDuration != null)
                return new SuscriptionResponse("There already exist a Subscription with that duration");
            if(existingSubscriptionByName != null)
                return new SuscriptionResponse("There already exist a Subscription with that name");            
            
            existingSuscription.Name = suscription.Name;
            existingSuscription.Price = suscription.Price;
            existingSuscription.MonthDuration = suscription.MonthDuration;
            try
            {
                _suscriptionRepository.Update(existingSuscription);
                await _unitOfWork.CompleteAsync();
                return new SuscriptionResponse(existingSuscription);
            }
            catch (Exception e)
            {
                return new SuscriptionResponse($"An error ocurred while saving the suscription {e.Message}");
            }
        }

        public async Task<SuscriptionResponse> DeleteAsync(int id)
        {
            var existingSuscription = await _suscriptionRepository.FindById(id);
            if (existingSuscription == null)
                return new SuscriptionResponse("Suscription Not Found");
            try
            {
                _suscriptionRepository.Remove(existingSuscription);
                await _unitOfWork.CompleteAsync();
                return new SuscriptionResponse(existingSuscription);
            }
            catch (Exception e)
            {
                return new SuscriptionResponse($"An error ocurred while deleting the suscription: {e.Message}");
            }
        }
    }
}