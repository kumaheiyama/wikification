using System;

namespace Wikification.Data.Interfaces
{
    public interface ILogifier
    {
        void LogError(string message, Exception exception = null);
        void LogInfo(string message);
        void LogWarning(string message);
    }
}
