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
        [HttpPost("{roleId}")]
        [SwaggerOperation(
            Summary = "Add new user",
            Description = "Add new user with initial data",
            OperationId = "AddUser"
        )]
        [SwaggerResponse(200, "User Added", typeof(UserResource))]
        [ProducesResponseType(typeof(UserResource), 200)]
        [Produces("application/json")]
        public async Task<IActionResult> PostAsync(int roleId, [FromBody] SaveUserResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessage());

            var user = _mapper.Map<SaveUserResource, User>(resource);
            var result = await _userService.SaveAsync(user, roleId);
            if (!result.Succes)
                return BadRequest(result.Message);
            var userResource = _mapper.Map<User, UserResource>(result.Resource);
            return Ok(userResource);
        }

        [HttpGet]
        [SwaggerOperation(
            Summary = "Get All Users",
            Description = "Get All Users In The Data Base",
            OperationId = "GetAllUsers"
        )]
        [SwaggerResponse(200, "Users Returned", typeof(IEnumerable<UserResource>))]
        [ProducesResponseType(typeof(IEnumerable<UserResource>), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        [Produces("application/json")]
        public async Task<IEnumerable<UserResource>> GetAllAsync()
        {
            var users = await _userService.ListAsync();
            var resources = _mapper.Map<IEnumerable<User>, IEnumerable<UserResource>>(users);
            return resources;
        }

        [HttpDelete("{id}")]
        [SwaggerOperation(
            Summary = "Delete User",
            Description = "Delete User By User Id",
            OperationId = "DeleteUserById"
        )]
        [SwaggerResponse(200, "User Deleted", typeof(UserResource))]
        [ProducesResponseType(typeof(UserResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        [Produces("application/json")]


        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _userService.DeleteAsync(id);

            if (!result.Succes)
                return BadRequest(result.Message);
            var userResource = _mapper.Map<User, UserResource>(result.Resource);

            return Ok(userResource);
        }

        [HttpGet("{id}")]
        [SwaggerOperation(
            Summary = "Get User",
            Description = "Get User By User Id",
            OperationId = "GetlUserById"
        )]
        [SwaggerResponse(200, "User Returned", typeof(UserResource))]
        [ProducesResponseType(typeof(UserResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        [Produces("application/json")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var result = await _userService.GetByIdAsync(id);

            if (!result.Succes)
                return BadRequest(result.Message);

            var userResource = _mapper.Map<User, UserResource>(result.Resource);
            return Ok(userResource);
        }

        [HttpPut("{id}")]
        [SwaggerOperation(
            Summary = "Update User",
            Description = "Update User By User Id",
            OperationId = "UpdateUserById"
        )]
        [SwaggerResponse(200, "User Updated", typeof(UserResource))]
        [ProducesResponseType(typeof(UserResource), 200)]
        [Produces("application/json")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveUserResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessage());

            var user = _mapper.Map<SaveUserResource, User>(resource);
            var result = await _userService.UpdateAsync(id, user);

            if (!result.Succes)
                return BadRequest(result.Message);

            var userResource = _mapper.Map<User, UserResource>(result.Resource);
            return Ok(userResource);
        }
    }
}