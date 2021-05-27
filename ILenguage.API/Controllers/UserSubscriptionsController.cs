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
    [ApiController]
    [Produces("application/json")]
    [Route("/api/subscriptions/{subscriptionId}/users")]
    public class UserSubscriptionsController : ControllerBase
    {
        private readonly IUserSubscriptionService _userSubscriptionService;
        private readonly IMapper _mapper;
        private readonly IUserService _userService;

        public UserSubscriptionsController(IUserSubscriptionService userSubscriptionService, IMapper mapper, IUserService userService)
        {
            _userSubscriptionService = userSubscriptionService;
            _mapper = mapper;
            _userService = userService;
        }


        [HttpPost("{userId}")]
        [SwaggerOperation(
            Summary = "Assing a user to one subscription",
            Description="Assing a user to one subscription and save it on the Database",
            OperationId="AssingUserSubscription")]
        public async Task<IActionResult> AssingUserSubscription(int userId, int subscriptionId)
        {
            var result = await _userSubscriptionService.AssingUserSubscriptionAsync(userId, subscriptionId);
            if (!result.Succes)
                return BadRequest(result.Message);
            var userResource = _mapper.Map<User, UserResource>(result.Resource.User);
            return Ok(userResource);
        }

        [HttpGet]
        [SwaggerOperation(
            Summary = "Get all users filtered by subscription",
            Description="Get all users that are relatead with an especific subscription",
            OperationId="GetUserBySubscriptionId")]
        public async Task<IEnumerable<UserResource>> GetAllBySubscriptionIdAsync(int subscriptionId)
        {
            var users = await _userService.ListBySubscriptionId(subscriptionId);
            var resources = _mapper.Map<IEnumerable<User>, IEnumerable<UserResource>>(users);
            return resources;
        }
        
        
        [HttpPut("/user/{userId}")]

        [SwaggerOperation(
            Summary = "Unassing a user to one subscription",
            Description = "Unssing a user to one subscription and save it on the Database",
            OperationId = "UnasingUserSubscription")]
        public async Task<IActionResult> UnssingUserToSubscription(int userId)
        {
            var result = await _userSubscriptionService.UnassingUserSubscriptionAsync(userId);
            if (!result.Succes)
                return BadRequest(result.Message);
            return Ok(result);
        }
        
    }
}