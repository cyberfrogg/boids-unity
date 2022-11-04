using System;

namespace Services.Logger
{
    public interface ILogger
    {
        void Log(string message);
        void Warn(string message);
        void Error(string message);
        void Exception(Exception exception);
    }
}