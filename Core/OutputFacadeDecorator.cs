using System;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace Core
{
    public sealed class OutputFacadeDecorator : IOutput
    {
        private readonly IReadOnlyCollection<IOutput> _outputs;

        public OutputFacadeDecorator(IEnumerable<IOutput> outputs)
        {
            if (outputs == null)
            {
                throw new ArgumentNullException(nameof(outputs));
            }

            _outputs = outputs.ToImmutableArray();
        }

        public void Write<T>(Func<T> output) => ForEach(_outputs, o => o.Write(output));

        public void WriteLine<T>(Func<T> output) => ForEach(_outputs, o => o.WriteLine(output));

        public void WriteTab() => ForEach(_outputs, o => o.WriteTab());

        public void WriteNewLine() => ForEach(_outputs, o => o.WriteNewLine());

        private static void ForEach<T>(IEnumerable<T> collection, Action<T> action)
        {
            foreach (var item in collection)
            {
                action(item);
            }
        }
    }
}