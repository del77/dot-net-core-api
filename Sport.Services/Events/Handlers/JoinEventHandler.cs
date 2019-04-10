using System.Threading.Tasks;
using Sport.Services.Events.Commands;
using Sport.Services.Interfaces;

namespace Sport.Services.Events.Handlers
{
    public class JoinEventHandler : ICommandHandler<JoinEvent>
    {
        private readonly IEventService _eventService;

        public JoinEventHandler(IEventService eventService)
        {
            _eventService = eventService;
        }
        public async Task HandleAsync(JoinEvent command)
        {
            await _eventService.JoinEventAsync(command.EventId, command.UserId);
        }
    }
}