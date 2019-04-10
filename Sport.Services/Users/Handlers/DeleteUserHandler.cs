using System;
using System.Threading.Tasks;
using Sport.Services.Dto;
using Sport.Services.Interfaces;
using Sport.Services.Users.Commands;

namespace Sport.Services.Users.Handlers
{
    public class DeleteUserHandler : ICommandHandler<DeleteUser>
    {
        private readonly IUserService _userService;

        public DeleteUserHandler(IUserService userService)
        {
            _userService = userService;
        }
        public async Task HandleAsync(DeleteUser command)
        {
            if (command.UserToDelete != command.UserId)
            {
                var requestOwner = await _userService.GetAsync(command.UserId);
                if (requestOwner.Role != RoleDto.Admin)
                {
                    throw new Exception("Operation forbidden.");
                }
            }
            await _userService.RemoveAsync(command.UserId);
        }
    }
}