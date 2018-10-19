using Wikification.Data.Interfaces;

namespace Wikification.Data.Datastructure
{
    public class LogPost : IEntity
    {
        public string ExceptionType { get; set; }
        public int Id { get; set; }
        public LogSeverity Level { get; set; }
        public string Message { get; set; }
        public string Sender { get; set; }
        public string StackTrace { get; set; }
    }
    public enum LogSeverity
    {
        Info,
        Warning,
        Error,
        Fatal
    }
}
