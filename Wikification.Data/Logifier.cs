using Microsoft.EntityFrameworkCore;
using System;
using System.Data.SqlClient;
using Wikification.Data.Interfaces;
using static Wikification.Data.Datastructure.LogPost;

namespace Wikification.Data
{
    public class Logifier : ILogifier
    {
        private readonly MainContext _context;

        public Logifier(MainContext context)
        {
            _context = context;
        }

        public void LogError(string message, Exception exception = null)
        {
            LogErrorAsync(message, exception);
        }

        public void LogInfo(string message)
        {
            throw new NotImplementedException();
        }

        public void LogWarning(string message)
        {
            throw new NotImplementedException();
        }

        async void LogErrorAsync(string message, Exception exception = null)
        {
            var exceptionType = new SqlParameter("@exceptionType", exception != null ? nameof(exception) : string.Empty);
            var msg = new SqlParameter("@message", message);
            var sender = new SqlParameter("@sender", string.Empty);
            var severity = new SqlParameter("@severity", Severity.Error);
            var stackTrace = new SqlParameter("@stackTrace", exception != null && exception.StackTrace != null ? exception.StackTrace : string.Empty);

            await _context.Database.ExecuteSqlCommandAsync(
                "INSERT INTO [system].[Log] (ExceptionType, Message, StackTrace, Level, Sender) " +
                $"VALUES (@exceptionType, @message, @stackTrace, @severity, @sender);"
                , exceptionType, msg, stackTrace, severity, sender);
        }
    }
}
