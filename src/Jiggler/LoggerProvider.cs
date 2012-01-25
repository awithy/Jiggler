using System;

namespace Jiggler
{
    public static class LoggerProvider
    {
        public static bool LoggingDisabled { get; private set; }

        static LoggerProvider()
        {
            LoggingDisabled = true;
        }

        public static ILogger GetLogger(Type type)
        {
            return new Logger(type);
        }

        public static void EnableLogging()
        {
            LoggingDisabled = false;
        }

        public static ILoggingTestToken ForTest()
        {
            return new LoggingTestToken();
        }

        private class LoggingTestToken : ILoggingTestToken
        {
            private readonly bool _originalValue;
            public LoggingTestToken()
            {
                _originalValue = LoggingDisabled;
                LoggingDisabled = true;
            }
            public void Dispose()
            {
                LoggingDisabled = _originalValue;
            }
        }
    }

    public interface ILoggingTestToken : IDisposable
    {
    }
}