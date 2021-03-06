﻿using System;
using System.Threading.Tasks;
using Autofac;

namespace Sport.Services.Interfaces
{
    public class CommandDispatcher : ICommandDispatcher
    {
        private readonly IComponentContext _componentContext;

        public CommandDispatcher(IComponentContext componentContext)
        {
            _componentContext = componentContext;
        }

        public async Task SendAsync<T>(T command) where T : ICommand
        {
            if (command == null)
            {
                throw new ArgumentNullException(nameof(command),
                    "Command can not be null.");
            }

            var handler = _componentContext.Resolve<ICommandHandler<T>>();

            await handler.HandleAsync(command);
        }
    }
}