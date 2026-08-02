using CRM.Application.Responses;
using System.Net;
using System.Text.Json;
using FluentValidation;

namespace CRM.API.Middlewares
{
    public sealed class ExceptionHandler(RequestDelegate next, ILogger<ExceptionHandler> logger)
    {
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception exception)
            {
                logger.LogError(exception, exception.Message);

                await HandleExceptionAsync(context, exception);
            }
        }

        private static async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";

            HttpStatusCode statusCode;
            object response;

            switch (exception)
            {
                case ValidationException validationException:
                    statusCode = HttpStatusCode.BadRequest;

                    response = new
                    {
                        Success = false,
                        Message = "Validation failed.",
                        Errors = validationException.Errors.Select(x => new
                        {
                            x.PropertyName,
                            x.ErrorMessage
                        })
                    };
                    break;

                case UnauthorizedAccessException:
                    statusCode = HttpStatusCode.Unauthorized;

                    response = new
                    {
                        Success = false,
                        Message = "Unauthorized."
                    };
                    break;

                case KeyNotFoundException:
                    statusCode = HttpStatusCode.NotFound;

                    response = new
                    {
                        Success = false,
                        Message = exception.Message
                    };
                    break;

                case ArgumentException:
                    statusCode = HttpStatusCode.BadRequest;

                    response = new
                    {
                        Success = false,
                        Message = exception.Message
                    };
                    break;

                default:
                    statusCode = HttpStatusCode.InternalServerError;

                    response = new
                    {
                        Success = false,
                        Message = exception.Message
                        // Production'da istersen bunun yerine
                        // "An unexpected error occurred."
                        // döndürebilirsin.
                    };
                    break;
            }

            context.Response.StatusCode = (int)statusCode;

            await context.Response.WriteAsync(
                JsonSerializer.Serialize(response));
        }
    }
}
