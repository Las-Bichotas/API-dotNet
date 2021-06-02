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
    
    [Route("api/[controller]")]
    public class SchedulesController : ControllerBase
    {

        private readonly IScheduleService _scheduleService;
        private readonly IMapper _mapper;

        public SchedulesController(IScheduleService ScheduleService, IMapper mapper)
        {
            _scheduleService = ScheduleService;
            _mapper = mapper;
        }


       
        [HttpGet]
        [SwaggerOperation(
            Summary = "Get all schedules",
            Description = "Get all schedules available",
            OperationId = "GetSchedules"
        )]
        [ProducesResponseType(typeof(IEnumerable<ScheduleResource>), 200)]
        public async Task<IEnumerable<ScheduleResource>> GetAllAsync()
        {
            var schedule = await _scheduleService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Schedule>, IEnumerable<ScheduleResource>>(schedule);
            return resources;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ScheduleResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        [SwaggerOperation(
            Summary = "Get Schedule by Id",
            Description = "Get a schedule only if it exists in the database",
            OperationId = "GetScheduleById"
        )]
        [SwaggerResponse(200, "Schedule Found", typeof(ScheduleResource))]
        [SwaggerResponse(404, "Schedule not found", typeof(ScheduleResource))]

        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var result = await _scheduleService.GetByIdAsync(id);
            if (!result.Succes)
                return BadRequest(result.Message);
            var scheduleResource = _mapper.Map<Schedule, ScheduleResource>(result.Resource);
            return Ok(scheduleResource);
        }

        [HttpPost]
        [SwaggerOperation(
            Summary = "Add new Schedule",
            Description = "Add new Schedule with initial data",
            OperationId = "AddSchedule"
        )]
        public async Task<IActionResult> PostAsync([FromBody] SaveScheduleResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessage());
            var schedule = _mapper.Map<SaveScheduleResource, Schedule>(resource);
            var result = await _scheduleService.SaveAsync(schedule);
            if (!result.Succes)
                return BadRequest(result.Message);
            var scheduleResource = _mapper.Map<Schedule, ScheduleResource>(result.Resource);
            return Ok(scheduleResource);
        }

        [HttpPut("{id}")]
        [SwaggerOperation(
            Summary = "Update Schedule",
            Description = "Update Schedule By Schedule Id",
            OperationId = "UpdateScheduleById"
        )]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveScheduleResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessage());
            var schedule = _mapper.Map<SaveScheduleResource, Schedule>(resource);
            var result = await _scheduleService.UpdateAsync(id, schedule);

            if (!result.Succes)
                return BadRequest(result.Message);
            var scheduleResource = _mapper.Map<Schedule, ScheduleResource>(result.Resource);
            return Ok(scheduleResource);
        }


        [HttpDelete("{id}")]
        [SwaggerOperation(
            Summary = "Delete Schedule",
            Description = "Delete Schedule By Schedule Id",
            OperationId = "DeleteScheduleById"
        )]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _scheduleService.DeleteAsync(id);
            if (!result.Succes)
                return BadRequest(result.Message);
            var scheduleResource = _mapper.Map<Schedule, ScheduleResource>(result.Resource);
            return Ok(scheduleResource);
        }


    }
}
