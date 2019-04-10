using System.Threading.Tasks;
using Sport.Services.Interfaces;
using Sport.Services.Users.Commands;

namespace Sport.Services.Users.Handlers
{
    public class ChangePasswordHandler : ICommandHandler<ChangePassword>
    {
        private readonly IUserService _userService;

        public ChangePasswordHandler(IUserService userService)
        {
            _userService = userService;
        }
        public async Task HandleAsync(ChangePassword command)
        {
            await _userService.ChangePasswordAsync(command.UserId, command.Password, command.NewPassword);
        }
    }
}