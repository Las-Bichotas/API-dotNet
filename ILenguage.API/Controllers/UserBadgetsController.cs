using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using ILenguage.API.Domain.Models;
using ILenguage.API.Domain.Services;
using ILenguage.API.Resources;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace ILenguage.API.Controllers
{

    [Route("/api/users/{userId}/badgets")]
    [ApiController]
    [Produces("application/json")]
    public class UserBadgetsController : ControllerBase
    {
        private readonly IUserBadgetsService _userBadgetsService;
        private readonly IBadgetService _badgetService;
        private readonly IMapper _mapper;

        public UserBadgetsController(IUserBadgetsService userBadgetsService, IMapper mapper, IBadgetService badgetService)
        {
            _userBadgetsService = userBadgetsService;
            _mapper = mapper;
            _badgetService = badgetService;
        }

        [HttpGet]
        [SwaggerOperation(
            Summary = "GetAllBadgets",
            Description = "Get all Badgets by user Id",
            OperationId = "GetAllBadgetsByUserId"
        )]
        [SwaggerResponse(200, "all badgets retuned", typeof(IEnumerable<BadgetsResource>))]
        [ProducesResponseType(typeof(IEnumerable<BadgetsResource>), 200)]
        [Produces("application/json")]
        public async Task<IEnumerable<BadgetsResource>> GetAllBadgetsByUserId(int userId)
        {
            var badgets = await _badgetService.ListByUserId(userId);
            var resources = _mapper.Map<IEnumerable<Badgets>, IEnumerable<BadgetsResource>>(badgets);
            return resources;
        }

        [HttpPost("{badgetId}")]
        [SwaggerOperation(
            Summary = "Assign badget to user",
            Description = "Assign badget to user by Id and userId",
            OperationId = "Assignlanguage"
        )]
        [SwaggerResponse(200, "badget user Assigned", typeof(BadgetsResource))]
        [ProducesResponseType(typeof(BadgetsResource), 200)]
        [Produces("application/json")]
        public async Task<IActionResult> AssignUserBadget(int userId, int badgetId)
        {
            var result = await _userBadgetsService.AssignBadgetUser(userId, badgetId);
            if (!result.Succes)
                return BadRequest(result.Message);
            var badget = await _badgetService.GetByIdAsync(result.Resource.BadgetId);
            var badgetResource = _mapper.Map<Badgets, BadgetsResource>(badget.Resource);
            return Ok(badgetResource);
        }
        [HttpDelete("{badgetId}")]
        [SwaggerOperation(
            Summary = "Unassign badget to user",
            Description = "Unassign badget to user by Id and userId",
            OperationId = "Assignlanguage"
        )]
        [SwaggerResponse(200, "badget user Unassigned", typeof(BadgetsResource))]
        [ProducesResponseType(typeof(BadgetsResource), 200)]
        [Produces("application/json")]
        public async Task<IActionResult> UnassignUserBadget(int userId, int badgetId)
        {
            var result = await _userBadgetsService.UnassignBadgetUser(userId, badgetId);
            if (!result.Succes)
                return BadRequest(result.Message);
            var badget = await _badgetService.GetByIdAsync(result.Resource.BadgetId);
            var badgetResource = _mapper.Map<Badgets, BadgetsResource>(badget.Resource);
            return Ok(badgetResource);
        }
    }
}