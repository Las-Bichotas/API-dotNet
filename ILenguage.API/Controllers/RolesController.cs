using AutoMapper;
using ILenguage.API.Domain.Models;
using ILenguage.API.Domain.Services;
using ILenguage.API.Extensions;
using ILenguage.API.Resources;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ILenguage.API.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("/api/[controller]")]
    public class RolesController : ControllerBase
    {
        private readonly IRoleService _roleService;
        private readonly IMapper _mapper;

        public RolesController(IRoleService roleService, IMapper mapper)
        {
            _roleService = roleService;
            _mapper = mapper;
        }

        [HttpPost]
        [SwaggerOperation(
            Summary = "Add new Role",
            Description = "Add new Role with initial data",
            OperationId = "AddRole"
            )]
        [SwaggerResponse(200, "Role Added", typeof(RoleResource))]
        [ProducesResponseType(typeof(RoleResource), 200)]
        [Produces("application/json")]
        public async Task<IActionResult> PostAsync([FromBody] SaveRoleResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessage());
            var role = _mapper.Map<SaveRoleResource, Role>(resource);
            var result = await _roleService.SaveAsync(role);
            if (!result.Succes)
                return BadRequest(result.Message);
            var roleResource = _mapper.Map<Role, RoleResource>(result.Resource);
            return Ok(roleResource);
        }
        [HttpGet]
        [SwaggerOperation(
             Summary = "Get All Roles",
             Description = "Get All Roles In The Data Base",
             OperationId = "GetAllRoles"
             )]
        [SwaggerResponse(200, "Roles Returned", typeof(IEnumerable<RoleResource>))]
        [ProducesResponseType(typeof(IEnumerable<RoleResource>), 200)]
        [ProducesResponseType(typeof(BadRequestObjectResult), 404)]
        [Produces("application/json")]
        public async Task<IEnumerable<RoleResource>> GetAllAsync()
        {
            var roles = await _roleService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Role>, IEnumerable<RoleResource>>(roles);
            return resources;
        }

        [HttpDelete("{id}")]
        [SwaggerOperation(
            Summary = "Delete Role",
            Description = "Delete Role By Role Id",
            OperationId = "DeleteRoleById"
        )]
        [SwaggerResponse(200, "Role Deleted", typeof(RoleResource))]
        [ProducesResponseType(typeof(RoleResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        [Produces("application/json")]


        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _roleService.DeleteAsync(id);

            if (!result.Succes)
                return BadRequest(result.Message);
            var roleResource = _mapper.Map<Role, RoleResource>(result.Resource);

            return Ok(roleResource);
        }
        [HttpGet("{id}")]
        [SwaggerOperation(
           Summary = "Get Role",
           Description = "Get Role By Role Id",
           OperationId = "GetRoleById"
       )]
        [SwaggerResponse(200, "Role Returned", typeof(RoleResource))]
        [ProducesResponseType(typeof(RoleResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        [Produces("application/json")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var result = await _roleService.GetByIdAsync(id);

            if (!result.Succes)
                return BadRequest(result.Message);

            var roleResource = _mapper.Map<Role, RoleResource>(result.Resource);
            return Ok(roleResource);
        }

        [HttpPut("{id}")]
        [SwaggerOperation(
            Summary = "Update Role",
            Description = "Update Role By Role Id",
            OperationId = "UpdateRoleById"
        )]
        [SwaggerResponse(200, "Role Updated", typeof(RoleResource))]
        [ProducesResponseType(typeof(RoleResource), 200)]
        [Produces("application/json")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveRoleResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessage());

            var role = _mapper.Map<SaveRoleResource, Role>(resource);
            var result = await _roleService.UpdateAsync(id, role);

            if (!result.Succes)
                return BadRequest(result.Message);

            var roleResource = _mapper.Map<Role, RoleResource>(result.Resource);
            return Ok(roleResource);
        }
    }
}
