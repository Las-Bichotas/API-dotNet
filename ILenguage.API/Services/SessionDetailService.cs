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
    public class SessionDetailService : ISessionDetailService
    {
        private readonly ISessionDetailRepository _sessionDetailRepository;
        private readonly IUnitOfWork _unitOfWork;

        public SessionDetailService(ISessionDetailRepository sessionDetailRepository, IUnitOfWork unitOfWork)
        {
            _sessionDetailRepository = sessionDetailRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<SessionDetail>> ListAsync()
        {
            return await _sessionDetailRepository.ListAsync();
        }

        public async Task<SessionDetailResponse> SaveAsync(SessionDetail sessionDetail)
        {
            try
            {
                await _sessionDetailRepository.AddAsync(sessionDetail);
                await _unitOfWork.CompleteAsync();

                return new SessionDetailResponse(sessionDetail);
            }
            catch (Exception ex)
            {
                return new SessionDetailResponse($"An error ocurred while saving sessionDetail: {ex.Message}");
            }
        }

        public async Task<SessionDetailResponse> UpdateAsync(int id, SessionDetail sessionDetail)
        {
            var existingSessionDetail = await _sessionDetailRepository.FindById(id);

            if (existingSessionDetail == null)
                return new SessionDetailResponse("SessionDetail not found");

            existingSessionDetail.State = sessionDetail.State;

            try
            {
                _sessionDetailRepository.Update(existingSessionDetail);
                await _unitOfWork.CompleteAsync();

                return new SessionDetailResponse(existingSessionDetail);
            }
            catch (Exception ex)
            {
                return new SessionDetailResponse($"An error ocurred while updating SessionDetail: {ex.Message}");
            }
        }

        public async Task<SessionDetailResponse> DeleteAsync(int id)
        {
            var existingSessionDetail = await _sessionDetailRepository.FindById(id);

            if (existingSessionDetail == null)
                return new SessionDetailResponse("SessionDetail not found");

            try
            {
                _sessionDetailRepository.Remove(existingSessionDetail);
                await _unitOfWork.CompleteAsync();

                return new SessionDetailResponse(existingSessionDetail);
            }
            catch (Exception ex)
            {
                return new SessionDetailResponse($"An error ocurred while deleting sessionDetail : {ex.Message}");
            }

        }
        
        public async Task<IEnumerable<SessionDetail>> ListBySessionIdAsync(int sessionId)
        {
            return await _sessionDetailRepository.GetBySessionIdAsync(sessionId);
        }

        public async Task<SessionDetailResponse> GetByIdAsync(int id)
        {
            var existingSessionDetail = await _sessionDetailRepository.FindById(id);

            if (existingSessionDetail == null)
                return new SessionDetailResponse("SessionDetail not found");
            return new SessionDetailResponse(existingSessionDetail);
        }

        public async Task<SessionDetailResponse> AssignSessionSessionDetail(int sessionId, int sessionDetailId)
        {
            try
            {
                await _sessionDetailRepository.AssignSessionSessionDetail(sessionId, sessionDetailId);
                await _unitOfWork.CompleteAsync();
                SessionDetail sessionDetail = await _sessionDetailRepository.FindById(sessionDetailId);
                return new SessionDetailResponse(sessionDetail);

            }
            catch (Exception ex)
            {
                return new SessionDetailResponse($"An error ocurred while assigning SessionDetail to Session: {ex.Message}");
            }
        }
    }
}
