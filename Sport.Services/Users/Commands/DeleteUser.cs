using System;
using Sport.Services.Interfaces;

namespace Sport.Services.Users.Commands
{
    public class DeleteUser : AuthenticatedCommand
    {
        public DeleteUser(Guid userToDelete)
        {
            UserToDelete = userToDelete;
        }
        public Guid UserToDelete { get; set; }
    }
}