using API.Middleware.Core.Logger;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace API.Uses.Cases.Middleware
{
    public class EjemploMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly LoggerCustom customLogger;
        private readonly ILogger _logger;

        public EjemploMiddleware(RequestDelegate next, ILoggerFactory loggerFactory)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            DateTime dateTime = DateTime.Now.AddHours(-3);
            _logger.LogInformation("Coneccion");
            await _next(context);
        }
    }
}
