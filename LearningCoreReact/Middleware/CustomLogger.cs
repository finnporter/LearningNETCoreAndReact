using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearningCoreReact.Middleware
{
    public class CustomLogger
    {
        private readonly RequestDelegate _next;

        public CustomLogger (RequestDelegate next)
        {
            _next = next ?? throw new ArgumentNullException(nameof(next));
        }

        public async Task Invoke(HttpContext httpContext)
        {
            if (httpContext == null)
            {
                throw new ArgumentNullException(nameof(httpContext));                
            }

            //TODO log request
            Console.WriteLine(httpContext.Request.Body);

            await _next(httpContext);

            //TODO - log resonse
            Console.WriteLine(httpContext.Response.Body);
        }
    }
}
