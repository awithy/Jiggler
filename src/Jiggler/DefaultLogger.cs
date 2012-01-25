using System;
using System.IO;

namespace Jiggler
{
    public interface ILogger
    {
        void Info(string message);
        void Debug(string message);
        void Error(string message, Exception ex);
    }

    public class Logger : ILogger
    {
        private string _name;

        public Logger(Type type)
        {
            _name = type.FullName;
        }

        public void Info(string message)
        {
            var logLevel = "INFO";
            _FormatAndOutputMessage(logLevel, message);
        }

        public void Debug(string message)
        {
            var logLevel = "DEBUG";
            _FormatAndOutputMessage(logLevel, message);
        }

        public void Error(string message, Exception ex)
        {
            var logLevel = "ERROR";
            var formattedErrorMessage = _FormatErrorMessage(message, ex);
            _FormatAndOutputMessage(logLevel, formattedErrorMessage);
        }

        private static string _FormatErrorMessage(string message, Exception ex)
        {
            return message + "  Detail: " + ex;
        }

        private void _FormatAndOutputMessage(string logLevel, string message)
        {
            var line = _FormatMessage(logLevel, message);
            _OutputLine(line);
        }

        private string _FormatMessage(string logLevel, string message)
        {
            var formattedDateTime = DateTime.Now.ToString("yyyyMMdd HH:mm:ss");
            var line = string.Format("[{0}][{1}][{2}] {3}", formattedDateTime, logLevel, _name, message);
            return line;
        }

        private void _OutputLine(string line)
        {
            if (LoggerProvider.LoggingDisabled)
                return;

            Console.WriteLine(line);
            _BestEffortLogToFile(line);
        }

        private void _BestEffortLogToFile(string message)
        {
            try
            {
                _LogToFileUnsafe(message);
            }
            catch (Exception ex)
            {
                var exceptionMessage = _FormatMessage("DEBUG", ex.GetType().Name + " thrown while attempting to log to text file.");
                Console.WriteLine(exceptionMessage);
            }
        }

        private static void _LogToFileUnsafe(string message)
        {
            using (var streamWriter = new StreamWriter("Jigger.log", true))
            {
                streamWriter.WriteLine(message);
            }
        }
    }
}