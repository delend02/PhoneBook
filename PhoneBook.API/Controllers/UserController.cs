using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PhoneBook.API.Models;
using PhoneBook.Application.Services.UserServices;
using PhoneBook.Domain.Entity;

namespace PhoneBook.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userServices;
        private readonly IConfiguration _configuration;


        public UserController(IUserService userServices, IConfiguration configuration)
        {
            _userServices    = userServices;
            _configuration = configuration;
        }

        [HttpPut("update")]
        public IActionResult Update([FromBody] User user)
        {
            var result = _userServices.Update(user);
            return Ok(result);
        }

        [HttpDelete]
        public IActionResult Delete([FromRoute] ulong id)
        {
            var result = _userServices.Delete(id);
            return Ok(result);
        }

        [HttpGet("id/{id}")]
        public IActionResult GetByID([FromRoute] ulong id)
        {
            var result = _userServices.GetByID(id);
            return Ok(result);
        }
        
        [HttpGet("login/{login}")]
        public IActionResult GetByLogin([FromRoute] string login)
        {
            var result = _userServices.Get(new User { Login = login });
            return Ok(result);
        }

        [HttpPost("auth")]
        public IActionResult AuthUser([FromBody] Authorization.Request auth)
        {
            var privateKey = _configuration.GetSection("PrivateKeys").GetValue<string>("JwtToken");
            var result = _userServices.AuthUser(auth.Login, auth.Password, privateKey);

            if (result is not null)
            {
                Authorization.Response response = new Authorization.Response { Token = result.Token };
                return Ok(response);
            }
            
            return NotFound(new { Error = "Не найден пользователь"} );
        }

        [HttpPost("registration")]
        public IActionResult RegistrationUser([FromBody] Registration.Request reg)
        {
            var privateKey = _configuration.GetSection("PrivateKeys").GetValue<string>("JwtToken");

            var result = _userServices.Create(new User 
            {
                FirstName = reg.FirstName, 
                LastName = reg.LastName, 
                Login = reg.Login,
                Password = reg.Password, 
                Role = (Role)reg.Role
            }, privateKey);

            if (result is not null)
            {
                Registration.Response response = new Registration.Response { Token = result };
                return Ok(response);
            }

            return BadRequest(new { Error = "Пользовтаель уже сущесвтует" });
        }
    }
}
