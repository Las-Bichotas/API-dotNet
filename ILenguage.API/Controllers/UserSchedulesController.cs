using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using ILenguage.API.Domain.Models;
using ILenguage.API.Domain.Services;
using ILenguage.API.Extensions;
using ILenguage.API.Resources;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace ILenguage.API.Controllers
{

    [ApiController]
    [Produces("application/json")]
  
    [Route("/api/users/{userId}/Schedule")]
    public class UserSchedulesController : ControllerBase
    {
        private readonly IUserScheduleService _userScheduleService;
        private readonly IMapper _mapper;
        private readonly IUserService _userService;
        public UserSchedulesController(IUserScheduleService userScheduleService, IMapper mapper, IUserService userService)
        {
            _userScheduleService = userScheduleService;
            _mapper = mapper;
            _userService = userService;
        }

        
        [HttpPost("{scheduleId}")]
        [SwaggerOperation(
            Summary = "Assing a user to one Schedule",
            Description="Assing a user to one Schedule and save it on the Database",
            OperationId="AssingUserSchedule")]
        public async Task<IActionResult> AssingUserSchedule(int userId, int scheduleId)
        {
            var result = await _userScheduleService.AssingUserScheduleAsync(userId, scheduleId);
            if (!result.Succes)
                return BadRequest(result.Message);
            var userResource = _mapper.Map<User, UserResource>(result.Resource.User);
            return Ok(userResource);
        }

        [HttpGet]
        [SwaggerOperation(
            Summary = "Get all users filtered by schedule",
            Description="Get all users that are relatead with an especific schedule",
            OperationId="GetAllByScheduleIdAsync")]
        public async Task<IEnumerable<UserResource>> GetAllByScheduleIdAsync(int scheduleId)
        {
            var users = await _userService.ListByScheduleId(scheduleId);
            var resources = _mapper.Map<IEnumerable<User>, IEnumerable<UserResource>>(users);
            return resources;
        }
        
        
        [HttpPut("/{scheduleId}")]

        [SwaggerOperation(
            Summary = "Unassing a user to one schedule",
            Description = "Unassing a user to one shedule and save it on the Database",
            OperationId = "UnasingUserSchedule")]
        public async Task<IActionResult> UnssingUserToSchedule(int userId)
        {
            var result = await _userScheduleService.UnassingUserScheduleAsync(userId);
            if (!result.Succes)
                return BadRequest(result.Message);
            return Ok(result);
        }



    }
}