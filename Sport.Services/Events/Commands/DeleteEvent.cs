using System;
using Sport.Services.Interfaces;

namespace Sport.Services.Events.Commands
{
    public class DeleteEvent : AuthenticatedCommand
    {
        public DeleteEvent(Guid eventToDelete)
        {
            EventToDelete = eventToDelete;
        }
        public Guid EventToDelete { get; set; }
    }
}