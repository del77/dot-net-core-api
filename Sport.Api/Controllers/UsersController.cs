using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sport.Services.Dto;
using Sport.Services.Interfaces;

namespace Sport.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var users = await _userService.GetAllAsync();
            if (users == null)
            {
                return NotFound();
            }
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var user = await _userService.GetAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }
    }
}