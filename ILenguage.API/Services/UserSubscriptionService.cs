using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ILenguage.API.Domain.Models;
using ILenguage.API.Domain.Persistence.Repositories;
using ILenguage.API.Domain.Services;
using ILenguage.API.Domain.Services.Communications;

namespace ILenguage.API.Services
{
    public class UserSubscriptionService : IUserSubscriptionService
    {
        private readonly IUserSubscriptionRepository _userSubscriptionRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UserSubscriptionService(IUserSubscriptionRepository userSubscriptionRepository, IUnitOfWork unitOfWork)
        {
            _userSubscriptionRepository = userSubscriptionRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<UserSubscription>> ListAsync()
        {
            return await _userSubscriptionRepository.ListAsync();
        }

        public async Task<IEnumerable<UserSubscription>> ListByUserIdAsync(int userId)
        {
            return await _userSubscriptionRepository.ListByUserId(userId);
        }

        public async Task<IEnumerable<UserSubscription>> ListBySubscriptionId(int suscriptionId)
        {
            return await _userSubscriptionRepository.ListBySubscriptionId(suscriptionId);
        }

        public async Task<UserSubscriptionResponse> AssingUserSubscriptionAsync(int userId, int subscriptionId)
        {
            try
            {
                
                var existingUserSubscription = await _userSubscriptionRepository.GetLastUserSubscriptionByUserIdAsync(userId);
                if (existingUserSubscription == null)
                {
                    await _userSubscriptionRepository.AssingUserSubscription(userId, subscriptionId);
                    await _unitOfWork.CompleteAsync();
                    UserSubscription userSubscriptionWhenUserHasNoSubscription =
                        await _userSubscriptionRepository.FindBySubscriptionIdAndUserId(userId, subscriptionId);
                    
                    return new UserSubscriptionResponse(userSubscriptionWhenUserHasNoSubscription);
                    
                }
                DateTime foundFinalDate = existingUserSubscription.FinalDate;
                if (DateTime.Compare(foundFinalDate, DateTime.Now)>0)
                {
                    return new UserSubscriptionResponse("The user already has an active subscription");
                }
                
                await _userSubscriptionRepository.AssingUserSubscription(userId, subscriptionId);
                await _unitOfWork.CompleteAsync();
                UserSubscription userSubscription =
                    await _userSubscriptionRepository.FindBySubscriptionIdAndUserId(userId, subscriptionId);
 
              
                return new UserSubscriptionResponse(userSubscription);
            }
            catch (Exception e)
            {
                return new UserSubscriptionResponse(
                    $"An error ocurred while assingin User to Subscription: {e.Message} ");
            }
        }

        public async Task<UserSubscriptionResponse> UnassingUserSubscriptionAsync(int userId, int subscriptionId)
        {
            try
            {
                
                UserSubscription userSubscription =
                    await _userSubscriptionRepository.FindBySubscriptionIdAndUserId(subscriptionId, userId);
                _userSubscriptionRepository.Remove(userSubscription);
                await _unitOfWork.CompleteAsync();
                return new UserSubscriptionResponse(userSubscription);
            }
            catch (Exception e)
            {
                return new UserSubscriptionResponse(
                    $"An error ocurred while unassinging User From Subscription: {e.Message}");
            }
        }


    }
}