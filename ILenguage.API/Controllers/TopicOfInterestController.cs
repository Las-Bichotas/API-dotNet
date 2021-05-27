using AutoMapper;
using ILenguage.API.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using ILenguage.API.Resources;
using ILenguage.API.Domain.Models;
using System.Threading.Tasks;
using ILenguage.API.Extensions;
using System.Collections.Generic;

namespace ILenguage.API.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("/api/[controller]")]
    public class TopicOfInterestController : ControllerBase
    {
        private readonly ITopicOfInterestService _topicOfInterestService;
        private readonly IMapper _mapper;

        public TopicOfInterestController(ITopicOfInterestService topicOfInterestService, IMapper mapper)
        {
            _topicOfInterestService = topicOfInterestService;
            _mapper = mapper;
        }

        [HttpPost]
        [SwaggerOperation(
            Summary = "Add new Topic",
            Description = "Add new topic with initial data",
            OperationId = "Addtopic"
        )]
        [SwaggerResponse(200, "Topic Added", typeof(TopicOfInterestResource))]
        [ProducesResponseType(typeof(TopicOfInterestResource), 200)]
        [Produces("application/json")]
        public async Task<IActionResult> PostAsync([FromBody] SaveTopicOfInterestResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessage());

            var topic = _mapper.Map<SaveTopicOfInterestResource, TopicsOfInterest>(resource);
            var result = await _topicOfInterestService.SaveAsync(topic);
            if (!result.Succes)
                return BadRequest(result.Message);
            var topicResource = _mapper.Map<TopicsOfInterest, TopicOfInterestResource>(result.Resource);
            return Ok(topicResource);
        }

        [HttpGet]
        [SwaggerOperation(
            Summary = "Get All topics",
            Description = "Get All topics In the Data Base",
            OperationId = "GetAllTopics"
        )]
        [SwaggerResponse(200, "Returned topics", typeof(TopicOfInterestResource))]
        [ProducesResponseType(typeof(TopicOfInterestResource), 200)]
        [Produces("application/json")]
        public async Task<IEnumerable<TopicOfInterestResource>> GetAllAsync()
        {
            var topics = await _topicOfInterestService.ListAsync();
            var resources = _mapper.Map<IEnumerable<TopicsOfInterest>, IEnumerable<TopicOfInterestResource>>(topics);
            return resources;
        }

        [HttpGet("{id}")]
        [SwaggerOperation(
            Summary = "Get topic",
            Description = "Get topic by language id",
            OperationId = "GetTopicById"
        )]
        [SwaggerResponse(200, "Returned Topic", typeof(TopicOfInterestResource))]
        [ProducesResponseType(typeof(TopicOfInterestResource), 200)]
        [Produces("application/json")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var result = await _topicOfInterestService.GetById(id);

            if (!result.Succes)
                return BadRequest(result.Message);

            var topicResource = _mapper.Map<TopicsOfInterest, TopicOfInterestResource>(result.Resource);
            return Ok(topicResource);
        }

        [HttpDelete("{id}")]
        [SwaggerOperation(
            Summary = "delete topic",
            Description = "delete topic by language id",
            OperationId = "deleteTopicById"
        )]
        [SwaggerResponse(200, "Deleted topic", typeof(TopicOfInterestResource))]
        [ProducesResponseType(typeof(TopicOfInterestResource), 200)]
        [Produces("application/json")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _topicOfInterestService.Delete(id);

            if (!result.Succes)
                return BadRequest(result.Message);
            var topicResource = _mapper.Map<TopicsOfInterest, TopicOfInterestResource>(result.Resource);

            return Ok(topicResource);
        }

        [HttpPut("{id}")]
        [SwaggerOperation(
            Summary = "update topic",
            Description = "updated topics by language id",
            OperationId = "updatedTopicById"
        )]
        [SwaggerResponse(200, "updated topic", typeof(TopicOfInterestResource))]
        [ProducesResponseType(typeof(TopicOfInterestResource), 200)]
        [Produces("application/json")]
        public async Task<IActionResult> UpdatedAsync(int id, [FromBody] SaveTopicOfInterestResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessage());

            var language = _mapper.Map<SaveTopicOfInterestResource, TopicsOfInterest>(resource);
            var result = await _topicOfInterestService.Update(id, language);

            if (!result.Succes)
                return BadRequest(result.Message);

            var topicResource = _mapper.Map<TopicsOfInterest, TopicOfInterestResource>(result.Resource);
            return Ok(topicResource);
        }
    }
}