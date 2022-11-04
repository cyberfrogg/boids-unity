using System;
using UnityEngine;

namespace Services.Logger.Impl
{
    public class ConsoleLogger : ILogger
    {
        public void Log(string message)
        {
            Debug.Log(message);
        }

        public void Warn(string message)
        {
            Debug.LogWarning(message);
        }

        public void Error(string message)
        {
            Debug.LogError(message);
        }

        public void Exception(Exception exception)
        {
            Debug.LogError($"{exception.GetType().Name}: {exception.Message} \n {exception.StackTrace}");
        }
    }
}