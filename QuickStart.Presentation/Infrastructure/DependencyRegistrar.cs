using Autofac;
using Autofac.Integration.Mvc;
using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace QuickStart.Presentation.Infrastructure
{
    public class DependencyRegistrar
    {
        public static void RegisterDependencies(ContainerBuilder builder)
        {
            var path = AppDomain.CurrentDomain.RelativeSearchPath;
            var assemblies = Directory.GetFiles(path, "QuickStart.*.dll")
                .Select(Assembly.LoadFrom)
                .ToArray();

            // DbContexts
            builder.RegisterAssemblyTypes(assemblies)
                .Where(t => t.Name.EndsWith("DbContext"))
                .InstancePerRequest();

            // Repositories
            builder.RegisterAssemblyTypes(assemblies)
                .Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces()
                .InstancePerRequest();

            // Services
            builder.RegisterAssemblyTypes(assemblies)
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