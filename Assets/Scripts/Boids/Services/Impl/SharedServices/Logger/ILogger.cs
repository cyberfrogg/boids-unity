using System;

namespace Boids.Services.Impl.SharedServices.Logger
{
    public interface ILogger : IService
    {
        void Log(string message);
        void Warn(string message);
        void Error(string message);
        void Exception(Exception exception);
    }
}