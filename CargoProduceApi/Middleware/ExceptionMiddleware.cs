using System.Net;
using static Core.Helpers.Exceptions;

namespace CargoProduceApi.Middleware
{
    public class Error
    {
        public int Code { get; set; }
        public string Message { get; set; }
    }

    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleGlobalExceptionAsync(httpContext, ex);
            }
        }

        private static Task HandleGlobalExceptionAsync(HttpContext context, Exception exception)
        {
            var code = HttpStatusCode.InternalServerError; // 500 if unexpected
            var mensaje = "Internal Server Error";
            
            if (exception is UnprocessableEntity) { code = HttpStatusCode.UnprocessableEntity; mensaje = UnprocessableEntity.Message;}
            // Faltaria agregar todas las excepciones controladas 

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;

            return context.Response.WriteAsJsonAsync(new Error() { Code = (int)code, Message = mensaje });
        }
    }
}

