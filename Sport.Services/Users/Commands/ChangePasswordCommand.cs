using System;
using Sport.Services.Interfaces;

namespace Sport.Services.Users.Commands
{
    public class ChangePasswordCommand : AuthenticatedCommand
    {
        public string Password { get; set; }
        public string NewPassword { get; set; }
    }
}