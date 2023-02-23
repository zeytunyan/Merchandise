using Merchandise.Exceptions;
using Merchandise.Models;

namespace Merchandise.Middlewares
{
    public class ErrorMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (NotFoundException ex)
            {
                await WriteError(context, StatusCodes.Status404NotFound, ex.Message);
            }
            catch (IncorrectProductsNumberException ex)
            {
                await WriteError(context, StatusCodes.Status400BadRequest, ex.Message);
            }
            catch (ProductPresentInOrderException ex)
            {
                await WriteError(context, StatusCodes.Status400BadRequest, ex.Message);
            }
            catch (Exception ex)
            {
                await WriteError(context, StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        private async Task WriteError(HttpContext context, int code, string message)
        {
            var errorModel = new ErrorModel(code, message);
            await Results.Json(errorModel, statusCode: code).ExecuteAsync(context);
        }
    }

    public static class ErrorMiddlewareExtensions
    {
        public static IApplicationBuilder UseErrorMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ErrorMiddleware>();
        }
    }
}
