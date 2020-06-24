using Autofac;

namespace NotatnikMechanika.Service
{
    public class ServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
            builder.RegisterAssemblyTypes(typeof(ServiceModule).Assembly).AsImplementedInterfaces();
        }
    }
}
