using System;

namespace Core
{
    public sealed class ConsoleOutput : IOutput
    {
        public void Write<T>(Func<T> output) => Console.Write(output());

        public void WriteLine<T>(Func<T> output) => Console.WriteLine(output());

        public void WriteTab() => Console.Write("\t");

        public void WriteNewLine() => Console.WriteLine();
    }
}