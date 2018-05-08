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
        private static readonly IContainer _kernel;

        public static void Main(string[] args)
        {
            using (var scope = _kernel.BeginLifetimeScope())
            {
                var tasks = scope.Resolve<IEnumerable<ITask>>();
                var currentCount = 0;
                foreach (var task in tasks)
                {
                    ConsoleOutput.Instance.WriteLine(() => $"{++currentCount} -> {task.GetType().Name}:");

                    task.Run(ConsoleOutput.Instance);

                    // Two new lines for separation
                    ConsoleOutput.Instance.WriteNewLine();
                    ConsoleOutput.Instance.WriteNewLine();
                }
            }

            _kernel?.Dispose();
        }

        static Program()
        {
            var builder = new ContainerBuilder();
            {
                builder.RegisterModule<ArraysAndStringsModule>();
                builder.RegisterModule<LinkedListsModule>();
            }

            _kernel = builder.Build();
        }
    }
}