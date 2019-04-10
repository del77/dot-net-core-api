using System;
using Sport.Services.Interfaces;

namespace Sport.Services.Events.Commands
{
    public class JoinEvent : AuthenticatedCommand
    {
        public Guid EventId { get; set; }
    }
}