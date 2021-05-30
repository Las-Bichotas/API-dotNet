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

        public async Task<SdayResponse> GetById(int id)
        {
        var existingSday = await _sdayRepository.FindById(id);
            if (existingSday == null)
                return new SdayResponse("Day Not Found");
            return new SdayResponse(existingSday);        }

        
        
        public async Task<SdayResponse> AssingSdayAsync(int id,Sday sday)
        {
          var existingSday = await _sdayRepository.FindById(id);
            if (existingSday == null)
                return new SdayResponse("Day Not Found");
            return new SdayResponse(existingSday);        

            
 
        }     
        
    

    }
}