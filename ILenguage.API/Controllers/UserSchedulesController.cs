using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using ILenguage.API.Domain.Models;
using ILenguage.API.Domain.Services;
using ILenguage.API.Extensions;
using ILenguage.API.Resources;
using Microsoft.AspNetCore.Mvc;

namespace ILenguage.API.Controllers
{

    [ApiController]
    [Produces("application/json")]
  
    [Route("/api/users/{userId}/Schedule")]
    public class UserSchedulesController : ControllerBase
    {
        private readonly IScheduleService _ScheduleService;
        private readonly IMapper _mapper;

        public UserSchedulesController(IScheduleService ScheduleService, IMapper mapper)
        {
            _ScheduleService = ScheduleService;
            _mapper = mapper;
        }

        
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ScheduleResource>), 200)]
        public async Task<IEnumerable<ScheduleResource>> GetAllByScheduleAsync(int userId)
        {
            var Schedules = await _ScheduleService.ListByUserIdAsync(userId);
            var resources = _mapper.Map<IEnumerable<Schedule>, IEnumerable<ScheduleResource>>(Schedules);
            return resources;
        }




    }
}