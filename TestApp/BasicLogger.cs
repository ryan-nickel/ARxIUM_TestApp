using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace TestApp
{
    public sealed class BasicLogger : IDisposable
    {
        // Default format uses '/' to force / character to be used instead of system date separater character
        public const string DateTimeFormatDefault = "MM'/'dd'/'yy HH:mm:ss";

        private static readonly BasicLogger instance = new BasicLogger();

        private StreamWriter writer = null;
        private ActionBlock<(string, DateTime?)> writerActionBlock;

        public string DateTimeFormat { get; set; } = DateTimeFormatDefault;

        public static BasicLogger Instance { get { return instance; } }

        // Static constructor and private constructor for singleton pattern
        static BasicLogger()
        {

        }

        private BasicLogger()
        {

        }

        public void Open(string fileName, bool append)
        {
            if (string.IsNullOrEmpty(fileName))
            {
                throw new BasicLoggerException($"{nameof(fileName)} is null or empty");
            }

            try
            {
                // Streamwriter default newline is \r\n so no modification needed
                // Autoflush so the stream is continually written
                writer = new StreamWriter(fileName, append)
                {
                    AutoFlush = true
                };

                // Assign the action to take when a new log message is queued
                writerActionBlock = new ActionBlock<(string text, DateTime? datetime)>(s => WriteLineAsync(s.text, s.datetime));
            }
            catch (Exception ex) when (ex is UnauthorizedAccessException || ex is ArgumentException || ex is DirectoryNotFoundException || ex is PathTooLongException || ex is IOException || ex is System.Security.SecurityException)
            {
                throw new BasicLoggerException("Could not open log file for writing", ex);
            }
        }

        public void Close()
        {
            // Wait for writer action block to complete any pending writes
            writerActionBlock.Complete();
            writerActionBlock.Completion.Wait();

            // Flush and close the writer
            writer.Flush();
            writer.Close();
        }

        public void Dispose()
        {
            Close();
        }

        private async Task WriteLineAsync(string value, DateTime? timestamp = null)
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

            if (!writerActionBlock.Post((value, timestamp)))
            {
                throw new BasicLoggerException("Could not post log message");
            }
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
