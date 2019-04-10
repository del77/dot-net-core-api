using System;

namespace Sport.Core.Domain
{
    public class UserEvent
    {
        public Guid UserId { get; set; }
        public virtual User User { get; set; }

        public Guid EventId { get; set; }
        public virtual Event Event { get; set; }
    }
}