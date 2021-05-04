using AutoMapper;
using ILanguage.API.Domain.Models;
using ILanguage.API.Domain.Services;
using ILanguage.API.Extensions;
using ILanguage.API.Resources;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ILanguage.API.Controllers
{
    [ApiController]
    [Produces("application/json")]
    
    [Route("api/[controller]")]
    public class SchedulesController : ControllerBase
    {

        private readonly IScheduleService _ScheduleService;
        private readonly IMapper _mapper;

        public AvailableSchedulesController(IScheduleService ScheduleService, IMapper mapper)
        {
            _ScheduleService = ScheduleService;
            _mapper = mapper;
        }


        [SwaggerOperation(
               Summary = "Add Schedule",
               Description = "Add new Schedule",
               OperationId = "AddSchedule",
               Tags = new[] { "Schedules" })]
        [SwaggerResponse(200, "Add Schedules", typeof(IEnumerable<ScheduleResource>))]
        [HttpPost]
        [ProducesResponseType(typeof(IEnumerable<ScheduleResource>), 200)]
        public async Task<IActionResult> PostAsync([FromBody] SaveScheduleResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetMessages());
            var Schedule = _mapper.Map<SaveScheduleResource, Schedule>(resource);
            var result = await _ScheduleService.SaveAsync(Schedule);

            if (!result.Success)
                return BadRequest(result.Message);

            var ScheduleResource = _mapper.Map<Schedule, ScheduleResource>(result.Resource);
            return Ok(ScheduleResource);
        }



        [SwaggerOperation(
             Summary = "Update Schedule by User",
             Description = "Update a Schedule by User",
             OperationId = "UpdateSchedulebyUser",
             Tags = new[] { "Schedules" })]
        [SwaggerResponse(200, "Update Schedules by User", typeof(IEnumerable<ScheduleResource>))]
        [HttpPut("{userId}")]
        [ProducesResponseType(typeof(IEnumerable<ScheduleResource>), 200)]
        public async Task<IActionResult> PutAsync(int userId, [FromBody] SaveScheduleResource resource)
        {
            var Schedule = _mapper.Map<SaveScheduleResource, Schedule>(resource);
            var result = await _ScheduleService.UpdateAsync(userId, Schedule);

            if (!result.Success)
                return BadRequest(result.Message);
            var ScheduleResource = _mapper.Map<Schedule, ScheduleResource>(result.Resource);
            return Ok(ScheduleResource);
        }


    }
}
