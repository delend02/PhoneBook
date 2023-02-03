using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Threading.Tasks;

namespace PhoneBook.API.Middleware
{
    public class AuthorizationMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IConfiguration _configuration;


        public AuthorizationMiddleware(RequestDelegate next, IConfiguration configuration)
        {
            _configuration = configuration;
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var privateKey = _configuration.GetSection("PrivateKeys").GetValue<string>("JwtToken");
            await _next(context);

            var manager = new Manager(privateKey);

            var isAuth = manager.ValidateToken(context.Request.Cookies["token"], out JwtSecurityToken jwtToken);

            if (isAuth is not false)
            {
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                await context.Response.WriteAsJsonAsync(new { Error = "Необходима авторизация" });
                return;
            }

            
        }
    }   
}
