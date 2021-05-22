using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ILenguage.API.Domain.Models;
using ILenguage.API.Domain.Persistence.Repositories;
using ILenguage.API.Domain.Services;
using ILenguage.API.Domain.Services.Communications;

namespace ILenguage.API.Services
{
    public class TopicOfInterestService : ITopicOfInterestService
    {
        private readonly ITopicOfInterestRepository _topicOfInterestRespository;
        private readonly IUnitOfWork _unitOfWork;

        public TopicOfInterestService(ITopicOfInterestRepository topicOfInterestRespository, IUnitOfWork unitOfWork)
        {
            _topicOfInterestRespository = topicOfInterestRespository;
            _unitOfWork = unitOfWork;
        }

        public async Task<TopicsOfInterestResponse> Delete(int topicId)
        {
            var exitstingTopic = await _topicOfInterestRespository.FindByIdAsync(topicId);
            if (exitstingTopic == null)
                return new TopicsOfInterestResponse("Topic Not Found");
            try
            {
                _topicOfInterestRespository.Remove(exitstingTopic);
                await _unitOfWork.CompleteAsync();
                return new TopicsOfInterestResponse(exitstingTopic);
            }
            catch (Exception ex)
            {
                return new TopicsOfInterestResponse($"and error ocurrend while deleteing topic: {ex.Message}");
            }
        }

        public async Task<TopicsOfInterestResponse> GetById(int topicId)
        {
            var existingTopic = await _topicOfInterestRespository.FindByIdAsync(topicId);

            if (existingTopic == null)
                return new TopicsOfInterestResponse("Topic Not Found ");

            return new TopicsOfInterestResponse(existingTopic);
        }

        public async Task<IEnumerable<TopicsOfInterest>> ListAsync()
        {
            return await _topicOfInterestRespository.ListAsync();
        }

        public async Task<TopicsOfInterestResponse> SaveAsync(TopicsOfInterest topicOf)
        {
            try
            {
                await _topicOfInterestRespository.AddAsync(topicOf);
                await _unitOfWork.CompleteAsync();
                return new TopicsOfInterestResponse(topicOf);
            }
            catch (Exception ex)
            {
                return new TopicsOfInterestResponse($"an error while saving topic: {ex.Message}");
            }
        }

        public async Task<TopicsOfInterestResponse> Update(int topicId, TopicsOfInterest topicOf)
        {
            var existingTopic = await _topicOfInterestRespository.FindByIdAsync(topicId);
            if (existingTopic == null)
                return new TopicsOfInterestResponse("Topic Not Found");
            existingTopic.Name = topicOf.Name;
            try
            {
                _topicOfInterestRespository.Update(existingTopic);
                await _unitOfWork.CompleteAsync();
                return new TopicsOfInterestResponse(existingTopic);
            }
            catch (Exception ex)
            {
                return new TopicsOfInterestResponse($"And error updating topic: {ex.Message}");
            }
        }
    }
}