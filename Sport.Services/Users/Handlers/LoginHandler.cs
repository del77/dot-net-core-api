using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.IdentityModel.Tokens;
using Sport.Services.Interfaces;
using Sport.Services.Users.Commands;

namespace Sport.Services.Users.Handlers
{
    public class LoginHandler : ICommandHandler<Login>
    {
        private readonly IUserService _userService;
        private readonly IJwtService _jwtService;
        private readonly IMemoryCache _cache;

        public LoginHandler(IUserService userService, IJwtService jwtService, IMemoryCache cache)
        {
            _userService = userService;
            _jwtService = jwtService;
            _cache = cache;
        }
        public async Task HandleAsync(Login command)
        {
            await _userService.LoginAsync(command.Username, command.Password);
            var user = await _userService.GetAsync(command.Username);
            var jwt = _jwtService.CreateToken(user.Id, user.Role);
            _cache.Set(command.Username, jwt, TimeSpan.FromSeconds(5));
        }
    }
}