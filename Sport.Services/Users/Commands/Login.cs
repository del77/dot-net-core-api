using System;
using Sport.Services.Interfaces;

namespace Sport.Services.Users.Commands
{
    public class Login : ICommand
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}