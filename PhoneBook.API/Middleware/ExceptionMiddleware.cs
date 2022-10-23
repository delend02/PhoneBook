using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace PhoneBook.API.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);   
            }
            catch (Exception ex)
            {
                
            }
        }
    }
}
