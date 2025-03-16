using Microsoft.EntityFrameworkCore;
using ProductCatalog.Domain.CustomeException;
using System.Net;
using System.Text.Json;
using FluentValidation;
using ProductCatalog.Domain.Model;

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
            List<ErrorMessage> ErrorMessages = [new ErrorMessage {Message = "An unexpected error occurred."}];

            switch (ex)
            {
                case CustomeException myEx:
                    StatusCode = myEx.ErrorCode;
                    ErrorMessages = [new ErrorMessage {Message = myEx.Message}];
                    break;

                case ValidationException myEx:
                    StatusCode = HttpStatusCode.BadRequest;
                    ErrorMessages = myEx.Errors
                        .Select(e => new ErrorMessage { Key = e.PropertyName, Message = e.ErrorMessage }).ToList();
                    break;
            }

            if (StatusCode == HttpStatusCode.InternalServerError) throw ex;

            context.Response.StatusCode = (int)StatusCode;

            return context.Response.WriteAsync(JsonSerializer.Serialize(ErrorMessages));
        }
    }
}
