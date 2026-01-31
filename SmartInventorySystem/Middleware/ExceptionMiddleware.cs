using SmartInventorySystem.Exceptions;
using System.Net;
    using System.Text.Json;

    namespace SmartInventorySystem.Middleware
    {
        public class ExceptionMiddleware
        {
            private readonly RequestDelegate _next;
            private readonly ILogger<ExceptionMiddleware> _logger;

            public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
            {
                _next = next;
                _logger = logger;
            }

            public async Task InvokeAsync(HttpContext context)
            {
                try
                {
                    await _next(context);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, ex.Message);
                    await HandleExceptionAsync(context, ex);
                }
            }

            private static Task HandleExceptionAsync(HttpContext context, Exception exception)
            {
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = exception switch
                {
                NotFoundException => (int)HttpStatusCode.NotFound,
                BadRequestException => (int)HttpStatusCode.BadRequest,
                _ => (int)HttpStatusCode.InternalServerError
                };

            var response = new
                {
                    statusCode = context.Response.StatusCode,
                    message = "An unexpected error occurred",
                    detailed = exception.Message
                };

                return context.Response.WriteAsync(JsonSerializer.Serialize(response));
            }
        }
    }

