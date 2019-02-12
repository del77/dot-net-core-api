using Autofac;
using Sport.Infrastructure.Repositories;

namespace Sport.Infrastructure.IoC
{
    public class InfrastructureModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(InfrastructureModule).Assembly).AsImplementedInterfaces();
            builder.RegisterType<DatabaseContext>().InstancePerLifetimeScope();
        }
    }
}