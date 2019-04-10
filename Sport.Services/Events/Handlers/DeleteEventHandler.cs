using System;
using System.Linq;
using System.Threading.Tasks;
using Sport.Services.Dto;
using Sport.Services.Events.Commands;
using Sport.Services.Interfaces;

namespace Sport.Services.Events.Handlers
{
    public class DeleteEventHandler : ICommandHandler<DeleteEvent>
    {
        private readonly IEventService _eventService;
        private readonly IUserService _userService;

        public DeleteEventHandler(IEventService eventService, IUserService userService)
        {
            _eventService = eventService;
            _userService = userService;
        }
        public async Task HandleAsync(DeleteEvent command)
        {
            var requestOwner = await _userService.GetAsync(command.UserId);
            if (requestOwner.Role != RoleDto.Admin)
            {
                var @event = await _eventService.GetAsync(command.EventToDelete);
                if (!requestOwner.MyEvents.Contains(@event))
                {
                    throw new Exception("Operation forbidden.");
                }
            }

            await _eventService.RemoveAsync(command.EventToDelete);
        }
    }
}