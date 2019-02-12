using System;

namespace Sport.Services.Interfaces
{
    public interface IAuthenticatedCommand : ICommand
    {
        Guid UserId { get; set; }
    }
}