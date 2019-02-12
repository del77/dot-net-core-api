using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sport.Services.Interfaces;

namespace Sport.Api.Controllers
{
    [Route("[controller]")]
    public abstract class ApiControllerBase : ControllerBase
    {
        private readonly ICommandDispatcher _commandDispatcher;

        protected ApiControllerBase(ICommandDispatcher commandDispatcher)
        {
            _commandDispatcher = commandDispatcher;
        }

        protected async Task SendAsync<T>(T command) where T : ICommand
        {
            if (command is IAuthenticatedCommand authenticatedCommand)
            {
                if (User?.Identity?.IsAuthenticated == true)
                {
                    authenticatedCommand.UserId = Guid.Parse(User.Identity.Name);
                }
            }
            await _commandDispatcher.SendAsync(command);
        }
    }
}