﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
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
            _userServices = userServices;
            _configuration = configuration;
        }

        [HttpPost]
        public IActionResult Create([FromBody] User user)
        {
            var result = _userServices.Create(user);
            return Ok(result);
        }

        [HttpPost]
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

        [HttpGet]
        public IActionResult GetByID([FromRoute] ulong id)
        {
            var result = _userServices.Get(id);
            return Ok(result);
        }

        [HttpPost("auth")]
        public IActionResult AuthUser([FromBody] string login, string password)
        {
            var privateKey = _configuration.GetSection("PrivateKeys").GetValue<string>("JwtToken");
            var result = _userServices.AuthUser(login, password, privateKey);

            if (result is null)
                return NotFound(login);

            return Ok(result);
        }
    }
}
