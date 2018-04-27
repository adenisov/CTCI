using System;

namespace Core
{
    public interface IOutput
    {
        void Write<T>(Func<T> output);

        void WriteLine<T>(Func<T> output);

        void WriteTab();

        void WriteNewLine();
    }
}