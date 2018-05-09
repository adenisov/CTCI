using System.Runtime.CompilerServices;
using System.Collections.Generic;
using ArraysAndStrings;
using Autofac;
using Core;
using LinkedLists;

[assembly: InternalsVisibleTo("Tests")]

namespace Runner
{
    internal static class Program
    {
        private const string GenericOutput = "output";

        private static readonly IContainer _kernel;

        public static void Main(string[] args)
        {
            using (var scope = _kernel.BeginLifetimeScope())
            {
                var output = scope.ResolveNamed<IOutput>(GenericOutput);

                var tasks = scope.Resolve<IEnumerable<ITask>>();
                var currentCount = 1;
                foreach (var task in tasks)
                {
                    var count = currentCount;
                    output.WriteLine(() => $"{count} -> {task.GetType().Name}:");

                    task.Run(output);

                    // Two new lines for separation
                    output.WriteNewLine();
                    output.WriteNewLine();

                    ++currentCount;
                }
            }

            _kernel?.Dispose();
        }

        static Program()
        {
            var builder = new ContainerBuilder();
            {
                // Register Core
                {
                    const string key = "output.Implementor";

                    builder.RegisterType<ConsoleOutput>()
                        .InstancePerLifetimeScope()
                        .Named<IOutput>(key);

                    builder.RegisterType<LogOutput>()
                        .InstancePerLifetimeScope()
                        .Named<IOutput>(key);

                    builder.Register(context => new OutputFacadeDecorator(context.ResolveNamed<IEnumerable<IOutput>>(key)))
                        .Named<IOutput>(GenericOutput)
                        .InstancePerLifetimeScope();
                }

                builder.RegisterModule<ArraysAndStringsModule>();
                builder.RegisterModule<LinkedListsModule>();
            }

            _kernel = builder.Build();
        }
    }
}