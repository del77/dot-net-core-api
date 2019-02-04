using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Sport.Core.Domain;
using Sport.Core.Repositories;
using Sport.Infrastructure.Repositories;

namespace Sport.Infrastructure.Extensions
{
    public static class IoC
    {
        public static IServiceCollection AddInfrastructureDependencies(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, MemoryUserRepository>();
            services.AddSingleton<IPasswordHasher<User>, PasswordHasher<User>>();
            
            return services;
        }
    }
}
