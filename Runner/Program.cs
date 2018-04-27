using System.Collections.Generic;
using ArraysAndStrings;
using Autofac;
using Core;

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
                foreach (var task in tasks)
                {
                    task.Run(ConsoleOutput.Instance);
                }
            }

            _kernel?.Dispose();
        }

        static Program()
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule<ArraysAndStringsModule>();

            _kernel = builder.Build();
        }
    }
}