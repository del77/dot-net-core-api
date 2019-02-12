using System;
using System.Threading.Tasks;
using Sport.Services.Interfaces;
using Sport.Services.Users.Commands;

namespace Sport.Services.Users.Handlers
{
    public class CreateUserHandler : ICommandHandler<CreateUser>
    {
        private readonly IUserService _userService;

        public CreateUserHandler(IUserService userService)
        {
            _userService = userService;
        }
        public async Task HandleAsync(CreateUser command)
        {
            command.Id = Guid.NewGuid();
            await _userService.RegisterAsync(command.Id, command.Username, command.Email, command.FirstName,
                command.LastName, command.Password);
        }
    }
}