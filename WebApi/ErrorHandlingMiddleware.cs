using Newtonsoft.Json;
using System.Net;

namespace WebApi
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate next;
        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context /* other dependencies */)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            var code = HttpStatusCode.InternalServerError; // 500 if unexpected

            var jsonResult = JsonConvert.SerializeObject(new
            {
                ErrorCode = (int)HttpStatusCode.InternalServerError,
                ErrorMessage = ex.Message,
                Succeed = false,
            });
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;
            return context.Response.WriteAsync(jsonResult);
        }
    }
}
