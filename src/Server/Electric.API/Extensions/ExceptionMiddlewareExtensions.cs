using CommonShare.Logger;
using Electric.API.Models;
using Electric.Core.Exeptions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using System.Net;

namespace Electric.API.Extensions
{
    public static class ExceptionMiddlewareExtensions
    {
        public static void ConfigureExceptionHandler(this IApplicationBuilder app, ILoggerManager logger)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    var exception = contextFeature?.Error;

                    var code = (int)HttpStatusCode.InternalServerError;
                    if (exception is NotFoundExeption) code = 404; // Not Found
                    else if (exception is ConflictExeption) code = 409; // Conflict

                    context.Response.StatusCode = code;
                    context.Response.ContentType = "application/json";

                    if (contextFeature != null)
                    {
                        logger.LogError($"API Error: {exception}");

                        await context.Response.WriteAsync(new ErrorDetails()
                        {
                            StatusCode = context.Response.StatusCode,
                            Message = exception.Message
                        }.ToString());
                    }
                });
            });
        }
    }
}
