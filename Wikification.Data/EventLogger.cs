using Wikification.Data.Datastructure;
using Wikification.Data.Interfaces;

namespace Wikification.Data
{
    public class EventLogger : IEventLogger
    {
        private readonly MainContext _context;

        public EventLogger(MainContext context)
        {
            _context = context;
        }

        public void LogEvent(string message, Event ev)
        {
            LogEventAsync(message, ev);
        }

        async void LogEventAsync(string message, Event ev)
        {
            _context.Events.Add(ev);
            await _context.SaveChangesAsync();
        }
    }
}
