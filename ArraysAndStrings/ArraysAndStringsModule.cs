using Autofac;
using Core;

namespace ArraysAndStrings
{
    public sealed class ArraysAndStringsModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(ThisAssembly).As<ITask>()
                .InstancePerLifetimeScope();
        }
    }
}