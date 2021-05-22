using System.Threading.Tasks;
using AutoMapper;
using ILenguage.API.Domain.Models;
using ILenguage.API.Domain.Services;
using ILenguage.API.Resources;
using Microsoft.AspNetCore.Mvc;

namespace ILenguage.API.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("/api/subscriptions/{subscriptionId}/users")]
    public class UserSubscriptionsController : ControllerBase
    {
        private readonly IUserSubscriptionService _userSubscriptionService;
        private readonly IMapper _mapper;

        public UserSubscriptionsController(IUserSubscriptionService userSubscriptionService, IMapper mapper)
        {
            _userSubscriptionService = userSubscriptionService;
            _mapper = mapper;
        }

        [HttpPost("{userId}")]
        public async Task<IActionResult> AssingUserSubscription(int userId, int subscriptionId)
        {
            var result = await _userSubscriptionService.AssingUserSubscriptionAsync(userId, subscriptionId);
            if (!result.Succes)
                return BadRequest(result.Message);
            var userResource = _mapper.Map<User, UserResource>(result.Resource.User);
            return Ok(userResource);
        } 
        
        
    }
}