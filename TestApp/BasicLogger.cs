using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp
{
    class BasicLogger : IDisposable
    {
        // Default format uses '/' to force / character to be used instead of system date separater character
        public const string dateTimeFormatDefault = "MM'/'dd'/'yy HH:mm:ss";
        private StreamWriter writer = null;

        public string DateTimeFormat { get; set; } = dateTimeFormatDefault;

        public void Open(string fileName, bool append)
        {
            if (string.IsNullOrEmpty(fileName))
            {
                throw new BasicLoggerException($"{nameof(fileName)} is null or empty");
            }

            try
            {
                // Streamwriter default newline is \r\n so no modification needed
                writer = new StreamWriter(fileName, append)
                {
                    AutoFlush = true
                };
            }
            catch (Exception ex) when (ex is UnauthorizedAccessException || ex is ArgumentException || ex is DirectoryNotFoundException || ex is PathTooLongException || ex is IOException || ex is System.Security.SecurityException )
            {
                throw new BasicLoggerException("Could not open log file for writing", ex);
            }
        }

        public void Close()
        {
            writer.Flush();
            writer.Close();
        }

        public void Dispose()
        {
            Close();
        }

        public async Task WriteLineAsync(string value, DateTime? timestamp = null)
        {
            if (writer == null)
            {
                throw new BasicLoggerException("Log not open");
            }

            timestamp ??= DateTime.Now;
            await writer.WriteLineAsync($"{timestamp?.ToString(DateTimeFormat)} - {value}");
        }

        public void WriteLine(string value, DateTime? timestamp = null)
        {
            if (writer == null)
            {
                throw new BasicLoggerException("Log not open");
            }

            timestamp ??= DateTime.Now;
            writer.WriteLine($"{timestamp?.ToString(DateTimeFormat)} - {value}");
        }

        [Serializable]
        public class BasicLoggerException : Exception
        {
            public BasicLoggerException() { }
            public BasicLoggerException(string message) : base(message) { }
            public BasicLoggerException(string message, Exception inner) : base(message, inner) { }
            protected BasicLoggerException(
              System.Runtime.Serialization.SerializationInfo info,
              System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
        }

    }
}
