using Autofac;
using BackendApiTest.Core.Services.Interfaces;

namespace BackendApiTest.IOC.Dependencies
{
    public class DependencyContainer
    {
        public static void RegisterService(ContainerBuilder builder)
        {
            string assemblyName = typeof(DependencyContainer).FullName!.Split('.')[0];
            string assemblyName2 = typeof(IPersonService).FullName!.Split('.')[0];
            bool equal = string.Equals(assemblyName, assemblyName2);
            var allAssemblies = AppDomain.CurrentDomain.GetAssemblies().ToList();
            var ourProjectAssemblies = allAssemblies
              .Where(x => x.FullName!.StartsWith(assemblyName));

            builder.RegisterAssemblyTypes(ourProjectAssemblies.ToArray())
               .Where(t => (t.IsClass || t.IsInterface) && t.FullName.EndsWith("Service"))
               .AsImplementedInterfaces()
               .InstancePerLifetimeScope();


            builder.RegisterAssemblyTypes(ourProjectAssemblies.ToArray())
               .Where(t => (t.IsClass || t.IsInterface) && t.FullName.EndsWith("Repository"))
               .AsImplementedInterfaces()
               .InstancePerLifetimeScope();
        }
    }
}
