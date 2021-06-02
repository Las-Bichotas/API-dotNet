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
    [Route("/api/users/{userId}/languages")]
    [ApiController]
    [Produces("application/json")]
    public class UserLanguageController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ILanguageOfInterestService _languageOfInterestService;
        private readonly IUserLanguageService _userLanguageService;
        private readonly IMapper _mapper;

        public UserLanguageController(IUserService userService, ILanguageOfInterestService languageOfInterestService, IUserLanguageService userLanguageService, IMapper mapper)
        {
            _userService = userService;
            _languageOfInterestService = languageOfInterestService;
            _userLanguageService = userLanguageService;
            _mapper = mapper;
        }
        [HttpGet]
        [SwaggerOperation(
            Summary = "GetAllLanguage",
            Description = "Get all languages by user Id",
            OperationId = "GetAllLanguageByUserId"
        )]
        [SwaggerResponse(200, "all topics retuned", typeof(IEnumerable<LanguageOfInterestResource>))]
        [ProducesResponseType(typeof(IEnumerable<LanguageOfInterestResource>), 200)]
        [Produces("application/json")]
        public async Task<IEnumerable<LanguageOfInterestResource>> GetAllTopicsByUserId(int userId)
        {
            var languages = await _languageOfInterestService.ListGetByUserId(userId);
            var resources = _mapper.Map<IEnumerable<LanguageOfInterest>, IEnumerable<LanguageOfInterestResource>>(languages);
            return resources;
        }

        [HttpPost("{languageId}")]
        [SwaggerOperation(
            Summary = "Assign language to user",
            Description = "Assign language to user by topicId and userId",
            OperationId = "Assignlanguage"
        )]
        [SwaggerResponse(200, "language user Assigned", typeof(LanguageOfInterest))]
        [ProducesResponseType(typeof(LanguageOfInterest), 200)]
        [Produces("application/json")]
        public async Task<IActionResult> AssignUserTopic(int userId, int languageId)
        {
            var result = await _userLanguageService.AssignLanguageUser(userId, languageId);
            if (!result.Succes)
                return BadRequest(result.Message);
            var language = await _languageOfInterestService.GetByIdAsync(result.Resource.LanguageId);
            var languageResource = _mapper.Map<LanguageOfInterest, LanguageOfInterestResource>(language.Resource);
            return Ok(languageResource);
        }

        [HttpDelete("{languageId}")]
        [SwaggerOperation(
            Summary = "Unassign language to user",
            Description = "Unassign language to user by topicId and userId",
            OperationId = "UnassignLanguage"
        )]
        [SwaggerResponse(200, "language user unassigned", typeof(LanguageOfInterest))]
        [ProducesResponseType(typeof(LanguageOfInterest), 200)]
        [Produces("application/json")]
        public async Task<IActionResult> UnassignUserTopic(int userId, int languageId)
        {
            var result = await _userLanguageService.UnassignLanguageUser(userId, languageId);
            if (!result.Succes)
                return BadRequest(result.Message);
            var language = await _languageOfInterestService.GetByIdAsync(result.Resource.LanguageId);
            var languageResource = _mapper.Map<LanguageOfInterest, LanguageOfInterestResource>(language.Resource);
            return Ok(languageResource);
        }
    }
}