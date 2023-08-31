using Autofac;
using BackendApiTest.Api.PresentationExtensions;
using BackendApiTest.DataLayer.Context;
using BackendApiTest.IOC.Dependencies;

namespace BackendApiTest.Api.Modules
{
    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<HttpContextAccessor>().As<IHttpContextAccessor>();
            builder.RegisterContext<BackendApiTestDbContext>(ConnectionStringNames.Core);
            
            DependencyContainer.RegisterService(builder);
        }
    }
}

