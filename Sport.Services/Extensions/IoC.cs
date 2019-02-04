using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Sport.Infrastructure.Extensions;
using Sport.Services.Interfaces;
using Sport.Services.Mapping;

namespace Sport.Services.Extensions
{
    public static class IoC
    {
        public static IServiceCollection AddServicesDependencies(this IServiceCollection services)
        {
            services.AddInfrastructureDependencies();
            services.AddScoped<IUserService, UserService>();
            services.AddSingleton(AutoMapperConfiguration.Initialize());

            return services;
        }
    }
}
