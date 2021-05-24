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

        
        [HttpGet]
        [SwaggerOperation(
            Summary = "Get all users filtered by schedule",
            Description="Get all users that are relatead with an especific schedule",
            OperationId="GetUserByScheduleId")]
        public async Task<IEnumerable<UserResource>> GetAllByScheduleIdAsync(int scheduleId)
        {
            var users = await _userService.ListByScheduleId(scheduleId);
            var resources = _mapper.Map<IEnumerable<User>, IEnumerable<UserResource>>(users);
            return resources;
        }
        



    }
}