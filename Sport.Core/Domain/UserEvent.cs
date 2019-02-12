using System;

namespace Sport.Core.Domain
{
    public class UserEvent
    {
        public Guid UserId { get; set; }
        public User User { get; set; }

        public Guid EventId { get; set; }
        public Event Event { get; set; }
    }
}