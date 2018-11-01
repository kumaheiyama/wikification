using System;
using Wikification.Data.Datastructure;

namespace Wikification.Data.Interfaces
{
    public interface IEventLogger
    {
        void LogEvent(string message, Event logEvent);
    }
}
