using NotesBase;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Reflection.Metadata;
using System.Text.Json;

namespace NotesWebApi.Middleware
{
    public class MiddlewareExceptionHandler
    {
        private readonly RequestDelegate _next;
        public MiddlewareExceptionHandler(RequestDelegate next)
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

        private Task HandleExceptionAsync(HttpContext context, Exception ex)
        {

            var exCode = HttpStatusCode.InternalServerError;
            string result = string.Empty;

            switch (ex)
            {
                case ValidationException validationException:
                    exCode = HttpStatusCode.BadRequest;
                    result = JsonSerializer.Serialize(validationException.Value);
                    break;
                default:
                    exCode = HttpStatusCode.NotFound;
                    result = JsonSerializer.Serialize(new {errpr = ex.Message});
                    break;
            }
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)exCode;

            return context.Response.WriteAsync(result);
        }
    }
}
