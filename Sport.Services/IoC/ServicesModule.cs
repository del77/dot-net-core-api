using Autofac;
using Microsoft.AspNetCore.Identity;
using Sport.Core.Domain;
using Sport.Infrastructure.IoC;
using Sport.Services.Mapping;

namespace Sport.Services.IoC
{
    public class ServicesModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule<InfrastructureModule>();
            builder.RegisterAssemblyTypes(typeof(ServicesModule).Assembly).AsImplementedInterfaces();
            builder.RegisterInstance(AutoMapperConfiguration.Initialize()).SingleInstance();
            builder.RegisterType<PasswordHasher<User>>().As<IPasswordHasher<User>>().SingleInstance();
        }
    }
}