using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using BookClub.Application.ApiExceptions;
using Microsoft.AspNetCore.Http;

namespace BookClub.API.Helpers
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context )
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
            var code = HttpStatusCode.BadRequest; 

            if      (exception is NotFoundException)       code = HttpStatusCode.NotFound;
            else if (exception is AlreadyExistsException)  code = HttpStatusCode.Conflict;
            else if (exception is WrongPasswordException) code = HttpStatusCode.Forbidden;

            var result = JsonSerializer.Serialize(new { error = exception.Message });
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;
            return context.Response.WriteAsync(result);
        }
    }
}