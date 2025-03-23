using System.Text;

namespace Template.API.Core
{
    public class LoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<LoggingMiddleware> _logger;

        public LoggingMiddleware(RequestDelegate next, ILogger<LoggingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            string requestBody = string.Empty;

            // Only read the body if the method supports it (e.g., POST, PUT, PATCH)
            if (context.Request.Method == HttpMethods.Post ||
                context.Request.Method == HttpMethods.Put ||
                context.Request.Method == HttpMethods.Patch)
            {
                context.Request.EnableBuffering();

                using (var reader = new StreamReader(context.Request.Body, Encoding.UTF8, leaveOpen: true))
                {
                    requestBody = await reader.ReadToEndAsync();
                }

                // Reset the request body stream position so the next middleware can read it
                context.Request.Body.Position = 0;
            }

            _logger.LogInformation($"Request: \nMethod: {context.Request.Method} \nPath: {context.Request.Path} \nBody: {requestBody}");
            await _next(context);
            _logger.LogInformation("Response {StatusCode}", context.Response.StatusCode);
        }
    }
}
