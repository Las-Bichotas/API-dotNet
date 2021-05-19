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
    [Route("/api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveUserResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessage());

            var user = _mapper.Map<SaveUserResource, User>(resource);
            var result = await _userService.SaveAsync(user);
            if (!result.Succes)
                return BadRequest(result.Message);
            var userResource = _mapper.Map<User, UserResource>(result.Resource);
            return Ok(userResource);
        }
    }
}