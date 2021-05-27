using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ILenguage.API.Domain.Models;
using ILenguage.API.Domain.Persistence.Repositories;
using ILenguage.API.Domain.Services;

namespace ILenguage.API.Services
{
    public class SubscriptionService : ISubscriptionService
    {
        private readonly ISubscriptionRepository _subscriptionRepository;
        private readonly IUnitOfWork _unitOfWork;

        public SubscriptionService(ISubscriptionRepository subscriptionRepository, IUnitOfWork unitOfWork)
        {
            _subscriptionRepository = subscriptionRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Subscription>> ListAsync()
        {
            return await _subscriptionRepository.ListAsync();
        }

        public async Task<SubscriptionResponse> GetById(int id)
        {
            var existingSuscription = await _subscriptionRepository.FindById(id);
            if (existingSuscription == null)
                return new SubscriptionResponse("Suscription Not Found");
            return new SubscriptionResponse(existingSuscription);
        }

        public async Task<SubscriptionResponse> GetByName(string name)
        {
            var existingSuscription = await _subscriptionRepository.FindByName(name);
            if (existingSuscription == null)
                return new SubscriptionResponse("Suscription Not Found");
            return new SubscriptionResponse(existingSuscription);
            
        }

        public async Task<SubscriptionResponse> GetByDuration(int duration)
        {
            var existingSuscription = await _subscriptionRepository.FindByDuration(duration);
            if (existingSuscription == null)
                return new SubscriptionResponse("Suscription Not Found");
            return new SubscriptionResponse(existingSuscription);
        }

        public async Task<SubscriptionResponse> SaveAsync(Subscription subscription)
        {
            var existingSubscriptionByDuration = await _subscriptionRepository.FindByDuration(subscription.MonthDuration);
            var existingSubscriptionByName = await _subscriptionRepository.FindByName(subscription.Name);
            if (existingSubscriptionByDuration != null)
                return new SubscriptionResponse("There already exist a Subscription with that duration");
            if(existingSubscriptionByName != null)
                return new SubscriptionResponse("There already exist a Subscription with that name");
            
            try
            {
                await _subscriptionRepository.AddAsync(subscription);
                await _unitOfWork.CompleteAsync();
                return new SubscriptionResponse(subscription);
            }
            catch (Exception e)
            {
                return new SubscriptionResponse($"An error ocurred while saving the suscription {e.Message}");
            }
        }

        public async Task<SubscriptionResponse> UpdateAsync(int id, Subscription subscription)
        {
            var existingSuscription = await _subscriptionRepository.FindById(id);
            if (existingSuscription == null)
                return new SubscriptionResponse("Suscription Not Found");
            
            var existingSubscriptionByDuration = await _subscriptionRepository.FindByDuration(subscription.MonthDuration);
            var existingSubscriptionByName = await _subscriptionRepository.FindByName(subscription.Name);
            if (existingSubscriptionByDuration != null)
                return new SubscriptionResponse("There already exist a Subscription with that duration");
            if(existingSubscriptionByName != null)
                return new SubscriptionResponse("There already exist a Subscription with that name");            
            
            existingSuscription.Name = subscription.Name;
            existingSuscription.Price = subscription.Price;
            existingSuscription.MonthDuration = subscription.MonthDuration;
            try
            {
                _subscriptionRepository.Update(existingSuscription);
                await _unitOfWork.CompleteAsync();
                return new SubscriptionResponse(existingSuscription);
            }
            catch (Exception e)
            {
                return new SubscriptionResponse($"An error ocurred while saving the suscription {e.Message}");
            }
        }

        public async Task<SubscriptionResponse> DeleteAsync(int id)
        {
            var existingSuscription = await _subscriptionRepository.FindById(id);
            if (existingSuscription == null)
                return new SubscriptionResponse("Suscription Not Found");
            try
            {
                _subscriptionRepository.Remove(existingSuscription);
                await _unitOfWork.CompleteAsync();
                return new SubscriptionResponse(existingSuscription);
            }
            catch (Exception e)
            {
                return new SubscriptionResponse($"An error ocurred while deleting the suscription: {e.Message}");
            }
        }
    }
}