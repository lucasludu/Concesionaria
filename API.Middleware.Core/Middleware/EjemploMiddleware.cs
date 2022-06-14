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

        public EjemploMiddleware(RequestDelegate next, ILoggerFactory logger)
        {
            _next = next;
            _logger = logger.CreateLogger<LoggerCustom>();
            customLogger = new LoggerCustom(_logger);
        }

        public async Task InvokeAsync(HttpContext context)
        {
            customLogger.Info("Ingreso al Middleware");
            await _next(context);
        }
    }
}
