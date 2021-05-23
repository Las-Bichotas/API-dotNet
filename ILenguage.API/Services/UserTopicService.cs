using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ILenguage.API.Domain.Models;
using ILenguage.API.Domain.Persistence.Repositories;
using ILenguage.API.Domain.Services;
using ILenguage.API.Domain.Services.Communications;

namespace ILenguage.API.Services
{
    public class UserTopicService : IUserTopicService
    {
        private readonly IUserTopicRepository _userTopicRepository;
        private readonly IUnitOfWork _unitOfWork;
        public async Task<UserTopicsResponse> AssignTopicUser(int userId, int topicId)
        {
            try
            {
                await _userTopicRepository.AssignTopicUser(userId, topicId);
                await _unitOfWork.CompleteAsync();
                UserTopics userTopics = await _userTopicRepository.FindByUserIdAndTopicId(userId, topicId);
                return new UserTopicsResponse(userTopics);
            }
            catch (Exception ex)
            {
                return new UserTopicsResponse($"An error ocurredn while assigning topic to user: {ex.Message}");
            }
        }

        public async Task<IEnumerable<UserTopics>> ListAsync()
        {
            return await _userTopicRepository.ListAsync();
        }

        public async Task<IEnumerable<UserTopics>> ListByTopicId(int topicId)
        {
            return await _userTopicRepository.ListByTopicId(topicId);
        }

        public async Task<IEnumerable<UserTopics>> ListByUserId(int userId)
        {
            return await _userTopicRepository.ListByUserId(userId);
        }

        public async Task<UserTopicsResponse> UnassignTopicUser(int userId, int topicId)
        {
            try
            {
                UserTopics userTopics = await _userTopicRepository.FindByUserIdAndTopicId(userId, topicId);
                _userTopicRepository.Remove(userTopics);
                await _unitOfWork.CompleteAsync();
                return new UserTopicsResponse(userTopics);
            }
            catch (Exception ex)
            {
                return new UserTopicsResponse($"An error ocurred while unassigning topic to user: {ex.Message}");
            }
        }
    }
}