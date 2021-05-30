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
    [Route("/api/user/{userId}/topics")]
    [ApiController]
    [Produces("application/json")]
    public class UserTopicController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ITopicOfInterestService _topicOfInterestService;
        private readonly IUserTopicService _userTopicsService;
        private readonly IMapper _mapper;

        public UserTopicController(IUserService userService, ITopicOfInterestService topicOfInterestService, IUserTopicService userTopicsService, IMapper mapper)
        {
            _userService = userService;
            _topicOfInterestService = topicOfInterestService;
            _userTopicsService = userTopicsService;
            _mapper = mapper;
        }

        [HttpGet]
        [SwaggerOperation(
            Summary = "GetAllTopics",
            Description = "Get all topics by user Id",
            OperationId = "GetAllTopicsByUserId"
        )]
        [SwaggerResponse(200, "all topics retuned", typeof(IEnumerable<TopicOfInterestResource>))]
        [ProducesResponseType(typeof(IEnumerable<TopicOfInterestResource>), 200)]
        [Produces("application/json")]
        public async Task<IEnumerable<TopicOfInterestResource>> GetAllTopicsByUserId(int userId)
        {
            var topics = await _topicOfInterestService.ListByUserIdAsyn(userId);
            var resources = _mapper.Map<IEnumerable<TopicsOfInterest>, IEnumerable<TopicOfInterestResource>>(topics);
            return resources;
        }
        [HttpPost("{topicId}")]
        [SwaggerOperation(
            Summary = "Assign topic to user",
            Description = "Assign topic to user by topicId and userId",
            OperationId = "AssignTopic"
        )]
        [SwaggerResponse(200, "topic user Assigned", typeof(TopicsOfInterest))]
        [ProducesResponseType(typeof(TopicsOfInterest), 200)]
        [Produces("application/json")]
        public async Task<IActionResult> AssignUserTopic(int userId, int topicId)
        {
            var result = await _userTopicsService.AssignTopicUser(userId, topicId);
            if (!result.Succes)
                return BadRequest(result.Message);
            var topic = await _topicOfInterestService.GetById(result.Resource.TopicId);
            var topicResource = _mapper.Map<TopicsOfInterest, TopicOfInterestResource>(topic.Resource);
            return Ok(topicResource);
        }
        [HttpDelete("{topicId}")]
        [SwaggerOperation(
            Summary = "Unassign topic to user",
            Description = "Unassign topic to user by topicId and userId",
            OperationId = "UnassignTopic"
        )]
        [SwaggerResponse(200, "topic user unassigned", typeof(TopicsOfInterest))]
        [ProducesResponseType(typeof(TopicsOfInterest), 200)]
        [Produces("application/json")]
        public async Task<IActionResult> UnassignUserTopic(int userId, int topicId)
        {
            var result = await _userTopicsService.UnassignTopicUser(userId, topicId);
            if (!result.Succes)
                return BadRequest(result.Message);
            var topic = await _topicOfInterestService.GetById(result.Resource.TopicId);
            var topicResource = _mapper.Map<TopicsOfInterest, TopicOfInterestResource>(topic.Resource);
            return Ok(topicResource);
        }
    }
}