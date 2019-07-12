using Autofac;
using System;
using System.Collections.Generic;
using System.Text;

namespace NotatnikMechanika.Repository
{
    public class RepositoryModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
            builder.RegisterAssemblyTypes(typeof(RepositoryModule).Assembly).AsImplementedInterfaces();
        }
    }
}
