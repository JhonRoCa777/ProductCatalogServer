using Microsoft.EntityFrameworkCore;
using ProductCatalog.Domain.CustomeException;
using System.Net;
using System.Text.Json;

namespace ProductCatalog.Infrastructure.Middleware
{
    public class HandlerGlobalExceptionMiddleware
    {
        private readonly RequestDelegate _Next;

        public HandlerGlobalExceptionMiddleware(RequestDelegate Next)
        {
            _Next = Next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _Next(context);
            }
            catch (Exception ex)
            {
                await HandleAsync(context, ex);
            }
        }

        private static Task HandleAsync(HttpContext context, Exception ex)
        {
            context.Response.ContentType = "application/json";

            HttpStatusCode StatusCode = HttpStatusCode.InternalServerError;
            string[] ErrorMessages = ["An unexpected error occurred."];

            switch (ex)
            {
                case CustomeException myEx:
                    StatusCode = myEx.ErrorCode;
                    ErrorMessages = [myEx.Message];
                    break;

                case DbUpdateException:
                    StatusCode = HttpStatusCode.BadRequest;
                    ErrorMessages = ["Database update error. Please check constraints and relationships."];
                    break;

                case InvalidOperationException myEx:
                    StatusCode = HttpStatusCode.BadRequest;
                    ErrorMessages = [myEx.Message];
                    break;

                default:
                    ErrorMessages = [ex.Message];
                    break;
            }

            context.Response.StatusCode = (int)StatusCode;

            return context.Response.WriteAsync(JsonSerializer.Serialize(ErrorMessages));
        }
    }
}
