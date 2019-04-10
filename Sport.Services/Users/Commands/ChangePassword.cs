using System;
using Sport.Services.Interfaces;

namespace Sport.Services.Users.Commands
{
    public class ChangePassword : AuthenticatedCommand
    {
        public string Password { get; set; }
        public string NewPassword { get; set; }
    }
}