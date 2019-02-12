using System;

namespace Sport.Services.Interfaces
{
    public abstract class AuthenticatedCommand : IAuthenticatedCommand
    {
        public Guid UserId { get; set; }
    }
}