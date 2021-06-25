using ILenguage.API.Domain.Models;
using ILenguage.API.Domain.Persistence.Repositories;
using ILenguage.API.Domain.Services;
using ILenguage.API.Domain.Services.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ILenguage.API.Services
{
    public class UserSessionService : IUserSessionService
    {
        private readonly IUserSessionRepository _userSessionRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UserSessionService(IUserSessionRepository userSessionRepository, IUnitOfWork unitOfWork)
        {
            _userSessionRepository = userSessionRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<UserSession>> ListAsync()
        {
            return await _userSessionRepository.ListAsync();
        }

        public async Task<IEnumerable<UserSession>> ListBySessionIdAsync(int sessionId)
        {
            return await _userSessionRepository.ListBySessionIdAsync(sessionId);
        }

        public async Task<IEnumerable<UserSession>> ListByUserIdAsync(int userId)
        {
            return await _userSessionRepository.ListByUserIdAsync(userId);
        }

        public async Task<UserSessionResponse> AssignUserSessionAsync(int userId, int sessionId)
        {
            try
            {
                await _userSessionRepository.AssignUserSession(userId, sessionId);
                await _unitOfWork.CompleteAsync();
                UserSession userSession= await _userSessionRepository.FindByUserIdAndSessionId(userId, sessionId);
                return new UserSessionResponse(userSession);

            }
            catch (Exception ex)
            {
                return new UserSessionResponse($"An error ocurred while assigning User to Session: {ex.Message}");
            }
        }

        public async Task<UserSessionResponse> UnassignUserSessionAsync(int userId, int sessionId)
        {
            try
            {
                UserSession userSession= await _userSessionRepository.FindByUserIdAndSessionId(userId, sessionId);

                _userSessionRepository.Remove(userSession);
                await _unitOfWork.CompleteAsync();

                return new UserSessionResponse(userSession);

            }
            catch (Exception ex)
            {
                return new UserSessionResponse($"An error ocurred while unassigning User from Session: {ex.Message}");
            }
        }
    }
}
