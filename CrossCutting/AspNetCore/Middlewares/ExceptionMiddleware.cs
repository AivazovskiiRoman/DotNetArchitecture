using System;
using System.Net;
using System.Net.Mime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Solution.CrossCutting.DependencyInjection;
using Solution.CrossCutting.Logging;
using Solution.CrossCutting.Utils;

namespace Solution.CrossCutting.AspNetCore.Middlewares
{
    public class ExceptionMiddleware
    {
        public ExceptionMiddleware(IHostingEnvironment environment, RequestDelegate request)
        {
            Environment = environment;
            Logger = DependencyInjector.GetService<ILogger>();
            Request = request;
        }

        private IHostingEnvironment Environment { get; }

        private ILogger Logger { get; }

        private RequestDelegate Request { get; }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await Request(context).ConfigureAwait(false);
            }
            catch (DomainException exception)
            {
                await ResponseAsync(context, HttpStatusCode.BadRequest, exception.Message).ConfigureAwait(false);
            }
            catch (Exception exception)
            {
                if (Environment.IsDevelopment())
                {
                    throw;
                }

                Logger.Error(exception);

                await ResponseAsync(context, HttpStatusCode.InternalServerError, string.Empty).ConfigureAwait(false);
            }
        }

        private static async Task ResponseAsync(HttpContext context, HttpStatusCode statusCode, string response)
        {
            context.Response.Clear();
            context.Response.StatusCode = (int)statusCode;
            context.Response.ContentType = MediaTypeNames.Application.Json;
            await context.Response.WriteAsync(response).ConfigureAwait(false);
        }
    }
}
