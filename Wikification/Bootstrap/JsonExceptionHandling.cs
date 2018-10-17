using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Threading.Tasks;
using Wikification.Business.Exceptions;

namespace Wikification.Bootstrap
{
    /// <summary>
    /// https://stackoverflow.com/questions/38630076/asp-net-core-web-api-exception-handling/38935583
    /// </summary>
    public class JsonExceptionHandling
    {
        private readonly RequestDelegate _next;

        public JsonExceptionHandling(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var code = HttpStatusCode.InternalServerError;

            var result = JsonConvert.SerializeObject(new
            {
                message = exception.Message
            });
            if (exception is SystemExistsException) {
                code = HttpStatusCode.Forbidden;
                var ex = (SystemExistsException)exception;
                result = JsonConvert.SerializeObject(
                    new
                    {
                        error = ex.Message,
                        externalId = ex.ExternalId
                    });
            }
            else if (exception is SystemNotFoundException) {
                code = HttpStatusCode.BadRequest;
                var ex = (SystemNotFoundException)exception;
                result = JsonConvert.SerializeObject(
                    new
                    {
                        error = ex.Message,
                        externalId = ex.ExternalId
                    });
            }
            else if (exception is EntityNotFoundException) {
                code = HttpStatusCode.BadRequest;
                var ex = (EntityNotFoundException)exception;
                result = JsonConvert.SerializeObject(
                    new
                    {
                        error = exception.Message,
                        paramName = ex.ParamName
                    });
            }

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;

            return context.Response.WriteAsync(result);
        }
    }
}
