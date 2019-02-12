using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Sport.Infrastructure.Extensions;
using Sport.Services.Interfaces;
using Sport.Services.Mapping;
using Sport.Services.Users;
using Sport.Services.Users.Commands;
using Sport.Services.Users.Handlers;

namespace Sport.Services.Extensions
{
    public static class IoC
    {
        public static IServiceCollection AddServicesDependencies(this IServiceCollection services)
        {
            services.AddInfrastructureDependencies();
            services.AddScoped<IUserService, UserService>();
            services.AddSingleton(AutoMapperConfiguration.Initialize());
            services.AddSingleton<ICommandDispatcher, CommandDispatcher>();
            services.AddTransient<ICommandHandler<CreateUser>, CreateUserHandler>();
            return services;
        }
    }
}
