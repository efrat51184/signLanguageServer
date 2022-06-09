using Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using SignLanguage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace SignLanguage
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class RaitingMiddleware
    {
        ILogger<RaitingMiddleware> _logger;
        private readonly RequestDelegate _next;
        SignLanguageDBContext  SignLanguageDBContext;

        public RaitingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext, SignLanguageDBContext SignLanguageDBContext, ILogger<RaitingMiddleware> logger)
        {
            this.SignLanguageDBContext = SignLanguageDBContext;
            Rating r = new Rating
            {
                Host = httpContext.Request.Host.ToString(),
                Method = httpContext.Request.Method,
                Path = httpContext.Request.Path,
                UserAgent = httpContext.Request.Headers["User-Agent"].ToString(),
                Referer = httpContext.Request.Headers["Referer"],
                RecordDate = DateTime.Now
            };
            await SignLanguageDBContext.Rating.AddAsync(r);
            await SignLanguageDBContext.SaveChangesAsync();
            await _next(httpContext);

        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class RaitingMiddlewareExtensions
    {
        public static IApplicationBuilder UseRaitingMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<RaitingMiddleware>();
            
        }
    }
}
