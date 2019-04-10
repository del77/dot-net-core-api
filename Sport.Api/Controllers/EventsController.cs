using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sport.Services.Events.Commands;
using Sport.Services.Interfaces;

namespace Sport.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EventsController : ApiControllerBase
    {
        private readonly IEventService _eventService;

        public EventsController(ICommandDispatcher commandDispatcher, IEventService eventService) : base(commandDispatcher)
        {
            _eventService = eventService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var @event = await _eventService.GetAsync(id);
            if (@event == null)
            {
                return NotFound();
            }
            return Ok(@event);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var events = await _eventService.GetAllAsync();
            if (!events.Any())
            {
                return NotFound();
            }
            return Ok(events);
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteEvent(id);
            await SendAsync(command);
            return NoContent();
        }

        [Authorize]
        [HttpPost("create")]
        public async Task<IActionResult> Post([FromBody] CreateEvent command)
        {
            await SendAsync(command);
            return Created($"events/{command.Id}", null);
        }

        [Authorize]
        [HttpPost("join")]
        public async Task<IActionResult> Post([FromBody] JoinEvent command)
        {
            await SendAsync(command);
            return NoContent();
        }
    }
}