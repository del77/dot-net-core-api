using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Sport.Services.Dto;
using Sport.Services.Interfaces;
using Sport.Services.Users.Commands;

namespace Sport.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AccountController : ApiControllerBase
    {
        private readonly IMemoryCache _cache;

        public AccountController(ICommandDispatcher commandDispatcher, IMemoryCache _cache) : base(commandDispatcher)
        {
            this._cache = _cache;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] Login command)
        {
            await SendAsync(command);
            var token = _cache.Get<JwtDto>(command.Username);
            return Ok(token);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] CreateUser command)
        {
            await SendAsync(command);
            return Created($"users/{command.Id}", null);
        }
    }
}