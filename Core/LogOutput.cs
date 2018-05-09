using System;
using System.Text;
using JetBrains.Annotations;
using NLog;

namespace Core
{
    [UsedImplicitly]
    public sealed class LogOutput : IOutput
    {
        private static readonly ILogger _log = LogManager.GetCurrentClassLogger();

        private readonly StringBuilder _buffer = new StringBuilder();

        public void Write<T>(Func<T> output)
        {
            _buffer.Append(output());
        }

        public void WriteLine<T>(Func<T> output)
        {
            WriteBufferToOutput();

            _log.Info(output());
        }

        public void WriteTab()
        {
            _buffer.Append("\t");
        }

        public void WriteNewLine()
        {
            WriteBufferToOutput();

            _log.Info(Environment.NewLine);
        }

        private void WriteBufferToOutput()
        {
            _log.Info(_buffer.ToString());
            _buffer.Clear();
        }
    }
}