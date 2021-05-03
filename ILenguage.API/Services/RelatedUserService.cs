
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ILenguage.API.Domain.Models;
using ILenguage.API.Domain.Persistence.Repositories;
using ILenguage.API.Domain.Services;
using ILenguage.API.Domain.Services.Communications;

namespace ILenguage.API.Services
{
    public class RelatedUserService : IRelatedUserService
    {
        private readonly IRelatedUserRepository _relatedUserRepository;
        private readonly IUnitOfWork _unitOfWord;

        public async Task<IEnumerable<RelatedUser>> ListAsync()
        {
            return await _relatedUserRepository.ListAsyn();
        }

        public async Task<IEnumerable<RelatedUser>> ListByIdAsync(int userId)
        {
            return await _relatedUserRepository.ListByUserIdAsyn(userId);
        }
        public async Task<RelatedUserResponse> AssignUserAsync(int userOneId, int userTwoId)
        {
            try
            {
                await _relatedUserRepository.AssignRelatedUser(userOneId, userTwoId);
                await _unitOfWord.CompleteAsync();
                RelatedUser relatedUser = await _relatedUserRepository.FindByUserOneIdAndUserTwoId(userOneId, userTwoId);
                return new RelatedUserResponse(relatedUser);
            }
            catch (Exception ex)
            {
                return new RelatedUserResponse($"And error while assigning userOne to userTwo: {ex.Message}");
            }
        }
        public async Task<RelatedUserResponse> UnassignUserAsync(int userOneId, int userTwoId)
        {
            try
            {
                RelatedUser relatedUser = await _relatedUserRepository.FindByUserOneIdAndUserTwoId(userOneId, userTwoId);
                _relatedUserRepository.Remove(relatedUser);
                await _unitOfWord.CompleteAsync();
                return new RelatedUserResponse(relatedUser);
            }
            catch (Exception ex)
            {
                return new RelatedUserResponse($"An error while assigning UserOne to UserTwo: {ex.Message}");
            }
        }
    }
}