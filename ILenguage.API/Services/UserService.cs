using ILenguage.API.Domain.Models;
using ILenguage.API.Domain.Persistence.Repositories;
using ILenguage.API.Domain.Repositories;
using ILenguage.API.Domain.Services;
using ILenguage.API.Domain.Services.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ILenguage.API.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserSubscriptionRepository _userSubscriptionRepository;
        private readonly IUserScheduleRepository _userScheduleRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly IUserTopicRepository _userTopicRepository;

        public UserService(IUserRepository userRepository, IUnitOfWork unitOfWork, IUserSubscriptionRepository userSubscriptionRepository, IUserScheduleRepository userScheduleRepository, IRoleRepository roleRepository, IUserTopicRepository userTopicRepository)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
            _userSubscriptionRepository = userSubscriptionRepository;
            _userScheduleRepository = userScheduleRepository;
            _roleRepository = roleRepository;
            _userTopicRepository = userTopicRepository;
        }

        public async Task<IEnumerable<User>> ListAsync()
        {
            return await _userRepository.ListAsync();
        }
        public async Task<UserResponse> DeleteAsync(int userId)
        {
            var exitingUser = await _userRepository.FindById(userId);
            if (exitingUser == null)
                return new UserResponse("User not found");
            try
            {
                _userRepository.Remove(exitingUser);
                await _unitOfWork.CompleteAsync();
                return new UserResponse(exitingUser);
            }
            catch (Exception ex)
            {
                return new UserResponse($"and error ocurrend while deleteing user: {ex.Message}");
            }
        }

        public async Task<IEnumerable<User>> ListBySubscriptionId(int subscriptionId)
        {
            var userSubscription = await _userSubscriptionRepository.ListBySubscriptionId(subscriptionId);
            var users = userSubscription.Select(us => us.User).ToList();
            return users;
        }
        public async Task<IEnumerable<User>> ListByScheduleId(int scheduleId)
        {
            var userSchedule = await _userScheduleRepository.ListByScheduleId(scheduleId);
            var users = userSchedule.Select(us => us.User).ToList();
            return users;
        }

        public async Task<UserResponse> GetByIdAsync(int userId)
        {
            var existingUser = await _userRepository.FindById(userId);
            if (existingUser == null)
                return new UserResponse("User not found");

            return new UserResponse(existingUser);
        }


        public async Task<UserResponse> SaveAsync(User user, int roleId)
        {
            var existingRole = await _roleRepository.FindById(roleId);
            if (existingRole == null)
                return new UserResponse("Role to assing User not found");
            user.Role = existingRole;
            user.RoleId = roleId;
            try
            {
                await _userRepository.AddAsync(user);
                await _unitOfWork.CompleteAsync();
                return new UserResponse(user);
            }
            catch (Exception ex)
            {
                return new UserResponse($"An error ocurred while saving the user: {ex.Message}");
            }
        }

        public async Task<UserResponse> UpdateAsync(int userId, User user)
        {
            var existingUser = await _userRepository.FindById(userId);
            if (existingUser == null)
                return new UserResponse("User not found");
            existingUser.Name = user.Name;
            existingUser.LastName = user.LastName;
            existingUser.Description = user.Description;
            existingUser.Email = user.Email;
            existingUser.Password = user.Password;
            existingUser.RelatedUsers = user.RelatedUsers;

            try
            {
                _userRepository.Update(existingUser);
                await _unitOfWork.CompleteAsync();
                return new UserResponse(existingUser);
            }
            catch (Exception ex)
            {
                return new UserResponse($"An error ocurrned while updating user: {ex.Message}");
            }
        }

        public async Task<IEnumerable<User>> ListByRoleId(int roleId)
        {
            return await _userRepository.ListUsersByRoleId(roleId);
        }

        public async Task<IEnumerable<User>> ListByRoleIdAndTopicId(int roleId, int topicId)
        {
            var userTopics = await _userTopicRepository.ListByRoleIdAndTopicId(roleId, topicId);
            var users = userTopics.Select(ut => ut.User).ToList();
            return users;
        }
    }
}