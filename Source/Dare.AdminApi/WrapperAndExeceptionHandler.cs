using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Dare.AdminApi
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class WrapperAndExeceptionHandler
    {
        private readonly RequestDelegate _next;

        public WrapperAndExeceptionHandler(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext, ILogger<WrapperAndExeceptionHandler> logger)
        {
            Stream originalBody = httpContext.Response.Body;
            using var memStream = new MemoryStream();
            httpContext.Response.Body = memStream;
            var responseBody = "";
            var hasError = false;

            try
            {
                // Success return wrapp
                await _next(httpContext);

                memStream.Position = 0;
                responseBody = new StreamReader(memStream).ReadToEnd();
            }
            catch (Exception ex)
            {
                hasError = true;
                logger.LogError(ex, "Dare exection");
                responseBody = JsonConvert.SerializeObject(new
                {
                    ex.Message
                }); ;
            }

            string wrappedResponse = Wrap(responseBody, hasError);
            byte[] responseBytes = Encoding.UTF8.GetBytes(wrappedResponse);

            httpContext.Response.Body = originalBody;
            await httpContext.Response.Body.WriteAsync(responseBytes, 0, responseBytes.Length);


        }

        private String Wrap(string originalBody, bool hasError)
        {
            dynamic response = JsonConvert.DeserializeObject<dynamic>(originalBody);

            var wrapper = new
            {
                api = this.ApiInfo(),
                hasError,
                data = response
            };

            string newBody = JsonConvert.SerializeObject(wrapper);

            return newBody;
        }


        private Object ApiInfo()
        {
            return new
            {
                version = "1.0.0",
                name = "Dare Admin API"
            };
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class WrapperAndExeceptionHandlerExtensions
    {
        public static IApplicationBuilder UseWrapperAndExeceptionHandler(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<WrapperAndExeceptionHandler>();
        }
    }
}
