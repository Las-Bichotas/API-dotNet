using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ILenguage.API.Domain.Models;
using ILenguage.API.Domain.Persistence.Repositories;
using ILenguage.API.Domain.Services;
using ILenguage.API.Domain.Services.Communications;

namespace ILenguage.API.Services
{
    public class SdayService : ISdayService
    {
        private readonly ISdayRepository _sdayRepository;
        private readonly IUnitOfWork _unitOfWork;

        public SdayService(ISdayRepository sdayRepository, IUnitOfWork unitOfWork)
        {
            _sdayRepository = sdayRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Sday>> ListAsync()
        {
            return await _sdayRepository.ListAsync();
        }

        public async Task<SdayResponse> GetByIdAsync(int id)
        {
        var existingSday = await _sdayRepository.FindById(id);
            if (existingSday == null)
                return new SdayResponse("Day Not Found");
            return new SdayResponse(existingSday);        }

        
        public async Task<SdayResponse> SaveAsync(Sday sday)
        {
            try
            {
                await _sdayRepository.AddAsync(sday);
                await _unitOfWork.CompleteAsync();

                return new SdayResponse(sday);
            }
            catch (Exception ex)
            {
                return new SdayResponse($"An error ocurred while saving day: {ex.Message}");
            }
        }

        public async Task<SdayResponse> UpdateAsync(int id, Sday sday)
        {
            var existingSday = await _sdayRepository.FindById(id);

            if (existingSday == null)
                return new SdayResponse("Sday not found");

            existingSday.InicialDay = sday.InicialDay;

            try
            {
                _sdayRepository.Update(existingSday);
                await _unitOfWork.CompleteAsync();

                return new SdayResponse(existingSday);
            }
            catch (Exception ex)
            {
                return new SdayResponse($"An error ocurred while updating Day: {ex.Message}");
            }
        }


        public async Task<SdayResponse> DeleteAsync(int id)
        {
            var existingSday = await _sdayRepository.FindById(id);

            if (existingSday == null)
                return new SdayResponse("Day not found");

            try
            {
                _sdayRepository.Remove(existingSday);
                await _unitOfWork.CompleteAsync();

                return new SdayResponse(existingSday);
            }
            catch (Exception ex)
            {
                return new SdayResponse($"An error ocurred while deleting day: {ex.Message}");
            }
        }
        public async Task<SdayResponse> AssingSdayAsync(int id)
        {
          var existingSday = await _sdayRepository.FindById(id);
            if (existingSday == null)
                return new SdayResponse("Day Not Found");
            return new SdayResponse(existingSday);        

            
 
        }     
        
    

    }
}