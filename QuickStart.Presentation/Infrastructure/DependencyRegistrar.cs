using Autofac;
using Autofac.Integration.Mvc;

namespace QuickStart.Presentation.Infrastructure
{
    public class DependencyRegistrar
    {
        public static void RegisterDependencies(ContainerBuilder builder)
        {
            // Register the types here
            // DbContexts
            
            // Repositories
            builder.RegisterAssemblyTypes()
                .Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces()
                .InstancePerRequest();

            // Services
            builder.RegisterAssemblyTypes()
                .Where(t => t.Name.EndsWith("Service"))
                .AsImplementedInterfaces()
                .InstancePerRequest();

            // Controllers
            builder.RegisterControllers(typeof(MvcApplication).Assembly)
                .InstancePerRequest();

            // Modules / providers
            builder.RegisterAssemblyModules(typeof(MvcApplication).Assembly);

            // HTTP request lifetime scoped registrations for the HTTP abstraction classes
            builder.RegisterModule<AutofacWebTypesModule>();
        }
    }
}