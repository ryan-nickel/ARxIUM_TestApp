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
        private ActionBlock<string> writerActionBlock;

        // Static constructor and private constructor for singleton pattern
        static BasicLogger()
        {

        }

        private BasicLogger()
        {

        }

        public static BasicLogger Instance { get { return instance; } }

        public string DateTimeFormat { get; set; } = DateTimeFormatDefault;

        
        public void Open(string fileName, bool append)
        {
            // If trying to re-open close first
            if (writer != null)
            {
                Close();
            }

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
                writerActionBlock = new ActionBlock<string>(s => writer.WriteLineAsync(s));
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
            writer = null;
        }

        public void Dispose()
        {
            Close();
        }

        public void WriteLine(string value, DateTime? timestamp = null)
        {
            if (writer == null)
            {
                throw new BasicLoggerException("Log not open");
            }

            timestamp ??= DateTime.Now;
            if (!writerActionBlock.Post($"{timestamp?.ToString(DateTimeFormat)} - {value}"))
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
