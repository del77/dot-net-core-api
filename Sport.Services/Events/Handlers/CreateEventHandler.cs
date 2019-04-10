using System;
using System.Threading.Tasks;
using Sport.Core.Domain;
using Sport.Services.Events.Commands;
using Sport.Services.Interfaces;

namespace Sport.Services.Events.Handlers
{
    public class CreateEventHandler : ICommandHandler<CreateEvent>
    {
        private readonly IEventService _eventService;

        public CreateEventHandler(IEventService eventService)
        {
            _eventService = eventService;
        }
        public async Task HandleAsync(CreateEvent command)
        {
            command.Id = Guid.NewGuid();
            await _eventService.AddAsync(command.Id, command.UserId, (Discipline)command.Discipline,
                command.Description, command.Slots, command.Price, command.Date, command.ApproximateDuration,
                command.Place);
        }
    }
}