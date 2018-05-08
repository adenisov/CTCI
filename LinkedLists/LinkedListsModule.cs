using Autofac;
using Core;

namespace LinkedLists
{
    public sealed class LinkedListsModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(ThisAssembly).As<ITask>()
                .InstancePerLifetimeScope();
        }
    }
}